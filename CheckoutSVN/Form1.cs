using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SharpSvn;
using SharpSvn.UI;

namespace CheckoutSVN
{
    public partial class Form1 : Form
    {
        bool cancel;
        bool busy;

        public struct WorkerArguments
        {
            public string uri;
            public string checkoutFolder;
            public SvnCheckOutArgs checkoutArgs;
        }

        public Form1()
        {
            InitializeComponent();
            repoAddressTextBox.BackColor = repoAddressTextBox.Text.Length == 0 ? Color.Salmon : Color.White;
            checkoutFolderTextBox.BackColor = checkoutFolderTextBox.Text.Length == 0 ? Color.Salmon : Color.White;
            cancelButton.Visible = false;
            busy = false;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                checkoutFolderTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void fetchButton_Click(object sender, EventArgs e)
        {
            if (repoAddressTextBox.Text.Length == 0)
            {
                MessageBox.Show("Fill in 'Repository Address'.", "Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            updateList();
        }

        private void checkoutButton_Click(object sender, EventArgs e)
        {
            if (!busy)
            {                
                if (repoAddressTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Fill in 'Repository Address', click Fetch and select a tag from the list.", "Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (tagList.SelectedItems.Count == 0 || tagList.SelectedItems[0].Text.Length == 0)
                {
                    MessageBox.Show("Select a tag from the list.", "Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (checkoutFolderTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Click Browse and choose a checkout folder.", "Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                checkoutLogRTB.Clear();
                cancel = false;
                busy = true;
                cancelButton.Visible = true;

                string tagName = tagList.SelectedItems[0].Text;
                string checkoutFolderBase = checkoutFolderTextBox.Text.TrimEnd('\\');
                string checkoutFolder = string.Format("{0}\\{1}", checkoutFolderBase, tagName);

                string baseUri = repoAddressTextBox.Text.TrimEnd('/');
                string fullUri = string.Format("{0}/{1}", baseUri, tagName);

                SvnCheckOutArgs args = new SvnCheckOutArgs();
                args.Notify += delegate(object sendern, SvnNotifyEventArgs en)
                {
                    appendRTB(en.Action + ": " + en.Path + Environment.NewLine);
                };

                args.Cancel += delegate(object senderc, SvnCancelEventArgs ec)
                {
                    ec.Cancel = cancel;
                };

                WorkerArguments workerArguments;
                workerArguments.uri = fullUri;
                workerArguments.checkoutFolder = checkoutFolder;
                workerArguments.checkoutArgs = args;

                backgroundWorker1.RunWorkerAsync(workerArguments);
            }
        }

        private void appendRTB(string text)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(appendRTB), new object[] { text });
                return;
            }
            checkoutLogRTB.AppendText(text);
            checkoutLogRTB.ScrollToCaret();
        }

        private void updateList()
        {
            Cursor.Current = Cursors.WaitCursor;

            tagList.Items.Clear();

            using (SvnClient client = new SvnClient())
            {
                try
                {
                    SvnUI.Bind(client, this);
                    SvnUriTarget svnUri = new SvnUriTarget(repoAddressTextBox.Text);
                    Collection<SvnListEventArgs> contents;
                    List<string> files = new List<string>();

                    if (client.GetList(svnUri, out contents))
                    {
                        if (contents.Count > 0)
                            contents.RemoveAt(0);

                        List<SvnListEventArgs> newList = new List<SvnListEventArgs>(contents);
                        newList = newList.OrderByDescending(o => o.Entry.Time.Ticks).ToList();

                        foreach (SvnListEventArgs item in newList)
                        {
                            ListViewItem tag = new ListViewItem(item.Name);
                            tag.SubItems.Add(new ListViewItem.ListViewSubItem(tag, item.Entry.Time.ToString()));
                            tag.SubItems.Add(new ListViewItem.ListViewSubItem(tag, item.Entry.Revision.ToString()));
                            tagList.Items.Add(tag);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "SVN Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            WorkerArguments arguments = (WorkerArguments)e.Argument;

            using (SvnClient client = new SvnClient())
            {
                SvnUI.Bind(client, this);
                SvnUriTarget svnUri = new SvnUriTarget(arguments.uri);
                SvnUpdateResult result;
                client.CheckOut(svnUri, arguments.checkoutFolder, arguments.checkoutArgs, out result);
                e.Result = result;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor.Current = Cursors.Default;
            cancelButton.Visible = false;
            busy = false;

            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "SVN Checkout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Revision " + ((SvnUpdateResult)e.Result).Revision + " checked out.", "Operation Completed");
            }                    
        }

        private void repoAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            repoAddressTextBox.BackColor = repoAddressTextBox.Text.Length == 0 ? Color.Salmon : Color.White;
        }

        private void checkoutFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            checkoutFolderTextBox.BackColor = checkoutFolderTextBox.Text.Length == 0 ? Color.Salmon : Color.White;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.targetFolder = checkoutFolderTextBox.Text;
            Properties.Settings.Default.repositoryAddress = repoAddressTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (repoAddressTextBox.Text.Length != 0)
                updateList();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            cancel = true;
        }
    }
}
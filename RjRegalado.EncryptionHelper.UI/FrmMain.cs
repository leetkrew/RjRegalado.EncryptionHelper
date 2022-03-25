using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RjRegalado.EncryptionHelper.Helpers;

namespace RjRegalado.EncryptionHelper.UI
{
    /// <summary>
    /// Provides UI for EncryptionHelper
    /// </summary>
    public partial class FrmMain : Form
    {
        private BackgroundWorker _bg = new BackgroundWorker();
        private List<EnumHelper> _operations = new List<EnumHelper>();
        private string _selectedOperation = string.Empty;

        /// <summary>
        /// Creates an instance of FrmMain
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Triggers when btnCancel button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            _bg.CancelAsync();
        }

        /// <summary>
        /// Triggers when btnExecute button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecute_Click(object sender, EventArgs e)
        {
            _selectedOperation = cboOperations.SelectedItem.ToString();
            cboOperations.Enabled = false;
            btnExecute.Enabled = false;
            btnCancel.Enabled = true;
            txtResult.Text = "";
            _bg.RunWorkerAsync();
        }

        /// <summary>
        /// Prepares UI functions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            _operations = EnumHelper.ToList<EnumHelper.OperationMethods>();
            foreach (var item in _operations)
            {
                cboOperations.Items.Add(item.Description);
            }

            cboOperations.SelectedItem = _operations.First().Description;

            /*
                Defaults:

                PublicKey = "./Certificates/EncryptByCertificate/public.crt";
                PrivateKey = "./Certificates/EncryptByCertificate/cert.pfx";
                Passkey = "password";
                Iv = "password";
            */

            txtPassPhrase.Text = Properties.Settings.Default.PassPhrase;
            txtInputText.Text = Properties.Settings.Default.InputText;
            txtPrivateKey.Text = Properties.Settings.Default.PrivateKey;
            txtPublicKey.Text = Properties.Settings.Default.PublicKey;
            txtIv.Text = Properties.Settings.Default.Iv;

            btnCancel.Enabled = false;
            _bg.WorkerSupportsCancellation = true;

            _bg.WorkerReportsProgress = true;
            _bg.ProgressChanged += delegate (object o, ProgressChangedEventArgs args)
            {
                if (args.UserState != null)
                {
                    txtResult.Text += $@"{args.UserState}";
                }

                progressBar1.Value = args.ProgressPercentage;
            };

            _bg.RunWorkerCompleted += delegate
            {
                btnExecute.Enabled = true;
                cboOperations.Enabled = true;
                btnCancel.Enabled = false;
                _bg.Dispose();
            };

            _bg.DoWork += (o, args) =>
            {
                try
                {
                    var selectedId = _operations.First(x => x.Description == _selectedOperation).Id;

                    switch (selectedId)
                    {
                        case (int)EnumHelper.OperationMethods.EncryptByCertificate:
                            using (IEncryptByCertificate demo = new EncryptByCertificate())
                            {
                                demo.PlainText = txtInputText.Text;
                                demo.PublicKey = txtPublicKey.Text;
                                demo.Passkey = txtPassPhrase.Text;
                                demo.ExecuteEncrypt(ref _bg);
                            }
                            break;
                        case (int)EnumHelper.OperationMethods.DecryptByCertificate:
                            using (IEncryptByCertificate demo = new EncryptByCertificate())
                            {
                                demo.EncryptedText = txtInputText.Text;
                                demo.PrivateKey = txtPrivateKey.Text;
                                demo.Passkey = txtPassPhrase.Text;
                                demo.ExecuteDecrypt(ref _bg);
                            }
                            break;
                        case (int)EnumHelper.OperationMethods.EncryptByTripleDes:
                            using (ITripleDes demo = new TripleDes())
                            {
                                demo.PlainText = txtInputText.Text;
                                demo.Passkey = txtPassPhrase.Text;
                                demo.Iv = txtIv.Text;
                                demo.ExecuteEncrypt(ref _bg);
                            }
                            break;
                        case (int)EnumHelper.OperationMethods.DecryptByTripleDes:
                            using (ITripleDes demo = new TripleDes())
                            {
                                demo.EncryptedText = txtInputText.Text;
                                demo.Passkey = txtPassPhrase.Text;
                                demo.Iv = txtIv.Text;
                                demo.ExecuteDecrypt(ref _bg);
                            }
                            break;
                        case (int)EnumHelper.OperationMethods.Md5:
                            using (IMd5Hash demo = new Md5Hash())
                            {
                                demo.PlainText = txtInputText.Text;
                                demo.ExecuteEncrypt(ref _bg);
                            }
                            break;
                        default:
                            throw new Exception("Not implemented");
                    }
                }
                catch (Exception ex)
                {
                    _bg.ReportProgress(0, ex.Message);
                }
            };
        }

        /// <summary>
        /// Allows the user to browse for a public key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowsePublicKey_Click(object sender, EventArgs e)
        {
            var fDlg = new OpenFileDialog();

            const string path = "./Certificates/";
            fDlg.InitialDirectory = Directory.Exists(path) ? Path.GetFullPath(path) : @"C:\";
            
            fDlg.Filter = @"Public Key (*.crt)|*.crt";
            fDlg.FilterIndex = 1;
            fDlg.Multiselect = false;

            if (fDlg.ShowDialog() != DialogResult.OK) return;
            this.txtPublicKey.Text = fDlg.FileName;
            Properties.Settings.Default.PublicKey = fDlg.FileName;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Allows the user to browse for a private key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowsePrivateKey_Click(object sender, EventArgs e)
        {
            var fDlg = new OpenFileDialog();

            const string path = "./Certificates/";
            fDlg.InitialDirectory = Directory.Exists(path) ? Path.GetFullPath(path) : @"C:\";

            fDlg.Filter = @"Private Key (*.pfx)|*.pfx";
            fDlg.FilterIndex = 1;
            fDlg.Multiselect = false;

            if (fDlg.ShowDialog() != DialogResult.OK) return;
            this.txtPrivateKey.Text = fDlg.FileName;
            Properties.Settings.Default.PrivateKey = fDlg.FileName;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Swaps the result and the input's value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSwap_Click(object sender, EventArgs e)
        {
            txtInputText.Text = txtInputText.Text + txtResult.Text;
            txtResult.Text = txtInputText.Text.Substring(0, txtInputText.Text.Length - txtResult.Text.Length);
            txtInputText.Text = txtInputText.Text.Substring(txtResult.Text.Length);
        }

        /// <summary>
        /// Automatically saves the public key field changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPublicKey_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PublicKey = txtPublicKey.Text;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Automatically saves the private key field changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPrivateKey_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PrivateKey = txtPrivateKey.Text;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Automatically saves the pass phrase field changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassPhrase_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PassPhrase = txtPassPhrase.Text;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Automatically saves the IV field changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtIv_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Iv = txtIv.Text;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Automatically saves the Input Text field changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInputText_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.InputText = txtInputText.Text;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Enable and Disable fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedOperation = cboOperations.SelectedItem.ToString();

            var tags = _operations.First(x => x.Description == _selectedOperation)
                .Tags;

            txtIv.Enabled = !tags.Contains("NO_IV");
            txtPrivateKey.Enabled = !tags.Contains("NO_PRIVATE_KEY");
            txtPublicKey.Enabled = !tags.Contains("NO_PUBLIC_KEY");
            txtPassPhrase.Enabled = !tags.Contains("NO_PASS_PHRASE");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using RjRegalado.EncryptionHelper.UI.Helpers;

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
            btnExecute.Enabled = false;
            btnCancel.Enabled = true;
            txtLogs.Text = "";
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


            btnCancel.Enabled = false;
            _bg.WorkerSupportsCancellation = true;

            _bg.WorkerReportsProgress = true;
            _bg.ProgressChanged += delegate (object o, ProgressChangedEventArgs args)
            {
                if (args.UserState != null)
                {
                    txtLogs.Text += $@"{args.UserState}";
                    txtLogs.AppendText(Environment.NewLine);
                    txtLogs.AppendText(Environment.NewLine);
                }

                progressBar1.Value = args.ProgressPercentage;
            };

            _bg.RunWorkerCompleted += delegate
            {
                txtLogs.AppendText("--------------------");
                txtLogs.AppendText(Environment.NewLine);
                btnExecute.Enabled = true;
                btnCancel.Enabled = false;
                _bg.Dispose();
            };

            _bg.DoWork += (o, args) =>
            {
                try
                {
                    _bg.ReportProgress(0, _selectedOperation);

                    var selectedId = _operations.First(x => x.Description == _selectedOperation).Id;

                    switch (selectedId)
                    {
                        case (int)EnumHelper.OperationMethods.EncryptByCertificate:
                            using (IEncryptByCertificate demo = new EncryptByCertificate())
                            {
                                demo.PlainText = txtPlainText.Text;
                                demo.PublicKey = "./Certificates/EncryptByCertificate/public.crt";
                                demo.Passkey = "password";
                                demo.ExecuteEncrypt(ref _bg);
                                //demo.ExecuteEncrypt(txtPlainText.Text, "./Certificates/EncryptByCertificate/public.crt", "password", ref _bg);
                            }
                            break;
                        case (int)EnumHelper.OperationMethods.DecryptByCertificate:
                            using (IEncryptByCertificate demo = new EncryptByCertificate())
                            {
                                demo.EncryptedText = txtPlainText.Text;
                                demo.PrivateKey = "./Certificates/EncryptByCertificate/cert.pfx";
                                demo.Passkey = "password";
                                demo.ExecuteDecrypt(ref _bg);
                                //demo.ExecuteDecrypt(txtPlainText.Text, "./Certificates/EncryptByCertificate/cert.pfx", "password", ref _bg);
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
    }
}

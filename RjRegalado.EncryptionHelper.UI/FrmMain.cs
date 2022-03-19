using System;
using System.ComponentModel;
using System.Windows.Forms;


namespace RjRegalado.EncryptionHelper.UI
{
    /// <summary>
    /// Provides UI for EncryptionHelper
    /// </summary>
    public partial class FrmMain : Form
    {
        private BackgroundWorker _bg = new BackgroundWorker();

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
            btnExecute.Enabled = false;
            btnCancel.Enabled = true;
            _bg.RunWorkerAsync();
        }

        /// <summary>
        /// Prepares UI functions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
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

            _bg.RunWorkerCompleted += delegate (object o, RunWorkerCompletedEventArgs args)
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
                    using (IEncryptByCertificate demo = new EncryptByCertificate())
                    {
                        demo.PlainText = txtPlainText.Text;
                        demo.PublicKey = "./Certificates/EncryptByCertificate/public.crt";
                        demo.PrivateKey = "./Certificates/EncryptByCertificate/cert.pfx";
                        demo.Passkey = "password";
                        demo.Demo(ref _bg);
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

namespace RjRegalado.EncryptionHelper.UI
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.txtInputText = new System.Windows.Forms.TextBox();
            this.cboOperations = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPublicKey = new System.Windows.Forms.TextBox();
            this.txtPrivateKey = new System.Windows.Forms.TextBox();
            this.txtPassPhrase = new System.Windows.Forms.TextBox();
            this.btnBrowsePublicKey = new System.Windows.Forms.Button();
            this.btnBrowsePrivateKey = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIv = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSwap = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(384, 136);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(182, 32);
            this.progressBar1.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(656, 136);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(16, 416);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(720, 141);
            this.txtResult.TabIndex = 13;
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Location = new System.Drawing.Point(576, 136);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 32);
            this.btnExecute.TabIndex = 4;
            this.btnExecute.Text = "E&xecute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // txtInputText
            // 
            this.txtInputText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputText.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F);
            this.txtInputText.Location = new System.Drawing.Point(12, 30);
            this.txtInputText.Multiline = true;
            this.txtInputText.Name = "txtInputText";
            this.txtInputText.Size = new System.Drawing.Size(724, 70);
            this.txtInputText.TabIndex = 1;
            this.txtInputText.Text = "Input Text";
            this.txtInputText.TextChanged += new System.EventHandler(this.txtInputText_TextChanged);
            // 
            // cboOperations
            // 
            this.cboOperations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOperations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperations.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOperations.FormattingEnabled = true;
            this.cboOperations.Location = new System.Drawing.Point(16, 136);
            this.cboOperations.Name = "cboOperations";
            this.cboOperations.Size = new System.Drawing.Size(360, 32);
            this.cboOperations.TabIndex = 2;
            this.cboOperations.SelectedIndexChanged += new System.EventHandler(this.cboOperations_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Input Text";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Operation";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(384, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Progress";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 392);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "Result";
            // 
            // txtPublicKey
            // 
            this.txtPublicKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPublicKey.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F);
            this.txtPublicKey.Location = new System.Drawing.Point(16, 208);
            this.txtPublicKey.Name = "txtPublicKey";
            this.txtPublicKey.Size = new System.Drawing.Size(632, 32);
            this.txtPublicKey.TabIndex = 6;
            this.txtPublicKey.TextChanged += new System.EventHandler(this.txtPublicKey_TextChanged);
            // 
            // txtPrivateKey
            // 
            this.txtPrivateKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrivateKey.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F);
            this.txtPrivateKey.Location = new System.Drawing.Point(16, 272);
            this.txtPrivateKey.Name = "txtPrivateKey";
            this.txtPrivateKey.Size = new System.Drawing.Size(632, 32);
            this.txtPrivateKey.TabIndex = 8;
            this.txtPrivateKey.TextChanged += new System.EventHandler(this.txtPrivateKey_TextChanged);
            // 
            // txtPassPhrase
            // 
            this.txtPassPhrase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassPhrase.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F);
            this.txtPassPhrase.Location = new System.Drawing.Point(16, 336);
            this.txtPassPhrase.Name = "txtPassPhrase";
            this.txtPassPhrase.Size = new System.Drawing.Size(360, 32);
            this.txtPassPhrase.TabIndex = 10;
            this.txtPassPhrase.TextChanged += new System.EventHandler(this.txtPassPhrase_TextChanged);
            // 
            // btnBrowsePublicKey
            // 
            this.btnBrowsePublicKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowsePublicKey.Location = new System.Drawing.Point(656, 208);
            this.btnBrowsePublicKey.Name = "btnBrowsePublicKey";
            this.btnBrowsePublicKey.Size = new System.Drawing.Size(75, 32);
            this.btnBrowsePublicKey.TabIndex = 7;
            this.btnBrowsePublicKey.Text = "Browse";
            this.btnBrowsePublicKey.UseVisualStyleBackColor = true;
            this.btnBrowsePublicKey.Click += new System.EventHandler(this.btnBrowsePublicKey_Click);
            // 
            // btnBrowsePrivateKey
            // 
            this.btnBrowsePrivateKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowsePrivateKey.Location = new System.Drawing.Point(656, 272);
            this.btnBrowsePrivateKey.Name = "btnBrowsePrivateKey";
            this.btnBrowsePrivateKey.Size = new System.Drawing.Size(75, 32);
            this.btnBrowsePrivateKey.TabIndex = 9;
            this.btnBrowsePrivateKey.Text = "Browse";
            this.btnBrowsePrivateKey.UseVisualStyleBackColor = true;
            this.btnBrowsePrivateKey.Click += new System.EventHandler(this.btnBrowsePrivateKey_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 19;
            this.label5.Text = "Private Key";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 20;
            this.label6.Text = "Public Key";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 312);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 21;
            this.label7.Text = "Pass Phrase";
            // 
            // txtIv
            // 
            this.txtIv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIv.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F);
            this.txtIv.Location = new System.Drawing.Point(384, 336);
            this.txtIv.Name = "txtIv";
            this.txtIv.Size = new System.Drawing.Size(264, 32);
            this.txtIv.TabIndex = 11;
            this.txtIv.TextChanged += new System.EventHandler(this.txtIv_TextChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(384, 312);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 23;
            this.label8.Text = "IV";
            // 
            // btnSwap
            // 
            this.btnSwap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSwap.Location = new System.Drawing.Point(656, 336);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(75, 32);
            this.btnSwap.TabIndex = 12;
            this.btnSwap.Text = "Swap";
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(656, 376);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 32);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 569);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSwap);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtIv);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBrowsePrivateKey);
            this.Controls.Add(this.btnBrowsePublicKey);
            this.Controls.Add(this.txtPassPhrase);
            this.Controls.Add(this.txtPrivateKey);
            this.Controls.Add(this.txtPublicKey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboOperations);
            this.Controls.Add(this.txtInputText);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnExecute);
            this.MinimumSize = new System.Drawing.Size(762, 200);
            this.Name = "FrmMain";
            this.Text = "Encryption Helper (By RJ Regalado)";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        



        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.TextBox txtInputText;
        private System.Windows.Forms.ComboBox cboOperations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPublicKey;
        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.TextBox txtPassPhrase;
        private System.Windows.Forms.Button btnBrowsePublicKey;
        private System.Windows.Forms.Button btnBrowsePrivateKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIv;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSwap;
        private System.Windows.Forms.Button btnClear;
    }
}


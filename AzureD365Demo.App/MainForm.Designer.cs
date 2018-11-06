namespace AzureD365Demo.App
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.grpLoad = new System.Windows.Forms.GroupBox();
            this.txtContactToLoad = new System.Windows.Forms.MaskedTextBox();
            this.lblLoadContact = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.grpSb = new System.Windows.Forms.GroupBox();
            this.lblProgressValue = new System.Windows.Forms.Label();
            this.lblSbMessageCount = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblMessageInBus = new System.Windows.Forms.Label();
            this.pgbServiceBus = new System.Windows.Forms.ProgressBar();
            this.grpCrm = new System.Windows.Forms.GroupBox();
            this.lblNbContactCrm = new System.Windows.Forms.Label();
            this.lblCrmContactCount = new System.Windows.Forms.Label();
            this.grpConsole = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.bgWorkerLoad = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerServiceBus = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerCrmCounter = new System.ComponentModel.BackgroundWorker();
            this.btnStartWebJob = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.grpLoad.SuspendLayout();
            this.grpSb.SuspendLayout();
            this.grpCrm.SuspendLayout();
            this.grpConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // grpLoad
            // 
            this.grpLoad.Controls.Add(this.txtContactToLoad);
            this.grpLoad.Controls.Add(this.lblLoadContact);
            this.grpLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLoad.Location = new System.Drawing.Point(26, 45);
            this.grpLoad.Name = "grpLoad";
            this.grpLoad.Size = new System.Drawing.Size(295, 246);
            this.grpLoad.TabIndex = 0;
            this.grpLoad.TabStop = false;
            this.grpLoad.Text = " [ Chargement ] ";
            // 
            // txtContactToLoad
            // 
            this.txtContactToLoad.Location = new System.Drawing.Point(12, 102);
            this.txtContactToLoad.Mask = "999999";
            this.txtContactToLoad.Name = "txtContactToLoad";
            this.txtContactToLoad.PromptChar = ' ';
            this.txtContactToLoad.Size = new System.Drawing.Size(269, 29);
            this.txtContactToLoad.TabIndex = 3;
            this.txtContactToLoad.Text = "10000";
            this.txtContactToLoad.ValidatingType = typeof(int);
            // 
            // lblLoadContact
            // 
            this.lblLoadContact.AutoSize = true;
            this.lblLoadContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadContact.Location = new System.Drawing.Point(7, 60);
            this.lblLoadContact.Name = "lblLoadContact";
            this.lblLoadContact.Size = new System.Drawing.Size(274, 25);
            this.lblLoadContact.TabIndex = 1;
            this.lblLoadContact.Text = "Nombre de contact à charger :";
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(345, 180);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(93, 111);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = " > ";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // grpSb
            // 
            this.grpSb.Controls.Add(this.lblProgressValue);
            this.grpSb.Controls.Add(this.lblSbMessageCount);
            this.grpSb.Controls.Add(this.lblProgress);
            this.grpSb.Controls.Add(this.lblMessageInBus);
            this.grpSb.Controls.Add(this.pgbServiceBus);
            this.grpSb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSb.Location = new System.Drawing.Point(460, 45);
            this.grpSb.Name = "grpSb";
            this.grpSb.Size = new System.Drawing.Size(754, 246);
            this.grpSb.TabIndex = 1;
            this.grpSb.TabStop = false;
            this.grpSb.Text = " [ Service Bus ] ";
            // 
            // lblProgressValue
            // 
            this.lblProgressValue.AutoSize = true;
            this.lblProgressValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressValue.Location = new System.Drawing.Point(171, 188);
            this.lblProgressValue.Name = "lblProgressValue";
            this.lblProgressValue.Size = new System.Drawing.Size(27, 29);
            this.lblProgressValue.TabIndex = 6;
            this.lblProgressValue.Text = "0";
            // 
            // lblSbMessageCount
            // 
            this.lblSbMessageCount.AutoSize = true;
            this.lblSbMessageCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSbMessageCount.Location = new System.Drawing.Point(422, 142);
            this.lblSbMessageCount.Name = "lblSbMessageCount";
            this.lblSbMessageCount.Size = new System.Drawing.Size(27, 29);
            this.lblSbMessageCount.TabIndex = 5;
            this.lblSbMessageCount.Text = "0";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(33, 188);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(132, 25);
            this.lblProgress.TabIndex = 5;
            this.lblProgress.Text = "Progression : ";
            // 
            // lblMessageInBus
            // 
            this.lblMessageInBus.AutoSize = true;
            this.lblMessageInBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageInBus.Location = new System.Drawing.Point(33, 146);
            this.lblMessageInBus.Name = "lblMessageInBus";
            this.lblMessageInBus.Size = new System.Drawing.Size(397, 25);
            this.lblMessageInBus.TabIndex = 4;
            this.lblMessageInBus.Text = "Nombre de messages dans le Service Bus : ";
            // 
            // pgbServiceBus
            // 
            this.pgbServiceBus.Location = new System.Drawing.Point(38, 60);
            this.pgbServiceBus.Name = "pgbServiceBus";
            this.pgbServiceBus.Size = new System.Drawing.Size(686, 53);
            this.pgbServiceBus.Step = 1;
            this.pgbServiceBus.TabIndex = 0;
            // 
            // grpCrm
            // 
            this.grpCrm.Controls.Add(this.lblNbContactCrm);
            this.grpCrm.Controls.Add(this.lblCrmContactCount);
            this.grpCrm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCrm.Location = new System.Drawing.Point(1346, 45);
            this.grpCrm.Name = "grpCrm";
            this.grpCrm.Size = new System.Drawing.Size(295, 246);
            this.grpCrm.TabIndex = 1;
            this.grpCrm.TabStop = false;
            this.grpCrm.Text = " [ D365 ] ";
            // 
            // lblNbContactCrm
            // 
            this.lblNbContactCrm.AutoSize = true;
            this.lblNbContactCrm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbContactCrm.Location = new System.Drawing.Point(15, 60);
            this.lblNbContactCrm.Name = "lblNbContactCrm";
            this.lblNbContactCrm.Size = new System.Drawing.Size(234, 25);
            this.lblNbContactCrm.TabIndex = 4;
            this.lblNbContactCrm.Text = "Nombre de contact D365:";
            // 
            // lblCrmContactCount
            // 
            this.lblCrmContactCount.AutoSize = true;
            this.lblCrmContactCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrmContactCount.Location = new System.Drawing.Point(19, 102);
            this.lblCrmContactCount.Name = "lblCrmContactCount";
            this.lblCrmContactCount.Size = new System.Drawing.Size(27, 29);
            this.lblCrmContactCount.TabIndex = 0;
            this.lblCrmContactCount.Text = "0";
            // 
            // grpConsole
            // 
            this.grpConsole.Controls.Add(this.pictureBox1);
            this.grpConsole.Controls.Add(this.txtConsole);
            this.grpConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpConsole.Location = new System.Drawing.Point(26, 309);
            this.grpConsole.Name = "grpConsole";
            this.grpConsole.Size = new System.Drawing.Size(1615, 415);
            this.grpConsole.TabIndex = 2;
            this.grpConsole.TabStop = false;
            this.grpConsole.Text = " [ Console ] ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1079, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(495, 360);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.Color.Black;
            this.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsole.ForeColor = System.Drawing.Color.Lime;
            this.txtConsole.Location = new System.Drawing.Point(12, 44);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.Size = new System.Drawing.Size(1597, 365);
            this.txtConsole.TabIndex = 0;
            // 
            // bgWorkerLoad
            // 
            this.bgWorkerLoad.WorkerReportsProgress = true;
            this.bgWorkerLoad.WorkerSupportsCancellation = true;
            this.bgWorkerLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerLoad_DoWork);
            this.bgWorkerLoad.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerLoad_ProgressChanged);
            this.bgWorkerLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerLoad_RunWorkerCompleted);
            // 
            // bgWorkerServiceBus
            // 
            this.bgWorkerServiceBus.WorkerReportsProgress = true;
            this.bgWorkerServiceBus.WorkerSupportsCancellation = true;
            this.bgWorkerServiceBus.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerServiceBus_DoWork);
            this.bgWorkerServiceBus.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerServiceBus_ProgressChanged);
            this.bgWorkerServiceBus.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerServiceBus_RunWorkerCompleted);
            // 
            // bgWorkerCrmCounter
            // 
            this.bgWorkerCrmCounter.WorkerReportsProgress = true;
            this.bgWorkerCrmCounter.WorkerSupportsCancellation = true;
            this.bgWorkerCrmCounter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerCrmCounter_DoWork);
            this.bgWorkerCrmCounter.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerCrmCounter_ProgressChanged);
            this.bgWorkerCrmCounter.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerCrmCounter_RunWorkerCompleted);
            // 
            // btnStartWebJob
            // 
            this.btnStartWebJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartWebJob.Location = new System.Drawing.Point(1236, 180);
            this.btnStartWebJob.Name = "btnStartWebJob";
            this.btnStartWebJob.Size = new System.Drawing.Size(93, 111);
            this.btnStartWebJob.TabIndex = 3;
            this.btnStartWebJob.Text = " > ";
            this.btnStartWebJob.UseVisualStyleBackColor = true;
            this.btnStartWebJob.Click += new System.EventHandler(this.btnStartWebJob_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(342, 45);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(1229, 45);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 100);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1660, 756);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnStartWebJob);
            this.Controls.Add(this.grpConsole);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.grpCrm);
            this.Controls.Add(this.grpSb);
            this.Controls.Add(this.grpLoad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Microsoft Experiences 2018 : Etendre les capacités de Dynamics 365 avec les Servi" +
    "ces PaaS dans Azure";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpLoad.ResumeLayout(false);
            this.grpLoad.PerformLayout();
            this.grpSb.ResumeLayout(false);
            this.grpSb.PerformLayout();
            this.grpCrm.ResumeLayout(false);
            this.grpCrm.PerformLayout();
            this.grpConsole.ResumeLayout(false);
            this.grpConsole.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLoad;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblLoadContact;
        private System.Windows.Forms.GroupBox grpSb;
        private System.Windows.Forms.ProgressBar pgbServiceBus;
        private System.Windows.Forms.GroupBox grpCrm;
        private System.Windows.Forms.Label lblCrmContactCount;
        private System.Windows.Forms.GroupBox grpConsole;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.MaskedTextBox txtContactToLoad;
        private System.ComponentModel.BackgroundWorker bgWorkerLoad;
        private System.ComponentModel.BackgroundWorker bgWorkerServiceBus;
        private System.ComponentModel.BackgroundWorker bgWorkerCrmCounter;
        private System.Windows.Forms.Label lblNbContactCrm;
        private System.Windows.Forms.Label lblProgressValue;
        private System.Windows.Forms.Label lblSbMessageCount;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblMessageInBus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnStartWebJob;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}


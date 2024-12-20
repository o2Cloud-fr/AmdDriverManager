namespace AmdDriverManager
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lstDriverVersions = new System.Windows.Forms.ListBox();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.lblDriverVersion = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(307, 432);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(147, 13);
            this.linkLabel1.TabIndex = 23;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Visitez le site des pilotes AMD";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 428);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "AmdDriverManager - Version 1.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(528, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "(Pour installer une nouvelle carte graphique)";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(487, 319);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(278, 41);
            this.button2.TabIndex = 20;
            this.button2.Text = "Nettoyer et étindre";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(556, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "(Risque de problème d\'écrn noir)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(487, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(278, 41);
            this.button1.TabIndex = 18;
            this.button1.Text = "Nettoyer ET NE PAS redémarrer";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(574, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "(Fortement recommandé)";
            // 
            // lstDriverVersions
            // 
            this.lstDriverVersions.FormattingEnabled = true;
            this.lstDriverVersions.Location = new System.Drawing.Point(12, 200);
            this.lstDriverVersions.Name = "lstDriverVersions";
            this.lstDriverVersions.Size = new System.Drawing.Size(421, 173);
            this.lstDriverVersions.TabIndex = 14;
            // 
            // btnUninstall
            // 
            this.btnUninstall.Location = new System.Drawing.Point(487, 190);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(278, 41);
            this.btnUninstall.TabIndex = 13;
            this.btnUninstall.Text = "Nettoyer et redémarrer";
            this.btnUninstall.UseVisualStyleBackColor = true;
            // 
            // lblDriverVersion
            // 
            this.lblDriverVersion.AutoSize = true;
            this.lblDriverVersion.Location = new System.Drawing.Point(141, 184);
            this.lblDriverVersion.Name = "lblDriverVersion";
            this.lblDriverVersion.Size = new System.Drawing.Size(80, 13);
            this.lblDriverVersion.TabIndex = 12;
            this.lblDriverVersion.Text = "lblDriverVersion";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::AmdDriverManager.Properties.Resources.AMD_Radeon_logo;
            this.pictureBox2.Location = new System.Drawing.Point(617, 370);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(171, 68);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AmdDriverManager.Properties.Resources.AMD_Radeon_logo_2019;
            this.pictureBox1.Location = new System.Drawing.Point(11, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(754, 131);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lstDriverVersions);
            this.Controls.Add(this.btnUninstall);
            this.Controls.Add(this.lblDriverVersion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "AmdDriverManager by o2Cloud";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lstDriverVersions;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.Label lblDriverVersion;
    }
}


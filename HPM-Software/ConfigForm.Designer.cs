namespace HPM_Software
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            txtClientId = new TextBox();
            txtClientSecret = new TextBox();
            btnSave = new Button();
            label1 = new Label();
            label6 = new Label();
            label5 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // txtClientId
            // 
            txtClientId.Location = new Point(86, 221);
            txtClientId.Name = "txtClientId";
            txtClientId.Size = new Size(522, 27);
            txtClientId.TabIndex = 0;
            // 
            // txtClientSecret
            // 
            txtClientSecret.Location = new Point(135, 265);
            txtClientSecret.Name = "txtClientSecret";
            txtClientSecret.Size = new Size(394, 27);
            txtClientSecret.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.RoyalBlue;
            btnSave.ForeColor = SystemColors.ActiveCaptionText;
            btnSave.Location = new Point(464, 326);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(144, 29);
            btnSave.TabIndex = 2;
            btnSave.Text = "Logar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Arial Rounded MT Bold", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(27, 77);
            label1.Name = "label1";
            label1.Size = new Size(394, 58);
            label1.TabIndex = 5;
            label1.Text = "HPM-Dentistry.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ActiveCaption;
            label6.Font = new Font("Segoe UI", 12F);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(407, 107);
            label6.Name = "label6";
            label6.Size = new Size(69, 28);
            label6.TabIndex = 10;
            label6.Text = "FpmIA";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(86, 185);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 11;
            label5.Text = "Token:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveCaption;
            label2.Font = new Font("Times New Roman", 15F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label2.Location = new Point(27, 9);
            label2.Name = "label2";
            label2.Size = new Size(72, 29);
            label2.TabIndex = 12;
            label2.Text = "Login";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(12, 224);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 13;
            label3.Text = "Client-ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(12, 268);
            label4.Name = "label4";
            label4.Size = new Size(117, 20);
            label4.TabIndex = 14;
            label4.Text = "Client Secret -ID";
            // 
            // ConfigForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.IMG_20161229_1551560122;
            ClientSize = new Size(679, 391);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(txtClientSecret);
            Controls.Add(txtClientId);
            ForeColor = SystemColors.ButtonFace;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ConfigForm";
            Text = "ConfigForm";
            Load += ConfigForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtClientId;
        private TextBox txtClientSecret;
        private Button btnSave;
        private Label label1;
        private Label label6;
        private Label label5;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
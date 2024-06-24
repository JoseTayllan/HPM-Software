namespace HPM_Software
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnExtrair = new Button();
            textBoxGoogleClientId = new TextBox();
            textBoxGoogleSecret = new TextBox();
            buttonSubmit = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // btnExtrair
            // 
            btnExtrair.Location = new Point(13, 109);
            btnExtrair.Name = "btnExtrair";
            btnExtrair.Size = new Size(161, 29);
            btnExtrair.TabIndex = 0;
            btnExtrair.Text = "Extrair";
            btnExtrair.UseVisualStyleBackColor = true;
            btnExtrair.Click += btnExtrair_Click;
            // 
            // textBoxGoogleClientId
            // 
            textBoxGoogleClientId.Location = new Point(13, 217);
            textBoxGoogleClientId.Name = "textBoxGoogleClientId";
            textBoxGoogleClientId.PlaceholderText = "textBoxGoogleClientId";
            textBoxGoogleClientId.Size = new Size(612, 27);
            textBoxGoogleClientId.TabIndex = 1;
            textBoxGoogleClientId.TextChanged += textBoxGoogleClientId_TextChanged;
            // 
            // textBoxGoogleSecret
            // 
            textBoxGoogleSecret.Location = new Point(13, 250);
            textBoxGoogleSecret.Name = "textBoxGoogleSecret";
            textBoxGoogleSecret.PlaceholderText = "textBoxGoogleSecret";
            textBoxGoogleSecret.Size = new Size(612, 27);
            textBoxGoogleSecret.TabIndex = 2;
            textBoxGoogleSecret.TextChanged += textBoxGoogleSecret_TextChanged;
            // 
            // buttonSubmit
            // 
            buttonSubmit.Location = new Point(13, 144);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(161, 29);
            buttonSubmit.TabIndex = 3;
            buttonSubmit.Text = "Trocar";
            buttonSubmit.UseVisualStyleBackColor = true;
            buttonSubmit.Click += buttonSubmit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Arial Rounded MT Bold", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(13, 9);
            label1.Name = "label1";
            label1.Size = new Size(430, 58);
            label1.TabIndex = 4;
            label1.Text = "HPM-DentistryIA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(154, 35);
            label2.Name = "label2";
            label2.Size = new Size(0, 35);
            label2.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 6F);
            label3.Location = new Point(259, 53);
            label3.Name = "label3";
            label3.Size = new Size(0, 12);
            label3.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(13, 86);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 7;
            label4.Text = "Funções:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(13, 194);
            label5.Name = "label5";
            label5.Size = new Size(114, 20);
            label5.TabIndex = 8;
            label5.Text = "Atualizar Token:";
            label5.Click += label5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.IMG_20161229_1551560122;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(638, 288);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonSubmit);
            Controls.Add(textBoxGoogleSecret);
            Controls.Add(textBoxGoogleClientId);
            Controls.Add(btnExtrair);
            Name = "Form1";
            Padding = new Padding(10);
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExtrair;
        private TextBox textBoxGoogleClientId;
        private TextBox textBoxGoogleSecret;
        private Button buttonSubmit;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}

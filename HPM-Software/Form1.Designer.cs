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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnExtrair = new Button();
            textBoxGoogleClientId = new TextBox();
            textBoxGoogleSecret = new TextBox();
            buttonSubmit = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnCriarNovaAba = new Button();
            textBoxNomeAba = new TextBox();
            btnChangeSpreadsheet = new Button();
            textBoxCurrentSpreadsheetId = new TextBox();
            btnCreateNewSpreadsheet = new Button();
            textBoxNewSpreadsheetName = new TextBox();
            SuspendLayout();
            // 
            // btnExtrair
            // 
            btnExtrair.BackColor = SystemColors.ButtonHighlight;
            btnExtrair.Location = new Point(13, 109);
            btnExtrair.Name = "btnExtrair";
            btnExtrair.Size = new Size(161, 29);
            btnExtrair.TabIndex = 0;
            btnExtrair.Text = "Extrair";
            btnExtrair.UseVisualStyleBackColor = false;
            btnExtrair.Click += btnExtrair_Click;
            // 
            // textBoxGoogleClientId
            // 
            textBoxGoogleClientId.Location = new Point(13, 197);
            textBoxGoogleClientId.Name = "textBoxGoogleClientId";
            textBoxGoogleClientId.PlaceholderText = "textBoxGoogleClientId";
            textBoxGoogleClientId.Size = new Size(612, 27);
            textBoxGoogleClientId.TabIndex = 1;
            textBoxGoogleClientId.TextChanged += textBoxGoogleClientId_TextChanged;
            // 
            // textBoxGoogleSecret
            // 
            textBoxGoogleSecret.Location = new Point(13, 230);
            textBoxGoogleSecret.Name = "textBoxGoogleSecret";
            textBoxGoogleSecret.PlaceholderText = "textBoxGoogleSecret";
            textBoxGoogleSecret.Size = new Size(479, 27);
            textBoxGoogleSecret.TabIndex = 2;
            textBoxGoogleSecret.TextChanged += textBoxGoogleSecret_TextChanged;
            // 
            // buttonSubmit
            // 
            buttonSubmit.BackColor = SystemColors.ButtonHighlight;
            buttonSubmit.Location = new Point(13, 263);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(161, 29);
            buttonSubmit.TabIndex = 3;
            buttonSubmit.Text = "Atualizar Token";
            buttonSubmit.UseVisualStyleBackColor = false;
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
            label1.Size = new Size(394, 58);
            label1.TabIndex = 4;
            label1.Text = "HPM-Dentistry.";
            label1.Click += label1_Click;
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
            label5.Location = new Point(13, 174);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 8;
            label5.Text = "Token:";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ActiveCaption;
            label6.Font = new Font("Segoe UI", 12F);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(391, 39);
            label6.Name = "label6";
            label6.Size = new Size(69, 28);
            label6.TabIndex = 9;
            label6.Text = "FpmIA";
            // 
            // btnCriarNovaAba
            // 
            btnCriarNovaAba.BackColor = SystemColors.ButtonHighlight;
            btnCriarNovaAba.Location = new Point(13, 322);
            btnCriarNovaAba.Name = "btnCriarNovaAba";
            btnCriarNovaAba.Size = new Size(94, 29);
            btnCriarNovaAba.TabIndex = 10;
            btnCriarNovaAba.Text = "Nova Aba";
            btnCriarNovaAba.UseVisualStyleBackColor = false;
            btnCriarNovaAba.Visible = false;
            btnCriarNovaAba.Click += btnCriarNovaAba_Click;
            // 
            // textBoxNomeAba
            // 
            textBoxNomeAba.Location = new Point(113, 324);
            textBoxNomeAba.Name = "textBoxNomeAba";
            textBoxNomeAba.PlaceholderText = "Título:";
            textBoxNomeAba.Size = new Size(125, 27);
            textBoxNomeAba.TabIndex = 11;
            textBoxNomeAba.Visible = false;
            // 
            // btnChangeSpreadsheet
            // 
            btnChangeSpreadsheet.BackColor = SystemColors.ButtonHighlight;
            btnChangeSpreadsheet.Location = new Point(13, 380);
            btnChangeSpreadsheet.Name = "btnChangeSpreadsheet";
            btnChangeSpreadsheet.Size = new Size(127, 29);
            btnChangeSpreadsheet.TabIndex = 12;
            btnChangeSpreadsheet.Text = "Trocar Planilha";
            btnChangeSpreadsheet.UseVisualStyleBackColor = false;
            btnChangeSpreadsheet.Click += btnChangeSpreadsheet_Click;
            // 
            // textBoxCurrentSpreadsheetId
            // 
            textBoxCurrentSpreadsheetId.Location = new Point(146, 380);
            textBoxCurrentSpreadsheetId.Name = "textBoxCurrentSpreadsheetId";
            textBoxCurrentSpreadsheetId.Size = new Size(346, 27);
            textBoxCurrentSpreadsheetId.TabIndex = 13;
            // 
            // btnCreateNewSpreadsheet
            // 
            btnCreateNewSpreadsheet.BackColor = SystemColors.ButtonHighlight;
            btnCreateNewSpreadsheet.Location = new Point(13, 412);
            btnCreateNewSpreadsheet.Name = "btnCreateNewSpreadsheet";
            btnCreateNewSpreadsheet.Size = new Size(127, 29);
            btnCreateNewSpreadsheet.TabIndex = 14;
            btnCreateNewSpreadsheet.Text = "Criar planilha";
            btnCreateNewSpreadsheet.UseVisualStyleBackColor = false;
            btnCreateNewSpreadsheet.Click += btnCreateNewSpreadsheet_Click;
            // 
            // textBoxNewSpreadsheetName
            // 
            textBoxNewSpreadsheetName.Location = new Point(146, 413);
            textBoxNewSpreadsheetName.Name = "textBoxNewSpreadsheetName";
            textBoxNewSpreadsheetName.PlaceholderText = "Título:";
            textBoxNewSpreadsheetName.Size = new Size(155, 27);
            textBoxNewSpreadsheetName.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.IMG_20161229_1551560122;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(638, 479);
            Controls.Add(textBoxNewSpreadsheetName);
            Controls.Add(btnCreateNewSpreadsheet);
            Controls.Add(textBoxCurrentSpreadsheetId);
            Controls.Add(btnChangeSpreadsheet);
            Controls.Add(textBoxNomeAba);
            Controls.Add(btnCriarNovaAba);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonSubmit);
            Controls.Add(textBoxGoogleSecret);
            Controls.Add(textBoxGoogleClientId);
            Controls.Add(btnExtrair);
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private Label label6;
        private Button btnCriarNovaAba;
        private TextBox textBoxNomeAba;
        private Button btnChangeSpreadsheet;
        private TextBox textBoxCurrentSpreadsheetId;
        private Button btnCreateNewSpreadsheet;
        private TextBox textBoxNewSpreadsheetName;
    }
}

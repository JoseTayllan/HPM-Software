using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HPM_Software
{
    public partial class ConfigForm : Form
    {
        public string GoogleClientId { get; private set; }
        public string GoogleSecret { get; private set; }
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GoogleClientId = txtClientId.Text.Trim();
            GoogleSecret = txtClientSecret.Text.Trim();

            if (string.IsNullOrEmpty(GoogleClientId) || string.IsNullOrEmpty(GoogleSecret))
            {
                MessageBox.Show("Please fill in both fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

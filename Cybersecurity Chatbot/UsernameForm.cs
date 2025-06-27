using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Cybersecurity_Chatbot.Forms
{
    public partial class UsernameForm : Form
    {
        public string EnteredName { get; private set; }

        public UsernameForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Welcome 😊\n\nPlease enter a valid name.", "Name Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EnteredName = name;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
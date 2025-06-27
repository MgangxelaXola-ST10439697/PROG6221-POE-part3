using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cybersecurity_Chatbot.Forms
{
    public partial class ActivityLogForm : Form
    {
        public ActivityLogForm(List<string> activityLog)
        {
            InitializeComponent();
            LoadActivityLog(activityLog);
        }

        private void LoadActivityLog(List<string> activityLog)
        {
            listBoxActivityLog.Items.Clear();
            foreach (var entry in activityLog)
            {
                listBoxActivityLog.Items.Add(entry);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Windows.Forms;
using Cybersecurity_Chatbot.Classes;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cybersecurity_Chatbot.Forms
{
    public partial class MainChatForm : Form
    {
        private ConversationMemory memory;
        private ActivityLogger log;
        private CyberTaskManager taskManager;

        public MainChatForm()
        {
            InitializeComponent();
            memory = new ConversationMemory();
            log = new ActivityLogger();
            taskManager = new CyberTaskManager();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string userInput = txtUserInput.Text.Trim();
            txtUserInput.Clear();

            if (string.IsNullOrWhiteSpace(userInput))
                return;

            AppendUserMessage(userInput);

            if (SentimentDetector.ContainsWorry(userInput))
            {
                AppendBotResponse("I sense you're worried. Take a deep breath—everything will be okay.");
                log.Add("Recognized user worry.");

                string reassuringTip = GetCyberTip(userInput);
                AppendBotResponse(reassuringTip);
                return;
            }

            var intent = KeywordInterpreter.DetectIntent(userInput.ToLower());

            switch (intent)
            {
                case KeywordInterpreter.IntentType.LaunchQuiz:
                    AppendBotResponse("Sure! Starting the cybersecurity quiz now...");
                    log.Add("Launched Quiz");
                    new CyberQuizForm().ShowDialog();
                    break;

                case KeywordInterpreter.IntentType.AddTask:
                    AppendBotResponse("Sure, I've added it to your tasks with a reminder set for tomorrow.");
                    new CyberTaskForm().ShowDialog();
                    log.Add("Opened Task Assistant");
                    break;

                case KeywordInterpreter.IntentType.ShowLog:
                    AppendBotResponse("Here are your recent actions:");
                    new ActivityLogForm(log.GetRecent()).ShowDialog();
                    break;

                default:
                    if (userInput.Contains("remind") || userInput.Contains("task"))
                    {
                        AppendBotResponse("Opening Task Assistant to add your reminder...");
                        new CyberTaskForm().ShowDialog();
                        log.Add("Task assistant opened via keyword.");
                    }
                    else if (userInput.Contains("what have you done"))
                    {
                        AppendBotResponse("Here's what I've done for you recently:");
                        new ActivityLogForm(log.GetRecent()).ShowDialog();
                    }
                    else
                    {
                        string tip = GetCyberTip(userInput);
                        AppendBotResponse(tip);
                    }
                    break;
            }
        }

        private void AppendBotResponse(string message)
        {
            Label lblBot = new Label();
            lblBot.Text = message;
            lblBot.AutoSize = true;
            lblBot.MaximumSize = new Size(700, 0);
            lblBot.BackColor = Color.Beige;
            lblBot.Padding = new Padding(10);
            lblBot.Margin = new Padding(5);
            lblBot.Font = new Font("Segoe UI", 10);
            lblBot.Anchor = AnchorStyles.Left;
            lblBot.TextAlign = ContentAlignment.MiddleLeft;

            pnlChatMessages.Controls.Add(lblBot);
        }

        private void AppendUserMessage(string message)
        {
            Label lblUser = new Label();
            lblUser.Text = message;
            lblUser.AutoSize = true;
            lblUser.MaximumSize = new Size(700, 0);
            lblUser.BackColor = Color.LightGray;
            lblUser.Padding = new Padding(10);
            lblUser.Margin = new Padding(5);
            lblUser.Font = new Font("Segoe UI", 10);
            lblUser.Anchor = AnchorStyles.Right;
            lblUser.TextAlign = ContentAlignment.MiddleRight;

            pnlChatMessages.Controls.Add(lblUser);
        }

        private string GetCyberTip(string userInput)
        {
            userInput = userInput.ToLower();

            if (userInput.Contains("phishing"))
                return "Phishing is when attackers pretend to be trusted sources to steal your info.";
            if (userInput.Contains("2fa") || userInput.Contains("two-factor"))
                return "2FA adds an extra layer of security to your logins. Enable it wherever you can.";
            if (userInput.Contains("vpn"))
                return "VPNs hide your internet activity from snoopers. Great for public Wi-Fi.";
            if (userInput.Contains("firewall"))
                return "A firewall blocks unwanted network traffic and keeps intruders out.";
            if (userInput.Contains("malware"))
                return "Malware is malicious software. Scan your system regularly to stay safe.";
            if (userInput.Contains("password"))
                return "Strong passwords are key. Use a mix of characters, and don’t reuse them.";
            if (userInput.Contains("encryption"))
                return "Encryption scrambles your data so only authorized users can access it.";
            if (userInput.Contains("backup"))
                return "Backups protect you from data loss. Use both cloud and physical drives.";
            if (userInput.Contains("social engineering"))
                return "Social engineering tricks you into giving up secrets. Always verify requests.";
            if (userInput.Contains("ransomware"))
                return "Ransomware locks your files until you pay a ransom. Backups can save you.";
            if (userInput.Contains("zero-day"))
                return "Zero-day exploits are attacks on software before a fix exists. Stay updated!";
            if (userInput.Contains("antivirus"))
                return "An antivirus helps detect and remove threats. Keep it updated.";
            if (userInput.Contains("public wi-fi"))
                return "Avoid logging into accounts over public Wi-Fi unless you use a VPN.";
            if (userInput.Contains("update") || userInput.Contains("patch"))
                return "Regular updates fix vulnerabilities. Set your apps to auto-update.";

            return "Hmm... I’m not sure about that yet. Try asking about phishing, VPNs, or passwords!";
        }

        // Goodbye popup when the form is closing
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            DialogResult result = MessageBox.Show(
                $"Goodbye, {Program.UserName}! Hope to chat again soon 😊",
                "Exit Chatbot",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}

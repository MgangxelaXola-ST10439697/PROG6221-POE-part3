using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cybersecurity_Chatbot
{
    public partial class CyberQuizForm : Form
    {
        // Question model
        class QuizQuestion
        {
            public string QuestionText { get; set; }
            public string[] Options { get; set; }
            public int CorrectOptionIndex { get; set; }
            public string Explanation { get; set; }
        }

        private List<QuizQuestion> questions;
        private int currentQuestionIndex = 0;
        private int score = 0;

        public CyberQuizForm()
        {
            InitializeComponent();
            LoadQuiz();
        }

        private void LoadQuiz()
        {
            questions = new List<QuizQuestion>
            {
               new QuizQuestion {
    QuestionText = "Which best describes a phishing attack in cybersecurity?",
    Options = new[] {
        "An email tactic used to deceive users into revealing confidential information",
        "A malware infection caused by downloading untrusted software",
        "A brute-force technique to guess passwords",
        "An encryption method used in secure communication"
    },
    CorrectOptionIndex = 0,
    Explanation = "Phishing attacks often come via email, posing as trusted sources to trick users into revealing sensitive data like passwords or credit card info."
},
new QuizQuestion {
    QuestionText = "True or False: A password like '123456' is considered secure due to its simplicity.",
    Options = new[] { "True", "False", "", "" },
    CorrectOptionIndex = 1,
    Explanation = "'123456' is one of the most commonly used and easily guessed passwords, making it extremely insecure."
},
new QuizQuestion {
    QuestionText = "Which of the following passwords follows the best practices for strong password creation?",
    Options = new[] {
        "P@ssw0rd1",          // Too common
        "Summer2024",         // Based on season/year, predictable
        "qwerty123!",         // Keyboard pattern
        "V@ult#92zT!"         // Strong: symbols, numbers, mixed case
    },
    CorrectOptionIndex = 3,
    Explanation = "Strong passwords are long, unique, and include uppercase and lowercase letters, numbers, and special characters."
},
new QuizQuestion {
    QuestionText = "In cybersecurity, what does the term '2FA' specifically refer to?",
    Options = new[] {
        "A second-layer verification method using two distinct authentication factors",
        "A type of encryption used in public key infrastructure",
        "A firewall protocol for blocking external threats",
        "A software tool used for password recovery"
    },
    CorrectOptionIndex = 0,
    Explanation = "2FA (Two-Factor Authentication) requires two different types of credentials: something you know (password) and something you have (token or device)."
},
new QuizQuestion {
    QuestionText = "Why is HTTPS considered more secure than HTTP?",
    Options = new[] {
        "It prevents the website from being indexed by search engines",
        "It blocks phishing attempts automatically",
        "It encrypts data transferred between client and server using SSL/TLS",
        "It replaces IP addresses with anonymous domains"
    },
    CorrectOptionIndex = 2,
    Explanation = "HTTPS uses SSL/TLS to encrypt the communication channel between your browser and the website, protecting against eavesdropping and tampering."
},
new QuizQuestion {
    QuestionText = "What is the safest action when receiving an unexpected email asking you to confirm personal information?",
    Options = new[] {
        "Click the link to verify its source",
        "Reply and ask for more details",
        "Mark it as important",
        "Delete the email or report it as phishing"
    },
    CorrectOptionIndex = 3,
    Explanation = "Suspicious emails should never be interacted with; delete or report them without clicking or replying."
},
new QuizQuestion {
    QuestionText = "What does 'social engineering' typically involve?",
    Options = new[] {
        "Manipulating people into divulging confidential information",
        "Programming social media bots",
        "Blocking social network traffic via a firewall",
        "Encrypting messages sent over instant messaging apps"
    },
    CorrectOptionIndex = 0,
    Explanation = "Social engineering uses human interaction and deception to gain unauthorized access to systems or data."
},
new QuizQuestion {
    QuestionText = "Which of the following is considered a best practice for online security?",
    Options = new[] {
        "Reusing passwords for multiple accounts",
        "Downloading software from unverified sources",
        "Using a password manager to generate and store unique passwords",
        "Clicking promotional links in unsolicited emails"
    },
    CorrectOptionIndex = 2,
    Explanation = "Password managers help you use strong, unique passwords across all your accounts without needing to remember them all."
},
new QuizQuestion {
    QuestionText = "True or False: You should always assume public Wi-Fi networks are safe for accessing sensitive information.",
    Options = new[] { "True", "False", "", "" },
    CorrectOptionIndex = 1,
    Explanation = "Public Wi-Fi networks are often insecure and can be exploited by attackers using sniffing or man-in-the-middle attacks."
},
new QuizQuestion {
    QuestionText = "Which of the following is a recommended data protection practice?",
    Options = new[] {
        "Disabling antivirus software to improve performance",
        "Ignoring software and firmware updates",
        "Regularly backing up data to secure offline or cloud storage",
        "Sharing backup drives across multiple users for convenience"
    },
    CorrectOptionIndex = 2,
    Explanation = "Regular backups ensure data can be recovered after incidents like ransomware, hardware failure, or accidental deletion."
}

            };

            DisplayQuestion();
        }

        private void DisplayQuestion()
        {
            if (currentQuestionIndex >= questions.Count)
            {
                ShowFinalScore();
                return;
            }

            var question = questions[currentQuestionIndex];
            labelQuestion.Text = question.QuestionText;

            radioOption1.Text = question.Options[0];
            radioOption2.Text = question.Options[1];
            radioOption3.Text = question.Options[2];
            radioOption4.Text = question.Options[3];

            radioOption1.Checked = false;
            radioOption2.Checked = false;
            radioOption3.Checked = false;
            radioOption4.Checked = false;

            labelFeedback.Text = "";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var question = questions[currentQuestionIndex];
            int selected = -1;

            if (radioOption1.Checked) selected = 0;
            else if (radioOption2.Checked) selected = 1;
            else if (radioOption3.Checked) selected = 2;
            else if (radioOption4.Checked) selected = 3;

            if (selected == -1)
            {
                MessageBox.Show("Please select an answer!");
                return;
            }

            if (selected == question.CorrectOptionIndex)
            {
                score++;
                labelFeedback.ForeColor = Color.Green;
                labelFeedback.Text = "Correct! " + question.Explanation;
            }
            else
            {
                labelFeedback.ForeColor = Color.Red;
                labelFeedback.Text = "Incorrect. " + question.Explanation;
            }

            labelScore.Text = $"Score: {score}/{questions.Count}";
            currentQuestionIndex++;

            buttonNext.Enabled = false;

            Timer timer = new Timer();
            timer.Interval = 2500;
            timer.Tick += (s, ev) =>
            {
                timer.Stop();
                buttonNext.Enabled = true;
                DisplayQuestion();
            };
            timer.Start();
        }

        private void ShowFinalScore()
        {
            string message;

            if (score >= 8)
                message = "Great job! You're a cybersecurity pro!";
            else if (score >= 5)
                message = "Nice effort! Keep learning to stay safe online.";
            else
                message = "Don't worry! Keep learning — cybersecurity takes practice.";

            MessageBox.Show($"Final Score: {score}/{questions.Count}\n\n{message}", "Quiz Complete");

            this.Close(); // or navigate back to main chatbot
        }
    }
}
namespace Cybersecurity_Chatbot.Forms
{
    partial class MainChatForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnQuiz = new System.Windows.Forms.Button();
            this.btnTasks = new System.Windows.Forms.Button();
            this.btnLogs = new System.Windows.Forms.Button();
            this.lblSuggestionMenu = new System.Windows.Forms.Label(); // NEW
            this.pnlChatMessages = new System.Windows.Forms.FlowLayoutPanel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.txtUserInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();

            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // 
            // btnQuiz
            // 
            this.btnQuiz.Text = "Cybersecurity Quiz";
            this.btnQuiz.Location = new System.Drawing.Point(10, 10);
            this.btnQuiz.Size = new System.Drawing.Size(150, 30);
            this.btnQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuiz.UseVisualStyleBackColor = true;

            // 
            // btnTasks
            // 
            this.btnTasks.Text = "Task Manager";
            this.btnTasks.Location = new System.Drawing.Point(170, 10);
            this.btnTasks.Size = new System.Drawing.Size(150, 30);
            this.btnTasks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTasks.UseVisualStyleBackColor = true;

            // 
            // btnLogs
            // 
            this.btnLogs.Text = "Activity Log";
            this.btnLogs.Location = new System.Drawing.Point(330, 10);
            this.btnLogs.Size = new System.Drawing.Size(150, 30);
            this.btnLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogs.UseVisualStyleBackColor = true;

            // 
            // lblSuggestionMenu (NEW)
            // 
            this.lblSuggestionMenu.Text = "💡 Try asking: What is phishing? | Remind me to update my password | Start the quiz";
            this.lblSuggestionMenu.Location = new System.Drawing.Point(10, 50);
            this.lblSuggestionMenu.Size = new System.Drawing.Size(800, 25);
            this.lblSuggestionMenu.ForeColor = System.Drawing.Color.DimGray;
            this.lblSuggestionMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSuggestionMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // pnlChatMessages
            // 
            this.pnlChatMessages.AutoScroll = true;
            this.pnlChatMessages.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlChatMessages.Location = new System.Drawing.Point(0, 80);
            this.pnlChatMessages.Name = "pnlChatMessages";
            this.pnlChatMessages.Padding = new System.Windows.Forms.Padding(10);
            this.pnlChatMessages.Size = new System.Drawing.Size(820, 340);
            this.pnlChatMessages.WrapContents = false;

            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.txtUserInput);
            this.panelBottom.Controls.Add(this.btnSend);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 420);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(820, 40);
            this.panelBottom.TabIndex = 2;

            // 
            // txtUserInput
            // 
            this.txtUserInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserInput.Location = new System.Drawing.Point(10, 5);
            this.txtUserInput.Name = "txtUserInput";
            this.txtUserInput.Size = new System.Drawing.Size(680, 26);
            this.txtUserInput.TabIndex = 0;

            // 
            // btnSend
            // 
            this.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSend.Location = new System.Drawing.Point(700, 5);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 30);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            // 
            // MainChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(820, 460);
            this.Controls.Add(this.pnlChatMessages);
            this.Controls.Add(this.lblSuggestionMenu); // Add suggestion label
            this.Controls.Add(this.btnLogs);
            this.Controls.Add(this.btnTasks);
            this.Controls.Add(this.btnQuiz);
            this.Controls.Add(this.panelBottom);
            this.Name = "MainChatForm";
            this.Text = "Cybersecurity Chatbot";

            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
        }


        #endregion

        private System.Windows.Forms.Button btnQuiz;
        private System.Windows.Forms.Button btnTasks;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.FlowLayoutPanel pnlChatMessages;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TextBox txtUserInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblSuggestionMenu;

    }
}


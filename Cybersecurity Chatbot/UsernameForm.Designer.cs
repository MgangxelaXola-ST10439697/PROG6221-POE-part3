namespace Cybersecurity_Chatbot.Forms
{
    partial class UsernameForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSubmit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblPrompt = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblPrompt
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Location = new System.Drawing.Point(25, 20);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(190, 17);
            this.lblPrompt.Text = "Welcome 😊\nPlease enter your name:";

            // txtName
            this.txtName.Location = new System.Drawing.Point(28, 50);
            this.txtName.Size = new System.Drawing.Size(250, 22);

            // btnSubmit
            this.btnSubmit.Location = new System.Drawing.Point(100, 90);
            this.btnSubmit.Size = new System.Drawing.Size(100, 30);
            this.btnSubmit.Text = "Continue";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            // UsernameForm
            this.ClientSize = new System.Drawing.Size(310, 140);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnSubmit);
            this.Name = "UsernameForm";
            this.Text = "Welcome";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

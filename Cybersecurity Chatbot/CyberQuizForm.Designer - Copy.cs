namespace Cybersecurity_Chatbot
{
    partial class CyberQuizForm
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
            this.labelQuestion = new System.Windows.Forms.Label();
            this.radioOption1 = new System.Windows.Forms.RadioButton();
            this.radioOption2 = new System.Windows.Forms.RadioButton();
            this.radioOption3 = new System.Windows.Forms.RadioButton();
            this.radioOption4 = new System.Windows.Forms.RadioButton();
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelFeedback = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.labelQuestion.Location = new System.Drawing.Point(30, 20);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(216, 22);
            this.labelQuestion.TabIndex = 0;
            this.labelQuestion.Text = "Question will appear here";
            // 
            // radioOption1
            // 
            this.radioOption1.AutoSize = true;
            this.radioOption1.Location = new System.Drawing.Point(50, 70);
            this.radioOption1.Name = "radioOption1";
            this.radioOption1.Size = new System.Drawing.Size(800, 19);
            this.radioOption1.TabIndex = 1;
            this.radioOption1.Text = "Option 1";
            this.radioOption1.UseVisualStyleBackColor = true;
            // 
            // radioOption2
            // 
            this.radioOption2.AutoSize = true;
            this.radioOption2.Location = new System.Drawing.Point(50, 100);
            this.radioOption2.Name = "radioOption2";
            this.radioOption2.Size = new System.Drawing.Size(800, 19);
            this.radioOption2.TabIndex = 2;
            this.radioOption2.Text = "Option 2";
            this.radioOption2.UseVisualStyleBackColor = true;
            // 
            // radioOption3
            // 
            this.radioOption3.AutoSize = true;
            this.radioOption3.Location = new System.Drawing.Point(50, 130);
            this.radioOption3.Name = "radioOption3";
            this.radioOption3.Size = new System.Drawing.Size(800, 19);
            this.radioOption3.TabIndex = 3;
            this.radioOption3.Text = "Option 3";
            this.radioOption3.UseVisualStyleBackColor = true;
            // 
            // radioOption4
            // 
            this.radioOption4.AutoSize = true;
            this.radioOption4.Location = new System.Drawing.Point(50, 160);
            this.radioOption4.Name = "radioOption4";
            this.radioOption4.Size = new System.Drawing.Size(800, 19);
            this.radioOption4.TabIndex = 4;
            this.radioOption4.Text = "Option 4";
            this.radioOption4.UseVisualStyleBackColor = true;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(50, 200);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(100, 30);
            this.buttonNext.TabIndex = 5;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // labelFeedback
            // 
            this.labelFeedback.AutoSize = true;
            this.labelFeedback.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic);
            this.labelFeedback.Location = new System.Drawing.Point(50, 250);
            this.labelFeedback.Name = "labelFeedback";
            this.labelFeedback.Size = new System.Drawing.Size(0, 19);
            this.labelFeedback.TabIndex = 6;
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.labelScore.Location = new System.Drawing.Point(900, 20);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(70, 19);
            this.labelScore.TabIndex = 7;
            this.labelScore.Text = "Score: 0";
            // 
            // CyberQuizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 487);
            this.Controls.Add(this.labelQuestion);
            this.Controls.Add(this.radioOption1);
            this.Controls.Add(this.radioOption2);
            this.Controls.Add(this.radioOption3);
            this.Controls.Add(this.radioOption4);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.labelFeedback);
            this.Controls.Add(this.labelScore);
            this.Name = "CyberQuizForm";
            this.Text = "Cybersecurity Quiz";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.GroupBox groupOptions;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton radioOption2;
        private System.Windows.Forms.RadioButton radioOption1;
        private System.Windows.Forms.RadioButton radioOption4;
        private System.Windows.Forms.RadioButton radioOption3;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label labelFeedback;
        private System.Windows.Forms.Label labelScore;
    }
}
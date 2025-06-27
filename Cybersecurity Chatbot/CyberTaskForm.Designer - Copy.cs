namespace Cybersecurity_Chatbot.Forms
{
    partial class CyberTaskForm
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.TextBox();
            this.checkBoxSetReminder = new System.Windows.Forms.CheckBox();
            this.dateTimePickerReminder = new System.Windows.Forms.DateTimePicker();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.listBoxTasks = new System.Windows.Forms.ListBox();
            this.buttonComplete = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(107, 23);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Task Title: ";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitle.Location = new System.Drawing.Point(125, 9);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(250, 27);
            this.textBoxTitle.TabIndex = 1;
            this.textBoxTitle.Text = "Title";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(13, 57);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(81, 16);
            this.labelDescription.TabIndex = 2;
            this.labelDescription.Text = "Description: ";
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(16, 85);
            this.Description.Multiline = true;
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(300, 60);
            this.Description.TabIndex = 3;
            this.Description.TextChanged += new System.EventHandler(this.Description_TextChanged);
            // 
            // checkBoxSetReminder
            // 
            this.checkBoxSetReminder.AutoSize = true;
            this.checkBoxSetReminder.Location = new System.Drawing.Point(16, 161);
            this.checkBoxSetReminder.Name = "checkBoxSetReminder";
            this.checkBoxSetReminder.Size = new System.Drawing.Size(118, 20);
            this.checkBoxSetReminder.TabIndex = 4;
            this.checkBoxSetReminder.Text = "Set Reminder?";
            this.checkBoxSetReminder.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerReminder
            // 
            this.dateTimePickerReminder.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerReminder.Enabled = false;
            this.dateTimePickerReminder.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerReminder.Location = new System.Drawing.Point(160, 161);
            this.dateTimePickerReminder.Name = "dateTimePickerReminder";
            this.dateTimePickerReminder.Size = new System.Drawing.Size(282, 22);
            this.dateTimePickerReminder.TabIndex = 5;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(31, 201);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Add Task";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // listBoxTasks
            // 
            this.listBoxTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxTasks.FormattingEnabled = true;
            this.listBoxTasks.ItemHeight = 16;
            this.listBoxTasks.Location = new System.Drawing.Point(31, 230);
            this.listBoxTasks.Name = "listBoxTasks";
            this.listBoxTasks.Size = new System.Drawing.Size(350, 148);
            this.listBoxTasks.TabIndex = 7;
            // 
            // buttonComplete
            // 
            this.buttonComplete.Location = new System.Drawing.Point(31, 397);
            this.buttonComplete.Name = "buttonComplete";
            this.buttonComplete.Size = new System.Drawing.Size(143, 25);
            this.buttonComplete.TabIndex = 8;
            this.buttonComplete.Text = "Mark Completed";
            this.buttonComplete.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(228, 397);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(147, 23);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Text = "Delete Selected ";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // CyberTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 483);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonComplete);
            this.Controls.Add(this.listBoxTasks);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dateTimePickerReminder);
            this.Controls.Add(this.checkBoxSetReminder);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.labelTitle);
            this.Name = "CyberTaskForm";
            this.Text = "CyberTaskForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox Description;
        private System.Windows.Forms.CheckBox checkBoxSetReminder;
        private System.Windows.Forms.DateTimePicker dateTimePickerReminder;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ListBox listBoxTasks;
        private System.Windows.Forms.Button buttonComplete;
        private System.Windows.Forms.Button buttonDelete;
    }
}
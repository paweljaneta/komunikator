namespace kilent
{
    partial class Form1
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
            this.nickText = new System.Windows.Forms.TextBox();
            this.toText = new System.Windows.Forms.TextBox();
            this.historyOfMessages = new System.Windows.Forms.TextBox();
            this.messageText = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nickText
            // 
            this.nickText.Location = new System.Drawing.Point(96, 13);
            this.nickText.Name = "nickText";
            this.nickText.Size = new System.Drawing.Size(100, 20);
            this.nickText.TabIndex = 0;
            // 
            // toText
            // 
            this.toText.Location = new System.Drawing.Point(96, 152);
            this.toText.Name = "toText";
            this.toText.Size = new System.Drawing.Size(100, 20);
            this.toText.TabIndex = 1;
            // 
            // historyOfMessages
            // 
            this.historyOfMessages.Location = new System.Drawing.Point(12, 39);
            this.historyOfMessages.Multiline = true;
            this.historyOfMessages.Name = "historyOfMessages";
            this.historyOfMessages.ReadOnly = true;
            this.historyOfMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.historyOfMessages.Size = new System.Drawing.Size(260, 107);
            this.historyOfMessages.TabIndex = 2;
            // 
            // messageText
            // 
            this.messageText.Location = new System.Drawing.Point(18, 185);
            this.messageText.Multiline = true;
            this.messageText.Name = "messageText";
            this.messageText.Size = new System.Drawing.Size(253, 74);
            this.messageText.TabIndex = 3;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(112, 265);
            this.sendButton.Name = "sendButton";
            this.sendButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sendButton.Size = new System.Drawing.Size(69, 30);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "nick";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "to:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 298);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageText);
            this.Controls.Add(this.historyOfMessages);
            this.Controls.Add(this.toText);
            this.Controls.Add(this.nickText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nickText;
        private System.Windows.Forms.TextBox toText;
        private System.Windows.Forms.TextBox historyOfMessages;
        private System.Windows.Forms.TextBox messageText;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}


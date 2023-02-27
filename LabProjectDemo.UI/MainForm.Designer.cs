namespace LabProjectDemo.UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.workButton = new System.Windows.Forms.Button();
            this.readedCodesLabel = new System.Windows.Forms.Label();
            this.readedCodes = new System.Windows.Forms.Label();
            this.numOfReadedLabel = new System.Windows.Forms.Label();
            this.numOfReaded = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // workButton
            // 
            this.workButton.Location = new System.Drawing.Point(174, 142);
            this.workButton.Name = "workButton";
            this.workButton.Size = new System.Drawing.Size(125, 58);
            this.workButton.TabIndex = 0;
            this.workButton.Text = "Start";
            this.workButton.UseVisualStyleBackColor = true;
            this.workButton.Click += new System.EventHandler(this.workButton_Click);
            // 
            // readedCodesLabel
            // 
            this.readedCodesLabel.AutoSize = true;
            this.readedCodesLabel.Location = new System.Drawing.Point(46, 51);
            this.readedCodesLabel.Name = "readedCodesLabel";
            this.readedCodesLabel.Size = new System.Drawing.Size(77, 15);
            this.readedCodesLabel.TabIndex = 1;
            this.readedCodesLabel.Text = "Readed Code";
            // 
            // readedCodes
            // 
            this.readedCodes.AutoSize = true;
            this.readedCodes.Location = new System.Drawing.Point(133, 51);
            this.readedCodes.Name = "readedCodes";
            this.readedCodes.Size = new System.Drawing.Size(38, 15);
            this.readedCodes.TabIndex = 2;
            this.readedCodes.Text = "label2";
            // 
            // numOfReadedLabel
            // 
            this.numOfReadedLabel.AutoSize = true;
            this.numOfReadedLabel.Location = new System.Drawing.Point(19, 21);
            this.numOfReadedLabel.Name = "numOfReadedLabel";
            this.numOfReadedLabel.Size = new System.Drawing.Size(104, 15);
            this.numOfReadedLabel.TabIndex = 3;
            this.numOfReadedLabel.Text = "Number of readed";
            // 
            // numOfReaded
            // 
            this.numOfReaded.AutoSize = true;
            this.numOfReaded.Location = new System.Drawing.Point(133, 21);
            this.numOfReaded.Name = "numOfReaded";
            this.numOfReaded.Size = new System.Drawing.Size(13, 15);
            this.numOfReaded.TabIndex = 4;
            this.numOfReaded.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 212);
            this.Controls.Add(this.numOfReaded);
            this.Controls.Add(this.numOfReadedLabel);
            this.Controls.Add(this.readedCodes);
            this.Controls.Add(this.readedCodesLabel);
            this.Controls.Add(this.workButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button workButton;
        private Label readedCodesLabel;
        private Label readedCodes;
        private Label numOfReadedLabel;
        private Label numOfReaded;
    }
}
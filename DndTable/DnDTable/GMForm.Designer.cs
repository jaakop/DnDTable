namespace DnDTable
{
    partial class GMForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.LoadLevelButton = new System.Windows.Forms.Button();
            this.levelPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DrawLevelButton = new System.Windows.Forms.Button();
            this.levelCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AddNoteButton = new System.Windows.Forms.Button();
            this.NoteInputTextBox = new System.Windows.Forms.RichTextBox();
            this.NoteTextBox = new System.Windows.Forms.RichTextBox();
            this.MessageIDText = new System.Windows.Forms.Label();
            this.NoteUpButton = new System.Windows.Forms.Button();
            this.NoteDownButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(64, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Level Control";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(17, 70);
            this.BrowseButton.Margin = new System.Windows.Forms.Padding(4);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(100, 28);
            this.BrowseButton.TabIndex = 1;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // LoadLevelButton
            // 
            this.LoadLevelButton.Location = new System.Drawing.Point(17, 106);
            this.LoadLevelButton.Margin = new System.Windows.Forms.Padding(4);
            this.LoadLevelButton.Name = "LoadLevelButton";
            this.LoadLevelButton.Size = new System.Drawing.Size(279, 28);
            this.LoadLevelButton.TabIndex = 2;
            this.LoadLevelButton.Text = "Load level";
            this.LoadLevelButton.UseVisualStyleBackColor = true;
            this.LoadLevelButton.Click += new System.EventHandler(this.LoadLevelButton_Click);
            // 
            // levelPath
            // 
            this.levelPath.Location = new System.Drawing.Point(125, 73);
            this.levelPath.Margin = new System.Windows.Forms.Padding(4);
            this.levelPath.Name = "levelPath";
            this.levelPath.Size = new System.Drawing.Size(169, 22);
            this.levelPath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(85, 149);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Level Selection";
            // 
            // DrawLevelButton
            // 
            this.DrawLevelButton.Location = new System.Drawing.Point(17, 210);
            this.DrawLevelButton.Margin = new System.Windows.Forms.Padding(4);
            this.DrawLevelButton.Name = "DrawLevelButton";
            this.DrawLevelButton.Size = new System.Drawing.Size(279, 28);
            this.DrawLevelButton.TabIndex = 6;
            this.DrawLevelButton.Text = "Draw Level";
            this.DrawLevelButton.UseVisualStyleBackColor = true;
            this.DrawLevelButton.Click += new System.EventHandler(this.DrawLevelButton_Click);
            // 
            // levelCombo
            // 
            this.levelCombo.FormattingEnabled = true;
            this.levelCombo.Location = new System.Drawing.Point(17, 177);
            this.levelCombo.Margin = new System.Windows.Forms.Padding(4);
            this.levelCombo.Name = "levelCombo";
            this.levelCombo.Size = new System.Drawing.Size(277, 24);
            this.levelCombo.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label3.Location = new System.Drawing.Point(508, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 30);
            this.label3.TabIndex = 9;
            this.label3.Text = "Notes";
            // 
            // AddNoteButton
            // 
            this.AddNoteButton.Location = new System.Drawing.Point(652, 164);
            this.AddNoteButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddNoteButton.Name = "AddNoteButton";
            this.AddNoteButton.Size = new System.Drawing.Size(104, 76);
            this.AddNoteButton.TabIndex = 12;
            this.AddNoteButton.Text = "Add note";
            this.AddNoteButton.UseVisualStyleBackColor = true;
            this.AddNoteButton.Click += new System.EventHandler(this.AddNoteButton_Click);
            // 
            // NoteInputTextBox
            // 
            this.NoteInputTextBox.Location = new System.Drawing.Point(361, 164);
            this.NoteInputTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.NoteInputTextBox.Name = "NoteInputTextBox";
            this.NoteInputTextBox.Size = new System.Drawing.Size(276, 74);
            this.NoteInputTextBox.TabIndex = 13;
            this.NoteInputTextBox.Text = "";
            // 
            // NoteTextBox
            // 
            this.NoteTextBox.Location = new System.Drawing.Point(361, 60);
            this.NoteTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.NoteTextBox.Name = "NoteTextBox";
            this.NoteTextBox.ReadOnly = true;
            this.NoteTextBox.Size = new System.Drawing.Size(276, 74);
            this.NoteTextBox.TabIndex = 14;
            this.NoteTextBox.Text = "";
            // 
            // MessageIDText
            // 
            this.MessageIDText.AutoSize = true;
            this.MessageIDText.Location = new System.Drawing.Point(644, 86);
            this.MessageIDText.Name = "MessageIDText";
            this.MessageIDText.Size = new System.Drawing.Size(46, 17);
            this.MessageIDText.TabIndex = 15;
            this.MessageIDText.Text = "label4";
            // 
            // NoteUpButton
            // 
            this.NoteUpButton.Location = new System.Drawing.Point(644, 60);
            this.NoteUpButton.Name = "NoteUpButton";
            this.NoteUpButton.Size = new System.Drawing.Size(75, 23);
            this.NoteUpButton.TabIndex = 16;
            this.NoteUpButton.Text = "UP";
            this.NoteUpButton.UseVisualStyleBackColor = true;
            this.NoteUpButton.Click += new System.EventHandler(this.NoteUpButton_Click);
            // 
            // NoteDownButton
            // 
            this.NoteDownButton.Location = new System.Drawing.Point(644, 111);
            this.NoteDownButton.Name = "NoteDownButton";
            this.NoteDownButton.Size = new System.Drawing.Size(75, 23);
            this.NoteDownButton.TabIndex = 17;
            this.NoteDownButton.Text = "DOWN";
            this.NoteDownButton.UseVisualStyleBackColor = true;
            this.NoteDownButton.Click += new System.EventHandler(this.NoteDownButton_Click);
            // 
            // GMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1588, 811);
            this.Controls.Add(this.NoteDownButton);
            this.Controls.Add(this.NoteUpButton);
            this.Controls.Add(this.MessageIDText);
            this.Controls.Add(this.NoteTextBox);
            this.Controls.Add(this.NoteInputTextBox);
            this.Controls.Add(this.AddNoteButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.levelCombo);
            this.Controls.Add(this.DrawLevelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.levelPath);
            this.Controls.Add(this.LoadLevelButton);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GMForm";
            this.Text = "GMFrom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Button LoadLevelButton;
        private System.Windows.Forms.TextBox levelPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DrawLevelButton;
        private System.Windows.Forms.ComboBox levelCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AddNoteButton;
        private System.Windows.Forms.RichTextBox NoteInputTextBox;
        private System.Windows.Forms.RichTextBox NoteTextBox;
        private System.Windows.Forms.Label MessageIDText;
        private System.Windows.Forms.Button NoteUpButton;
        private System.Windows.Forms.Button NoteDownButton;
    }
}
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
            this.NoteBox = new System.Windows.Forms.GroupBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.AddNoteButton = new System.Windows.Forms.Button();
            this.NoteTextBox = new System.Windows.Forms.RichTextBox();
            this.NoteBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(48, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Level Control";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(13, 57);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 1;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // LoadLevelButton
            // 
            this.LoadLevelButton.Location = new System.Drawing.Point(13, 86);
            this.LoadLevelButton.Name = "LoadLevelButton";
            this.LoadLevelButton.Size = new System.Drawing.Size(209, 23);
            this.LoadLevelButton.TabIndex = 2;
            this.LoadLevelButton.Text = "Load level";
            this.LoadLevelButton.UseVisualStyleBackColor = true;
            this.LoadLevelButton.Click += new System.EventHandler(this.LoadLevelButton_Click);
            // 
            // levelPath
            // 
            this.levelPath.Location = new System.Drawing.Point(94, 59);
            this.levelPath.Name = "levelPath";
            this.levelPath.Size = new System.Drawing.Size(128, 20);
            this.levelPath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(64, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Level Selection";
            // 
            // DrawLevelButton
            // 
            this.DrawLevelButton.Location = new System.Drawing.Point(13, 171);
            this.DrawLevelButton.Name = "DrawLevelButton";
            this.DrawLevelButton.Size = new System.Drawing.Size(209, 23);
            this.DrawLevelButton.TabIndex = 6;
            this.DrawLevelButton.Text = "Draw Level";
            this.DrawLevelButton.UseVisualStyleBackColor = true;
            this.DrawLevelButton.Click += new System.EventHandler(this.DrawLevelButton_Click);
            // 
            // levelCombo
            // 
            this.levelCombo.FormattingEnabled = true;
            this.levelCombo.Location = new System.Drawing.Point(13, 144);
            this.levelCombo.Name = "levelCombo";
            this.levelCombo.Size = new System.Drawing.Size(209, 21);
            this.levelCombo.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label3.Location = new System.Drawing.Point(381, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Notes";
            // 
            // NoteBox
            // 
            this.NoteBox.Controls.Add(this.vScrollBar1);
            this.NoteBox.Location = new System.Drawing.Point(271, 46);
            this.NoteBox.Name = "NoteBox";
            this.NoteBox.Size = new System.Drawing.Size(296, 220);
            this.NoteBox.TabIndex = 10;
            this.NoteBox.TabStop = false;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.LargeChange = 1;
            this.vScrollBar1.Location = new System.Drawing.Point(276, 16);
            this.vScrollBar1.Maximum = 0;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 201);
            this.vScrollBar1.TabIndex = 0;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // AddNoteButton
            // 
            this.AddNoteButton.Location = new System.Drawing.Point(489, 274);
            this.AddNoteButton.Name = "AddNoteButton";
            this.AddNoteButton.Size = new System.Drawing.Size(78, 62);
            this.AddNoteButton.TabIndex = 12;
            this.AddNoteButton.Text = "Add note";
            this.AddNoteButton.UseVisualStyleBackColor = true;
            this.AddNoteButton.Click += new System.EventHandler(this.AddNoteButton_Click);
            // 
            // NoteTextBox
            // 
            this.NoteTextBox.Location = new System.Drawing.Point(271, 274);
            this.NoteTextBox.Name = "NoteTextBox";
            this.NoteTextBox.Size = new System.Drawing.Size(208, 61);
            this.NoteTextBox.TabIndex = 13;
            this.NoteTextBox.Text = "";
            // 
            // GMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 659);
            this.Controls.Add(this.NoteTextBox);
            this.Controls.Add(this.AddNoteButton);
            this.Controls.Add(this.NoteBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.levelCombo);
            this.Controls.Add(this.DrawLevelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.levelPath);
            this.Controls.Add(this.LoadLevelButton);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GMForm";
            this.Text = "GMFrom";
            this.NoteBox.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox NoteBox;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Button AddNoteButton;
        private System.Windows.Forms.RichTextBox NoteTextBox;
    }
}
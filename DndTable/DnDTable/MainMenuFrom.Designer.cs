namespace DnDTable
{
    partial class MainMenuFrom
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
            this.ScreenCom = new System.Windows.Forms.ComboBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LoadGameButton = new System.Windows.Forms.Button();
            this.LevelEditorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ScreenCom
            // 
            this.ScreenCom.FormattingEnabled = true;
            this.ScreenCom.Location = new System.Drawing.Point(44, 30);
            this.ScreenCom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ScreenCom.Name = "ScreenCom";
            this.ScreenCom.Size = new System.Drawing.Size(92, 21);
            this.ScreenCom.TabIndex = 0;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(161, 26);
            this.StartButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(95, 27);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "New game";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.NewGameClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label1.Location = new System.Drawing.Point(41, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Screen";
            // 
            // LoadGameButton
            // 
            this.LoadGameButton.Location = new System.Drawing.Point(161, 58);
            this.LoadGameButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoadGameButton.Name = "LoadGameButton";
            this.LoadGameButton.Size = new System.Drawing.Size(95, 27);
            this.LoadGameButton.TabIndex = 3;
            this.LoadGameButton.Text = "Load game";
            this.LoadGameButton.UseVisualStyleBackColor = true;
            this.LoadGameButton.Click += new System.EventHandler(this.LoadGameButton_Click);
            // 
            // LevelEditorButton
            // 
            this.LevelEditorButton.Location = new System.Drawing.Point(44, 58);
            this.LevelEditorButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LevelEditorButton.Name = "LevelEditorButton";
            this.LevelEditorButton.Size = new System.Drawing.Size(105, 27);
            this.LevelEditorButton.TabIndex = 4;
            this.LevelEditorButton.Text = "Open LevelEditor";
            this.LevelEditorButton.UseVisualStyleBackColor = true;
            this.LevelEditorButton.Click += new System.EventHandler(this.LevelEditorButton_Click);
            // 
            // MainMenuFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 105);
            this.Controls.Add(this.LevelEditorButton);
            this.Controls.Add(this.LoadGameButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ScreenCom);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainMenuFrom";
            this.Text = "GMScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ScreenCom;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LoadGameButton;
        private System.Windows.Forms.Button LevelEditorButton;
    }
}


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
            this.ScreenCom.Location = new System.Drawing.Point(59, 37);
            this.ScreenCom.Name = "ScreenCom";
            this.ScreenCom.Size = new System.Drawing.Size(121, 24);
            this.ScreenCom.TabIndex = 0;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(215, 32);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(127, 33);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "New game";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.NewGameClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label1.Location = new System.Drawing.Point(55, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Screen";
            // 
            // LoadGameButton
            // 
            this.LoadGameButton.Location = new System.Drawing.Point(215, 71);
            this.LoadGameButton.Name = "LoadGameButton";
            this.LoadGameButton.Size = new System.Drawing.Size(127, 33);
            this.LoadGameButton.TabIndex = 3;
            this.LoadGameButton.Text = "Load game";
            this.LoadGameButton.UseVisualStyleBackColor = true;
            // 
            // LevelEditorButton
            // 
            this.LevelEditorButton.Location = new System.Drawing.Point(59, 71);
            this.LevelEditorButton.Name = "LevelEditorButton";
            this.LevelEditorButton.Size = new System.Drawing.Size(140, 33);
            this.LevelEditorButton.TabIndex = 4;
            this.LevelEditorButton.Text = "Open LevelEditor";
            this.LevelEditorButton.UseVisualStyleBackColor = true;
            this.LevelEditorButton.Click += new System.EventHandler(this.LevelEditorButton_Click);
            // 
            // GMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 129);
            this.Controls.Add(this.LevelEditorButton);
            this.Controls.Add(this.LoadGameButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ScreenCom);
            this.Name = "GMForm";
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


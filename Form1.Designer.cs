namespace Image_Slider_Puzzle
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            PuzzelBox = new GroupBox();
            OriginalImageBox = new GroupBox();
            lblMovesMade = new Label();
            lblTimeElapsed = new Label();
            tmrTimeElapse = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(25, 512);
            label1.Name = "label1";
            label1.Size = new Size(83, 30);
            label1.TabIndex = 0;
            label1.Text = "ListOne";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(599, 512);
            label2.Name = "label2";
            label2.Size = new Size(180, 30);
            label2.TabIndex = 1;
            label2.Text = "Status";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(917, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(103, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += OpenFileEvent;
            // 
            // PuzzelBox
            // 
            PuzzelBox.Location = new Point(25, 46);
            PuzzelBox.Name = "PuzzelBox";
            PuzzelBox.Size = new Size(430, 425);
            PuzzelBox.TabIndex = 3;
            PuzzelBox.TabStop = false;
            PuzzelBox.Text = "Puzzle Box";
            // 
            // OriginalImageBox
            // 
            OriginalImageBox.Location = new Point(475, 46);
            OriginalImageBox.Name = "OriginalImageBox";
            OriginalImageBox.Size = new Size(300, 300);
            OriginalImageBox.TabIndex = 4;
            OriginalImageBox.TabStop = false;
            OriginalImageBox.Text = "Original";
            // 
            // lblMovesMade
            // 
            lblMovesMade.AutoSize = true;
            lblMovesMade.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblMovesMade.ForeColor = SystemColors.ControlText;
            lblMovesMade.Location = new Point(303, 485);
            lblMovesMade.Name = "lblMovesMade";
            lblMovesMade.Size = new Size(118, 19);
            lblMovesMade.TabIndex = 5;
            lblMovesMade.Text = "Moves Made:  ";
            lblMovesMade.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTimeElapsed
            // 
            lblTimeElapsed.AutoSize = true;
            lblTimeElapsed.Font = new Font("Impact", 48F, FontStyle.Regular, GraphicsUnit.Point);
            lblTimeElapsed.Location = new Point(475, 366);
            lblTimeElapsed.Name = "lblTimeElapsed";
            lblTimeElapsed.Size = new Size(264, 80);
            lblTimeElapsed.TabIndex = 6;
            lblTimeElapsed.Text = "00:00:00";
            // 
            // tmrTimeElapse
            // 
            tmrTimeElapse.Interval = 1000;
            tmrTimeElapse.Tick += UpdateTimeElapsedEvent;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(917, 560);
            Controls.Add(lblTimeElapsed);
            Controls.Add(lblMovesMade);
            Controls.Add(OriginalImageBox);
            Controls.Add(PuzzelBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Image Slider Puzzle";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private GroupBox PuzzelBox;
        private GroupBox OriginalImageBox;
        private Label lblMovesMade;
        private Label lblTimeElapsed;
        private System.Windows.Forms.Timer tmrTimeElapse;
    }
}
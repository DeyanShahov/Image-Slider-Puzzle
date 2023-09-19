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
            GalleryToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            SettingsOpenClosedClickEvent = new ToolStripMenuItem();
            languageToolStripMenuItem = new ToolStripMenuItem();
            englishToolStripMenuItem = new ToolStripMenuItem();
            bulgarianToolStripMenuItem = new ToolStripMenuItem();
            GermanToolStripMenuItem = new ToolStripMenuItem();
            ChineseToolStripMenuItem = new ToolStripMenuItem();
            PuzzleBox = new GroupBox();
            GalleryBox = new GroupBox();
            pictureBox7 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            panSettings = new Panel();
            lblVeryHardMod = new Label();
            lblHardMod = new Label();
            lblNormalMod = new Label();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox1 = new PictureBox();
            OriginalImageBox = new GroupBox();
            lblMovesMade = new Label();
            lblTimeElapsed = new Label();
            tmrTimeElapse = new System.Windows.Forms.Timer(components);
            btnShuffle = new Button();
            btnPause = new Button();
            btnQuit = new Button();
            btnSwitch = new Button();
            btnAutoSolve = new Button();
            panBFS = new Panel();
            lblBFSCurrMove = new Label();
            lblBFSNextMove = new Label();
            btnBFSPlay = new Button();
            btnBFSSolve = new Button();
            textBoxBFSResult = new TextBox();
            lblBFSAttempts = new Label();
            lblBFSMultiplier = new Label();
            lblBFSSolution = new Label();
            textBoxBFSAttemps = new TextBox();
            lblBFSClose = new Label();
            tmrAutoSolve = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            GalleryBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panBFS.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(25, 512);
            label1.Name = "label1";
            label1.Size = new Size(89, 30);
            label1.TabIndex = 0;
            label1.Text = "List One";
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, GalleryToolStripMenuItem, settingsToolStripMenuItem, SettingsOpenClosedClickEvent, languageToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(803, 24);
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
            // GalleryToolStripMenuItem
            // 
            GalleryToolStripMenuItem.Name = "GalleryToolStripMenuItem";
            GalleryToolStripMenuItem.Size = new Size(55, 20);
            GalleryToolStripMenuItem.Text = "Gallery";
            GalleryToolStripMenuItem.Click += GalleryOpenCloseClickEvent;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(12, 20);
            // 
            // SettingsOpenClosedClickEvent
            // 
            SettingsOpenClosedClickEvent.Name = "SettingsOpenClosedClickEvent";
            SettingsOpenClosedClickEvent.Size = new Size(61, 20);
            SettingsOpenClosedClickEvent.Text = "Settings";
            SettingsOpenClosedClickEvent.Click += SettingsOpenClosedClickEvent_Click;
            // 
            // languageToolStripMenuItem
            // 
            languageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { englishToolStripMenuItem, bulgarianToolStripMenuItem, GermanToolStripMenuItem, ChineseToolStripMenuItem });
            languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            languageToolStripMenuItem.Size = new Size(71, 20);
            languageToolStripMenuItem.Text = "Language";
            // 
            // englishToolStripMenuItem
            // 
            englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            englishToolStripMenuItem.Size = new Size(124, 22);
            englishToolStripMenuItem.Text = "English";
            englishToolStripMenuItem.Click += EnglishToolStripMenuItem_Click;
            // 
            // bulgarianToolStripMenuItem
            // 
            bulgarianToolStripMenuItem.Name = "bulgarianToolStripMenuItem";
            bulgarianToolStripMenuItem.Size = new Size(124, 22);
            bulgarianToolStripMenuItem.Text = "Bulgarian";
            bulgarianToolStripMenuItem.Click += BulgarianToolStripMenuItem_Click;
            // 
            // GermanToolStripMenuItem
            // 
            GermanToolStripMenuItem.Name = "GermanToolStripMenuItem";
            GermanToolStripMenuItem.Size = new Size(124, 22);
            GermanToolStripMenuItem.Text = "German";
            GermanToolStripMenuItem.Click += GermanToolStripMenuItem_Click;
            // 
            // ChineseToolStripMenuItem
            // 
            ChineseToolStripMenuItem.Name = "ChineseToolStripMenuItem";
            ChineseToolStripMenuItem.Size = new Size(124, 22);
            ChineseToolStripMenuItem.Text = "Chinese";
            ChineseToolStripMenuItem.Click += ChineseToolStripMenuItem_Click;
            // 
            // PuzzleBox
            // 
            PuzzleBox.Location = new Point(25, 46);
            PuzzleBox.Name = "PuzzleBox";
            PuzzleBox.Size = new Size(430, 425);
            PuzzleBox.TabIndex = 3;
            PuzzleBox.TabStop = false;
            PuzzleBox.Text = "Puzzle Box";
            // 
            // GalleryBox
            // 
            GalleryBox.BackColor = SystemColors.ControlDark;
            GalleryBox.BackgroundImageLayout = ImageLayout.None;
            GalleryBox.Controls.Add(pictureBox7);
            GalleryBox.Controls.Add(pictureBox2);
            GalleryBox.Controls.Add(pictureBox3);
            GalleryBox.Controls.Add(pictureBox4);
            GalleryBox.Controls.Add(panSettings);
            GalleryBox.Controls.Add(pictureBox6);
            GalleryBox.Controls.Add(pictureBox5);
            GalleryBox.Controls.Add(pictureBox1);
            GalleryBox.Location = new Point(120, 27);
            GalleryBox.Name = "GalleryBox";
            GalleryBox.Size = new Size(572, 488);
            GalleryBox.TabIndex = 0;
            GalleryBox.TabStop = false;
            GalleryBox.Text = "Gallery";
            GalleryBox.Visible = false;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = Properties.Resources.Untitled1763;
            pictureBox7.Location = new Point(219, 335);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(149, 116);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 6;
            pictureBox7.TabStop = false;
            pictureBox7.Click += pictureBox7_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Untitled1758;
            pictureBox2.Location = new Point(220, 37);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(149, 116);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.Untitled1759;
            pictureBox3.Location = new Point(396, 37);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(149, 116);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.Untitled1760;
            pictureBox4.Location = new Point(41, 186);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(149, 116);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // panSettings
            // 
            panSettings.BackColor = SystemColors.ActiveBorder;
            panSettings.BorderStyle = BorderStyle.FixedSingle;
            panSettings.Controls.Add(lblVeryHardMod);
            panSettings.Controls.Add(lblHardMod);
            panSettings.Controls.Add(lblNormalMod);
            panSettings.ForeColor = Color.Black;
            panSettings.Location = new Point(174, 4);
            panSettings.Name = "panSettings";
            panSettings.Size = new Size(242, 478);
            panSettings.TabIndex = 0;
            panSettings.Visible = false;
            // 
            // lblVeryHardMod
            // 
            lblVeryHardMod.Anchor = AnchorStyles.None;
            lblVeryHardMod.BorderStyle = BorderStyle.FixedSingle;
            lblVeryHardMod.FlatStyle = FlatStyle.Popup;
            lblVeryHardMod.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblVeryHardMod.Location = new Point(3, 290);
            lblVeryHardMod.Name = "lblVeryHardMod";
            lblVeryHardMod.Size = new Size(234, 31);
            lblVeryHardMod.TabIndex = 2;
            lblVeryHardMod.Text = "VERY HARD";
            lblVeryHardMod.TextAlign = ContentAlignment.MiddleCenter;
            lblVeryHardMod.Click += lblVeryHardMod_Click;
            // 
            // lblHardMod
            // 
            lblHardMod.BorderStyle = BorderStyle.FixedSingle;
            lblHardMod.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblHardMod.Location = new Point(3, 190);
            lblHardMod.Name = "lblHardMod";
            lblHardMod.Size = new Size(234, 31);
            lblHardMod.TabIndex = 1;
            lblHardMod.Text = "HARD";
            lblHardMod.TextAlign = ContentAlignment.MiddleCenter;
            lblHardMod.Click += lblHardMod_Click;
            // 
            // lblNormalMod
            // 
            lblNormalMod.BorderStyle = BorderStyle.FixedSingle;
            lblNormalMod.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblNormalMod.Location = new Point(3, 92);
            lblNormalMod.Name = "lblNormalMod";
            lblNormalMod.Size = new Size(234, 31);
            lblNormalMod.TabIndex = 0;
            lblNormalMod.Text = "NORMAL";
            lblNormalMod.TextAlign = ContentAlignment.MiddleCenter;
            lblNormalMod.Click += lblNormalMod_Click;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.Untitled1762;
            pictureBox6.Location = new Point(396, 186);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(149, 116);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 2;
            pictureBox6.TabStop = false;
            pictureBox6.Click += pictureBox6_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.Untitled1761;
            pictureBox5.Location = new Point(220, 186);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(149, 116);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 1;
            pictureBox5.TabStop = false;
            pictureBox5.Click += pictureBox5_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Untitled1757;
            pictureBox1.Location = new Point(41, 37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(149, 116);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
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
            lblMovesMade.Location = new Point(263, 483);
            lblMovesMade.Name = "lblMovesMade";
            lblMovesMade.Size = new Size(118, 19);
            lblMovesMade.TabIndex = 5;
            lblMovesMade.Text = "Moves Made:  ";
            lblMovesMade.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTimeElapsed
            // 
            lblTimeElapsed.BorderStyle = BorderStyle.Fixed3D;
            lblTimeElapsed.Font = new Font("Impact", 48F, FontStyle.Regular, GraphicsUnit.Point);
            lblTimeElapsed.Location = new Point(475, 366);
            lblTimeElapsed.Name = "lblTimeElapsed";
            lblTimeElapsed.Size = new Size(300, 82);
            lblTimeElapsed.TabIndex = 6;
            lblTimeElapsed.Text = "00:00:00";
            lblTimeElapsed.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tmrTimeElapse
            // 
            tmrTimeElapse.Interval = 1000;
            tmrTimeElapse.Tick += UpdateTimeElapsedEvent;
            // 
            // btnShuffle
            // 
            btnShuffle.Location = new Point(490, 468);
            btnShuffle.Name = "btnShuffle";
            btnShuffle.Size = new Size(75, 23);
            btnShuffle.TabIndex = 7;
            btnShuffle.Text = "Shuffle";
            btnShuffle.UseVisualStyleBackColor = true;
            btnShuffle.Click += btnShuffleClick;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(586, 468);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(75, 23);
            btnPause.TabIndex = 8;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPauseOrResumeClick;
            // 
            // btnQuit
            // 
            btnQuit.Location = new Point(681, 468);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(75, 23);
            btnQuit.TabIndex = 9;
            btnQuit.Text = "Quit";
            btnQuit.UseVisualStyleBackColor = true;
            btnQuit.Click += btnQuitClick;
            // 
            // btnSwitch
            // 
            btnSwitch.Location = new Point(489, 519);
            btnSwitch.Name = "btnSwitch";
            btnSwitch.Size = new Size(75, 23);
            btnSwitch.TabIndex = 10;
            btnSwitch.Text = "Switch +1";
            btnSwitch.UseVisualStyleBackColor = true;
            btnSwitch.Click += btnSwitch_Click;
            // 
            // btnAutoSolve
            // 
            btnAutoSolve.Location = new Point(379, 519);
            btnAutoSolve.Name = "btnAutoSolve";
            btnAutoSolve.Size = new Size(94, 23);
            btnAutoSolve.TabIndex = 11;
            btnAutoSolve.Text = "BFS Answer";
            btnAutoSolve.UseVisualStyleBackColor = true;
            btnAutoSolve.Click += BtnAutoSolve_Click;
            // 
            // panBFS
            // 
            panBFS.BackColor = SystemColors.ActiveBorder;
            panBFS.BorderStyle = BorderStyle.FixedSingle;
            panBFS.Controls.Add(lblBFSCurrMove);
            panBFS.Controls.Add(lblBFSNextMove);
            panBFS.Controls.Add(btnBFSPlay);
            panBFS.Controls.Add(btnBFSSolve);
            panBFS.Controls.Add(textBoxBFSResult);
            panBFS.Controls.Add(lblBFSAttempts);
            panBFS.Controls.Add(lblBFSMultiplier);
            panBFS.Controls.Add(lblBFSSolution);
            panBFS.Controls.Add(textBoxBFSAttemps);
            panBFS.Controls.Add(lblBFSClose);
            panBFS.Location = new Point(475, 46);
            panBFS.Name = "panBFS";
            panBFS.Size = new Size(300, 317);
            panBFS.TabIndex = 12;
            panBFS.Visible = false;
            // 
            // lblBFSCurrMove
            // 
            lblBFSCurrMove.AutoSize = true;
            lblBFSCurrMove.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblBFSCurrMove.Location = new Point(13, 252);
            lblBFSCurrMove.Name = "lblBFSCurrMove";
            lblBFSCurrMove.Size = new Size(64, 21);
            lblBFSCurrMove.TabIndex = 9;
            lblBFSCurrMove.Text = "Move : ";
            // 
            // lblBFSNextMove
            // 
            lblBFSNextMove.AutoSize = true;
            lblBFSNextMove.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblBFSNextMove.Location = new Point(13, 283);
            lblBFSNextMove.Name = "lblBFSNextMove";
            lblBFSNextMove.Size = new Size(99, 21);
            lblBFSNextMove.TabIndex = 8;
            lblBFSNextMove.Text = "Next Move :";
            // 
            // btnBFSPlay
            // 
            btnBFSPlay.Location = new Point(6, 94);
            btnBFSPlay.Name = "btnBFSPlay";
            btnBFSPlay.Size = new Size(75, 23);
            btnBFSPlay.TabIndex = 7;
            btnBFSPlay.Text = "PLAY";
            btnBFSPlay.UseVisualStyleBackColor = true;
            btnBFSPlay.Click += btnBFSPlay_Click;
            // 
            // btnBFSSolve
            // 
            btnBFSSolve.Location = new Point(219, 94);
            btnBFSSolve.Name = "btnBFSSolve";
            btnBFSSolve.Size = new Size(75, 23);
            btnBFSSolve.TabIndex = 6;
            btnBFSSolve.Text = "SOLVE";
            btnBFSSolve.UseVisualStyleBackColor = true;
            btnBFSSolve.Click += btnBFSSolve_Click;
            // 
            // textBoxBFSResult
            // 
            textBoxBFSResult.BackColor = SystemColors.ControlLight;
            textBoxBFSResult.Location = new Point(6, 123);
            textBoxBFSResult.Multiline = true;
            textBoxBFSResult.Name = "textBoxBFSResult";
            textBoxBFSResult.ReadOnly = true;
            textBoxBFSResult.Size = new Size(288, 94);
            textBoxBFSResult.TabIndex = 5;
            // 
            // lblBFSAttempts
            // 
            lblBFSAttempts.AutoSize = true;
            lblBFSAttempts.Location = new Point(6, 62);
            lblBFSAttempts.Name = "lblBFSAttempts";
            lblBFSAttempts.Size = new Size(120, 15);
            lblBFSAttempts.TabIndex = 4;
            lblBFSAttempts.Text = "Attempts for solution";
            // 
            // lblBFSMultiplier
            // 
            lblBFSMultiplier.AutoSize = true;
            lblBFSMultiplier.Location = new Point(217, 62);
            lblBFSMultiplier.Name = "lblBFSMultiplier";
            lblBFSMultiplier.Size = new Size(55, 15);
            lblBFSMultiplier.TabIndex = 3;
            lblBFSMultiplier.Text = "x 100 000";
            // 
            // lblBFSSolution
            // 
            lblBFSSolution.AutoSize = true;
            lblBFSSolution.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblBFSSolution.Location = new Point(66, 5);
            lblBFSSolution.Name = "lblBFSSolution";
            lblBFSSolution.Size = new Size(165, 30);
            lblBFSSolution.TabIndex = 2;
            lblBFSSolution.Text = "BFS SOLUTION";
            // 
            // textBoxBFSAttemps
            // 
            textBoxBFSAttemps.Location = new Point(132, 59);
            textBoxBFSAttemps.Name = "textBoxBFSAttemps";
            textBoxBFSAttemps.Size = new Size(79, 23);
            textBoxBFSAttemps.TabIndex = 1;
            textBoxBFSAttemps.Text = "10";
            textBoxBFSAttemps.TextAlign = HorizontalAlignment.Center;
            // 
            // lblBFSClose
            // 
            lblBFSClose.AutoSize = true;
            lblBFSClose.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblBFSClose.Location = new Point(265, 5);
            lblBFSClose.Name = "lblBFSClose";
            lblBFSClose.Size = new Size(30, 32);
            lblBFSClose.TabIndex = 0;
            lblBFSClose.Text = "X";
            lblBFSClose.Click += lblBFSClose_Click;
            // 
            // tmrAutoSolve
            // 
            tmrAutoSolve.Interval = 1000;
            tmrAutoSolve.Tick += TmrAutoSolve_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(803, 560);
            Controls.Add(GalleryBox);
            Controls.Add(panBFS);
            Controls.Add(btnAutoSolve);
            Controls.Add(btnSwitch);
            Controls.Add(btnQuit);
            Controls.Add(btnPause);
            Controls.Add(btnShuffle);
            Controls.Add(lblTimeElapsed);
            Controls.Add(lblMovesMade);
            Controls.Add(OriginalImageBox);
            Controls.Add(PuzzleBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Image Slider Puzzle";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            GalleryBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panBFS.ResumeLayout(false);
            panBFS.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private GroupBox PuzzleBox;
        private GroupBox OriginalImageBox;
        private Label lblMovesMade;
        private Label lblTimeElapsed;
        private System.Windows.Forms.Timer tmrTimeElapse;
        private Button btnShuffle;
        private Button btnPause;
        private Button btnQuit;
        private ToolStripMenuItem GalleryToolStripMenuItem;
        private GroupBox GalleryBox;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox7;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private Panel panSettings;
        private ToolStripMenuItem SettingsOpenClosedClickEvent;
        private Label lblNormalMod;
        private Label lblVeryHardMod;
        private Label lblHardMod;
        private Button btnSwitch;
        private ToolStripMenuItem languageToolStripMenuItem;
        private ToolStripMenuItem englishToolStripMenuItem;
        private ToolStripMenuItem bulgarianToolStripMenuItem;
        private ToolStripMenuItem GermanToolStripMenuItem;
        private ToolStripMenuItem ChineseToolStripMenuItem;
        private Button btnAutoSolve;
        private Panel panBFS;
        private Label lblBFSClose;
        private Label lblBFSMultiplier;
        private Label lblBFSSolution;
        private TextBox textBoxBFSAttemps;
        private Label lblBFSAttempts;
        private TextBox textBoxBFSResult;
        private Button btnBFSSolve;
        private Button btnBFSPlay;
        private Label lblBFSNextMove;
        private Label lblBFSCurrMove;
        private System.Windows.Forms.Timer tmrAutoSolve;
    }
}
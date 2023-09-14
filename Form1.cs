namespace Image_Slider_Puzzle
{
    public partial class Form1 : Form
    {
        private List<Bitmap> imageFromGallery = new List<Bitmap>();
        private List<PictureBox> pictureBoxList = new List<PictureBox>();
        private List<Bitmap> images = new List<Bitmap>();
        private List<string> locations = new List<string>();
        private List<string> currentLocations = new List<string>();

        private string winPositions;
        private string currentPositions;

        private int moves = 0;
        private int elapsedSeconds = 0;

        Bitmap MainBitmap;

        public Form1()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.puzzle;

            imageFromGallery.Add(Properties.Resources.Untitled1757);
            imageFromGallery.Add(Properties.Resources.Untitled1758);
            imageFromGallery.Add(Properties.Resources.Untitled1759);
            imageFromGallery.Add(Properties.Resources.Untitled1760);
            imageFromGallery.Add(Properties.Resources.Untitled1761);
            imageFromGallery.Add(Properties.Resources.Untitled1762);
            imageFromGallery.Add(Properties.Resources.Untitled1763);
        }

       

        private void SetOriginalImageBox()
        {
            Bitmap tempBitmap = new Bitmap(MainBitmap, new Size(270, 270));            
            OriginalImageBox.BackgroundImageLayout = ImageLayout.Center;
            OriginalImageBox.BackgroundImage = tempBitmap;
        }

        private void CreatePictureBoxes()
        {
            for (int i = 0; i < 9; i++)
            {
                PictureBox tempPic = new PictureBox();
                tempPic.Size = new Size(130, 130);
                tempPic.Tag = i.ToString();
                tempPic.Click += OnPicClick;
                pictureBoxList.Add(tempPic);
                locations.Add(tempPic.Tag.ToString());
            }
        }       

        private void CropImage(Bitmap mainBitmap, int height, int width)
        {
            int x = 0;
            int y = 0;

            for (int blocks = 0; blocks < 9; blocks++)
            {
                Bitmap croppedImage = new Bitmap(width, height);

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        croppedImage.SetPixel(i, j, mainBitmap.GetPixel((i + x), (j + y)));
                    }
                }

                images.Add(croppedImage);

                x += 130;
                if (x == 390)
                {
                    x = 0;
                    y += 130;
                }
            }
        }

        private void AddImages()
        {
            Bitmap tempBitmap = new Bitmap(MainBitmap, new Size(390, 390));
            CropImage(tempBitmap, 130, 130);

            for (int i = 1; i < pictureBoxList.Count; i++)
            {
                pictureBoxList[i].BackgroundImage = images[i];
                //pictureBoxList[i].BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                //tempBitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

            PlacePictureBoxesToForm();
        }

        private void PlacePictureBoxesToForm()
        {
            var shuffleImages = pictureBoxList.OrderBy(a => Guid.NewGuid()).ToList();
            pictureBoxList = shuffleImages;

            int x = PuzzleBox.Location.X - 5;//200;
            int y = PuzzleBox.Location.Y - 25;//25;

            for (int i = 0; i < pictureBoxList.Count; i++)
            {
                pictureBoxList[i].BackColor = Color.Black;

                if (i == 3 || i == 6)
                {
                    y += 130;
                    x = PuzzleBox.Location.X - 5;//200;
                }

                pictureBoxList[i].BorderStyle = BorderStyle.FixedSingle;
                pictureBoxList[i].Location = new Point(x, y);

                PuzzleBox.Controls.Add(pictureBoxList[i]);
                x += 130;
                winPositions += locations[i];
            }
        }

        private bool CheckGame()
        {
            bool isWin = false;

            foreach (Control x in PuzzleBox.Controls)
            {
                if (x is PictureBox) currentLocations.Add(x.Tag.ToString());
            }

            currentPositions = string.Join("", currentLocations);
            label1.Text = winPositions;
            label2.Text = currentPositions;

            if (winPositions == currentPositions)
            {
                label2.Text = "Matched!!!";
                isWin = true;
            }

            return isWin;
        }      

        private void LoadImageFromGalleryOrPc(Bitmap image)
        {
            if (pictureBoxList != null)
            {
                foreach (PictureBox pics in pictureBoxList)
                {
                    PuzzleBox.Controls.Remove(pics);
                }

                OriginalImageBox.BackgroundImage = null;

                pictureBoxList.Clear();
                images.Clear();
                locations.Clear();
                currentLocations.Clear();
                winPositions = string.Empty;
                currentPositions = string.Empty;
                label2.Text = string.Empty;
            }

            if (MainBitmap != null) MainBitmap.Dispose();

            ResetPuzzle();
            MainBitmap = (Bitmap)image.Clone();
            CreatePictureBoxes();
            SetOriginalImageBox();
            AddImages();

            GalleryBox.Visible = false;
            btnShuffle.Enabled = true;
            btnPause.Enabled = true;
        }

        private void ResetPuzzle()
        {
            tmrTimeElapse.Stop();
            elapsedSeconds = 0;
            lblTimeElapsed.Text = "00:00:00";

            moves = 0;
            lblMovesMade.Text = "Moves Made: 0";

            winPositions = string.Empty;
            label1.Text = "";

            currentPositions = string.Empty;
            label2.Text = "";

            PlacePictureBoxesToForm();
        }


        #region Event from Form

        private void OnPicClick(object? sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            PictureBox emptyBox = pictureBoxList.Find(x => x.Tag == "0");

            Point pic1 = new Point(pictureBox.Location.X, pictureBox.Location.Y);
            Point pic2 = new Point(emptyBox.Location.X, emptyBox.Location.Y);

            var index1 = PuzzleBox.Controls.IndexOf(pictureBox);
            var index2 = PuzzleBox.Controls.IndexOf(emptyBox);

            if (pictureBox.Right == emptyBox.Left && pictureBox.Location.Y == emptyBox.Location.Y
                || pictureBox.Left == emptyBox.Right && pictureBox.Location.Y == emptyBox.Location.Y
                || pictureBox.Top == emptyBox.Bottom && pictureBox.Location.X == emptyBox.Location.X
                || pictureBox.Bottom == emptyBox.Top && pictureBox.Location.X == emptyBox.Location.X)
            {
                pictureBox.Location = pic2;
                emptyBox.Location = pic1;


                PuzzleBox.Controls.SetChildIndex(pictureBox, index2);
                PuzzleBox.Controls.SetChildIndex(emptyBox, index1);

                lblMovesMade.Text = "Moves Made: " + (++moves);

                if (lblTimeElapsed.Text == "00:00:00")
                {
                    tmrTimeElapse.Start();
                }
            }

            label2.Text = "";
            currentLocations.Clear();

            //Check is win move
            if (CheckGame())
            {
                tmrTimeElapse.Stop();
                MessageBox.Show("Congratulations...\nYour Win\nTime Elapsed : " + elapsedSeconds + " s.\nTotal Moves Made : " + moves, "Puzzle");
                GalleryBox.Visible = true;

                pictureBoxList.ForEach(p => p.Enabled = false);
                btnShuffle.Enabled = false;
                btnPause.Enabled = false;
            }
        }

        private void OpenFileEvent(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.Filter = "Image Files Only | *.jpg; *.jpeg; *.gif; *.png";

                if (open.ShowDialog() == DialogResult.OK) LoadImageFromGalleryOrPc(new Bitmap(open.FileName));
            }
        }

        private void UpdateTimeElapsedEvent(object sender, EventArgs e)
        {
            if (tmrTimeElapse.Interval.ToString() != "00:00:00")
            {
                elapsedSeconds++;
                TimeSpan time = TimeSpan.FromSeconds(elapsedSeconds);
                lblTimeElapsed.Text = time.ToString("hh':'mm':'ss");
            }

            if (lblTimeElapsed.Text == "01:00:00")
            {
                tmrTimeElapse.Stop();
                MessageBox.Show("Time is Up\nTry Again", "Puzzle");
                ResetPuzzle();
            }

        }

        private void GalleryOpenCloseClickEvent(object sender, EventArgs e)
        {
            if (GalleryBox.Visible == false) GalleryBox.Visible = true;
            else GalleryBox.Visible = false;
        }   

        #region Btn Click Event
        private void btnQuitClick(object sender, EventArgs e)
        {
            AskPermissionBeforeQuite(sender, e as FormClosingEventArgs);
        }

        private void btnPauseOrResumeClick(object sender, EventArgs e)
        {
            if (lblTimeElapsed.Text != "00:00:00")
            {
                if (btnPause.Text == "Pause")
                {
                    tmrTimeElapse.Stop();
                    PuzzleBox.Controls.Clear();
                    btnPause.Text = "Resume";
                }
                else
                {
                    tmrTimeElapse.Start();
                    PuzzleBox.Controls.AddRange(pictureBoxList.ToArray());
                    btnPause.Text = "Pause";
                }
            }
        }

        private void btnShuffleClick(object sender, EventArgs e)
        {
            DialogResult YesOrNo = new DialogResult();
            if (lblTimeElapsed.Text != "00:00:00")
            {
                YesOrNo = MessageBox.Show("Are You Sure To Restart ?", "Puzzle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (YesOrNo == DialogResult.Yes || lblTimeElapsed.Text == "00:00:00")
            {
                ResetPuzzle();
            }
        }

        #endregion

        private void AskPermissionBeforeQuite(object sender, FormClosingEventArgs e)
        {
            DialogResult YesOrNO = MessageBox.Show(this, "Are You Sure To Quit ?", "Puzzle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sender as Button != btnQuit && YesOrNO == DialogResult.No) e.Cancel = true;
            if (sender as Button == btnQuit && YesOrNO == DialogResult.Yes) Environment.Exit(0);

        }


        #region Gallery Image Click Event
        private void pictureBox1_Click(object sender, EventArgs e) => LoadImageFromGalleryOrPc(imageFromGallery[0]);

        private void pictureBox2_Click(object sender, EventArgs e) => LoadImageFromGalleryOrPc(imageFromGallery[1]);

        private void pictureBox3_Click(object sender, EventArgs e) => LoadImageFromGalleryOrPc(imageFromGallery[2]);

        private void pictureBox4_Click(object sender, EventArgs e) => LoadImageFromGalleryOrPc(imageFromGallery[3]);

        private void pictureBox5_Click(object sender, EventArgs e) => LoadImageFromGalleryOrPc(imageFromGallery[4]);

        private void pictureBox6_Click(object sender, EventArgs e) => LoadImageFromGalleryOrPc(imageFromGallery[5]);

        private void pictureBox7_Click(object sender, EventArgs e) => LoadImageFromGalleryOrPc(imageFromGallery[6]);

        #endregion

        #endregion

    }
}
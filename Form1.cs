namespace Image_Slider_Puzzle
{
    public partial class Form1 : Form
    {
        List<PictureBox> pictureBoxList = new List<PictureBox>();
        List<Bitmap> images = new List<Bitmap>();
        List<string> locations = new List<string>();
        List<string> currentLocations = new List<string>();

        string winPositions;
        string currentPositions;

        Bitmap MainBitmap;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFileEvent(object sender, EventArgs e)
        {
            if (pictureBoxList != null)
            {
                foreach (PictureBox pics in pictureBoxList)
                {
                    this.Controls.Remove(pics);
                }

                pictureBoxList.Clear();
                images.Clear();
                locations.Clear();
                currentLocations.Clear();
                winPositions = string.Empty;
                currentPositions = string.Empty;
                label2.Text = string.Empty;
            }

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files Only | *.jpg; *.jpeg; *.gif; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                MainBitmap = new Bitmap(open.FileName);
                CreatePictureBoxes();
                AddImages();
            }
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

        private void OnPicClick(object? sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            PictureBox emptyBox = pictureBoxList.Find(x => x.Tag == "0");

            Point pic1 = new Point(pictureBox.Location.X, pictureBox.Location.Y);
            Point pic2 = new Point(emptyBox.Location.X, emptyBox.Location.Y);

            //var index1 = this.Controls.IndexOf(pictureBox);
            //var index2 = this.Controls.IndexOf(emptyBox);

            var index1 = PuzzelBox.Controls.IndexOf(pictureBox);
            var index2 = PuzzelBox.Controls.IndexOf(emptyBox);

            if (pictureBox.Right == emptyBox.Left && pictureBox.Location.Y == emptyBox.Location.Y
                || pictureBox.Left == emptyBox.Right && pictureBox.Location.Y == emptyBox.Location.Y
                || pictureBox.Top == emptyBox.Bottom && pictureBox.Location.X == emptyBox.Location.X
                || pictureBox.Bottom == emptyBox.Top && pictureBox.Location.X == emptyBox.Location.X)
            {
                pictureBox.Location = pic2;
                emptyBox.Location = pic1;

                //this.Controls.SetChildIndex(pictureBox, index2);
                //this.Controls.SetChildIndex(emptyBox, index1);

                PuzzelBox.Controls.SetChildIndex(pictureBox, index2);
                PuzzelBox.Controls.SetChildIndex(emptyBox, index1);
            }

            label2.Text = "";
            currentLocations.Clear();
            CheckGame();
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
                pictureBoxList[i].BackgroundImage = (Image)images[i];
            }

            PlacePictureBoxesToForm();
        }

        private void PlacePictureBoxesToForm()
        {
            var shuffleImages = pictureBoxList.OrderBy(a => Guid.NewGuid()).ToList();
            pictureBoxList = shuffleImages;

            int x = PuzzelBox.Location.X - 5;//200;
            int y = PuzzelBox.Location.Y - 25;//25;

            for (int i = 0; i < pictureBoxList.Count; i++)
            {
                pictureBoxList[i].BackColor = Color.Black;

                if (i == 3 || i == 6)
                {
                    y += 130;
                    x = PuzzelBox.Location.X - 5; //200;
                }

                pictureBoxList[i].BorderStyle = BorderStyle.FixedSingle;
                pictureBoxList[i].Location = new Point(x, y);

                //this.Controls.Add(pictureBoxList[i]);
                PuzzelBox.Controls.Add(pictureBoxList[i]);
                x += 130;
                winPositions += locations[i];
            }
        }

        private void CheckGame()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox) currentLocations.Add(x.Tag.ToString());
            }

            currentPositions = string.Join("", currentLocations);
            label1.Text = winPositions;
            label2.Text = currentPositions;

            if (winPositions == currentPositions) label2.Text = "Matched!!!";
        }
    }
}
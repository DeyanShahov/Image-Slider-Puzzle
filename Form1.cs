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
            throw new NotImplementedException();
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

        }

        private void CheckGame()
        {

        }
    }
}
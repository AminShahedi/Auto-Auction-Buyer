
using ImageFormat = System.Drawing.Imaging.ImageFormat;
using Tesseract;
using System.Runtime.InteropServices;
using WindowsInput;
using System.Configuration;
using System.Speech.Synthesis;

namespace AHAB
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint cInputs, INPUT input, int size);
        const UInt32 WM_KEYDOWN = 0x0100;
        const int VK_1 = 0x31;
        const int MYACTION_HOTKEY_ID = 1;
        const int MYACTION_HOTKEY_ID_2 = 2;
        Boolean isRunning = false;
        readonly int REFRESH_X = 810;
        readonly int REFRESH_Y = 180;
        readonly int BUY_X = 430;
        readonly int BUY_Y = 460;
        readonly int BUY_NOW_X = 400;
        readonly int BUY_NOW_Y = 329;
        readonly int FIR_AH_ITEM_X = 690;
        readonly int FIR_AH_ITEM_Y = 217;
        readonly int ITEM_X = 1330;
        readonly int ITEM_Y = 655;
        int noBaitCounter = 0;
        readonly int BaitItemCount_X_Y = 280;
        readonly int EMPY_SPACE_X_Y = 350;
        SpeechSynthesizer tts;
        int LogIncludedWindow = 436;
        int LogExcludedWindow = 262;
        int totalpurchased = 0;
        int newbait = 0;
        DateTime lasttime;
        double totalSeconds;
        bool firstTimeRunning = true;
        TesseractEngine engine;
        int IGNORE_BTN_X = 720;
        int IGNORE_BTN_Y = 220;
        int IgnoreCounter = 0;
        public Form1()
        {
            InitializeComponent();
            engine = new TesseractEngine(FullAddress("tessdata"), "eng", EngineMode.Default);

            tts = new SpeechSynthesizer();
            tts.Volume = 100;
            tts.Rate = -3;

            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, 2, (int)Keys.F12);
            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID_2, 2, (int)Keys.F11);

            // Last Gold Price
            if (ConfigurationManager.AppSettings["priceg"] != null)
                goldTextBox.Text = ConfigurationManager.AppSettings["priceg"];

            // Last Silver Price
            if (ConfigurationManager.AppSettings["prices"] != null)
                silverTextBox.Text = ConfigurationManager.AppSettings["prices"];

            if (ConfigurationManager.AppSettings["delay"] != null)
                maskedTextBox2.Text = ConfigurationManager.AppSettings["delay"];

            // How many 
            if (ConfigurationManager.AppSettings["baitcounter"] != null)
                numericUpDown1.Value = Decimal.Parse(ConfigurationManager.AppSettings["baitcounter"]);

            // Minimum item to Buy, most of the times it's 1
            if (ConfigurationManager.AppSettings["minb"] != null)
                numericUpDown2.Value = Decimal.Parse(ConfigurationManager.AppSettings["minb"]);


            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - 530, workingArea.Bottom - Size.Height + 50);

            numericUpDown1.Enabled = checkBox1.Checked;
            richTextBox1.AppendText("Log : ");
            richTextBox1.HideSelection = false;
            this.TopLevel = true;
            this.TopMost = true;
        }

        private void textbox1_textChange(object sender, EventArgs e)
        {
            SetSetting("priceg", goldTextBox.Text);
        }
        private void silver_textChange(object sender, EventArgs e)
        {
            SetSetting("prices", silverTextBox.Text);
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            SetSetting("baitcounter", numericUpDown1.Value.ToString());
        }
        public static void SetSetting(string key, string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            var entry = config.AppSettings.Settings[key];
            if (entry == null)
                config.AppSettings.Settings.Add(key, value);
            else
                config.AppSettings.Settings[key].Value = value;

            config.Save(ConfigurationSaveMode.Modified);
        }

        String FullAddress(String name)
        {
            return Path.GetFullPath(Directory.GetCurrentDirectory() + @"\files\" + name);

        }
        void log(String s)
        {
            richTextBox1.Invoke((MethodInvoker)delegate
            {
                var time = DateTime.Now.ToString("h:mm:ss") + " - ";
                richTextBox1.AppendText("\n" + time + s);
            });

        }
        void Check()
        {
            while (isRunning)
            {
                IgnoreCounter++;

                if (!firstTimeRunning)
                {
                    label9.Invoke((MethodInvoker)delegate
                    {
                        TimeSpan duration = DateTime.Now.Subtract(lasttime);
                        totalSeconds = totalSeconds + duration.TotalMilliseconds;
                        int elapsedmin = TimeSpan.FromMilliseconds(totalSeconds).Minutes;
                        label9.Text = elapsedmin + "m " + TimeSpan.FromMilliseconds(totalSeconds).Seconds + "s";
                        lasttime = DateTime.Now;

                        int goldSpend = (totalpurchased - newbait) * Int32.Parse(goldTextBox.Text);
                        if (goldSpend < 0)
                            goldSpend = 0;

                        int goldWhenSold = totalpurchased * 25;
                        int sud = goldWhenSold - goldSpend;

                        double gpm = sud / (TimeSpan.FromMilliseconds(totalSeconds).TotalSeconds / 60);
                        label11.Text = sud.ToString("N0");
                        label10.Text = "GPM : " + (int)gpm;

                    });
                }
                else
                {
                    lasttime = DateTime.Now;
                    firstTimeRunning = false;
                }

                if (IgnoreCounter > 20)
                {
                    ClickSomePoint(IGNORE_BTN_X, IGNORE_BTN_Y, false);
                    Thread.Sleep(50);
                    ClickSomePoint(IGNORE_BTN_X, IGNORE_BTN_Y, true);
                    IgnoreCounter = 0;
                }

                ClickSomePoint(REFRESH_X, REFRESH_Y, false);
                Thread.Sleep(50);
                ClickSomePoint(REFRESH_X, REFRESH_Y, true);
                int delay = Int32.Parse(maskedTextBox2.Text);
                Thread.Sleep(delay / 2);
                takeSS();
                String Price = GetText(FullAddress("test.jpg"));
                String Quanity = GetText(FullAddress("testq.jpg"));
                int priceint = 9999999;
                int maxPrice = 0;
                int quanityInt = 0;
                try
                {
                    priceint = Int32.Parse(Price);

                    var silverrr = silverTextBox.Text;
                    if (silverTextBox.Text.Length < 2)
                        silverrr = "0" + silverTextBox.Text;

                    var priceString = goldTextBox.Text + silverrr + "00";

                    maxPrice = Int32.Parse(priceString);
                    quanityInt = Int32.Parse(Quanity) - 9;
                }
                catch (Exception ex)
                {
                    tts.SpeakAsync("Check addon or bag");
                    log("ERR / Maybe Bag or Addon");

                    Thread.Sleep(2000);
                }

                log(quanityInt + "_" + Price + "_" + (maxPrice >= priceint));

                if (!isRunning)
                    break;


                if (maxPrice >= priceint && quanityInt > numericUpDown2.Value)
                {
                    ClickSomePoint(FIR_AH_ITEM_X, FIR_AH_ITEM_Y, false);
                    Thread.Sleep(100);
                    ClickSomePoint(FIR_AH_ITEM_X, FIR_AH_ITEM_Y, true);
                    Thread.Sleep(100);

                    ClickSomePoint(BUY_X, BUY_Y, false);
                    Thread.Sleep(100);
                    ClickSomePoint(BUY_X, BUY_Y, true);

                    Thread.Sleep(100);
                    if (!isRunning)
                        break;

                    ClickSomePoint(BUY_NOW_X, BUY_NOW_Y, false);
                    Thread.Sleep(50);
                    ClickSomePoint(BUY_NOW_X, BUY_NOW_Y, true);
                    Thread.Sleep(50);
                    ClickSomePoint(BUY_NOW_X, BUY_NOW_Y, true);
                    Thread.Sleep(50);
                    ClickSomePoint(BUY_NOW_X, BUY_NOW_Y, true);
                    Thread.Sleep(50);
                    ClickSomePoint(BUY_NOW_X, BUY_NOW_Y, true);
                    Thread.Sleep(50);
                    ClickSomePoint(BUY_NOW_X, BUY_NOW_Y, true);
                    Thread.Sleep(50);
                    ClickSomePoint(BUY_NOW_X, BUY_NOW_Y, true);
                    Thread.Sleep(50);
                    ClickSomePoint(BUY_NOW_X, BUY_NOW_Y, true);
                    Thread.Sleep(50);
                    ClickSomePoint(BUY_NOW_X, BUY_NOW_Y, true);
                    Thread.Sleep(50);
                    ClickSomePoint(BUY_NOW_X, BUY_NOW_Y, true);
                    Thread.Sleep(50);
                    ClickSomePoint(BUY_NOW_X, BUY_NOW_Y, true);
                    Thread.Sleep(50);
                    ClickSomePoint(BUY_NOW_X, BUY_NOW_Y, true);
                    int lastgekauft = quanityInt - 1;
                    log(lastgekauft + " items were purchased");

                    totalpurchased += lastgekauft;
                    label6.Invoke((MethodInvoker)delegate
                    {
                        label6.Text = "Purchased : " + totalpurchased;
                    });

                    tts.SpeakAsync(lastgekauft + " items were purchased");
                    Thread.Sleep(500);
                }

                if (!isRunning)
                    break;

                if (priceint > maxPrice && checkBox1.Checked)
                {
                    if (noBaitCounter == 0)
                    {
                        log("Bait not found");

                        string fileName = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\files\coin.wav");
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(fileName);
                        player.Play();
                    }
                    if (noBaitCounter >= numericUpDown1.Value)
                    {
                        noBaitCounter = 0;
                        log("Renewing the bait");
                        newbait += 1;
                        label7.Invoke((MethodInvoker)delegate
                        {
                            label7.Text = "Bait renewed : " + newbait;
                            numericUpDown2.Value = 1;
                        });
                        InputSimulator inputSimulator = new InputSimulator();

                        Thread.Sleep(200);

                        RightClickSomePoint(ITEM_X, ITEM_Y, false);
                        Thread.Sleep(200);
                        RightClickSomePoint(ITEM_X, ITEM_Y, true);
                        Thread.Sleep(500);
                        ClickSomePoint(BaitItemCount_X_Y, BaitItemCount_X_Y, false);
                        Thread.Sleep(200);
                        ClickSomePoint(BaitItemCount_X_Y, BaitItemCount_X_Y, true);
                        Thread.Sleep(300);
                        inputSimulator.Keyboard.TextEntry("1");
                        Thread.Sleep(300);
                        ClickSomePoint(221, 325, false);
                        Thread.Sleep(100);
                        ClickSomePoint(221, 325, true);

                        String priceG = goldTextBox.Text;
                        String priceS = silverTextBox.Text;

                        inputSimulator.Keyboard.TextEntry(priceG);
                        Thread.Sleep(300);
                        Thread.Sleep(300);
                        ClickSomePoint(280, 325, false);
                        Thread.Sleep(200);
                        ClickSomePoint(280, 325, true);
                        inputSimulator.Keyboard.TextEntry(priceS);
                        Thread.Sleep(300);

                        if (!isRunning)
                            break;

                        ClickSomePoint(210, 500, false);
                        Thread.Sleep(200);
                        ClickSomePoint(210, 500, true);
                        Thread.Sleep(1000);

                        ClickSomePoint(90, 640, false);
                        Thread.Sleep(200);
                        ClickSomePoint(90, 640, true);
                        Thread.Sleep(500);

                        if (!isRunning)
                            break;

                        ClickSomePoint(420, 200, false);
                        Thread.Sleep(200);
                        ClickSomePoint(420, 200, true);
                        Thread.Sleep(500);

                    }
                    else
                    {
                        Thread.Sleep(500);
                        noBaitCounter++;
                        Decimal x = (Decimal)noBaitCounter / numericUpDown1.Value;

                        label3.Invoke((MethodInvoker)delegate
                        {
                            label3.Text = "Counter : " + noBaitCounter + "/" + numericUpDown1.Value;
                        });



                        log("bait counter " + noBaitCounter + "/" + numericUpDown1.Value);

                    }
                }
                else
                {
                    if (noBaitCounter > 0)
                        log("bait counter reset");

                    noBaitCounter = 0;

                }
                Thread.Sleep(delay / 2);
            }
        }



        //Take Screenshot and Crop Price Areas
        //Sample Screen shot located in files folder
        void takeSS()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                bitmap.Save(FullAddress("ScreenShot.jpg"), ImageFormat.Jpeg);
                bitmap.Dispose();

                Rectangle cropRect = new(880, 315, 140, 50); //Price
                Rectangle cropRectQuanity = new Rectangle(910, 260, 85, 50);


                Bitmap bb = new(FullAddress("ScreenShot.jpg"));

                Bitmap cloned = bb.Clone(cropRect, bb.PixelFormat);

                // ApplyContrast(100, cloned);
                cloned = new(cloned, new Size(cloned.Width * 2, cloned.Height * 2));
                cloned.Save(FullAddress("test.jpg"), ImageFormat.Jpeg); //Price


                cloned = bb.Clone(cropRectQuanity, bb.PixelFormat);
                cloned = new(cloned, new Size(cloned.Width * 2, cloned.Height * 2));

                ApplyContrast(100, cloned);
                cloned.Save(FullAddress("testq.jpg"), ImageFormat.Jpeg); //Quanity
                bb.Dispose();
            }
        }

        //Read and get price from image
        public string GetText(String imgsource)
        {
            var ocrtext = string.Empty;

            using (var img = Pix.LoadFromMemory(File.ReadAllBytes(imgsource)))
            {
                using (var page = engine.Process(img))
                {
                    ocrtext = page.GetText();
                }
            }

            //Some Corrections
            return ocrtext.Replace(" ", "").Replace("\n", "").Replace("O", "0");
        }

        //Apply Contrast to avoid reading errors
        private unsafe void ApplyContrast(double contrast, Bitmap bmp)
        {
            byte[] contrast_lookup = new byte[256];
            double newValue = 0;
            double c = (100.0 + contrast) / 100.0;

            c *= c;

            for (int i = 0; i < 256; i++)
            {
                newValue = (double)i;
                newValue /= 255.0;
                newValue -= 0.5;
                newValue *= c;
                newValue += 0.5;
                newValue *= 255;

                if (newValue < 0)
                    newValue = 0;
                if (newValue > 255)
                    newValue = 255;
                contrast_lookup[i] = (byte)newValue;
            }

            var bitmapdata = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            int PixelSize = 4;

            for (int y = 0; y < bitmapdata.Height; y++)
            {
                byte* destPixels = (byte*)bitmapdata.Scan0 + (y * bitmapdata.Stride);
                for (int x = 0; x < bitmapdata.Width; x++)
                {
                    destPixels[x * PixelSize] = contrast_lookup[destPixels[x * PixelSize]]; // B
                    destPixels[x * PixelSize + 1] = contrast_lookup[destPixels[x * PixelSize + 1]]; // G
                    destPixels[x * PixelSize + 2] = contrast_lookup[destPixels[x * PixelSize + 2]]; // R
                                                                                                    //destPixels[x * PixelSize + 3] = contrast_lookup[destPixels[x * PixelSize + 3]]; //A
                }
            }
            bmp.UnlockBits(bitmapdata);
        }

        public static void ClickSomePoint(int x, int y, bool click)
        {
            // Set the cursor position
            Cursor.Position = new Point(x, y);
            if (click)
            {
                DoClickMouse(0x2); // Button down
                DoClickMouse(0x4); // Button up
            }

        }
        public static void RightClickSomePoint(int x, int y, bool click)
        {
            Cursor.Position = new Point(x, y);

            if (click)
            {
                DoClickMouse(0x08);
                DoClickMouse(0x10);
            }

        }

        static void DoClickMouse(int mouseButton)
        {
            var input = new INPUT()
            {
                dwType = 0,
                mi = new MOUSEINPUT() { dwFlags = mouseButton }
            };

            if (SendInput(1, input, Marshal.SizeOf(input)) == 0)
            {
                throw new Exception();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = checkBox1.Checked;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Log:";
        }

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            SetSetting("delay", maskedTextBox2.Text);

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            SetSetting("minb", numericUpDown2.Value.ToString());

        }

        private void groupBox5_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(groupBox5, "Minimum item to buy (for using the baits of the other players)");
        }

        private void groupBoxDelay_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(groupBox2, "Time between each refresh");
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            readonly int dx;
            readonly int dy;
            readonly int mouseData;
            public int dwFlags;
            readonly int time;
            readonly IntPtr dwExtraInfo;
        }
        struct INPUT
        {
            public uint dwType;
            public MOUSEINPUT mi;
        }




    }
}
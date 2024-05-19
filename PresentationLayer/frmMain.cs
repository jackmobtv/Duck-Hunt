using System.Reflection;
using System.Resources;
using LogicLayer;
using DataDomain;
using System.Media;


namespace PresentationLayer
{
    public partial class frmMain : Form
    {
        // initializing class-level variables
        private readonly ResourceManager _rm = new ResourceManager(
            "PresentationLayer.Properties.Resources", Assembly.GetExecutingAssembly());
        private bool PlaySounds = true;
        private SoundPlayer shot;
        private SoundPlayer fall;
        private SoundPlayer laugh;
        private bool Miss = true;
        private String anim1;
        private String anim2;
        private bool d1Hit = false;
        private bool d2Hit = false;
        private int duck1H;
        private int duck2H;
        private int duck1V;
        private int duck2V;
        private bool fall1 = false;
        private bool fall2 = false;
        private int score = 0;

        public frmMain()
        {
            InitializeComponent();
        }
        // resets the screen and has the dog laugh if no ducks are hit
        private async void Reset()
        {
            if (Miss)
            {
                duck1.Top = 325;
                duck2.Top = 325;
                if (PlaySounds)
                {
                    laugh.Play();
                }
                for (int i = 0; i < 25; i++)
                {
                    await Task.Delay(30);
                    dog.Top -= 5;
                }
                await Task.Delay(500);
                for (int i = 0; i < 25; i++)
                {
                    await Task.Delay(30);
                    dog.Top += 5;
                }
            }
            while (true)
            {
                await Task.Delay(30);
                if (!fall1 && !fall2)
                {
                    break;
                }
            }
            duck1.Top = 325;
            duck2.Top = 325;
            if (score >= int.MaxValue - 1)
            {
                Win();
            }
            DuckMove();
        }
        // moves the ducks
        private async void DuckMove()
        {
            d1Hit = false;
            d2Hit = false;
            int last = 1;
            int num = 1;
            Miss = true;
            duck1.Left = AssetMovement.StartDuckPos();
            duck2.Left = AssetMovement.StartDuckPos();
            for (int o = 0; o < 3; o++)
            {
                if (!d1Hit)
                {
                    duck1H = AssetMovement.GetNewHDirection();
                    duck1V = AssetMovement.GetNewVDirection();
                    anim1 = AssetMovement.GetAnimationDuck(duck1H, duck1V);
                    duck1.Image = (Image)_rm.GetObject(anim1 + "1");
                }
                if (!d2Hit)
                {
                    duck2H = AssetMovement.GetNewHDirection();
                    duck2V = AssetMovement.GetNewVDirection();
                    anim2 = AssetMovement.GetAnimationDuck(duck2H, duck2V);
                    duck2.Image = (Image)_rm.GetObject(anim2 + "1");
                }


                for (int i = 0; i < 36; i++)
                {
                    await Task.Delay(30);
                    if (!d1Hit)
                    {
                        duck1.Left += duck1H;
                        duck1.Top -= duck1V;
                    }
                    if (!d2Hit)
                    {
                        duck2.Left += duck2H;
                        duck2.Top -= duck2V;
                    }

                    if ((i % 3) == 0)
                    {
                        if (num == 1)
                        {
                            last = 1;
                            num++;
                        }
                        else if (num == 3)
                        {
                            last = 3;
                            num--;
                        }
                        else
                        {
                            if (last == 1)
                            {
                                num++;
                            }
                            else
                            {
                                num--;
                            }
                        }

                    }
                    if (!d1Hit)
                    {
                        duck1.Image = (Image)_rm.GetObject(anim1 + num);
                    }
                    if (!d2Hit)
                    {
                        duck2.Image = (Image)_rm.GetObject(anim2 + num);
                    }


                }
            }
            Reset();
        }


        // checks the sound files and throws an exception
        // that disables the sound effects in the program
        // if the files are not found
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                string shotFile = AppData.DataPath + "sounds/shot.wav";
                string fallFile = AppData.DataPath + "sounds/fall.wav";
                string laughFile = AppData.DataPath + "sounds/laugh.wav";

                if (File.Exists(shotFile) && File.Exists(fallFile) && File.Exists(laughFile))
                {
                    shot = new SoundPlayer(shotFile);
                    fall = new SoundPlayer(fallFile);
                    laugh = new SoundPlayer(laughFile);
                }
                else
                {
                    throw new Exception("One or more sound files not found.");
                }
            }
            catch (Exception)
            {
                PlaySounds = false;
                MessageBox.Show("One or more sound files not found\n\nSounds will not be played", "Missing Files", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            DuckMove();
        }
        // checks if the duck hasn't already been hit
        // and then increments score
        // and sets the duck to fall mode
        private async void Hit(int duck)
        {
            Miss = false;
            if (duck == 1)
            {
                if (!d1Hit)
                {
                    score++;
                    scoreDisplay.Text = "Score: " + score;
                    fall1 = true;
                    d1Hit = true;
                    if (PlaySounds)
                    {
                        shot.Play();
                    }
                    duck1.Image = (Image)_rm.GetObject("shot");
                    await Task.Delay(300);
                    Falling(1);
                }
            }
            else if (duck == 2)
            {
                if (!d2Hit)
                {
                    if (score != int.MaxValue)
                    {
                        score++;
                    }
                    else
                    {
                        Win();
                    }
                    scoreDisplay.Text = "Score: " + score;
                    fall2 = true;
                    d2Hit = true;
                    if (PlaySounds)
                    {
                        shot.Play();
                    }
                    duck2.Image = (Image)_rm.GetObject("shot");
                    await Task.Delay(300);
                    duck2.Image = (Image)_rm.GetObject("ffall");
                    Falling(2);
                }
            }
        }
        // makes the ducks fall
        private async void Falling(int duck)
        {
            if (duck == 1)
            {
                duck1.Image = (Image)_rm.GetObject("ffall");
                if (PlaySounds)
                {
                    fall.Play();
                }
                for (int f = 0; f < 100; f++)
                {
                    await Task.Delay(30);
                    duck1.Top += 4;
                }
                fall1 = false;
            }
            else if (duck == 2)
            {
                duck2.Image = (Image)_rm.GetObject("ffall");
                if (PlaySounds)
                {
                    fall.Play();
                }
                for (int f = 0; f < 100; f++)
                {
                    await Task.Delay(30);
                    duck2.Top += 4;
                }
                fall2 = false;
            }
        }

        private void Win()
        {
            MessageBox.Show("YOU WIN!!!", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            Application.Exit();
        }

        // triggers Hit() when the ducks are clicked on
        private void duck1_Click(object sender, EventArgs e)
        {
            Hit(1);
        }

        private void duck2_Click(object sender, EventArgs e)
        {
            Hit(2);
        }
    }
}
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
        private Duck _duck1 = new Duck();
        private Duck _duck2 = new Duck();
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
                if (!_duck1.Fall && !_duck2.Fall)
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
            _duck1.Hit = false;
            _duck2.Hit = false;
            int last = 1;
            int num = 1;
            Miss = true;
            duck1.Left = AssetMovement.StartDuckPos();
            duck2.Left = AssetMovement.StartDuckPos();
            for (int o = 0; o < 3; o++)
            {
                if (!_duck1.Hit)
                {
                    _duck1.dirX = AssetMovement.GetNewHDirection();
                    _duck1.dirY = AssetMovement.GetNewVDirection();
                    _duck1.Animation = AssetMovement.GetAnimationDuck(_duck1.dirX, _duck1.dirY);
                    duck1.Image = (Image)_rm.GetObject(_duck1.Animation + "1");
                }
                if (!_duck2.Hit)
                {
                    _duck2.dirX = AssetMovement.GetNewHDirection();
                    _duck2.dirY = AssetMovement.GetNewVDirection();
                    _duck2.Animation = AssetMovement.GetAnimationDuck(_duck2.dirX, _duck2.dirY);
                    duck2.Image = (Image)_rm.GetObject(_duck2.Animation + "1");
                }


                for (int i = 0; i < 36; i++)
                {
                    await Task.Delay(30);
                    if (!_duck1.Hit)
                    {
                        duck1.Left += _duck1.dirX;
                        duck1.Top -= _duck1.dirY;
                    }
                    if (!_duck2.Hit)
                    {
                        duck2.Left += _duck2.dirX;
                        duck2.Top -= _duck2.dirY;
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
                    if (!_duck1.Hit)
                    {
                        duck1.Image = (Image)_rm.GetObject(_duck1.Animation + num);
                    }
                    if (!_duck2.Hit)
                    {
                        duck2.Image = (Image)_rm.GetObject(_duck2.Animation + num);
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
                if (!_duck1.Hit)
                {
                    score++;
                    scoreDisplay.Text = "Score: " + score;
                    _duck1.Fall = true;
                    _duck1.Hit = true;
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
                if (!_duck2.Hit)
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
                    _duck2.Fall = true;
                    _duck2.Hit = true;
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
                _duck1.Fall = false;
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
                _duck2.Fall = false;
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
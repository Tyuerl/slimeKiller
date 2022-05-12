using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
namespace mygame
{
    
    public partial class Form1 : Form
    {
        const int Width = 800;
        const int Height = 430;
        private Graphics _nameGame;
        private bool game_is_start = false;
        private System.Media.SoundPlayer bgmusic = new System.Media.SoundPlayer("../../Resources/bgmus.wav");
        private Player _human;
        private List<Mob> enemys = new List<Mob>();
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 100;
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //BUTTON StartGame
           //MessageBox.Show("You die");
            panel1.BackgroundImage = null;
            label1.Visible = false;
            game_is_start = true;
            InitGame();
            

        }

        public void InitGame()
        {
            //таймстарт:d
            timer1.Start();

            // create main hero
            _human = new Player(300, 300, 1, 100, 100, 15, 10, 90);

            //init mowement
            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);

            // create enemys
            Random position_enemy = new Random(); 
            enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            
            // sound
            bgmusic.PlayLooping(); 
            // init map;

            

        }

        private void OnPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    _human.Lver = -4;
                    break;
                case Keys.S:
                    _human.Lver = 4;
                    break;
                case Keys.A:
                    _human.Lhor = -4;
                    break;
                case Keys.D:
                    _human.Lhor = 4;
                    break;
            }
            _human.IsMoving = true;

        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            _human.stopMove();
            _human.IsMoving = false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //bgmusic.PlayLooping();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_human.IsMoving)
                _human.Move();
            panel1.Invalidate();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Paint_onMainPanel(object sender, PaintEventArgs e)
        {

            _nameGame = e.Graphics;
            if (_human != null)
                _human.AnimationPaint(e.Graphics);
           // if (enemys != null)
             //   foreach (var temp in enemys)
               //  temp.AnimationPaint(e.Graphics);
            if (game_is_start == false)
            {
                _nameGame.DrawImage(Properties.Resources.Alt_Durt, 150, 70, 500, 80);
            }


        }
    }

}

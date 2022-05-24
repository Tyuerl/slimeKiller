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
using System.IO;

namespace mygame
{
    
    public partial class Form1 : Form
    {
        const int Width = 800;
        static int timespwan = 0;
        const int Height = 430;
        private bool game_is_start = false;
        private System.Media.SoundPlayer bgmusic = new System.Media.SoundPlayer("../../Resources/bgmus.wav");
        private Player _human;
        private List<Mob> enemys = new List<Mob>();
        private Graphics graph;
        Random position_enemy = new Random();
        private int Points = 0;
        private bool t = true;
        string infstring;
        private Dictionary<string, int> result = new Dictionary<string, int>();
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 100;
            timer1.Tick += new EventHandler(timer1_Tick);

            label2.Visible = false;
            label3.Visible = false;
            textBox1.Visible = false;
            tableLayoutPanel1.Visible = false;

            // для резов 
            StreamReader alltext = new StreamReader("./../../result.txt");
            string allstring = alltext.ReadToEnd();
            string temp;
            for (int i = 0; i < allstring.Length; i++)
            {
                string a = "";
                while (i < allstring.Length && allstring[i] != ' ')
                {
                    a += allstring[i];
                    i++;
                }
                i++;
                temp = a;
                a = "";
                while (i < allstring.Length && allstring[i] != '\n')
                {
                    a += allstring[i];
                    i++;
                }
                result.Add(temp, int.Parse(a));
            }
            alltext.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //BUTTON StartGame
            BackgroundImage = Properties.Resources.space_bg2;
            label1.Visible = false;
            game_is_start = true;
            InitGame();

        }

        public void InitGame()
        {
            //таймстарт:d

            timer1.Start();

            // create main hero
            if (_human == null)
                _human = new Player(300, 300, 1, 100, 100, 15, 10, 62);
            else
                _human.Hp = 100;
            _human.Animation = 1;
            t = true;

            //init mowement
            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);

            // create enemys

            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            enemys.Add(new Mob(300, 200));
            enemys.Add(new Mob(500, 200));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            //enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));


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
                case Keys.E:
                    _human.Atack(enemys, 0); // 0 - animation only
                    _human.stopMove();
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
            timespwan++;
            if (timespwan % 50 == 0 || 
                (timespwan > 600  && timespwan % 30 == 0) || 
                (timespwan > 1200 && timespwan % 15 == 0) ||
                (timespwan > 1800 && timespwan % 5 == 0))
            {
                enemys.Add(new Mob(position_enemy.Next(360, 740), (position_enemy.Next(0, 240))));
            }
            int i = 0;
            if (_human.IsMoving)
                _human.Move();
            if (enemys.Remove(enemys.Find(x => x.Animation == 13)))
            {
                if (timespwan < 600)
                    Points += 10;
                else if (timespwan < 1200)
                    Points += 20;
                else
                    Points += 40;
            }
            foreach (var qur in enemys)
            {
                if (i % 2 == 0)
                    qur.Brain(_human.Posx, _human.Posy, enemys, _human);
                else
                    qur.Brain2(_human.Posx, _human.Posy, enemys, _human);
                i++;

            }
            if (Math.Abs(_human.Animation) > 4 && Math.Abs(_human.Animation) < 9)
            {
                _human.Atack(enemys, 1); // 1 - hit enemy
            }
            Invalidate();
            if (_human.Hp < 0)
                game_is_start = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                                                                                                        
        }

        private void Paint_onMainPanel(object sender, PaintEventArgs e)
        { 
            graph = e.Graphics;
            if (game_is_start == true)
            {
                _human.AnimationPaint(graph);
                foreach (var temp in enemys)
                    temp.AnimationPaint(graph);
                graph.DrawString(Points.ToString(), new Font("Arial", 32), new SolidBrush(Color.Red), 200, 0);

            }
            else
            {
                graph.DrawImage(Properties.Resources.Alt_Durt, 150, 70, 500, 80);
                if (_human != null && _human.Hp < 0 && t)
                {
                    t = false;
                    MessageBox.Show("You die");
                    GameOver();
                    int i = 0;
                    foreach (var t in result)
                    {
                        string a = (t.Key + " " + t.Value);
                        //graph.DrawString(a, new Font("Arial", 13), new SolidBrush(Color.White), 500, 100 + 10 * i);
                        i++;
                    }
                }
            }
        }
        public void GameOver()
        {
            timespwan = 0;
            timer1.Stop();
            StreamReader alltext = new StreamReader("./../../result.txt");
            infstring = alltext.ReadToEnd();
            int LastPoint = int.MaxValue;
            int count = 0;

            for (int i = 0; i < infstring.Length && count < 10; i++)
            {
                
                if (infstring[i] == ' ' && count < 10)
                {
                    int j = i;
                    string a = "";
                    while (infstring[++j] != '\n')
                        a += infstring[j];
                    if (LastPoint > int.Parse(a))
                        LastPoint = int.Parse(a);
                    count++;
                }
               

            }
            alltext.Close();
            if (Points > LastPoint)
            {
                MessageBox.Show("Вы набрали отличный результат, запишите его в таблицу результатов:");
                label2.Visible = true;
                label3.Visible = true;
                textBox1.Visible = true;
             //   tableLayoutPanel1.Visible = true;
                BackgroundImage = Properties.Resources.bg4;
               //... tableLayoutPanel1[i]

            }
            else
            {
                label1.Visible = true;
                BackgroundImage = Properties.Resources.space_bg2;
                enemys.RemoveAll(x => x.IsAlive == true);
                Points = 0;
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            SortResult();
            label2.Visible = false;
            label3.Visible = false;
            textBox1.Visible = false;
            label1.Visible = true;
            enemys.RemoveAll(x => x.IsAlive == true);
            Points = 0;
        }

        private void SortResult()
        {


            result.Add(textBox1.Text, Points);
            result.OrderByDescending(x => x.Key);
            StreamWriter fwrite = new StreamWriter("./../../result.txt");
            foreach (var t in result.OrderByDescending(x => x.Value))
                fwrite.WriteLine(t.Key + " " + t.Value);
            fwrite.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace mygame
{
    public class Mob
    {
        protected int _posX;
        protected int _posY;
        protected int _animation;
        protected int _healt;
        protected int _mana;
        protected int _atack;
        protected int _atcDist;
        protected int _size;
        protected int _lhor;
        protected int _lver;
        protected bool _isMoving;
        protected int _side;
        protected List<Image> _framesAtack = new List<Image>();
        protected List<Image> _framesMove = new List<Image>();
        protected List<Image> _framesIdle = new List<Image>();
        protected List<Image> _framesHurt = new List<Image>();
        protected List<Image> _framesDie = new List<Image>();
        private short _countToAtck;
        private bool _isAlive;



        public Mob()
        {
            _posX = 0;
            _posY = 0;
            _animation = 1;
            _side = 1;
            _healt = 35;
            _mana = 100;
            _atack = 1; ;
            _atcDist = 3;
            _size = 64;
            _lhor = 0;
            _lver = 0;
            _isMoving = false;
            _countToAtck = 0;
            _isAlive = true;
        }


        public Mob(int posx, int posy)
        {
            _posX = posx;
            _posY = posy;
            _animation = 1;
            _healt = 35;
            _side = 1;
            _mana = 100;
            _atack = 10; ;
            _atcDist = 3;
            _size = 64;
            _lhor = 0;
            _lver = 0;
            _isMoving = false;
            _countToAtck = 0;
            _isAlive = true;
        }
        public Mob(int posx, int posy, int anim, int hp, int mana, int atc, int atcDist, int size)
        {
            _posX = posx;
            _posY = posy;
            _animation = anim;
            _healt = hp;
            _side = 1;
            _mana = mana;
            _atack = atc;
            _atcDist = atcDist;
            _size = size;
            _lhor = 0;
            _lver = 0;
            _isMoving = false;
            _countToAtck = 0;
            _isAlive = true;
        }

        public int Animation
        {
            get => _animation;
            set => _animation = value;
        }

        public bool IsAlive
        {
            get => _isAlive;
            set => _isAlive = value;
        }

        public short CountAtck
        { 
            get => _countToAtck;
            set => _countToAtck = value; 
        }

        public void Hit(int n)
        {
            _healt -= n;
            if (_healt < 0)
            {
                _isAlive = false;
                _animation = 10;
            }
        }

        public virtual void Move(int hor, int vert)
        {
            if (_isAlive == true)
            {
                _posX += hor;
                _posY += vert;
            }
        }
        public int Posx 
        {get => _posX;}
        public int Posy
        { get => _posY; }

        public bool AtackOnHero(int heroX, int heroY, Player ahad)
        {
            if (((heroX < _posX && heroX + _size - 20> _posX) || (heroX > _posX) && (heroX < _posX + _size + 20))
                && (Math.Abs(_posY - heroY) < 30))
            {
                if (_countToAtck == 3)
                {
                    if (_animation < 5)
                        _animation = 5;
                    _countToAtck = 1;
                }
                else
                    _countToAtck++;
                if (_animation == 9)
                    ahad.Hit(this._atack);
                return (true);
            }
            if (_animation > 4)
                _animation = 1;
            return (false);
        }
        public void Brain(int heroX, int heroY, List<Mob> allmobs, Player ahad)
        {
            if (IsAlive == false)
                return;
            if (AtackOnHero(heroX, heroY, ahad))
                return;
            if ((_posY < heroY) && !allmobs.Exists(x => (x._posY > _posY) && (x._posY < _posY + _size - 30) &&
                (Math.Abs(_posX - x.Posx) < 20)))
            {
                Move(0, 2);
            }
            if ((_posY > heroY) && !allmobs.Exists(x => (x._posY < _posY) && (x._posY + _size - 30 > _posY) &&
                 (Math.Abs(_posX - x.Posx) < 20)))
            {
                Move(0, -2);

            }
            if ((_posX > heroX + 62 / 2) && !allmobs.Exists(x => (x._posX < _posX) && (x._posX + _size - 5 > _posX) &&
              (Math.Abs(_posY - x.Posy) < 40)))
            {
                Move(-2, 0);
                _side = 1;
                return;
            }
            if ((_posX < heroX - _size)  && !allmobs.Exists(x => (x._posX > _posX) && (x._posX < _posX + _size) &&
              (Math.Abs(_posY - x.Posy) < 40)))
            { 
                Move(2, 0);
                _side = -1;
                return;
            }
        }

        public void Brain2(int heroX, int heroY, List<Mob> allmobs, Player ahad)
        {
            if (IsAlive == false)
                return;
            if (AtackOnHero(heroX, heroY, ahad))
                return;
            if ((_posX > heroX + 62 / 2) && !allmobs.Exists(x => (x._posX < _posX) && (x._posX + _size - 5 > _posX) &&
            (Math.Abs(_posY - x.Posy) < 40)))
            {
                Move(-2, 0);
                _side = 1;
                return;
            }
            if ((_posX < heroX - _size) && !allmobs.Exists(x => (x._posX > _posX) && (x._posX < _posX + _size) &&
             (Math.Abs(_posY - x.Posy) < 40)))
            {
                Move(2, 0);
                _side = -1;
                return;
            }
            if ((_posY < heroY) && !allmobs.Exists(x => (x._posY > _posY) && (x._posY < _posY + _size - 30) &&
                (Math.Abs(_posX - x.Posx) < _size - 20)))
            {
                Move(0, 2);
                return;
            }
            if ((_posY > heroY) && !allmobs.Exists(x => (x._posY < _posY) && (x._posY + _size - 30 > _posY) &&
                 (Math.Abs(_posX - x.Posx) < _size - 20)))
            {
                Move(0, -2);
                return;
            }
        }


        public void Frames(List<Image> idle, List<Image> move, List<Image> atck,
            List<Image> hurt, List<Image> die)
        {
            if (idle != null)
                foreach (var qur in idle)
                    _framesIdle.Add(qur);
            if (move != null)
                foreach (var qur in move)
                    _framesIdle.Add(qur);
            if (atck != null)
                foreach (var qur in atck)
                    _framesIdle.Add(qur);
            if (hurt != null)
                foreach (var qur in hurt)
                    _framesIdle.Add(qur);
            if (die != null)
                foreach (var qur in die)
                    _framesIdle.Add(qur);
        }

        public virtual void AnimationPaint(Graphics g)
        {
            if (_side == -1)
                switch (_animation)
                {
                    // only idle
                    case 1:
                        g.DrawImage(Properties.Resources.slime_move_0, _posX  + _size, _posY, _size * _side, _size - 14);
                        _animation++;
                        break;
                    case 2:
                        g.DrawImage(Properties.Resources.slime_move_1, _posX + _size,  _posY, _size * _side, _size - 14);
                        _animation++;
                        break;
                    case 3:
                        g.DrawImage(Properties.Resources.slime_move_2, _posX + _size, _posY, _size * _side, _size - 14);
                        _animation++;
                        break;
                    case 4:
                        g.DrawImage(Properties.Resources.slime_move_3, _posX + _size, _posY, _size * _side, _size - 14);
                        _animation = 1;
                        break;
                    case 5:
                        g.DrawImage(Properties.Resources.slime_attack_0, _posX + _size, _posY, _size * _side, _size - 14);
                        _animation++;
                        break;
                    case 6:
                        g.DrawImage(Properties.Resources.slime_attack_1, _posX + _size, _posY, _size * _side, _size - 14);
                        _animation++;
                        break;
                    case 7:
                        g.DrawImage(Properties.Resources.slime_attack_2, _posX + _size, _posY, _size * _side, _size - 14);
                        _animation++;
                        break;
                    case 8:
                        g.DrawImage(Properties.Resources.slime_attack_3, _posX + _size, _posY, _size * _side, _size - 14);
                        _animation++;
                        break;
                    case 9:
                        g.DrawImage(Properties.Resources.slime_attack_4, _posX + _size, _posY, _size * _side, _size - 14);
                        _animation = 5;
                        break;
                    case 10:
                        g.DrawImage(Properties.Resources.slime_die_0, _posX + _size, _posY, _size * _side, _size - 14);
                        _animation = 11;
                        break;
                    case 11:
                        g.DrawImage(Properties.Resources.slime_die_1, _posX + _size, _posY, _size * _side, _size - 14);
                        _animation = 12;
                        break;
                    case 12:
                        g.DrawImage(Properties.Resources.slime_die_2, _posX + _size, _posY, _size * _side, _size - 14);
                        _animation = 13;
                        break;
                    case 13:
                        g.DrawImage(Properties.Resources.slime_die_3, _posX + _size, _posY, _size * _side, _size - 14);
                        _animation = 13;
                        break;
                }
            else
                switch (_animation)
                {
                    // only idle
                    case 1:
                        g.DrawImage(Properties.Resources.slime_move_0, _posX, _posY, _size * _side, _size - 14);
                        _animation++;
                        break;
                    case 2:
                        g.DrawImage(Properties.Resources.slime_move_1, _posX, _posY, _size * _side, _size - 14);
                        _animation++;
                        break;
                    case 3:
                        g.DrawImage(Properties.Resources.slime_move_2, _posX, _posY, _size * _side, _size - 14);
                        _animation++;
                        break;
                    case 4:
                        g.DrawImage(Properties.Resources.slime_move_3, _posX, _posY, _size * _side, _size - 14);
                        _animation = 1;
                        break;
                    case 5:
                        g.DrawImage(Properties.Resources.slime_attack_0, _posX, _posY, _size * _side, _size - 14);
                        _animation++;
                        break;
                    case 6:
                        g.DrawImage(Properties.Resources.slime_attack_1, _posX, _posY, _size * _side, _size - 14);
                        _animation++;
                        break;
                    case 7:
                        g.DrawImage(Properties.Resources.slime_attack_2, _posX, _posY, _size * _side, _size - 14);
                        _animation++;
                        break;
                    case 8:
                        g.DrawImage(Properties.Resources.slime_attack_3, _posX, _posY, _size * _side, _size - 14);
                        _animation++;
                        break;
                    case 9:
                        g.DrawImage(Properties.Resources.slime_attack_4, _posX, _posY, _size * _side, _size - 14);
                        _animation = 5;
                        break;
                    case 10:
                        g.DrawImage(Properties.Resources.slime_die_0, _posX , _posY, _size * _side, _size - 14);
                        _animation = 11;
                        break;
                    case 11:
                        g.DrawImage(Properties.Resources.slime_die_1, _posX , _posY, _size * _side, _size - 14);
                        _animation = 12;
                        break;
                    case 12:
                        g.DrawImage(Properties.Resources.slime_die_2, _posX, _posY, _size * _side, _size - 14);
                        _animation = 13;
                        break;
                    case 13:
                        g.DrawImage(Properties.Resources.slime_die_3, _posX, _posY, _size * _side, _size - 14);
                        _animation = 13;
                        break;
                }
        }
    }
}

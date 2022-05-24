using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mygame
{
    public class Player : Mob
    {
        public Player(int posx, int posy, int anim, int hp, int mana, int atc, int atcDist, int size)
            : base(posx, posy, anim, hp, mana, atc, atcDist, size)
        {
            ;
        }
        public int Hp
        {
            get => _healt;
            set => _healt = value;
        }
        public void stopMove()
        {
            _lhor = 0;
            _lver = 0;
        }
        public void Move()
        {
            _posX += _lhor;
            _posY += _lver;
            if (_lhor < 0 && _animation > 0)
                _animation = -_animation;
            if (_lhor > 0 && _animation < 0)
                _animation = -_animation;
                
        }

        public void Atack(List<Mob> enemys, int t)
        {
            if (t == 0)
            {
                if (_animation > 0)
                    _animation = 5;
                else
                    _animation = -5;
            }
            else
            {
                this.stopMove();
                foreach (var mob in enemys)
                {
                    if ((Math.Abs(Posy - mob.Posy) < 40) && ((mob.Posx > Posx && mob.Posx < Posx + 50 && _animation == 8) ||
                        (mob.Posx < Posx && mob.Posx > Posx - 80 && _animation == -8)))
                        mob.Hit(_atack);
                }
            }
        }

        public int Lhor
        { get => _lhor; set => _lhor = value; }
        public int Lver
        { get => _lver; set => _lver = value; }
        public bool IsMoving
        { get => _isMoving; set => _isMoving = value; }

        public override void AnimationPaint(Graphics g)
        {
            g.DrawLine(new Pen(Color.Red, 80), 0, 0, 2 * _healt, 0);
            switch (_animation)
            {
                // only going + atck
                case 1:
                    g.DrawImage(Properties.Resources.right1, _posX, _posY, _size, _size - 14);
                    _animation++;
                    break;
                case 2:
                    g.DrawImage(Properties.Resources.right2, _posX, _posY, _size, _size - 14);
                    _animation++;
                    break;
                case 3:
                    g.DrawImage(Properties.Resources.right3, _posX, _posY, _size, _size - 14);
                    _animation++;
                    break;
                case 4:
                    g.DrawImage(Properties.Resources.right4, _posX, _posY, _size, _size - 14);
                    _animation =1;
                    break;
                case 5:
                    g.DrawImage(Properties.Resources._2frame, _posX, _posY - 12, _size + 8, _size + 8 - 14);
                    _animation = 6;
                    break;
                case 6:
                    g.DrawImage(Properties.Resources._3frame, _posX, _posY - 12, _size + 8, _size + 8 - 14);
                    _animation = 7;
                    break;
                case 7:
                    g.DrawImage(Properties.Resources._4frame, _posX, _posY - 12, _size + 8, _size + 8 - 14);
                    _animation = 8;
                    break;
                case 8:
                    g.DrawImage(Properties.Resources._5frame, _posX, _posY - 12, _size + 8, _size + 8 - 14);
                    _animation = 1;
                    break;
                case -1:
                    g.DrawImage(Properties.Resources.right1, _posX + _size / 2, _posY, -_size, _size - 14);
                    _animation--;
                    break;
                case -2:
                    g.DrawImage(Properties.Resources.right2, _posX + _size / 2, _posY, -_size, _size - 14);
                    _animation--;
                    break;
                case -3:
                    g.DrawImage(Properties.Resources.right3, _posX + _size / 2, _posY, -_size, _size - 14);
                    _animation--;
                    break;
                case -4:
                    g.DrawImage(Properties.Resources.right4, _posX + _size / 2, _posY,  -_size, _size - 14);
                    _animation = -1;
                    break;
                case -5:
                    g.DrawImage(Properties.Resources._2frame, _posX + _size / 2, _posY - 12, -(_size + 8), _size + 8 - 14);
                    _animation = -6;
                    break;
                case -6:
                    g.DrawImage(Properties.Resources._3frame, _posX + _size / 2, _posY - 12, -(_size + 8), _size + 8 - 14);
                    _animation = -7;
                    break;
                case -7:
                    g.DrawImage(Properties.Resources._4frame, _posX + _size / 2, _posY - 12, -(_size + 8), _size + 8 - 14);
                    _animation = -8;
                    break;
                case -8:
                    g.DrawImage(Properties.Resources._5frame, _posX + _size / 2, _posY - 12, -(_size + 8), _size + 8 - 14);
                    _animation = -1;
                    break;
            }
        }
    }
}

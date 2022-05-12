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

        public void SwitchMove() // можно пихнуть ретурны в каждый, чтобы было быстрее
        {
            if (_animation < 0)
                _animation--;
            if (_animation > 0)
                _animation++;
            if (_isMoving && _animation < -4)
                _animation = -1;
            else if (!_isMoving && _animation < - 2)
                _animation = -1;
            if (_isMoving && _animation > 4)
                _animation = 1;
            else if (!_isMoving && _animation > 2)
                _animation = 1;
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

        public int Lhor
        { get => _lhor; set => _lhor = value; }
        public int Lver
        { get => _lver; set => _lver = value; }
        public bool IsMoving
        { get => _isMoving; set => _isMoving = value; }

        public override void AnimationPaint(Graphics g)
        {
            switch (_animation)
            {
                // only going
                case 1:
                    g.DrawImage(Properties.Resources.right1, _posX, _posY, _size, _size - 12);
                    break;
                case 2:
                    g.DrawImage(Properties.Resources.right2, _posX, _posY, _size, _size - 12);
                    break;
                case 3:
                    g.DrawImage(Properties.Resources.right3, _posX, _posY, _size, _size - 12);
                    break;
                case 4:
                    g.DrawImage(Properties.Resources.right4, _posX, _posY, _size, _size - 12);
                    break;
                case -1:
                    g.DrawImage(Properties.Resources.left1, _posX - 40, _posY, _size, _size - 12);
                    break;
                case -2:
                    g.DrawImage(Properties.Resources.left2, _posX - 40, _posY, _size, _size - 12);
                    break;
                case -3:
                    g.DrawImage(Properties.Resources.left3, _posX - 40, _posY, _size, _size - 12);
                    break;
                case -4:
                    g.DrawImage(Properties.Resources.left4, _posX - 40, _posY,  _size, _size - 12);
                    break;
            }
            SwitchMove();
        }
    }
}

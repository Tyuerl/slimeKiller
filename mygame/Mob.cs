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
        protected List<Image> frames = new List<Image>();



        public Mob()
        {
            _posX = 0;
            _posY = 0;
            _animation = 0;
            _healt = 35;
            _mana = 100;
            _atack = 1; ;
            _atcDist = 3;
            _size = 60;
            _lhor = 0;
            _lver = 0;
            _isMoving = false;
        }


        public Mob(int posx, int posy)
        {
            _posX = posx;
            _posY = posy;
            _animation = 0;
            _healt = 35;
            _mana = 100;
            _atack = 1; ;
            _atcDist = 3;
            _size = 60;
            _lhor = 0;
            _lver = 0;
            _isMoving = false;

        }
        public Mob(int posx, int posy, int anim, int hp, int mana, int atc, int atcDist, int size)
        {
            _posX = posx;
            _posY = posy;
            _animation = anim;
            _healt = hp;
            _mana = mana;
            _atack = atc;
            _atcDist = atcDist;
            _size = size;
            _lhor = 0;
            _lver = 0;
            _isMoving = false;

        }

        public int Animation 
        {
            get => _animation;
            set => _animation = value;
        }

        public void Hit(int n)
        {
            _healt -= n;
        }

        public virtual void Move(int hor, int vert)
        {
            _posX += hor;
            _posY += vert;
        }


        public virtual void AnimationPaint(Graphics g)
        {
            g.DrawImage(Properties.Resources.right1, _posX, _posY, _size, _size);
        }

    }
}

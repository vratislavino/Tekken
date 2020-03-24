using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekken
{
    public class Fighter : ICloneable
    {
        private string name;
        public string Name => name;
        private string imgPath;
        public string ImgPath
        {
            get { return imgPath; }
        }

        private int damage;
        public int Damage => damage;
        private int chanceToDoubleAttack;
        private int health;
        public int Health => health;
        private int critChance;
        private int dodgeChance;

        public string OtherData
        {
            get { return string.Format("({0}/{1}/{2})",chanceToDoubleAttack,critChance,dodgeChance); }
        }

        public Fighter(string n, string i, int d, int h, int ctda, int cc, int dc)
        {
            this.name = n;
            this.imgPath = i;
            this.damage = d;
            this.health = h;
            this.chanceToDoubleAttack = ctda;
            this.critChance = cc;
            this.dodgeChance = dc;
        }

        public object Clone()
        {
            return new Fighter(name, imgPath, damage, health, chanceToDoubleAttack, critChance, dodgeChance);
        }
    }
}

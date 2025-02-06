using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MainClasses
{
    public class Enemy
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int ATK { get; set; }
        public int DEF {  get; set; }
        public int SPD { get; set; }

        public Enemy(string name, int hP, int aTK, int dEF, int sPD)
        {
            Name = name;
            HP = hP;
            ATK = aTK;
            DEF = dEF;
            SPD = sPD;
        }
        public Enemy() { }
    }
    public class Players
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int SPD { get; set; }
        public Players(string name, int hP, int aTK, int dEF, int sPD)
        {
            Name = name;
            HP = hP;
            ATK = aTK;
            DEF = dEF;
            SPD = sPD;
        }
        public Players() { }
    }
    public interface Items
    {

        string Name { get; set; }
        int Status { get; set; }
    }
}


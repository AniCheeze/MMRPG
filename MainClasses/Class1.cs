using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainClasses
{
    public class Enemy
    {
        string Name { get; set; }
        int HP { get; set; }
        int ATK { get; set; }
        int DEF {  get; set; }
        int SPD { get; set; }
        Enemy(string name, int hP, int aTK, int dEF, int sPD)
        {
            Name = name;
            HP = hP;
            ATK = aTK;
            DEF = dEF;
            SPD = sPD;
        }
    }
    public class Players
    {
        string Name { get; set; }
        int HP { get; set; }
        int ATK { get; set; }
        int DEF { get; set; }
        int SPD { get; set; }
        Dictionary<string,double> keyValuePairs { get; set; }
        Players(string name, int hP, int aTK, int dEF, int sPD)
        {
            Name = name;
            HP = hP;
            ATK = aTK;
            DEF = dEF;
            SPD = sPD;
        }
    }
    public interface Items
    {

        string Name { get; set; }
        int Status { get; set; }
    }
}


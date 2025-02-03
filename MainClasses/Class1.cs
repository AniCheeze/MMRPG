using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainClasses
{
    public interface Enemy
    {
        string Name { get; set; }
        int HP { get; set; }
        int ATK { get; set; }
        int DEF {  get; set; }
        int SPD { get; set; }
    }
    public interface Player
    {
        string Name { get; set; }
        int HP { get; set; }
        int ATK { get; set; }
        int DEF { get; set; }
        int SPD { get; set; }
        Dictionary<string,double> keyValuePairs { get; set; }

    }
    public interface Items
    {

        string Name { get; set; }
        int Status { get; set; }
    }
}


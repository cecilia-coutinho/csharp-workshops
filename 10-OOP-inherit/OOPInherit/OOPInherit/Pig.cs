using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOPInherit
{
    public class Pig : Animals
    {
        public Pig(string pigName) : base(pigName)
        {
            this.Legs = 4;
            this.Sounds = "'OINK OINK!'";
            this.EatFood = "cooked broccoli and pitted apricots";
        }
    }
}

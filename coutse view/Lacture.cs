using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Model
{
    public class Lacture
    {
        public string LactureName { get; set; }
        public string VideoUrl { get; set; }

        public override string ToString()
        {


            return LactureName;
        }
    }
}

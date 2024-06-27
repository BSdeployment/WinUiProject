using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Model
{
    public class Sections
    {
        public string SectionName { get; set; }

        public List<Lacture> Lacts { get; set; } = new List<Lacture>();
    }
}

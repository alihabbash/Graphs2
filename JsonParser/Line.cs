using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser
{
    public class Line
    {
        public bool visited { get; set; }
        public String Name { get; set; }
        public Node Begin { get; set; }
        public Node End { get; set; }
        public int Weight { get; set; }
        public Line(String name)
        {
            Name = name;
            visited = false;
            Begin = End = null;
        }
        public Line()
        {
            Name = "";
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}

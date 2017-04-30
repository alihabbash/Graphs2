using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser
{
   public class Graph
    {
       
       public String name;
        public List<Node> nodes;
       public List<Line> lines;
        public Graph()
        {
            nodes = new List<Node>();
            lines = new List<Line>();
            name = "";
        }
        public Graph(String name,List<Node>nodes,List<Line>lines)
        {
            this.name = name;
            this.nodes = nodes;
            this.lines = lines;
        }
       override
        public String ToString()
        {
            return this.name;
        }
    }
}

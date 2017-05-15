using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser
{
    public class GraphOperation
    {
        List<Graph> graphs;
        List<Node> nodes;
        List<Line> lines;
        public GraphOperation(List<Node> nodes, List<Line> lines) 
        {
            this.nodes = nodes;
            this.lines = lines;
        }
        public List<Node> Karp_Sipser()
        {
            List<Node> M = new List<Node>();
            int currentdegree = 1;
            int nodesCount = nodes.Count;
            for (int i = 0; i < nodes.Count; i ++ )
            {
                if (nodes[i].getdegree(lines) == 0)
                    nodes.Remove(nodes[i]);
                if (nodes[i].getdegree(lines) == currentdegree)
                {
                    Node child = new Node();
                    M.Add(nodes[i]);
                    for (int j = 0; j < lines.Count; j++ )
                    {
                        if (lines[j].Begin.ToString() == nodes[i].ToString())
                        {
                            child = lines[j].End;
                            lines.Remove(lines[j]);
                        }
                        else
                            if (lines[j].End.ToString() == nodes[i].ToString())
                            {
                                child = lines[j].Begin;
                                lines.Remove(lines[j]);
                                M.Add(child);
                            }
                    }
                   int Count = lines.Count;
                    for (int k = 0; k < Count; k++)
                    {
                        if (child.ToString() == lines[k].Begin.ToString() || child.ToString() == lines[k].End.ToString())
                        {
                            lines.Remove(lines[k]);
                            k = 0;
                            Count = lines.Count;
                        }
                        currentdegree = 1;
                    }
                }
                else
                {
                   // currentdegree++;
                }
                i = 0;
                nodesCount = nodes.Count;
            }
            return M;
        } 
    }
}

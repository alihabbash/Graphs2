using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace JsonParser
{
    public class Node
    {
        public String Name { get; set; }
        public bool visited { get; set; }
        public Node()
        {
            Name = "";
            visited = false;
        }
        public Node(String name)
        {
            Name = name;
            visited = false;
        }
        public int getdegree(List<Line> lines)
        {
            try
            {
                int degree = 0;
                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].Begin.ToString() == this.ToString())
                        degree++;
                    if (lines[i].End.ToString() == this.ToString())
                        degree++;
                }
                return degree;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        public List<Node> getchilds(List<Line> lines, bool islinevisited)
        {
            try
            {
                List<Node> nodelist = new List<Node>();
                for (int i = 0; i < lines.Count; i++)
                {

                    if (lines[i].Begin == this)
                        if (!nodelist.Contains(lines[i].End))
                            if (!islinevisited)
                            {
                                if (!lines[i].End.visited)
                                    nodelist.Add(lines[i].End);
                            }
                            else
                                if (!lines[i].visited)
                                    nodelist.Add(lines[i].End);
                    if (lines[i].End == this)
                        if (!nodelist.Contains(lines[i].Begin))
                            if (!islinevisited)
                            {
                                if (!lines[i].Begin.visited)
                                    nodelist.Add(lines[i].Begin);
                            }
                            else
                                if (!lines[i].visited)
                                    nodelist.Add(lines[i].Begin);
                }
                if (nodelist.Count == 0)
                    return null;
                return nodelist;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
       
        public override string ToString()
        {
            return this.Name;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Windows;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace JsonParser
{
    public class JsonWriter : ICloneable
    {
        public Graph graph;
        public List<Node> nodes;
        public List<Line> lines;
        public JsonWriter()
        {
            nodes = new List<Node>();
            lines = new List<Line>();
        }
        private int getcountof(String Text, char ch)
        {
            try
            {
                String temp = Text;
                int end = 0, counter = 0;
                while (true)
                {
                    if (temp.Contains(ch))
                    {
                        counter++;
                        end = temp.IndexOf(ch);
                        if (end == -1)
                        {
                            break;
                        }
                        temp = temp.Substring(end + 1, temp.Length - end - 1);
                        end++;
                    }
                    else
                        break;
                }
                return counter;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        private String[] extract(String Text, char ch)
        {
            try
            {
                int counter = getcountof(Text, ch), offest = 0, end = 0;
                String[] temp = new String[counter + 1];
                counter = 0;
                while (true)
                {
                    end = Text.IndexOf(ch, offest);
                    if (end == -1)
                    {
                        temp[counter++] = Text.Substring(offest, Text.Length - offest);
                        break;
                    }
                    temp[counter++] = Text.Substring(offest, end - offest);
                    offest = end + 1;

                }
                return temp;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public void createNew(String Textbox, String RichTextbox)
        {
            try
            {
                String[] temp = extract(Textbox, ',');
                for (int i = 0; i < temp.Length; i++)
                    nodes.Add(new Node(temp[i]));
                int linecount = getcountof(RichTextbox, '\n');
                linecount++;
                String[][] temp1 = new String[linecount][];
                temp = extract(RichTextbox, '\n');
                String[] names = new String[temp.Length];
                String[] Begins = new String[temp.Length];
                String[] ends = new String[temp.Length];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp1[i] = extract(temp[i], ',');
                    lines.Add(new Line());
                }
                for (int i = 0; i < temp1.Length; i++)
                    for (int k = 0; k < temp1[i].Length; k++)
                        if (k % 3 == 0)
                            names[i] = temp1[i][k];
                        else
                            if (k % 3 == 1)
                                Begins[i] = temp1[i][k];
                            else
                                ends[i] = temp1[i][k];
                for (int i = 0; i < lines.Count; i++)
                    lines[i].Name = names[i];
                for (int i = 0; i < lines.Count; i++)
                {
                    for (int j = 0; j < nodes.Count; j++)
                        if (nodes[j].Name.Equals(Begins[i]))
                            lines[i].Begin = nodes[j];
                    for (int j = 0; j < nodes.Count; j++)
                        if (nodes[j].Name.Equals(ends[i]))
                            lines[i].End = nodes[j];
                    graph = new Graph("G1", nodes, lines);
                }
                MessageBox.Show("Added successfully", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void WriteOnJSON(String filepath)
        {
            try
            {
                JavaScriptSerializer sr = new JavaScriptSerializer();
                String outputjson = sr.Serialize(graph);
                File.WriteAllText(filepath, outputjson);
                MessageBox.Show("Saved Successfully in " + filepath, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        //private void WriteOnJSON()
        //{
        //    try
        //    {
        //        using (Newtonsoft.Json.JsonWriter write = new JsonTextWriter(new StreamWriter(filepath)))
        //        {
        //            write.Formatting = Formatting.Indented;
        //            write.WriteStartArray();
        //            foreach (Graph graph in graphs)
        //            {
        //                write.WriteStartObject();
        //                write.WritePropertyName("Name");
        //                write.WriteValue(graph.name);
        //                write.WritePropertyName("Nodes");
        //                write.WriteStartArray();
        //                if(graph.nodes!=null)
        //                {
        //                    foreach (Node node in nodes)
        //                    {
        //                        write.WriteStartObject();
        //                        write.WritePropertyName("Name");
        //                        write.WriteValue(node.Name);
        //                        write.WritePropertyName("Visited");
        //                        write.WriteValue(node.visited);
        //                        write.WriteEndObject();
        //                    }
        //                }
        //                write.WriteEndArray();
        //                write.WritePropertyName("Lines");
        //                write.WriteStartArray();
        //                if (graph.lines != null)
        //                {
        //                    foreach (Line line in lines)
        //                    {
        //                        write.WriteStartObject();
        //                        write.WritePropertyName("Name");
        //                        write.WriteValue(line.Name);
        //                        write.WritePropertyName("Visited");
        //                        write.WriteValue(line.visited);
        //                        write.WritePropertyName("Begin");
        //                        write.WriteValue(line.Begin.Name);
        //                        write.WritePropertyName("End");
        //                        write.WriteValue(line.End.Name);
        //                        write.WritePropertyName("weight");
        //                        write.WriteValue(line.Weight);
        //                        write.WriteEndObject();
        //                    }
        //                }
        //                write.WriteEndObject();
        //            }
        //            write.WriteEndArray();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public object Clone()
        {
            List<Node> nodes = new List<Node>();
            List<Line> lines = new List<Line>();
            nodes.AddRange(this.nodes);
            lines.AddRange(this.lines);
            Graph graph = new Graph("G1", nodes, lines);
            return graph;

        }
    }
}

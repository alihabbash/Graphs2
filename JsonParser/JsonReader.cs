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
    public class JsonReader
    {
        List<Graph> graphs;
        String filepath;
        List<Line> lines;
        List<Node> nodes;
        public JsonReader(String filepath)
        {
            this.filepath = filepath;
            lines = new List<Line>();
            nodes = new List<Node>();
            graphs = new List<Graph>();
        }
        public void ReadFromJson()
        {
            try
            {
                String json = File.ReadAllText(filepath);
                JavaScriptSerializer sz = new JavaScriptSerializer();
                List<Graph> Gs = sz.Deserialize<List<Graph>>(json);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

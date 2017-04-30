using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Windows;
using System.IO;
using Newtonsoft.Json;
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
                using (StreamReader sw = new StreamReader(filepath))
                {
                    String json = sw.ReadToEnd();
                    graphs = JsonConvert.DeserializeObject<List<Graph>>(json);
                    //using (Newtonsoft.Json.JsonReader reader = new JsonTextReader(new StreamReader(filepath)))
                    //{
                    //    while (reader.Read())
                    //    {

                    //    }
                    //}
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

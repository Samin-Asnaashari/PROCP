using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulator
{
    public class WorkspaceDesign
    {
        public string Grid { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public List<Crossing> allcreatedcrossings;

        public WorkspaceDesign(string grid,string name, DateTime time)
        {
            this.Grid = grid;
            this.Name=name;
            this.Time = time;
            allcreatedcrossings = new List<Crossing>();
        }

    }
}

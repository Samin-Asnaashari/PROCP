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
    class WorkspaceDesign
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }

        public Size size = new Size(1, 1);
        public Dictionary<Point, Crossing> Crossings { get; set; }
        public Size draw_offset { get; set; }

        private String extension = ".bin";

        public WorkspaceDesign(string name, DateTime time/*,Size s, Size offset*/)
        {
            this.Name=name;
            this.Time = time;
        }

        public void setSize(Size s)
        {
            if (s == null) throw new NullReferenceException("size for the sketch is null");
            this.size = s;
        }
        public void setOffset(Size offset)
        {
            this.draw_offset = offset;
        }


        public void AddCrossing(Crossing c)
        {
            this.Crossings.Add(c.Position, c);
        }

        public void resizeAllImages(Size new_size)
        {
            if (new_size == null) throw new NullReferenceException("Scale to set is null");
            Console.WriteLine(new_size);

            foreach (Crossing item in this.Crossings.Values)
            {
                item.resizeImage(new_size);
            }
        }

        public void Load(Stream steam)
        {
            IFormatter formatter = new BinaryFormatter();
            WorkspaceDesign deserialized = (WorkspaceDesign)formatter.Deserialize(steam);

            this.size = deserialized.size;
            this.Name= deserialized.Name;
            this.Crossings = deserialized.Crossings;
        }

        public void Save()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(this.Name + this.extension, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Close();
        }

        public void SaveAs(Stream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
        }


    }
}

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
    [Serializable]
    public class WorkspaceDesign
    {
        public string Grid { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public List<Crossing> allcreatedcrossings;

        public WorkspaceDesign(string grid, string name, DateTime time)
        {
            this.Grid = grid;
            this.Name = name;
            this.Time = time;
            this.allcreatedcrossings = new List<Crossing>();
        }

        //study this 
        /// <summary>
        /// load a simulation deasign 
        /// </summary>
        /// <param name="steam"></param>
        public void Load(Stream steam)
        {
            IFormatter formatter = new BinaryFormatter();
            WorkspaceDesign deserialized = (WorkspaceDesign)formatter.Deserialize(steam);

            this.Name = deserialized.Name;
            this.Grid = deserialized.Grid;
            this.Time = deserialized.Time;
            this.allcreatedcrossings = deserialized.allcreatedcrossings;
        }

        //study this 
        /// <summary>
        /// save the design  
        /// </summary>
        public void Save()
        {
            //IFormatter formatter = new BinaryFormatter();
            //Stream stream = new FileStream(this.Name+".bin", FileMode.Create, FileAccess.Write, FileShare.None);
            //formatter.Serialize(stream, this);
            //stream.Close();

            FileStream fs = null;
            BinaryFormatter bf;
            try
            {
                fs = new FileStream(this.Name + ".bin", FileMode.Create, FileAccess.Write);
                bf = new BinaryFormatter();

                bf.Serialize(fs, this);
            }
            catch (IOException ioex)
            {
                throw new IOException(ioex.Message);
            }
            finally
            { if (fs != null) fs.Close(); }
        }


        //study this
        /// <summary>
        /// save as a design 
        /// </summary>
        /// <param name="stream"></param>
        public void SaveAs(Stream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
        }


        public bool CheckIfIsValidToSetUpSimulator()
        {
            int count = 0;

            for (int i = 0; i < allcreatedcrossings.Count; i++)
            {
                for (int j = 1; j < allcreatedcrossings.Count; j++)
                {
                    if (
                        ((allcreatedcrossings[i].StartPoint.Y - allcreatedcrossings[i].Size) == allcreatedcrossings[j].StartPoint.Y)
                        &&
                        (allcreatedcrossings[i].StartPoint.X == allcreatedcrossings[j].StartPoint.X)

                        ||
                        ((allcreatedcrossings[i].StartPoint.X + allcreatedcrossings[i].Size) == allcreatedcrossings[j].StartPoint.X)
                        &&
                        (allcreatedcrossings[i].StartPoint.Y == allcreatedcrossings[j].StartPoint.Y)

                        ||
                        ((allcreatedcrossings[i].StartPoint.X - allcreatedcrossings[i].Size) == allcreatedcrossings[j].StartPoint.X)
                        &&
                        (allcreatedcrossings[i].StartPoint.Y == allcreatedcrossings[j].StartPoint.Y)

                        ||
                        ((allcreatedcrossings[i].StartPoint.Y + allcreatedcrossings[i].Size) == allcreatedcrossings[j].StartPoint.Y)
                        &&
                        (allcreatedcrossings[i].StartPoint.X == allcreatedcrossings[j].StartPoint.X)
                      )
                    {
                        count++;
                        break;
                    }
                }
            }
            if (count == allcreatedcrossings.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

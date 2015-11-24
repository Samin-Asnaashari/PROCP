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
<<<<<<< HEAD
        [Serializable]
=======
>>>>>>> refs/remotes/origin/Samin
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

<<<<<<< HEAD
        //study this 
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
        public void SaveAs(Stream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
        }


=======
>>>>>>> refs/remotes/origin/Samin
    }
}

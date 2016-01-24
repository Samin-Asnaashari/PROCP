using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficSimulator
{
    [Serializable]
    public class WorkspaceDesign
    {
        private string savedFile;
        public string Grid { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public List<Crossing> allcreatedcrossings;

        public List<Lane> Lanes;
        public List<Lane> EnterancesLanes;


        public WorkspaceDesign(string grid, string name, DateTime time)
        {
            this.Grid = grid;
            this.Name = name;
            this.Time = time;
            this.allcreatedcrossings = new List<Crossing>();
        }

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

        /// <summary>
        /// save the design  
        /// </summary>
        public bool Save(Controller controler)
        {
            Stream saveStream = null;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = savedFile;
            if ((saveStream = saveFileDialog.OpenFile()) != null)
            {
                IFormatter formater = new BinaryFormatter();
                formater.Serialize(saveStream, controler);
                saveStream.Close();
                return true;
            }
            else
                return false;
        }


        /// <summary>
        /// save as a design 
        /// </summary>
        /// <param name="stream"></param>
        public bool SaveAs(Controller controler)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.FileName = "Simulation1";
            dialog.Filter = "SimulatorExtension files (*.simex)|*.simex";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                BinaryFormatter bf = null;

                fs = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write);
                bf = new BinaryFormatter();
                this.savedFile = dialog.FileName;
                bf.Serialize(fs, controler);
                fs.Close();
                return true;

            }
            return false;

        }


        public bool CheckIfIsValidToSetUpSimulator() //needs to be fix 
        {
            this.allcreatedcrossings.Sort();
            if (allcreatedcrossings.Count == 1)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < allcreatedcrossings.Count -1; i++)
                {
                    if (!(
                        ((allcreatedcrossings[i].StartPoint.Y - allcreatedcrossings[i].Size) == allcreatedcrossings[i + 1].StartPoint.Y)
                        &&
                        (allcreatedcrossings[i].StartPoint.X == allcreatedcrossings[i + 1].StartPoint.X)

                        ||
                        ((allcreatedcrossings[i].StartPoint.X + allcreatedcrossings[i].Size) == allcreatedcrossings[i + 1].StartPoint.X)
                        &&
                        (allcreatedcrossings[i].StartPoint.Y == allcreatedcrossings[i + 1].StartPoint.Y)

                        ||
                        ((allcreatedcrossings[i].StartPoint.X - allcreatedcrossings[i].Size) == allcreatedcrossings[i + 1].StartPoint.X)
                        &&
                        (allcreatedcrossings[i].StartPoint.Y == allcreatedcrossings[i + 1].StartPoint.Y)

                        ||
                        ((allcreatedcrossings[i].StartPoint.Y + allcreatedcrossings[i].Size) == allcreatedcrossings[i + 1].StartPoint.Y)
                        &&
                        (allcreatedcrossings[i].StartPoint.X == allcreatedcrossings[i + 1].StartPoint.X)
                      ))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //needs to be fixed 
        public List<Lane> SetUpLanes(List<Crossing> All/*, out List<LaneWithOneDirection> T1,out List<LaneWithTwoDirection> T2,out List<EmptyLane> Empty*/)
        {
            All.Sort();
            List<Lane> L = new List<Lane>();
            int crossCounter = 0;
            foreach (var item in allcreatedcrossings)
            {
                if (item.CType == 1)
                {
                    item.Lanes.Add(new LaneWithOneDirection((crossCounter * 12) + 1, new Point(item.StartPoint.X + ((Int32) (0.4 * item.Size)), item.StartPoint.Y), 
                        new Point(item.StartPoint.X + ((Int32)(0.4*item.Size)),item.StartPoint.Y + ((Int32)(0.3 * item.Size))),Direction.south, (crossCounter * 12) + 12, 0));
                    item.Lanes.Add(new LaneWithTwoDirection((crossCounter * 12) + 2, new Point(item.StartPoint.X + ((Int32)(0.5 * (item.Size))), item.StartPoint.Y),
                        new Point(item.StartPoint.X + ((Int32)(0.5 * item.Size)), item.StartPoint.Y + ((Int32)(0.3 * item.Size))),Direction.south, (crossCounter * 12) + 6, (crossCounter * 12) + 9));
                    item.Lanes.Add(new EmptyLane((crossCounter * 12) + 3, new Point(item.StartPoint.X + ((Int32)(0.6 * item.Size)), item.StartPoint.Y + ((Int32)(0.3 * item.Size))),
                       new Point(item.StartPoint.X + ((Int32)(0.6 * item.Size)), item.StartPoint.Y),Direction.north, 0, 0));

                    item.Lanes.Add(new LaneWithOneDirection((crossCounter * 12) + 4, new Point(item.StartPoint.X + item.Size, item.StartPoint.Y + ((Int32)(0.4 * item.Size))),
                        new Point(item.StartPoint.X + ((Int32)(0.7 * item.Size)), item.StartPoint.Y + ((Int32)(0.4 * item.Size))),Direction.west, (crossCounter * 12) + 3, 0));
                    item.Lanes.Add(new LaneWithTwoDirection((crossCounter * 12) + 5, new Point(item.StartPoint.X + item.Size, item.StartPoint.Y + ((Int32)(0.5 * item.Size))),
                        new Point(item.StartPoint.X + ((Int32)(0.7 * item.Size)), item.StartPoint.Y + ((Int32)(0.5 * item.Size))),Direction.west, (crossCounter * 12) + 9, (crossCounter * 12) + 12));
                    item.Lanes.Add(new EmptyLane((crossCounter * 12) + 6, new Point(item.StartPoint.X + ((Int32)(0.7 * item.Size)), item.StartPoint.Y + ((Int32)(0.6 * item.Size))),
                       new Point(item.StartPoint.X +item.Size, item.StartPoint.Y + ((Int32)(0.6 * item.Size))),Direction.east, 0, 0));

                    item.Lanes.Add(new LaneWithOneDirection((crossCounter * 12) + 7, new Point(item.StartPoint.X + ((Int32)(0.6 * (item.Size))), item.StartPoint.Y + item.Size),
                       new Point(item.StartPoint.X + ((Int32)(0.6 * item.Size)), item.StartPoint.Y + ((Int32)(0.7 * item.Size))),Direction.north, (crossCounter * 12) + 6, 0));
                    item.Lanes.Add(new LaneWithTwoDirection((crossCounter * 12) + 8, new Point(item.StartPoint.X + ((Int32)(0.5 * item.Size)), item.StartPoint.Y + item.Size),
                        new Point(item.StartPoint.X + ((Int32)(0.5 * item.Size)), item.StartPoint.Y + ((Int32)(0.7 * item.Size))),Direction.north, (crossCounter * 12) + 12, (crossCounter * 12) + 3));
                    item.Lanes.Add(new EmptyLane((crossCounter * 12) + 9, new Point(item.StartPoint.X + ((Int32)(0.4 * item.Size)), item.StartPoint.Y + ((Int32)(0.7 * item.Size))),
                       new Point(item.StartPoint.X + ((Int32)(0.4* item.Size)), item.StartPoint.Y + item.Size),Direction.south, 0, 0));

                    item.Lanes.Add(new LaneWithOneDirection((crossCounter * 12) + 10, new Point(item.StartPoint.X, item.StartPoint.Y + ((Int32)(0.6 * item.Size))),
                      new Point(item.StartPoint.X + ((Int32)(0.3 * item.Size)), item.StartPoint.Y + ((Int32)(0.6 * item.Size))),Direction.east, (crossCounter * 12) + 9, 0));
                    item.Lanes.Add(new LaneWithTwoDirection((crossCounter * 12) + 11, new Point(item.StartPoint.X, item.StartPoint.Y + ((Int32)(0.5 * item.Size))),
                        new Point(item.StartPoint.X + ((Int32)(0.3 * item.Size)), item.StartPoint.Y + ((Int32)(0.5 * item.Size))),Direction.east, (crossCounter * 12) + 3, (crossCounter * 12) + 6));
                    item.Lanes.Add(new EmptyLane((crossCounter * 12) + 12, new Point(item.StartPoint.X + ((Int32)(0.3 * item.Size)), item.StartPoint.Y + ((Int32)(0.4 * item.Size))),
                       new Point(item.StartPoint.X, item.StartPoint.Y + ((Int32)(0.4 * item.Size))),Direction.west, 0, 0));
                }
                else if (item.CType == 2)
                {
                    item.Lanes.Add(new LaneWithTwoDirection(1, new Point(item.StartPoint.X + ((Int32)(0.45 * item.Size)), item.StartPoint.Y),
                        new Point(item.StartPoint.X + ((Int32)(0.45 * item.Size)), item.StartPoint.Y + ((Int32)(0.3 * item.Size))), Direction.south, 7, 10));
                    item.Lanes.Add(new EmptyLane(2, new Point(item.StartPoint.X + ((Int32)(0.55 * item.Size)), item.StartPoint.Y + ((Int32)(0.3 * item.Size))),
                        new Point(item.StartPoint.X + ((Int32)(0.55 * item.Size)), item.StartPoint.Y), Direction.north, 0, 0));

                    item.Lanes.Add(new LaneWithTwoDirection(3, new Point(item.StartPoint.X + item.Size, item.StartPoint.Y + ((Int32)(0.4 * item.Size))),
                        new Point(item.StartPoint.X + ((Int32)(0.7 * item.Size)), item.StartPoint.Y + ((Int32)(0.4 * item.Size))), Direction.west, 2, 10));
                    item.Lanes.Add(new LaneWithOneDirection(4, new Point(item.StartPoint.X + item.Size, item.StartPoint.Y + ((Int32)(0.5 * item.Size))),
                        new Point(item.StartPoint.X + ((Int32)(0.7 * item.Size)), item.StartPoint.Y + ((Int32)(0.5 * item.Size))), Direction.west, 7, 0));
                    item.Lanes.Add(new EmptyLane(5, new Point(item.StartPoint.X + ((Int32)(0.7 * item.Size)), item.StartPoint.Y + ((Int32)(0.6 * item.Size))),
                        new Point(item.StartPoint.X + item.Size, item.StartPoint.Y + ((Int32)(0.6 * item.Size))), Direction.east, 0, 0));

                    item.Lanes.Add(new LaneWithTwoDirection(6, new Point(item.StartPoint.X + ((Int32)(0.55 * item.Size)), item.StartPoint.Y + item.Size),
                        new Point(item.StartPoint.X + ((Int32)(0.55 * item.Size)), item.StartPoint.Y + ((Int32)(0.7 * item.Size))), Direction.north, 2, 5));
                    item.Lanes.Add(new EmptyLane(7, new Point(item.StartPoint.X + ((Int32)(0.45 * item.Size)), item.StartPoint.Y + ((Int32)(0.3 * item.Size))),
                        new Point(item.StartPoint.X + ((Int32)(0.45 * item.Size)), item.StartPoint.Y), Direction.south, 0, 0));

                    item.Lanes.Add(new LaneWithTwoDirection(8, new Point(item.StartPoint.X, item.StartPoint.Y + ((Int32)(0.6 * item.Size))),
                        new Point(item.StartPoint.X + ((Int32)(0.3 * item.Size)), item.StartPoint.Y + ((Int32)(0.6 * item.Size))), Direction.east, 5, 7));
                    item.Lanes.Add(new LaneWithOneDirection(9, new Point(item.StartPoint.X, item.StartPoint.Y + ((Int32)(0.5 * item.Size))),
                        new Point(item.StartPoint.X + ((Int32)(0.3 * item.Size)), item.StartPoint.Y + ((Int32)(0.5 * item.Size))), Direction.east, 2, 0));
                    item.Lanes.Add(new EmptyLane(10, new Point(item.StartPoint.X + ((Int32)(0.3 * item.Size)), item.StartPoint.Y + ((Int32)(0.4 * item.Size))),
                        new Point(item.StartPoint.X, item.StartPoint.Y + ((Int32)(0.4 * item.Size))), Direction.north, 0, 0));
                }

                //crossCounter++;
            }
            //L.Sort();
            return L;
        }
    }
}

﻿using System;
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
        private static Random randomLaneChooser = new Random();

        public List<Lane> EnterancesLanes;
        //public List<Lane> Lanes;

        public WorkspaceDesign(string grid, string name, DateTime time)
        {
            this.Grid = grid;
            this.Name = name;
            this.Time = time;
            this.allcreatedcrossings = new List<Crossing>();

            EnterancesLanes = new List<Lane>();
            //Lanes = new List<Lane>();
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
            //this.allcreatedcrossings.Sort();
            if (allcreatedcrossings.Count == 1)
            {
                return true;
            }
            else
            {
                foreach (var citem in allcreatedcrossings)
                {
                    int count = 0;
                    foreach (var litem in citem.Lanes)
                    {
                        if (litem.NextCrossingLaneNeighbor != null)
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        return false;
                    }
                    else return true;
                }
                return true;//??
            }
                //    for (int i = 0; i < allcreatedcrossings.Count -1; i++)
                //    {
                //        if (!(
                //            ((allcreatedcrossings[i].StartPoint.Y - allcreatedcrossings[i].Size) == allcreatedcrossings[i + 1].StartPoint.Y)
                //            &&
                //            (allcreatedcrossings[i].StartPoint.X == allcreatedcrossings[i + 1].StartPoint.X)

                //            ||
                //            ((allcreatedcrossings[i].StartPoint.X + allcreatedcrossings[i].Size) == allcreatedcrossings[i + 1].StartPoint.X)
                //            &&
                //            (allcreatedcrossings[i].StartPoint.Y == allcreatedcrossings[i + 1].StartPoint.Y)

                //            ||
                //            ((allcreatedcrossings[i].StartPoint.X - allcreatedcrossings[i].Size) == allcreatedcrossings[i + 1].StartPoint.X)
                //            &&
                //            (allcreatedcrossings[i].StartPoint.Y == allcreatedcrossings[i + 1].StartPoint.Y)

                //            ||
                //            ((allcreatedcrossings[i].StartPoint.Y + allcreatedcrossings[i].Size) == allcreatedcrossings[i + 1].StartPoint.Y)
                //            &&
                //            (allcreatedcrossings[i].StartPoint.X == allcreatedcrossings[i + 1].StartPoint.X)
                //          ))
                //        {
                //            return false;
                //        }
                //    }
                
                //return true;
        }

        //needs to be fixed 
        public void SetUpLanes(List<Crossing> All/*, out List<LaneWithOneDirection> T1,out List<LaneWithTwoDirection> T2,out List<EmptyLane> Empty*/)
        {
            //All.Sort();
            //List<Lane> L = new List<Lane>();
            //int crossCounter = 0;

            foreach (var item in allcreatedcrossings)
            {
                if (item.CType == 1)
                {
                    item.Lanes.Add(new LaneWithOneDirection(1, new Point(item.StartPoint.X + ((Int32) (0.36 * item.Size)), item.StartPoint.Y), 
                        new Point(item.StartPoint.X + ((Int32)(0.36*item.Size)),item.StartPoint.Y + ((Int32)(0.3 * item.Size))),Direction.south, 12, 0));
                    item.Lanes.Add(new LaneWithTwoDirection(2, new Point(item.StartPoint.X + ((Int32)(0.47 * (item.Size))), item.StartPoint.Y),
                        new Point(item.StartPoint.X + ((Int32)(0.47 * item.Size)), item.StartPoint.Y + ((Int32)(0.3 * item.Size))),Direction.south, 6, 9));
                    item.Lanes.Add(new EmptyLane(3, new Point(item.StartPoint.X + ((Int32)(0.59 * item.Size)), item.StartPoint.Y + ((Int32)(0.3 * item.Size))),
                       new Point(item.StartPoint.X + ((Int32)(0.59 * item.Size)), item.StartPoint.Y),Direction.north, 0, 0));

                    item.Lanes.Add(new LaneWithOneDirection(4, new Point(item.StartPoint.X + item.Size, item.StartPoint.Y + ((Int32)(0.37 * item.Size))),
                        new Point(item.StartPoint.X + ((Int32)(0.7 * item.Size)), item.StartPoint.Y + ((Int32)(0.37 * item.Size))),Direction.west, 3, 0));
                    item.Lanes.Add(new LaneWithTwoDirection(5, new Point(item.StartPoint.X + item.Size, item.StartPoint.Y + ((Int32)(0.48 * item.Size))),
                        new Point(item.StartPoint.X + ((Int32)(0.7 * item.Size)), item.StartPoint.Y + ((Int32)(0.48 * item.Size))),Direction.west, 9, 12));
                    item.Lanes.Add(new EmptyLane(6, new Point(item.StartPoint.X + ((Int32)(0.7 * item.Size)), item.StartPoint.Y + ((Int32)(0.57 * item.Size))),
                       new Point(item.StartPoint.X +item.Size, item.StartPoint.Y + ((Int32)(0.57 * item.Size))),Direction.east, 0, 0));

                    item.Lanes.Add(new LaneWithOneDirection(7, new Point(item.StartPoint.X + ((Int32)(0.59 * (item.Size))), item.StartPoint.Y + item.Size),
                       new Point(item.StartPoint.X + ((Int32)(0.59 * item.Size)), item.StartPoint.Y + ((Int32)(0.7 * item.Size))),Direction.north,  6, 0));
                    item.Lanes.Add(new LaneWithTwoDirection(8, new Point(item.StartPoint.X + ((Int32)(0.47 * item.Size)), item.StartPoint.Y + item.Size),
                        new Point(item.StartPoint.X + ((Int32)(0.47 * item.Size)), item.StartPoint.Y + ((Int32)(0.7 * item.Size))),Direction.north, 12, 3));
                    item.Lanes.Add(new EmptyLane(9, new Point(item.StartPoint.X + ((Int32)(0.36 * item.Size)), item.StartPoint.Y + ((Int32)(0.7 * item.Size))),
                       new Point(item.StartPoint.X + ((Int32)(0.36* item.Size)), item.StartPoint.Y + item.Size),Direction.south, 0, 0));

                    item.Lanes.Add(new LaneWithOneDirection(10, new Point(item.StartPoint.X, item.StartPoint.Y + ((Int32)(0.57 * item.Size))),
                      new Point(item.StartPoint.X + ((Int32)(0.3 * item.Size)), item.StartPoint.Y + ((Int32)(0.57 * item.Size))),Direction.east, 9, 0));
                    item.Lanes.Add(new LaneWithTwoDirection(11, new Point(item.StartPoint.X, item.StartPoint.Y + ((Int32)(0.48 * item.Size))),
                        new Point(item.StartPoint.X + ((Int32)(0.3 * item.Size)), item.StartPoint.Y + ((Int32)(0.48 * item.Size))),Direction.east, 3, 6));
                    item.Lanes.Add(new EmptyLane(12, new Point(item.StartPoint.X + ((Int32)(0.3 * item.Size)), item.StartPoint.Y + ((Int32)(0.37 * item.Size))),
                       new Point(item.StartPoint.X, item.StartPoint.Y + ((Int32)(0.37 * item.Size))),Direction.west, 0, 0));
                }
                else if (item.CType == 2)
                {
                    item.Lanes.Add(new LaneWithOneDirection(1, new Point(item.StartPoint.X + ((Int32)(0.40 * item.Size)), item.StartPoint.Y),
                        new Point(item.StartPoint.X + ((Int32)(0.40 * item.Size)), item.StartPoint.Y + ((Int32)(0.3 * item.Size))), Direction.south, 7, 10));
                    item.Lanes.Add(new EmptyLane(2, new Point(item.StartPoint.X + ((Int32)(0.57 * item.Size)), item.StartPoint.Y + ((Int32)(0.3 * item.Size))),
                        new Point(item.StartPoint.X + ((Int32)(0.57 * item.Size)), item.StartPoint.Y), Direction.north, 0, 0));

                    item.Lanes.Add(new LaneWithTwoDirection(3, new Point(item.StartPoint.X + item.Size, item.StartPoint.Y + ((Int32)(0.37 * item.Size))),
                        new Point(item.StartPoint.X + ((Int32)(0.7 * item.Size)), item.StartPoint.Y + ((Int32)(0.37 * item.Size))), Direction.west, 2, 10));
                    item.Lanes.Add(new LaneWithOneDirection(4, new Point(item.StartPoint.X + item.Size, item.StartPoint.Y + ((Int32)(0.48 * item.Size))),
                        new Point(item.StartPoint.X + ((Int32)(0.7 * item.Size)), item.StartPoint.Y + ((Int32)(0.48 * item.Size))), Direction.west, 7, 0));
                    item.Lanes.Add(new EmptyLane(5, new Point(item.StartPoint.X + ((Int32)(0.7 * item.Size)), item.StartPoint.Y + ((Int32)(0.57 * item.Size))),
                        new Point(item.StartPoint.X + item.Size, item.StartPoint.Y + ((Int32)(0.57 * item.Size))), Direction.east, 0, 0));

                    item.Lanes.Add(new LaneWithOneDirection(6, new Point(item.StartPoint.X + ((Int32)(0.57 * item.Size)), item.StartPoint.Y + item.Size),
                        new Point(item.StartPoint.X + ((Int32)(0.57 * item.Size)), item.StartPoint.Y + ((Int32)(0.7 * item.Size))), Direction.north, 2, 5));
                    item.Lanes.Add(new EmptyLane(7, new Point(item.StartPoint.X + ((Int32)(0.40 * item.Size)), item.StartPoint.Y + ((Int32)(0.7 * item.Size))),
                        new Point(item.StartPoint.X + ((Int32)(0.40 * item.Size)), item.StartPoint.Y + item.Size), Direction.south, 0, 0));

                    item.Lanes.Add(new LaneWithTwoDirection(8, new Point(item.StartPoint.X, item.StartPoint.Y + ((Int32)(0.57 * item.Size))),
                        new Point(item.StartPoint.X + ((Int32)(0.3 * item.Size)), item.StartPoint.Y + ((Int32)(0.57 * item.Size))), Direction.east, 5, 7));
                    item.Lanes.Add(new LaneWithOneDirection(9, new Point(item.StartPoint.X, item.StartPoint.Y + ((Int32)(0.48 * item.Size))),
                        new Point(item.StartPoint.X + ((Int32)(0.3 * item.Size)), item.StartPoint.Y + ((Int32)(0.48 * item.Size))), Direction.east, 2, 0));
                    item.Lanes.Add(new EmptyLane(10, new Point(item.StartPoint.X + ((Int32)(0.3 * item.Size)), item.StartPoint.Y + ((Int32)(0.37 * item.Size))),
                        new Point(item.StartPoint.X, item.StartPoint.Y + ((Int32)(0.37 * item.Size))), Direction.north, 0, 0));
                }

                //crossCounter++;
            }
            //return L;
        }

        //public void SetNextLaneCrossingNeigbor()
        //{
        //    //for (int i = 0; i < allcreatedcrossings.Count; i++)
        //    //{
        //    //    for (int j = 0; j < allcreatedcrossings[i].Lanes.Count; j++)
        //    //    {
        //    //        for (int k = 0; k < Lanes.Count; k++)
        //    //        {
        //    //            if (allcreatedcrossings[i].Lanes[j].Entrance == Lanes[k].Entrance)
        //    //            {
        //    //                allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Lanes[k];
        //    //            }
        //    //        }
        //    //    }
        //    //}
        //}


        public void SetNextLaneCrossingNeigborC1()
        {
            for (int i = 0; i < allcreatedcrossings.Count; i++)
            {
                if (allcreatedcrossings[i].CType == 1)
                {
                    for (int j = 0; j < allcreatedcrossings[i].Lanes.Count; j++)
                    {
                        if (allcreatedcrossings[i].Lanes[j].LaneID >= 1 && allcreatedcrossings[i].Lanes[j].LaneID <= 3)
                        {
                            Point p = new Point(allcreatedcrossings[i].StartPoint.X, (allcreatedcrossings[i].StartPoint.Y - allcreatedcrossings[i].Size));
                            Crossing C = allcreatedcrossings.Find(x => x.StartPoint == p);
                            if (C != null && (C.CType == 1))
                            {
                                int a = allcreatedcrossings[i].Lanes[j].LaneID;
                                if (a == 1)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 9);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else if (a == 2)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 8);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 7);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                            }
                            else if (C != null && (C.CType == 2))
                            {
                                int a = allcreatedcrossings[i].Lanes[j].LaneID;
                                if (a == 1)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 6);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else if (a == 2)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 6);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 7);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                            }
                        }
                        else if (allcreatedcrossings[i].Lanes[j].LaneID >= 4 && allcreatedcrossings[i].Lanes[j].LaneID <= 6)
                        {
                            Point p = new Point((allcreatedcrossings[i].StartPoint.X + allcreatedcrossings[i].Size), allcreatedcrossings[i].StartPoint.Y);
                            Crossing C = allcreatedcrossings.Find(x => x.StartPoint == p);
                            if (C != null && C.CType == 1)
                            {
                                int a = allcreatedcrossings[i].Lanes[j].LaneID;
                                if (a == 4)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 12);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else if (a == 5)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 11);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 10);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                            }
                            else if (C != null && (C.CType == 2))
                            {
                                int a = allcreatedcrossings[i].Lanes[j].LaneID;
                                if (a == 4)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 10);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else if (a == 5)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 9);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 8);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                            }
                        }
                        else if (allcreatedcrossings[i].Lanes[j].LaneID >= 7 && allcreatedcrossings[i].Lanes[j].LaneID <= 9)
                        {
                            Point p = new Point(allcreatedcrossings[i].StartPoint.X, (allcreatedcrossings[i].StartPoint.Y + allcreatedcrossings[i].Size));
                            Crossing C = allcreatedcrossings.Find(x => x.StartPoint == p);
                            if (C != null && C.CType == 1)
                            {
                                int a = allcreatedcrossings[i].Lanes[j].LaneID;
                                if (a == 7)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 3);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else if (a == 8)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 2);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 1);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                            }
                            else if (C != null && (C.CType == 2))
                            {
                                int a = allcreatedcrossings[i].Lanes[j].LaneID;
                                if (a == 7)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 2);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else if (a == 8)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 2);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 1);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                            }
                        }
                        else if (allcreatedcrossings[i].Lanes[j].LaneID >= 10 && allcreatedcrossings[i].Lanes[j].LaneID <= 12)
                        {
                            Point p = new Point((allcreatedcrossings[i].StartPoint.X - allcreatedcrossings[i].Size), allcreatedcrossings[i].StartPoint.Y);
                            Crossing C = allcreatedcrossings.Find(x => x.StartPoint == p);
                            if (C != null && C.CType == 1)
                            {
                                int a = allcreatedcrossings[i].Lanes[j].LaneID;
                                if (a == 10)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 6);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else if (a == 11)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 5);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 4);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                            }
                            else if (C != null && (C.CType == 2))
                            {
                                int a = allcreatedcrossings[i].Lanes[j].LaneID;
                                if (a == 10)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 5);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else if (a == 11)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 4);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 3);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                            }
                        }
                    }
                }
            }


        }

        public void SetNextLaneCrossingNeigborC2() //Make random for neigbor T1
        {
            for (int i = 0; i < allcreatedcrossings.Count; i++)
            {
                if (allcreatedcrossings[i].CType == 2)
                {
                    for (int j = 0; j < allcreatedcrossings[i].Lanes.Count; j++)
                    {
                        if (allcreatedcrossings[i].Lanes[j].LaneID >= 1 && allcreatedcrossings[i].Lanes[j].LaneID <= 2)
                        {
                            Point p = new Point(allcreatedcrossings[i].StartPoint.X, (allcreatedcrossings[i].StartPoint.Y - allcreatedcrossings[i].Size));
                            Crossing C = allcreatedcrossings.Find(x => x.StartPoint == p);
                            if (C != null && (C.CType == 1))
                            {
                                int a = allcreatedcrossings[i].Lanes[j].LaneID;
                                if (a == 1)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 9);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else if (a == 2)
                                {
                                    int randomInt = randomLaneChooser.Next(7, 9);

                                    Lane Next = C.Lanes.Find(x => x.LaneID == randomInt);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                            }
                            else if (C != null && (C.CType == 2))
                            {
                                int a = allcreatedcrossings[i].Lanes[j].LaneID;
                                if (a == 1)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 7);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else if (a == 2)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 6);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                            }
                        }
                        else if (allcreatedcrossings[i].Lanes[j].LaneID >= 3 && allcreatedcrossings[i].Lanes[j].LaneID <= 5)
                        {
                            Point p = new Point((allcreatedcrossings[i].StartPoint.X + allcreatedcrossings[i].Size), allcreatedcrossings[i].StartPoint.Y);
                            Crossing C = allcreatedcrossings.Find(x => x.StartPoint == p);
                            if (C != null && C.CType == 1)
                            {
                                int a = allcreatedcrossings[i].Lanes[j].LaneID;
                                if (a == 3)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 12);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else if (a == 4)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 11);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 10);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                            }
                            else if (C != null && (C.CType == 2))
                            {
                                int a = allcreatedcrossings[i].Lanes[j].LaneID;
                                if (a == 3)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 10);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else if (a == 4)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 9);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 8);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                            }
                        }
                        else if (allcreatedcrossings[i].Lanes[j].LaneID >= 6 && allcreatedcrossings[i].Lanes[j].LaneID <= 7)
                        {
                            Point p = new Point(allcreatedcrossings[i].StartPoint.X, (allcreatedcrossings[i].StartPoint.Y + allcreatedcrossings[i].Size));
                            Crossing C = allcreatedcrossings.Find(x => x.StartPoint == p);
                            if (C != null && C.CType == 1)
                            {
                                int a = allcreatedcrossings[i].Lanes[j].LaneID;
                                if (a == 6)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 3);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else if (a == 7)
                                {
                                    int randomInt = randomLaneChooser.Next(1, 3);

                                    Lane Next = C.Lanes.Find(x => x.LaneID == randomInt);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                            }
                            else if (C != null && (C.CType == 2))
                            {
                                int a = allcreatedcrossings[i].Lanes[j].LaneID;
                                if (a == 6)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 2);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else if (a == 7)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 1);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                            }
                        }
                        else if (allcreatedcrossings[i].Lanes[j].LaneID >= 8 && allcreatedcrossings[i].Lanes[j].LaneID <= 10)
                        {
                            Point p = new Point((allcreatedcrossings[i].StartPoint.X - allcreatedcrossings[i].Size), allcreatedcrossings[i].StartPoint.Y);
                            Crossing C = allcreatedcrossings.Find(x => x.StartPoint == p);
                            if (C != null && C.CType == 1)
                            {
                                int a = allcreatedcrossings[i].Lanes[j].LaneID;
                                if (a == 8)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 6);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else if (a == 9)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 5);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 4);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                            }
                            else if (C != null && (C.CType == 2))
                            {
                                int a = allcreatedcrossings[i].Lanes[j].LaneID;
                                if (a == 8)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 5);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else if (a == 9)
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 4);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                                else
                                {
                                    Lane Next = C.Lanes.Find(x => x.LaneID == 3);
                                    allcreatedcrossings[i].Lanes[j].NextCrossingLaneNeighbor = Next;
                                }
                            }
                        }
                    }
                }
            }
        }


        public void setEnterancesLanes()
        {
            foreach (var citem in allcreatedcrossings)
            {
                foreach (var litem in citem.Lanes)
                {
                    if (litem.NextCrossingLaneNeighbor == null && !(litem is EmptyLane))
                    {
                        EnterancesLanes.Add(litem);
                    }
                }
            }
        }

    }
}

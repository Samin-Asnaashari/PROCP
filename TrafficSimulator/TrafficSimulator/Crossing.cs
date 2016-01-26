using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficSimulator
{
    [Serializable]
    public class Crossing : IComparable
    {
        public Image image { get; set; }
        public int Size { get; set; }
        public int LightCounter { get; set; }
        public int LightIterator { get; set; }
        public Point StartPoint { get; set; }
        public int CType { get; set; }
        public List<Lane> Lanes;
        public List<Crossing> Neighbors;

        public GroupType Group;
        public List<int> Groups;
        //public Crossing North;
        //public Crossing East;
        //public Crossing West;
        //public Crossing South;

        public Crossing(Point p,Image image, int size)
        {
            this.image = image;
            this.Size = size;
            this.StartPoint = p;
            this.CType = 0;
            Lanes = new List<Lane>();
            Neighbors = new List<Crossing>();
            this.Groups = new List<int>();
            LightCounter = 0;
            LightIterator = -1; //to increment to 0 on first time
            //this.image = (Image)new Bitmap(new Bitmap(this.Image_Filename.Split('.')[0] + ".png"), this.image.Size);
            //North = null;
            //East = null;
            //West = null;
            //South = null;
        }
        
        public int CompareTo(object obj)
        {
            if (this.StartPoint.X < ((Crossing)obj).StartPoint.X)
            {
                    return -1;
            }
            else if (this.StartPoint.X == ((Crossing)obj).StartPoint.X && this.StartPoint.Y < ((Crossing)obj).StartPoint.Y)
            {
                    return -1;
            }
            else if (this.StartPoint.X > ((Crossing)obj).StartPoint.X)
            {
                return 1;
            }
            else if (this.StartPoint.X == ((Crossing)obj).StartPoint.X && this.StartPoint.Y > ((Crossing)obj).StartPoint.Y)
            {
                return 1;
            }
            { return 0; }
        } //check

        public void countDown()
        {
            if (LightCounter > 0)
            {
                LightCounter--;
            }
            else
            {
                if (LightIterator < Groups.Count - 1)
                {
                    LightIterator++;
                }
                else
                {
                    LightIterator = 0;
                }

                //MessageBox.Show("" + LightIterator);
                if (Group == GroupType.GroupLightsForCrossingType1)
                {
                    GroupLightsForCrossingType1 index = (GroupLightsForCrossingType1)LightIterator;
                    switch (index)
                    {
                        case GroupLightsForCrossingType1.Lights123:
                            {
                                for (int i = 0; i < Lanes.Count; i++)
                                {
                                    Lane lane = Lanes[i];
                                    if (lane.Light.LightID >= 1 && lane.LaneID <= 3)
                                    {
                                        lane.Light.Color = LightColor.green;
                                    }
                                    else
                                    {
                                        lane.Light.Color = LightColor.red;
                                    }
                                }
                            }
                            break;
                        case GroupLightsForCrossingType1.Lights1357:
                            {
                                for (int i = 0; i < Lanes.Count; i++)
                                {
                                    Lane lane = Lanes[i];
                                    if (lane.Light.LightID == 1 || lane.Light.LightID == 3 || lane.Light.LightID == 5 || lane.Light.LightID == 7)
                                    {
                                        lane.Light.Color = LightColor.green;
                                    }
                                    else
                                    {
                                        lane.Light.Color = LightColor.red;
                                    }
                                }
                            }
                            break;
                        case GroupLightsForCrossingType1.Lights178:
                            {
                                for (int i = 0; i < Lanes.Count; i++)
                                {
                                    Lane lane = Lanes[i];
                                    if (lane.Light.LightID == 1 || lane.Light.LightID == 7 || lane.Light.LightID == 8)
                                    {
                                        lane.Light.Color = LightColor.green;
                                    }
                                    else
                                    {
                                        lane.Light.Color = LightColor.red;
                                    }
                                }
                            }
                            break;
                        case GroupLightsForCrossingType1.Lights345:
                            {
                                for (int i = 0; i < Lanes.Count; i++)
                                {
                                    Lane lane = Lanes[i];
                                    if (lane.Light.LightID >= 3 && lane.Light.LightID <= 5)
                                    {
                                        lane.Light.Color = LightColor.green;
                                    }
                                    else
                                    {
                                        lane.Light.Color = LightColor.red;
                                    }
                                }
                            }
                            break;
                        case GroupLightsForCrossingType1.Lights567:
                            {
                                for (int i = 0; i < Lanes.Count; i++)
                                {
                                    Lane lane = Lanes[i];
                                    if (lane.Light.LightID >= 5 && lane.Light.LightID <= 7)
                                    {
                                        lane.Light.Color = LightColor.green;
                                    }
                                    else
                                    {
                                        lane.Light.Color = LightColor.red;
                                    }
                                }
                            }
                            break;
                    }
                }

                else if (Group == GroupType.GroupLightsForCrossingType2)
                {
                    GroupLightsForCrossingType2 index = (GroupLightsForCrossingType2)LightIterator;
                    switch (index)
                    {
                        case GroupLightsForCrossingType2.Light2:
                            {
                                for (int i = 0; i < Lanes.Count; i++)
                                {
                                    Lane lane = Lanes[i];
                                    if (lane.Light.LightID == 2)
                                    {
                                        lane.Light.Color = LightColor.green;
                                    }
                                    else
                                    {
                                        lane.Light.Color = LightColor.red;
                                    }
                                }
                            }
                            break;
                        case GroupLightsForCrossingType2.Light6:
                            {
                                for (int i = 0; i < Lanes.Count; i++)
                                {
                                    Lane lane = Lanes[i];
                                    if (lane.Light.LightID == 6)
                                    {
                                        lane.Light.Color = LightColor.green;
                                    }
                                    else
                                    {
                                        lane.Light.Color = LightColor.red;
                                    }
                                }
                            }
                            break;
                        case GroupLightsForCrossingType2.Lights34:
                            {
                                for (int i = 0; i < Lanes.Count; i++)
                                {
                                    Lane lane = Lanes[i];
                                    if (lane.Light.LightID == 3 || lane.Light.LightID == 4)
                                    {
                                        lane.Light.Color = LightColor.green;
                                    }
                                    else
                                    {
                                        lane.Light.Color = LightColor.red;
                                    }
                                }
                            }
                            break;
                        case GroupLightsForCrossingType2.Lights14:
                            {
                                for (int i = 0; i < Lanes.Count; i++)
                                {
                                    Lane lane = Lanes[i];
                                    if (lane.Light.LightID == 1 || lane.Light.LightID == 4)
                                    {
                                        lane.Light.Color = LightColor.green;
                                    }
                                    else
                                    {
                                        lane.Light.Color = LightColor.red;
                                    }
                                }
                            }
                            break;
                        case GroupLightsForCrossingType2.Lights35:
                            {
                                for (int i = 0; i < Lanes.Count; i++)
                                {
                                    Lane lane = Lanes[i];
                                    if (lane.Light.LightID == 3 || lane.Light.LightID == 5)
                                    {
                                        lane.Light.Color = LightColor.green;
                                    }
                                    else
                                    {
                                        lane.Light.Color = LightColor.red;
                                    }
                                }
                            }
                            break;
                        case GroupLightsForCrossingType2.Lights17:
                            {
                                for (int i = 0; i < Lanes.Count; i++)
                                {
                                    Lane lane = Lanes[i];
                                    if (lane.Light.LightID == 1 || lane.Light.LightID == 7)
                                    {
                                        lane.Light.Color = LightColor.green;
                                    }
                                    else
                                    {
                                        lane.Light.Color = LightColor.red;
                                    }
                                }
                            }
                            break;
                        case GroupLightsForCrossingType2.Lights73:
                            {
                                for (int i = 0; i < Lanes.Count; i++)
                                {
                                    Lane lane = Lanes[i];
                                    if (lane.Light.LightID == 3 || lane.Light.LightID == 7)
                                    {
                                        lane.Light.Color = LightColor.green;
                                    }
                                    else
                                    {
                                        lane.Light.Color = LightColor.red;
                                    }
                                }
                            }
                            break;
                        case GroupLightsForCrossingType2.Lights78:
                            {
                                for (int i = 0; i < Lanes.Count; i++)
                                {
                                    Lane lane = Lanes[i];
                                    if (lane.Light.LightID == 7 || lane.Light.LightID == 8)
                                    {
                                        lane.Light.Color = LightColor.green;
                                    }
                                    else
                                    {
                                        lane.Light.Color = LightColor.red;
                                    }
                                }
                            }
                            break;
                        case GroupLightsForCrossingType2.Lights84:
                            {
                                for (int i = 0; i < Lanes.Count; i++)
                                {
                                    Lane lane = Lanes[i];
                                    if (lane.Light.LightID == 8 || lane.Light.LightID == 4)
                                    {
                                        lane.Light.Color = LightColor.green;
                                    }
                                    else
                                    {
                                        lane.Light.Color = LightColor.red;
                                    }
                                }
                            }
                            break;
                        case GroupLightsForCrossingType2.Lights85:
                            {
                                for (int i = 0; i < Lanes.Count; i++)
                                {
                                    Lane lane = Lanes[i];
                                    if (lane.Light.LightID == 5 || lane.Light.LightID == 8)
                                    {
                                        lane.Light.Color = LightColor.green;
                                    }
                                    else
                                    {
                                        lane.Light.Color = LightColor.red;
                                    }
                                }
                            }
                            break;
                    }
                }
                //MessageBox.Show("" + LightIterator);
                LightCounter = Groups[LightIterator];
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficSimulator
{
    [Serializable]
    public class Controller
    {
        /// <summary>
        /// class to control the form 
        /// </summary>

        private static Controller instance;
        private DebugWindow debug;
        private Random random;
        public bool Started;
        public WorkspaceDesign Design;
        public float panelw;
        public float panelh;
        public int lines;

        public Crossing C;
        public int tempCType;

        private Controller()
        {
            debug = new DebugWindow();
            random = new Random(12);
            Started = false;
            debug.Show();
            lines = 0;
            tempCType = 0;
        }

        public static Controller getController()
        {
            if (instance == null)
            {
                instance = new Controller();
            }

            return instance;
        }

        public void setSettings(float pw, float ph, WorkspaceDesign d)
        {
            this.Design = d;
            this.panelw = pw;
            this.panelh = ph;
        }

        /// <summary>
        /// crate a grid in workspace area base on user choice(small,medium,large)
        /// </summary>
        /// <param name="gr"></param>
        public void drawthedesigngrid(Graphics gr)
        {
            float x = 0f;
            float y = 0f;
            Pen mypen = new Pen(Brushes.Black, 1);

            float xspace = panelw / lines;
            float yspace = panelh / lines;

            //vertical
            for (int i = 0; i < lines + 1; i++)
            {
                gr.DrawLine(mypen, x, y, x, panelh);
                x += xspace;
            }
            //horizontal 
            x = 0f;
            //y = 0f;
            for (int i = 0; i < lines + 1; i++)
            {
                gr.DrawLine(mypen, x, y, panelw, y);
                y += yspace;
            }
        }

        /// <summary>
        /// draw one crossing in a chosen cell and crossing type picture 
        /// user click and drag the crossing type to the workspace area 
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="clickedpoint"></param>
        /// <param name="C"></param>
        public void drawcrossing(Graphics gr, Point position, Crossing C)
        {
            try
            {
                int size = Convert.ToInt32(panelw / lines);
                Rectangle reg = new Rectangle(position.X - 1, position.Y - 1, Convert.ToInt32(panelw / lines), Convert.ToInt32(panelh / lines));
                gr.DrawImage(C.image, reg);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        //study this center of the square 
        /// <summary>
        /// find the cell base on the user click position 
        /// </summary>
        /// <param name="clickedpoint"></param>
        /// <returns></returns>
        public Point findcell(Point clickedpoint)
        {
            Point start;
            int xx = 0;
            int yy = 0;

            for (int x = 0; x <= panelw + Convert.ToInt32(panelw / lines); x += Convert.ToInt32(panelw / lines))
            {
                if (x > clickedpoint.X)
                {
                    xx = x - Convert.ToInt32(panelw / lines);
                    break;
                }
            }

            for (int y = 0; y <= panelh + Convert.ToInt32(panelw / lines); y += Convert.ToInt32(panelh / lines))
            {
                if (y > clickedpoint.Y)
                {
                    yy = y - Convert.ToInt32(panelh / lines);
                    break;
                }
            }
            start = new Point(xx, yy);
            return start;
        }

        public void callinvalidate(Control Control)
        {
            Control.Invalidate();
        }

        /// <summary>
        /// check if the cell is occupied
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool isTakenCell(Point p)
        {
            bool taken = false;
            foreach (var item in this.Design.allcreatedcrossings)
            {
                if (item.StartPoint == findcell(p))
                {
                    taken = true;
                    break;
                }
            }
            return taken;
        }

        public int CarSize()
        {
            if (lines == 4)
            {
                return 8;
            }
            else if(lines == 3)
            {
                return 7;
            }
            else /*if(lines == 2)*/
            {
                return 6;
            }
        }

        public void DrawCars(Graphics gr)
        {
            List<Crossing> crossings = Design.allcreatedcrossings;
            if (!Started)
            {
                Started = true;
                for (int i = 0; i < crossings.Count; i++)
                {
                    List<Lane> lanes = crossings[i].Lanes;
                    for (int j = 0; j < lanes.Count; j++)
                    {
                        Lane lane = lanes[i];
                        debug.addLog("Lane " + lane.LaneID + " Entrance point: " + lane.Entrance.ToString() + "\n" + "Lane " + lane.LaneID + " Intersection point: " + lane.Intersection.ToString() + "\n");
                    }
                }
            }

            int s = CarSize();

            for (int i = 0; i < crossings.Count; i++) //(list of the entrances add car to the enterances lane)
            {
                List<Lane> lanes = crossings[i].Lanes;
                for (int j = 0; j < lanes.Count; j++)
                {
                    if (lanes[j].CountCars < 1 && !(lanes[j] is EmptyLane))
                    {
                        /*Direction D = Direction.north; //for satisfing the compiler 
                        if (Design.Lanes[i] is LaneWithOneDirection || Design.Lanes[i] is EmptyLane)
                        {
                            D = Design.Lanes[i].DirectionIsTo;
                        }
                        else if (Design.Lanes[i] is LaneWithTwoDirection)
                        {
                            //random direction
                        }*/

                        Direction D = lanes[j].DirectionIsTo;

                        lanes[j].Cars.Add(new Car(lanes[j].Entrance, D, s));
                        lanes[j].CountCars++;
                    }
                }
            }

            for (int i = 0; i < crossings.Count; i++)
            {
                List<Lane> lanes = crossings[i].Lanes;
                for (int j = 0; j < lanes.Count; j++)
                {
                    List<Car> cars = lanes[j].Cars;
                    for (int k = 0; k < cars.Count; k++)
                    {
                        if (lanes[j].Cars[k].Position == lanes[j].Intersection)
                        {
                            debug.addLog("Car of lane-id " + lanes[j].LaneID + " intersected at point " + lanes[j].Intersection.ToString() + "\n");

                            if (lanes[j] is LaneWithOneDirection)
                            {
                                if (lanes[j].Light.Color == LightColor.green)
                                {
                                    //but need to go to the right next lane
                                    //Design.Lanes[j + 1].Cars.Add(Design.Lanes[i].Cars[j]); //if is possible add it

                                    for (int l = 0; l < lanes.Count; l++)
                                    {
                                        if (lanes[l].LaneID == lanes[j].Connections[0])
                                        {
                                            Car car = lanes[j].Cars[k];
                                            car.Position = lanes[l].Entrance;
                                            car.Direction = lanes[l].DirectionIsTo;
                                            lanes[l].Cars.Add(car);
                                            lanes[l].CountCars++;
                                        }
                                    }

                                    lanes[j].Cars.Remove(lanes[j].Cars[k]);
                                }
                                //if green go to next lane delete from the list of the lane cars 
                                //if red wait 
                            }
                            else if (lanes[j] is LaneWithTwoDirection)
                            {
                                if (lanes[j].Light.Color == LightColor.green)
                                {
                                    int randomInt = random.Next(2);
                                    debug.addLog("randomInt " + randomInt);

                                    for (int l = 0; l < lanes.Count; l++)
                                    {
                                        if (lanes[l].LaneID == lanes[l].Connections[randomInt])
                                        {
                                            debug.addLog("Connection Lane ID: " + lanes[l].LaneID);
                                            Car car = lanes[j].Cars[k];
                                            car.Position = lanes[l].Entrance;
                                            car.Direction = lanes[l].DirectionIsTo;
                                            lanes[l].Cars.Add(car);
                                            lanes[l].CountCars++;
                                        }
                                    }
                                    //Design.Lanes[j + 1].Cars.Add(Design.Lanes[i].Cars[j]); //if is possible add it
                                    lanes[j].Cars.Remove(lanes[j].Cars[k]);

                                    //Design.Lanes[Design.Lanes[i].Connections[0]].Cars.Add(Design.Lanes[i].Cars[j]);
                                }
                            }
                            else if (lanes[j] is EmptyLane)
                            {
                                lanes[j].Cars.Remove(lanes[j].Cars[k]);
                            }
                        }
                    }
                    for (int k = 0; k < cars.Count; k++)
                    {
                        if (lanes[j].Cars[k].Position != lanes[j].Intersection)
                        {
                            lanes[j].Cars[k].MoveTheCar(lanes[j].DirectionIsTo);
                            lanes[j].Cars[k].DrawCar(gr);
                        }
                    }
                }
            }
        }
    }
}
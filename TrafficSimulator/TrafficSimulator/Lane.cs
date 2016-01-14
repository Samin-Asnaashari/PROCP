using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulator
{
    /// <summary>
    /// group of possibilities for green lights for crossing type 1
    /// </summary>
    public enum GroupLightsForCrossingType1
    {
        Lights123, Lights345, Lights567, Lights1357, Lights178
    }
    /// <summary>
    /// group of possibilities for green lights for crossing type 2
    /// </summary>
    public enum GroupLightsForCrossingType2
    {
        Light2, Light6, Lights34, Lights14, Lights35, Lights17, Lights73, Lights78, Lights84, Lights85
    }
    public class Lane : IComparable
    {
        public int LaneID { get; set; }
        public Point Entrance { get; set; }
        public Point Intersection { get; set; }
        public Direction DirectionIsTo { get; set; }
        public List<Car> Cars { get; set; }
        public int CountCars;
        public Light Light;
        public List<int> Group;
        public List<int> Connections { get; set; } //which lanes the car may enter in intersection

        public Lane(int laneID, Point enter , Point intersect,Direction D, int c1, int c2)
        {
            this.LaneID = laneID;
            this.Entrance = enter;
            this.Intersection = intersect;
            this.DirectionIsTo = D;
            Light = new Light();
            CountCars = 0;
            Cars = new List<Car>();
            Group = new List<int>();
            Connections = new List<int>();
            Connections.Add(c1);
            Connections.Add(c2);
        }

        public int CompareTo(object obj)
        {
            if (this.Entrance.X < ((Lane)obj).Entrance.X)
            {
                return -1;
            }
            else if (this.Entrance.X == ((Lane)obj).Entrance.X && this.Entrance.Y < ((Lane)obj).Entrance.Y)
            {
                return -1;
            }
            else if (this.Entrance.X > ((Lane)obj).Entrance.X)
            {
                return 1;
            }
            else if (this.Entrance.X == ((Lane)obj).Entrance.X && this.Entrance.Y > ((Lane)obj).Entrance.Y)
            {
                return 1;
            }
            { return 0; }
        }

    }

    public class LaneWithOneDirection : Lane
    {
        public Direction PossibleDirection { get; set; }

        public LaneWithOneDirection(int id, Point e,Point i,Direction d, int c1, int c2):base(id,e,i,d,c1,c2)
        {
            
        }
    }

    public class LaneWithTwoDirection : Lane
    {
        public string[] PossibleDirection { get; set; }

        public LaneWithTwoDirection(int id, Point e, Point i, Direction d, int c1, int c2): base(id,e, i, d,c1,c2)
        {
            this.PossibleDirection = new string[2];
        }
    }

    public class EmptyLane : Lane
    {
        public EmptyLane(int id, Point ei, Point exit,Direction d, int c1, int c2):base(id, ei,exit,d, c1, c2)
        {
            
        }
    }



}

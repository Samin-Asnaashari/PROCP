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
    /// 
    public enum GroupType
    {
        GroupLightsForCrossingType1, GroupLightsForCrossingType2
    }

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
    [Serializable]
    public class Lane 
    {
        public int LaneID { get; set; }
        public Point Entrance { get; set; }
        public Point Intersection { get; set; }
        public Direction DirectionIsTo { get; set; }
        //public Car[] Cars { get; set; }
        public int CountCars; //not needed
        public List<Car> Cars;
        public Light Light;
        //public List<int> Group;
        public Lane NextCrossingLaneNeighbor;
        public List<int> Connections { get; set; } //which lanes the car may enter in intersection

        public Lane(int laneID, Point enter , Point intersect,Direction D, int c1, int c2)
        {
            this.LaneID = laneID;
            this.Entrance = enter;
            this.Intersection = intersect;
            this.DirectionIsTo = D;
            Light = new Light();
            CountCars = 0;
            //Cars = new Car[5];
            Cars = new List<Car>();
            //Group = new List<int>();

            this.NextCrossingLaneNeighbor = null;
            Connections = new List<int>();
            Connections.Add(c1);
            Connections.Add(c2);

            Light.Color = LightColor.green; //change this later
        }
    }
    [Serializable]
    public class LaneWithOneDirection : Lane
    {
        //public Direction PossibleDirection { get; set; }

        public LaneWithOneDirection(int id, Point e,Point i,Direction d, int c1, int c2):base(id,e,i,d,c1,c2)
        {
        }
    }
    [Serializable]
    public class LaneWithTwoDirection : Lane
    {
        public Direction[] PossibleDirection { get; set; }

        public LaneWithTwoDirection(int id, Point e, Point i, Direction currentd1, int c1, int c2): base(id,e, i,currentd1,c1,c2)
        {
            //this.PossibleDirection = new Direction[2];
            //PossibleDirection[0] = currentd1;
            //PossibleDirection[1] = d2;
        }
    }
    [Serializable]
    public class EmptyLane : Lane
    {
        //public Direction PossibleDirection { get; set; }

        public EmptyLane(int id, Point ei, Point exit,Direction d, int c1, int c2):base(id, ei,exit,d,c1,c2)
        {
        }
    }



}

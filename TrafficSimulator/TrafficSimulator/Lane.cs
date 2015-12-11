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
        public Point Entrance { get; set; }
        public Point Intersection { get; set; }
        public Direction DirectionIsTo { get; set; }
        public List<Car> Cars { get; set; }
        public int CountCars;
        public Light Light;
        public List<int> Group;

        public Lane(Point enter , Point intersect,Direction D)
        {
            this.Entrance = enter;
            this.Intersection = intersect;
            this.DirectionIsTo = D;
            Light = new Light();
            CountCars = 0;
            Cars = new List<Car>();
            Group = new List<int>();
        }

<<<<<<< HEAD
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

        public LaneWithOneDirection(Point e,Point i,Direction d):base(e,i,d)
        {
           
=======
        public void calculateDirection(Car car)
        {

>>>>>>> origin/master
        }
    }

    public class LaneWithTwoDirection : Lane
    {
        public string[] PossibleDirection;

        public LaneWithTwoDirection(Point e, Point i, Direction d): base(e, i, d)
        {
            this.PossibleDirection = new string[2];
        }
    }

    public class EmptyLane : Lane
    {
        public EmptyLane(Point ei, Point exit,Direction d):base(ei,exit,d)
        {
            
        }
    }



}

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
    public enum GroupLightsTypeA
    {
        Lights123, Lights345, Lights567, Lights1357, Lights178
    }
    /// <summary>
    /// group of possibilities for green lights for crossing type 2
    /// </summary>
    public enum GroupLightsType2
    {
        Light2, Light6, Lights34, Lights14, Lights35, Lights17, Lights73, Lights78, Lights84, Lights85
    }
    public class Lane :IComparable
    {
        public Point Entrance { get; set; }
        public Point Intersection { get; set; }

        public Car[] Cars { get; set; }

        public Lane(Point enter , Point intersect)
        {
            this.Entrance = enter;
            this.Intersection = intersect;
            Cars = new Car[5];
        }

        public int CompareTo(object obj)
        {
            return 0; ///write this 
        }

    }

    class LaneType1 : Lane
    {
        public string PossibleDirection { get; set; }

        public LaneType1(Point e,Point i):base(e,i)
        {
            this.PossibleDirection = null;
        }
    }

    class LaneType2 : Lane
    {
        public string[] PossibleDirection;

        public LaneType2(Point e, Point i): base(e,i)
        {
            this.PossibleDirection = new string[2];
        }
    }

    class EmptyLane : Lane
    {
        public EmptyLane(Point e, Point i)
            : base(e, i)
        {
            
        }
    }



}

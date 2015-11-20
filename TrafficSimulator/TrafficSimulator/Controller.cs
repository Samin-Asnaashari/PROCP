using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulator
{
    class Controller
    {
        public Size Workspace_size { get; set; }
        public Dictionary<string, Size> Sizes { get; set; }
        public Pen Workspace_pen { get; set; }
        //
        public WorkspaceDesign Design { get; set; }

        public Graphics Workspace_graphics { get; set; }
        public Point[]  Clicks { get; set; }
        public Size Scale { get; set; }


        public Size CreateGrid(string size)
        {
            Size s = this.Sizes[size];
            return s;
        }

        public Controller(Size wspace_size, Graphics wspace_graphics, WorkspaceDesign design)
        {
            this.Workspace_size = wspace_size; ;
            this.Workspace_graphics = wspace_graphics;
            this.Scale = new Size();
            this.Clicks = new Point[2];
            this.Workspace_pen =  new Pen(Brushes.Black);
            this.Sizes = new Dictionary<string, Size>
            {
                { "small", new Size(25, 25) },
                { "medium", new Size(15, 15) },
                { "large", new Size(5, 5) }
            };

            //
            this.Design = design;         
        }


        //private WorkspaceDesign getdesign()
        //{
        //    return this.Design;
        //}
        //private void setdesign(WorkspaceDesign design)
        //{
        //    this.Design = design;
        //}


        public void redrawGrid()
        {
            int offset_x = this.Workspace_size.Width / this.Design.size.Width;
            int offset_y = this.Workspace_size.Height / this.Design.size.Height;
            this.Scale = new Size(offset_x / 2, offset_y / 2);

            // draw the vertical lines along the x axis
            for (int x = 1; x <= Workspace_size.Width; x++)
            {
                this.Workspace_graphics.DrawLine(this.Workspace_pen, x * offset_x, 0, x * offset_x, this.Workspace_size.Height);
            }

            // draw the horizontal lines along the y axis
            for (int y = 1; y <= this.Workspace_size.Height; y++)
            {
                this.Workspace_graphics.DrawLine(this.Workspace_pen, 0, y * offset_y, this.Workspace_size.Width, y * offset_y);
            }
        }

        public void redrawCrossing()
        {
            foreach (Crossing item in this.Design.Crossings.Values)
            {
                this.Workspace_graphics.DrawImage(item.image, item.Position);
            }
        }

        public void resizeDesignCrossings()
        {
            Size new_size = new Size(this.Workspace_size.Width / this.Design.size.Width,this.Workspace_size.Height / this.Design.size.Height);
            this.Design.draw_offset = new Size(this.Workspace_size.Width / this.Design.size.Width, this.Workspace_size.Height / this.Design.size.Height);
            this.Design.resizeAllImages(new_size);
        }

        public void resizeDesignCrossing(Crossing C)
        {
            Size new_size = new Size(this.Workspace_size.Width / this.Design.size.Width, this.Workspace_size.Height / this.Design.size.Height);
            C.resizeImage(new_size);
        }

        internal Point CurrentCell(Point p)
        {
            int offset_x = this.Workspace_size.Width / this.Design.size.Width;
            int offset_y = this.Workspace_size.Height / this.Design.size.Height;

            int top = 0;
            int left = 0;

            for (int x = 0; x <= this.Workspace_size.Width; x += offset_x)
            {
                if (x > p.X)
                {
                    left = x - offset_x;
                    break;
                }
            }

            for (int y = 0; y <= this.Workspace_size.Height; y += offset_y)
            {
                if (y > p.Y)
                {
                    top = y - offset_y;
                    break;
                }
            }

            return new Point(left, top);
        }


        public void AddCrossing(Point p, int type)
        {
            Point loc = this.CurrentCell(p);
            Crossing crossing = null;

            switch (type)
            {
                case 1:
                    crossing = new CrossingTypeA(loc);
                    break;
                case 2:
                    crossing = new CrossingTypeB(loc);
                    break;
                default:
                    throw new ArgumentException("Wrong Type...");
            };

            this.resizeDesignCrossing(crossing);
            if (this.isTakenCell(crossing.Position))
            {

            }
            this.Design.Crossings.Add(crossing.Position,crossing);
        }


        public bool isTakenCell(Point p)
        {
            return this.Design.Crossings.ContainsKey(p);
        }

        public Crossing getClickedElement(Point p)
        {
            return this.Design.Crossings[this.CurrentCell(p)];
        }

        public void RememberClick(int index, Point p)
        {
            this.Clicks[index] = this.CurrentCell(p);
        }

        public void LoadDesign(Stream sketch_stream, string file_name)
        {
            this.Design.Load(sketch_stream);
        }

        public void SaveDesignAs(Stream sketch_stream, string file_name)
        {
            this.Design.Name = file_name;
            this.Design.SaveAs(sketch_stream);
        }

        public void SaveDesign()
        {
            this.Design.Save();
        }

        public void cleanUp()
        {
            this.Workspace_graphics.Dispose();
            this.Workspace_pen.Dispose();
            this.Design = null;
        }

        public void Pointer()
        {
        }

        public void Pedestrain()
        {
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Threading;

namespace TrafficSimulator
{
    public enum LightColor{red,green, yellow}//not used for now

    public class Light
    {
       
        public event EventHandler LightChanged;
        private bool lRed;              
        private bool lYellow;           
        private bool lGreen;
        public Point Position;       // X and Y


        /// <summary>
        /// Creates traffic light with Red light on, at specified location
        /// with default Green light time of 30 seconds.
        /// </summary>
        /// <param name="x">x coordinate of the traffic light</param>
        /// <param name="y">y coordinate of the traffic light</param>
        public Light(int x, int y)
        {
            //DONE
            // Check if  coordinates are within limits
            //NEED TO DECIDE THE UPPER LIMIT
            if (x < 0 || y < 0)
            { throw new ArgumentOutOfRangeException(); }
            else
            {
                Position = new Point(x, y);
                lRed = true;
                lYellow = false;
                lGreen = false;
                //gTime = 10; //default time
                //IsWorking = false; //it's not working yet
            }
        }
        /// <summary>
        /// Returns which state the traffic light is on
        /// </summary>
        /// <returns>
        /// 0 - Red light             (traffic is forbidden)
        /// 1 - Red and yellow lights (light is about to get green)
        /// 2 - Yellow light          (light is about to get red)
        /// 3 - Green light           (traffic is allowed)
        ///-1 - Something went wrong
        /// </returns>
        public int WhatIsOn()
        {
            
            int retValue = -1;
            if (lGreen)
                retValue = 3;
            if (lYellow && lRed)
                retValue = 1;
            else if (lRed)
                retValue = 0;
            else if (lYellow)
                retValue = 2;
            return retValue;
        }

        /// <summary>
        /// Check if current light is green
        /// </summary>
        /// <returns>true if current light is green</returns>
        public Boolean IsGreen()
        {
            //DONE
            return lGreen;
        }

        /// <summary>
        /// returns the possition of the trafficlight
        /// </summary>
        /// <returns>Position on the crossing (x and y)</returns>
        public Point GetPosition()
        {
            return this.Position;
        }

        /// <summary>
        /// Changes the traffic light to Green, with all the intermediate steps
        /// </summary>
        private void ChangeToGreen()
        {
            //Light is Red
            if (!this.IsGreen())
            {
                //Red and yellow lights are on for 1 seconds
                lYellow = true;
                for (int i = 0; i < 1; i++)
                    Thread.Sleep(1000);
                //Turn of red and yellow lights
                lRed = false;
                lYellow = false;
                //Green Light is on
                lGreen = true;
                OnLightChanged(EventArgs.Empty);        //fire event
            }
        }

        /// <summary>
        /// Changes the traffic light to Green, with all the intermediate steps
        /// </summary>
        private void ChangeToRed()
        {
            //Light is Green
            if (this.IsGreen())
            {
                //Forbid traffic
                lGreen = false;
                OnLightChanged(EventArgs.Empty);        //<<<<<<<<<<<<<<Event Fired
                //Yellow light is on for 1 seconds
                lYellow = true;
                for (int i = 0; i < 1; i++)
                    Thread.Sleep(1000);
                //Turn off yellow light
                lYellow = false;
                //Red light is on
                lRed = true;
            }
        }

        public void ChangeLight()
        {
            if (this.IsGreen())
                this.ChangeToRed();
            else
                this.ChangeToGreen();
        }

        public void Draw(Graphics gr)
        {
            SolidBrush brushGreen = new SolidBrush(Color.LightGreen);
            SolidBrush brushYellow = new SolidBrush(Color.Yellow);
            SolidBrush brushRed = new SolidBrush(Color.Red);
            SolidBrush brushGray = new SolidBrush(Color.Gray);
            SolidBrush brushBlack = new SolidBrush(Color.Black);

            int status = this.WhatIsOn();

            switch (status)
            {
                case 0:
                    gr.FillRectangle(brushBlack, this.Position.X-1, this.Position.Y-1, 10, 24);
                    gr.FillEllipse(brushRed, this.Position.X, this.Position.Y, 7, 7);
                    gr.FillEllipse(brushGray, this.Position.X, this.Position.Y + 7, 7, 7);
                    gr.FillEllipse(brushGray, this.Position.X, this.Position.Y + 14, 7, 7);
                    break;
                case 1:
                    gr.FillRectangle(brushBlack, this.Position.X-1, this.Position.Y-1, 10, 24);
                    gr.FillEllipse(brushRed, this.Position.X, this.Position.Y, 7, 7);
                    gr.FillEllipse(brushYellow, this.Position.X, this.Position.Y + 7, 7, 7);
                    gr.FillEllipse(brushGray, this.Position.X, this.Position.Y + 14, 7, 7);
                    break;
                case 2:
                    gr.FillRectangle(brushBlack, this.Position.X-1, this.Position.Y-1, 10, 24);
                    gr.FillEllipse(brushGray, this.Position.X, this.Position.Y, 7, 7);
                    gr.FillEllipse(brushYellow, this.Position.X, this.Position.Y + 7, 7, 7);
                    gr.FillEllipse(brushGray, this.Position.X, this.Position.Y + 14, 7, 7);
                    break;
                case 3:
                    gr.FillRectangle(brushBlack, this.Position.X-1, this.Position.Y-1, 10, 24);
                    gr.FillEllipse(brushGray, this.Position.X, this.Position.Y, 7, 7);
                    gr.FillEllipse(brushGray, this.Position.X, this.Position.Y + 7, 7, 7);
                    gr.FillEllipse(brushGreen, this.Position.X, this.Position.Y + 14, 7, 7);
                    break;
                default:
                    gr.FillRectangle(brushBlack, this.Position.X-1, this.Position.Y-1, 10, 24);
                    gr.FillEllipse(brushGray, this.Position.X, this.Position.Y, 7, 7);
                    gr.FillEllipse(brushGray, this.Position.X, this.Position.Y + 7, 7, 7);
                    gr.FillEllipse(brushGray, this.Position.X, this.Position.Y + 14, 7, 7);
                    break;

            }
        }

        protected virtual void OnLightChanged(EventArgs e)
        {
            EventHandler handler = LightChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
    }
    

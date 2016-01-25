using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficSimulator
{
    [Serializable]
    public partial class DebugWindow : Form
    {
        public DebugWindow()
        {
            InitializeComponent();
        }

        public void addLog(string log)
        {
            if (!debugLog.IsDisposed)
            {
                debugLog.AppendText(log + "\n");
            }
        }
    }
}

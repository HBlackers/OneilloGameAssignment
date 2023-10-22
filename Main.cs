using O_NeilloGame.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O_NeilloGame
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            LoadGame(flp_GameInfo);
            
        }
        public static void LoadGame(FlowLayoutPanel flp) 
        {
            ctrGameInfo Player1Info = new ctrGameInfo(1,"Player1",true);
            ctrGameInfo Player2Info = new ctrGameInfo(2,"Player2",false);
            flp.Controls.Add(Player1Info);
            flp.Controls.Add(Player2Info);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static O_neilloGame.Components.ctrToken;

namespace O_NeilloGame.Components
{
    public partial class ctrGameInfo : UserControl
    {
        public int _playerNum;
        public int _tokensOnBoard;
        public bool _playerTurn;
        public bool _winner;
        public string _playername;
        public ctrGameInfo(int PlayerNum, string PlayerName, bool PlayerTurn)
        {
            _playerNum = PlayerNum;
            _playerTurn = PlayerTurn;
            InitializeComponent();
            lblPlayerTurn.Visible = _playerTurn;
            txtPlayerName.Text = PlayerName;
        }


    }
}

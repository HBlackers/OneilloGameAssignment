using O_neilloGame;
using O_neilloGame.Services;
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
    public partial class Player : UserControl
    {
        public int PlayerNum;
        public int TokensOnBoards = 2;
        public bool PlayerTurn;
        public bool Winner;
        public string PlayerName;
        public TokenTypes PlayerColour;
        private readonly GameService _gameService;
        public Player(int playerNum, string playerName, bool playerTurn ,TokenTypes playerColour, GameService gameService)
        {
            PlayerNum = playerNum;
            PlayerTurn = playerTurn;
            PlayerName = playerName;
            _gameService = gameService;
            PlayerColour = playerColour;
            InitializeComponent();
            txtPlayerName.Text = playerName;
            lblPlayerTurn.Visible = playerTurn;
            lblPlayerTokenNum.Text = TokensOnBoards.ToString();
        }
        public void UpdatePlayer() 
        {
            UpdateTokenCount();
            UpdatePlayerTurn();
        }
        /// <summary>
        /// Updates players token count - called within tile clicked event
        /// </summary>
        private void UpdateTokenCount()
        {
            TokensOnBoards = 0;
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    if (_gameService.GameBoard[row, column].TokenColour == PlayerColour)
                    {
                        TokensOnBoards++;
                    }
                }
            }
            lblPlayerTokenNum.Text = TokensOnBoards.ToString();
        }
        /// <summary>
        /// Update display for who's turn it is
        /// </summary>
        private void UpdatePlayerTurn() 
        {
            //Update the player turn
            PlayerTurn = PlayerTurn ? false : true;
            lblPlayerTurn.Visible = PlayerTurn;
        }
    }
}

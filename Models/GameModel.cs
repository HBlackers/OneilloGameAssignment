using O_neilloGame.Components;
using O_NeilloGame.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O_neilloGame.Models
{
    public class GameModel
    {
        #region Properties
        /// <summary>
        /// Instance of current gameboard
        /// </summary>
        private ctrToken[,] GameBoard = new ctrToken[8, 8];
        /// <summary>
        /// current instances of players
        /// </summary>
        private Player Player1;
        private Player Player2;
        #endregion
        #region Constructor
        public GameModel(ctrToken[,] gameBoard, Player player1, Player player2)
        {
            GameBoard = gameBoard;
            Player1 = player1;
            Player2 = player2;
        }
        #endregion
    }
}

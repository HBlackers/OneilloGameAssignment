using O_neilloGame.Common.Enums;
using O_neilloGame.Components;

namespace O_neilloGame.Models
{
    /// <summary>
    /// Stores an instance of a sqaure on a board
    /// </summary>
    public class TokenModel
    {
        #region Properties
        /// <summary>
        /// State of the token
        /// </summary>
        public TokenTypes.TokenType TokenColour;
        /// <summary>
        /// Instance of player
        /// </summary>
        public PlayerModel Player1;
        /// <summary>
        /// Instance of player
        /// </summary>
        public PlayerModel Player2;
        /// <summary>
        /// Tiles on intialisation are all set to illegal , this gets changed based on the legal moves function
        /// </summary>
        public bool Legal;
        /// <summary>
        /// coordinates of the tile on the gameboard array on the x axis
        /// </summary>
        public int XCoord;
        /// <summary>
        /// coordinates of the tile on the gameboard array on the y axis
        /// </summary>
        public int YCoord;
        #endregion
        #region Constructors
        /// <summary>
        /// Used During JSON Deserialization
        /// </summary>
        public TokenModel() { }
        /// <summary>
        /// Used to transfer backend properties of the each sqaure in the gameboard 
        /// </summary>
        /// <param name="ctrToken"></param>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        public TokenModel(ctrToken ctrToken, PlayerModel player1 , PlayerModel player2) 
        {
            TokenColour = ctrToken.TokenColour;
            Legal = ctrToken.Legal;
            XCoord = ctrToken.XCoord;
            YCoord = ctrToken.YCoord;
            Player1 = player1;
            Player2 = player2;
        }
        #endregion
    }
}

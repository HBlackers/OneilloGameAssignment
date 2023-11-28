using O_neilloGame.Common.Enums;
using O_NeilloGame.Components;

namespace O_neilloGame.Models
{
    /// <summary>
    /// Stores an instance of a player
    /// </summary>
    public class PlayerModel
    {
        #region Propeties
        // <summary>
        /// Number to identify player , player1 or player2
        /// </summary>
        public int PlayerNum;
        /// <summary>
        /// number of tokens on the gameboard
        /// </summary>
        public int TokensOnBoards;
        /// <summary>
        /// players turn
        /// </summary>
        public bool PlayerTurn;
        /// <summary>
        /// stores if the player has won
        /// </summary>
        public bool Winner;
        /// <summary>
        /// player's name
        /// </summary>
        public string PlayerName;
        /// <summary>
        /// colour player is using can only be black or white
        /// </summary>
        public TokenTypes.TokenType PlayerColour;
        #endregion
        #region Constructors
        /// <summary>
        /// Used During JSON Deserialization
        /// </summary>
        public PlayerModel() 
        {
        
        }
        /// <summary>
        /// Used to Transfer backend properties of current instances of players
        /// </summary>
        /// <param name="player"></param>
        public PlayerModel(Player player) 
        {
            PlayerName = player.PlayerName;
            PlayerNum = player.PlayerNum;
            PlayerColour = player.PlayerColour;
            PlayerTurn = player.PlayerTurn;
            Winner = player.Winner;
            TokensOnBoards = player.TokensOnBoards;
        }
        #endregion
    }
}

using O_neilloGame.Services;

namespace O_neilloGame.Models
{
    /// <summary>
    /// Stores an instance of a saved game
    /// </summary>
    public class GameModel
    {
        #region Properties
        /// <summary>
        /// Name of Game Instance
        /// </summary>
        public string GameName;
        /// <summary>
        /// GameBoard
        /// </summary>
        public TokenModel[,] GameBoard;
        private readonly GameService _gameservice;
        #endregion
        #region Constructors
        /// <summary>
        /// Used During JSON Deserialization
        /// </summary>
        public GameModel(){ }
        /// <summary>
        /// Used to transfer the current games backend properties into the model for serialization
        /// </summary>
        /// <param name="gameService"></param>
        public GameModel(GameService gameService) 
        {
            _gameservice = gameService;
            GameName = _gameservice.GameName;
            GameBoard = _gameservice.GameBoardModel;
        }
        #endregion
    }
}
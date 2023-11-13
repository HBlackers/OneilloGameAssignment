using O_neilloGame.Components;
using O_neilloGame.Services;
using O_NeilloGame.Components;

namespace O_neilloGame.Models
{
    public class GameModel
    {
        #region Properties
        private string _gameName;
        private ctrToken[,] _gameBoard;
        private Player _player1;
        private Player _player2;
        private readonly GameService _gameservice;
        public GameModel(GameService gameService) 
        {
            _gameservice = gameService;
            _gameName = _gameservice.GameName;
            _gameBoard = _gameservice.GameBoard;

        }
        #endregion
    }
}

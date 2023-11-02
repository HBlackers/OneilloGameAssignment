using O_neilloGame;
using O_neilloGame.Services;
using O_NeilloGame.Components;

namespace O_NeilloGame
{
    public partial class Main : Form
    {
        private readonly GameService _gameService;

        public Main(GameService gameService)
        {
            InitializeComponent();
            _gameService = gameService;
            LoadGame();
           
        }
        private void LoadGame()
        {   
            Player Player1Info = new Player(1,"Player1",true,TokenTypes.black,_gameService);
            Player Player2Info = new Player(2,"Player2",false,TokenTypes.white,_gameService);
            flpGameInfo.Controls.Add(Player1Info);
            flpGameInfo.Controls.Add(Player2Info);
            _gameService.GenerateBoard(tlpGameBoard,Player1Info, Player2Info);
            _gameService.GetLegalMoves(Player1Info);
        }
    }
}

using O_neilloGame.Properties;
using O_neilloGame.Services;
using O_NeilloGame.Components;

namespace O_neilloGame.Components
{
    public partial class ctrToken : UserControl
    {
        #region Properties
        /// <summary>
        /// State of the token
        /// </summary>
        public TokenTypes TokenColour = TokenTypes.none;
        /// <summary>
        /// The two players
        /// </summary>
        public Player Player1;
        public Player Player2;
        /// <summary>
        /// Tiles on intialisation are all set to illegal , this gets changed based on the legal moves function
        /// </summary>
        public bool Legal = false;
        /// <summary>
        /// coordinates of the tile on the gameboard array
        /// </summary>
        public int XCoord;
        public int YCoord;
        private readonly GameService _gameService;
        #endregion
        #region Constructor
        /// <summary>
        /// Both players and game service needs to be passed through to instantiate a token
        /// </summary>
        /// <param name="player1">Required</param>
        /// <param name="player2"></param>
        /// <param name="gameService"></param>
        public ctrToken(Player player1, Player player2, GameService gameService)
        {
            Player1 = player1;
            Player2 = player2;
            _gameService = gameService;
            InitializeComponent();
        }
        #endregion
        #region Click Event Handler
        /// <summary>
        /// Tile click event handler that checks the tile clicked is a legal move.
        ///If it is , it will update the tiles on the board and the next stage of the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TileClicked(object sender, EventArgs e)
        {
            // if the tile is a legal move
            if (Legal)
            {
                //change the colour of the tile clicked
                GameService.ChangeTokenDisplayColour(Player1.PlayerTurn ? Player1 : Player2, this);
                //list of tokens that need to be changed
                List<ctrToken> TokensToFlip = _gameService.FindFlippableTokens(this);
                foreach (var Token in TokensToFlip)
                {
                    GameService.ChangeTokenDisplayColour(Player1.PlayerTurn ? Player1 : Player2, Token);

                }
                //Update Players
                Player1.UpdatePlayer();
                Player2.UpdatePlayer();
                //Update legal moves
                _gameService.GetLegalMoves(Player1.PlayerTurn ? Player1 : Player2);
            }
        }
        #endregion
    }
}

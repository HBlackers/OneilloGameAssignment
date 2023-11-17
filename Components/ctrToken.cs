using O_neilloGame.Common.Enums;
using O_neilloGame.Services;
using O_NeilloGame.Components;

namespace O_neilloGame.Components
{
    /// <summary>
    /// Represents each Sqaure on the Board
    /// </summary>
    public partial class ctrToken : UserControl
    {
        #region Properties
        /// <summary>
        /// State of the token
        /// </summary>
        public TokenTypes.TokenType TokenColour = TokenTypes.TokenType.none;
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
        /// coordinates of the tile on the gameboard array on x axis
        /// </summary>
        public int XCoord;
        /// <summary>
        /// coordinates of the tile on the gameboard array on y axis
        /// </summary>
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
            Player1.txtPlayerName.ReadOnly = true;
            Player2.txtPlayerName.ReadOnly = true;
            // if the tile is a legal move
            if (Legal)
            {
                var CurrentPlayer = Player1.PlayerTurn ? Player1 : Player2;
                var OppossitePlayer = Player1.PlayerTurn ? Player2 : Player1;
                //change the colour of the tile clicked
                GameService.ChangeTokenDisplayColour(CurrentPlayer, this);
                //list of tokens that need to be changed
                List<ctrToken> TokensToFlip = _gameService.FindFlippableTokens(this);
                foreach (var Token in TokensToFlip)
                {
                    GameService.ChangeTokenDisplayColour(CurrentPlayer, Token);

                }
                //Update Players
                CurrentPlayer.UpdatePlayer();
                OppossitePlayer.UpdatePlayer();
                //Update legal moves
                _gameService.GetLegalMoves(OppossitePlayer);
                //if there are no legal moves for the current player
                bool MovesforOppossition = _gameService.CheckMovesForCurrentPlayer(OppossitePlayer);
                if (!MovesforOppossition)
                {
                    //check for the other player
                    _gameService.GetLegalMoves(CurrentPlayer);
                    bool MovesforCurrent = _gameService.CheckMovesForCurrentPlayer(CurrentPlayer);
                    if (!MovesforCurrent)
                    {
                        //if no legal moves exist for both player then the game is done
                        _gameService.GetWinner(Player1, Player2);
                    }
                    else
                    {
                        CurrentPlayer.UpdatePlayer();
                        OppossitePlayer.UpdatePlayer();
                        CurrentPlayer.StateTurn();
                    }
                }
                else
                {
                    OppossitePlayer.StateTurn();
                }
            }
        }
        #endregion
    }
}

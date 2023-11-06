using O_neilloGame;
using O_neilloGame.Services;
using System.Speech.Synthesis;
namespace O_NeilloGame.Components
{
    public partial class Player : UserControl
    {
        #region Properties
        /// <summary>
        /// Number to identify player , player1 or player2
        /// </summary>
        public int PlayerNum;
        /// <summary>
        /// number of tokens on the gameboard
        /// </summary>
        public int TokensOnBoards = 2;
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
        public TokenTypes PlayerColour;
        /// <summary>
        /// Determines wether speak setting is enabled
        /// </summary>
        public bool Speak = false;
        private readonly GameService _gameService;
        #endregion
        #region Constructor
        public Player(int playerNum, string playerName, bool playerTurn, TokenTypes playerColour, GameService gameService)
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
        #endregion
        #region UpdatePlayerDetails
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
        public void UpdatePlayerTurn()
        {
            //Update the player turn
            PlayerTurn = PlayerTurn ? false : true;
            lblPlayerTurn.Visible = PlayerTurn;
        }
        #endregion
        #region StatePlayersTurn
        public void StateTurn()
        {
            if (PlayerTurn && Speak)
            {
                SpeechSynthesizer Synthesizer = new SpeechSynthesizer();
                Synthesizer.Volume = 100;
                Synthesizer.Rate = 1;
                Synthesizer.SpeakAsync(PlayerName + " Turn");
            }
        }
        #endregion
        #region PlayerNameChangedEventHandler
        private void txtPlayerName_TextChanged(object sender, EventArgs e)
        {
            PlayerName = txtPlayerName.Text;
        }
        #endregion
    }
}

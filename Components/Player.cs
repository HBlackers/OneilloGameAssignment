using O_neilloGame.Common.Enums;
using O_neilloGame.Properties;
using O_neilloGame.Services;
using System.Speech.Synthesis;
namespace O_NeilloGame.Components
{
    /// <summary>
    /// Represents the player in the game and displays players details in game
    /// </summary>
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
        public TokenTypes.TokenType PlayerColour;
        private readonly GameService _gameService;
        #endregion
        #region Constructor
        public Player(int playerNum, string playerName, bool playerTurn, TokenTypes.TokenType playerColour, GameService gameService)
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
            OutputPlayerColour();
        }
        #endregion
        #region UpdatePlayerDetails
        /// <summary>
        /// Displays the players token colour to the user
        /// </summary>
        public void OutputPlayerColour()
        {
            switch (PlayerColour)
            {
                case TokenTypes.TokenType.black:
                    imgPlayerTokenColour.Image = Resources.BlackToken;
                    break;
                case TokenTypes.TokenType.white:
                    imgPlayerTokenColour.Image = Resources.WhiteToken;
                    break;
            }
            imgPlayerTokenColour.SizeMode = PictureBoxSizeMode.Zoom;
        }
        /// <summary>
        /// Handles updating the players turn and token count during the game
        /// </summary>
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
        /// Update Player's turn
        /// </summary>
        public void UpdatePlayerTurn()
        {
            //Update the player turn
            PlayerTurn = PlayerTurn ? false : true;
            lblPlayerTurn.Visible = PlayerTurn;
        }
        #endregion
        #region RestorePlayerDetails
        /// <summary>
        /// Restores the player turn property and updates the display to the user
        /// </summary>
        /// <param name="turn">true/false, sets the players turn</param>
        public void RestoreplayerTurn(bool turn) 
        {
            //Update the player turn
            PlayerTurn = turn;
            lblPlayerTurn.Visible = turn;
        }
        /// <summary>
        /// Restores the player's name and displays it to the user
        /// </summary>
        /// <param name="name"></param>
        public void RestorePlayerName(string name) 
        {
            txtPlayerName.Text = name;
            txtPlayerName.ReadOnly = true;
            PlayerName = name;
        }
        /// <summary>
        /// Restores tokens on board property for the user and updates the number displayed
        /// </summary>
        /// <param name="tokens"></param>
        public void RestoreTokensOnBoard(int tokens) 
        {
            TokensOnBoards = tokens;
            lblPlayerTokenNum.Text = tokens.ToString();
        }
        #endregion
        #region PlayerNameChangedEventHandler
        /// <summary>
        /// Sets the playername property to the value inputted in the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPlayerName_TextChanged(object sender, EventArgs e)
        {
            PlayerName = txtPlayerName.Text;
        }
        #endregion
    }
}

using O_neilloGame.Components;
using O_neilloGame.Services;
using O_NeilloGame.Components;
using O_neilloGame.Forms;
using O_neilloGame.Common.Enums;

namespace O_NeilloGame
{
    public partial class Main : Form
    {
        private readonly GameService _gameService;
        private Player _player1;
        private Player _player2;
        private MiniForm _miniForm;
        public Main(GameService gameService)
        {
            InitializeComponent();
            _gameService = gameService;
            _player1 = new Player(1, "Player1", true, TokenTypes.TokenType.black, _gameService);
            _player2 = new Player(2, "Player2", false, TokenTypes.TokenType.white, _gameService);
            LoadGame();
        }
        #region ClickEvents
        #region Help
        /// <summary>
        /// Opens About Feature
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void About_Click(object sender, EventArgs e)
        {
            CreateForm(ModalFormType.Purpose.About);
        }
        #endregion
        #region Settings
        /// <summary>
        /// Hides/Unhides the information panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Information_Click(object sender, EventArgs e)
        {
            flpGameInfo.Visible = !flpGameInfo.Visible;
            informationPanelToolStripMenuItem.Checked = flpGameInfo.Visible;
        }
        /// <summary>
        /// Turns on/off the speech feature
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Speak_Click(object sender, EventArgs e)
        {
            //Sets speak property to the oppossite of what it currently is for both players
            _player1.Speak = !_player1.Speak;
            _player2.Speak = !_player2.Speak;
            //changes the checked box
            speakToolStripMenuItem.Checked = !speakToolStripMenuItem.Checked;
            //states the players turn
            _player1.StateTurn();
            _player2.StateTurn();
        }
        #endregion
        #region Game
        /// <summary>
        /// Opens Save Feature
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveGame_Click(object sender, EventArgs e)
        {
            CreateForm(ModalFormType.Purpose.RestoreGame);
        }
        /// <summary>
        /// Closes the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitGame_Click(object sender, EventArgs e)
        {
            switch (SaveGamePrompt())
            {
                case DialogResult.Yes:
                    CreateForm(ModalFormType.Purpose.SaveGame);
                    WipeGame();
                    break;
                case DialogResult.No:
                    Dispose();
                    break;
            }
        }
        /// <summary>
        /// Creates a New Game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGame_Click(object sender, EventArgs e)
        {
            switch (SaveGamePrompt())
            {
                case DialogResult.Yes:
                    CreateForm(ModalFormType.Purpose.SaveGame);
                    WipeGame();
                    break;
                case DialogResult.No:
                    WipeGame();
                    break;
            }
        }
        /// <summary>
        /// Opens Restore Game Feature
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestoreGame_Click(object sender, EventArgs e)
        {
            CreateForm(ModalFormType.Purpose.RestoreGame);
        }
        #endregion
        #endregion
        #region CreateModalForm
        /// <summary>
        /// Creates Modal Form
        /// </summary>
        private void CreateForm(ModalFormType.Purpose purpose)
        {
            _miniForm = new MiniForm(_gameService, purpose);
            _miniForm.ShowDialog();
        }
        #endregion
        /// <summary>
        ///Loads the game
        /// </summary>
        private void LoadGame()
        {
            flpGameInfo.Controls.Add(_player1);
            flpGameInfo.Controls.Add(_player2);
            _gameService.GenerateBoard(tlpGameBoard, _player1, _player2);
            _gameService.GetLegalMoves(_player1);
        }
        /// <summary>
        /// Wipes game and loads up a new game
        /// </summary>
        private void WipeGame()
        {
            _gameService.GameBoard = new ctrToken[8, 8];
            _player1 = new Player(1, "Player1", true, TokenTypes.TokenType.black, _gameService);
            _player2 = new Player(2, "Player2", false, TokenTypes.TokenType.white, _gameService);
            flpGameInfo.Controls.Clear();
            tlpGameBoard.Controls.Clear();
            LoadGame();
        }
        #region UserNotification
        /// <summary>
        /// Prompts the user to save the game if they are exiting the application or starting a new game
        /// </summary>
        /// <returns>Returns the users choice</returns>
        private DialogResult SaveGamePrompt()
        {
            return MessageBox.Show("Would you like to save the game", "Start New Game", MessageBoxButtons.YesNoCancel);
        }
        #endregion
    }
}
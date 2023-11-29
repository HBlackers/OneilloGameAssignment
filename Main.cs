using O_neilloGame.Services;
using O_neilloGame.Forms;
using O_neilloGame.Common.Enums;
using O_neilloGame.Common.Helpers;

namespace O_NeilloGame
{
    public partial class Main : Form
    {
        private readonly GameService _gameService;
        private readonly SettingsService _settingsService;
        private MiniForm _miniForm;
        public Main(GameService gameService, SettingsService settingsService)
        {
            InitializeComponent();
            _gameService = gameService;
            _settingsService = settingsService;
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
            _settingsService.ShowInfoPanel = !_settingsService.ShowInfoPanel;
            flpGameInfo.Visible = !flpGameInfo.Visible;
            informationPanelToolStripMenuItem.Checked = !informationPanelToolStripMenuItem.Checked;
        }
        /// <summary>
        /// Turns on/off the speech feature
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Speak_Click(object sender, EventArgs e)
        {
            //Sets speak property to the oppossite of what it currently is for both players
            _settingsService.Speak = !_settingsService.Speak;
            //changes the checked box
            speakToolStripMenuItem.Checked = !speakToolStripMenuItem.Checked;
            //states the players turn
            _settingsService.StateTurn(_gameService.Player1);
            _settingsService.StateTurn(_gameService.Player2);
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
            CreateForm(ModalFormType.Purpose.SaveGame);
            restoreGameToolStripMenuItem.Enabled = true;
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
                    restoreGameToolStripMenuItem.Enabled = true;
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
                    restoreGameToolStripMenuItem.Enabled = true;
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
            WipeGame();
            CreateForm(ModalFormType.Purpose.RestoreGame);
        }
        #endregion
        #endregion
        #region CreateModalForm
        /// <summary>
        /// Creates Modal Form
        /// </summary>
        public void CreateForm(ModalFormType.Purpose purpose)
        {
            _miniForm = new MiniForm(_gameService,_settingsService,purpose,this);
            _miniForm.ShowDialog();
        }
        #endregion
        /// <summary>
        ///Loads the game
        /// </summary>
        private void LoadGame()
        {
            var applicationModel = GameHelper.GetSavedApplication();
            if (applicationModel != null)
            {
                _settingsService.RestoreSettings(applicationModel.Settings);
            }
            else
            {
                _settingsService.RestoreSettings(null);
                restoreGameToolStripMenuItem.Enabled = false;
            }
            _gameService.GenerateBoard(tlpGameBoard);
            _gameService.GetLegalMoves(_gameService.Player1);
            flpGameInfo.Controls.Add(_gameService.Player1);
            flpGameInfo.Controls.Add(_gameService.Player2);
            informationPanelToolStripMenuItem.Checked = _settingsService.ShowInfoPanel;
            flpGameInfo.Visible = _settingsService.ShowInfoPanel;
            speakToolStripMenuItem.Checked = _settingsService.Speak;
            _settingsService.StateTurn(_gameService.Player1.PlayerTurn ? _gameService.Player1 : _gameService.Player2);
        }
        /// <summary>
        /// Wipes game and loads up a new game
        /// </summary>
        private void WipeGame()
        {
            _gameService.ResetGame();
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
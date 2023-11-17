using O_neilloGame.Common.Helpers;
using O_neilloGame.Models;
using O_neilloGame.Services;

namespace O_neilloGame.Components
{
    /// <summary>
    /// Handles all logic for saving games
    /// </summary>
    public partial class ctrSaveGame : UserControl
    {
        #region Properties
        /// <summary>
        /// All Games currently saved
        /// </summary>
        private List<GameModel> _savedGameModels;
        /// <summary>
        /// current game the user wants to save
        /// </summary>
        private GameModel _currentGame;
        /// <summary>
        /// prompt or warning to the user
        /// </summary>
        private DialogResult _prompt;
        /// <summary>
        /// Component of _prompt
        /// </summary>
        private string _message;
        /// <summary>
        /// Component of _prompt
        /// </summary>
        private string _caption;
        /// <summary>
        /// Component of _prompt
        /// </summary>
        private MessageBoxButtons _buttons;
        private bool _saveValid = false;
        private bool _savedModelsExist = false;
        private readonly GameService _gameService;
        #endregion
        #region Constructor
        public ctrSaveGame(GameService gameService)
        {
            _gameService = gameService;
            InitializeComponent();
            OutputSavedGames();
        }
        #endregion
        #region UpdateUi
        /// <summary>
        /// Fill the combo box with the names of existing saved games
        /// </summary>
        private void OutputSavedGames()
        {
            _savedGameModels = GameHelper.GetSavedGames();
            if (_savedGameModels != null)
            {
                foreach (var Game in _savedGameModels)
                {
                    cmbSavedGames.Items.Add(Game.GameName);
                }
                _savedModelsExist = true;
            }
        }
        #endregion
        #region SetGameName
        /// <summary>
        /// Check to see if the user has inputted a name for the game instance
        /// </summary>
        private void CheckSaveName()
        {
            if (!string.IsNullOrEmpty(txtGameNameInput.Text))
            {
                _gameService.SetGameName(txtGameNameInput.Text);
            }
            else
            {
                _gameService.SetGameName(DateTime.Now.ToString("g"));
            }
        }
        #endregion
        #region UserNotifications
        /// <summary>
        /// Prompt allowing the user to confirm wether they want to overwrite an existing saved game
        /// </summary>
        private void CreateOverwriteConfirmPrompt()
        {
            _message = "SavedGame found with same name as current,\nwould you like to overwrite this save?";
            _caption = "Overwrite game";
            _buttons = MessageBoxButtons.YesNo;
            _prompt = MessageBox.Show(_message, _caption, _buttons);
        }
        /// <summary>
        /// Warning to the user that they have the maximum saved games
        /// </summary>
        private void TooManySavedGamesExistWarning()
        {
            _message = "You have the maximum amount of games Saved,\nSelect a game to overwrite";
            _caption = "Too many saved games";
            _prompt = MessageBox.Show(_message, _caption);
        }
        /// <summary>
        /// Notifies the user that the game has been saved
        /// </summary>
        private void GameSavedNotification()
        {
            _caption = "game saved";
            _prompt = MessageBox.Show(_caption);
        }
        #endregion
        #region SaveEventHanlder
        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            CheckSaveName();
            _gameService.CreateModels();
            _currentGame = new GameModel(_gameService);
            if (_savedModelsExist)
            {
                bool IsDuplicate = GameHelper.CheckDuplicates(_currentGame, _savedGameModels);
                if (!IsDuplicate && cmbSavedGames.SelectedItem == null)
                {
                    if (_savedGameModels.Count >= 5)
                    {
                        TooManySavedGamesExistWarning();
                    }
                    else
                    {
                        _savedGameModels.Add(_currentGame);
                        _saveValid = true;
                    }
                }
                else if (!IsDuplicate && cmbSavedGames.SelectedItem != null)
                {
                    _saveValid = true;
                    GameHelper.OverwriteSave(cmbSavedGames.SelectedItem.ToString(), _currentGame, _savedGameModels);
                }
                else
                {
                    CreateOverwriteConfirmPrompt();
                    if (_prompt == DialogResult.Yes)
                    {
                        _saveValid = true;
                        GameHelper.OverwriteSave(_currentGame, _savedGameModels);
                    }
                }
            }
            else
            {
                _savedGameModels = new List<GameModel> { _currentGame };
                _saveValid = true;
            }
            if (_saveValid)
            {
                GameHelper.SaveGame(_savedGameModels);
                GameSavedNotification();
                ParentForm.Dispose();
            }
        }
        #endregion
    }
}
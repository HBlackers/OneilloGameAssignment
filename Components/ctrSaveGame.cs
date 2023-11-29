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
        /// All Games currently saved and saved settings 
        /// </summary>
        private ApplicationModel _applicationModel;
        /// <summary>
        /// current game the user wants to save
        /// </summary>
        private GameServiceModel _currentGame;
        /// <summary>
        /// Settings the user has set to be saved
        /// </summary>
        private SettingsServiceModel _settingsModel;
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
        /// <summary>
        /// Determines wether the application should save to Game_Data.json
        /// </summary>
        private bool _saveValid = false;
        /// <summary>
        /// Determines wether there any existing saves in Game_Data.json
        /// </summary>
        private bool _savedModelsExist = false;
        private readonly GameService _gameService;
        private readonly SettingsService _settingsService;
        #endregion
        #region Constructor
        public ctrSaveGame(GameService gameService, SettingsService settingsService)
        {
            _gameService = gameService;
            _settingsService = settingsService;
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
            _applicationModel = GameHelper.GetSavedApplication();
            if (_applicationModel != null)
            {
                foreach (var Game in _applicationModel.Games)
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
            //creates model of gameboard
            _gameService.CreateModels();
            //creates models for game state and settings state
            _currentGame = new GameServiceModel(_gameService);
            _settingsModel = new SettingsServiceModel(_settingsService);
            //if there any existing saves
            if (_savedModelsExist)
            {
                //checks for duplicates
                bool IsDuplicate = GameHelper.CheckDuplicates(_currentGame, _applicationModel.Games);
                //if it is not a duplicate and the user has not selected an save to overwrite
                if (!IsDuplicate && cmbSavedGames.SelectedItem == null)
                {
                    //if the number of exisitng saves is 5 or over
                    if (_applicationModel.Games.Count >= 5)
                    {
                        TooManySavedGamesExistWarning();
                    }
                    else
                    {
                        //adds new save
                        _applicationModel.Games.Add(_currentGame);
                        _saveValid = true;
                    }
                }
                //if the user has selected a save to overwrite and it is not a duplicate
                else if (cmbSavedGames.SelectedItem != null)
                {
                    _saveValid = true;
                    //replaces the save
                    GameHelper.OverwriteSave(cmbSavedGames.SelectedItem.ToString(), _currentGame, _applicationModel.Games);
                }
                else
                {
                    //user has set the new save name to an existing save name
                    CreateOverwriteConfirmPrompt();
                    if (_prompt == DialogResult.Yes)
                    {
                        _saveValid = true;
                        GameHelper.OverwriteSave(_currentGame, _applicationModel.Games);
                    }
                }
            }
            else
            {
                //creates a new list of game models containing the new game to save
                _applicationModel = new ApplicationModel { Games = new List<GameServiceModel> { _currentGame } };
                _saveValid = true;
            }
            if (_saveValid)
            {
                _applicationModel.Settings = _settingsModel;
                GameHelper.SaveGame(_applicationModel);
                GameSavedNotification();
                ParentForm.Dispose();
            }
        }
        #endregion
    }
}
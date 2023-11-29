using O_neilloGame.Common.Helpers;
using O_neilloGame.Models;
using O_neilloGame.Services;

namespace O_neilloGame.Components
{
    /// <summary>
    /// Restore feature handling the restoration of a previous game saved by the user
    /// </summary>
    public partial class ctrRestoreGame : UserControl
    {
        /// <summary>
        /// All saved games and settings
        /// </summary>
        private ApplicationModel _applicationModel;
        /// <summary>
        /// Used to determine wether any games exist
        /// </summary>
        private bool _savedModelsExist = false;
        private Form _mainForm;
        private readonly GameService _gameService;
        private readonly SettingsService _settingsService;
        public ctrRestoreGame(GameService gameService, SettingsService settingsService, Form mainForm)
        {
            _gameService = gameService;
            _settingsService = settingsService;
            _mainForm = mainForm;
            InitializeComponent();
            OutputSavedGames();
        }
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
                if (cmbSavedGames.Items.Count == 1)
                {
                    cmbSavedGames.SelectedItem = cmbSavedGames.Items[0];
                    cmbSavedGames.Enabled = false;
                }
                _savedModelsExist = true;
            }
        }
        #region Load Game EventHandler
        /// <summary>
        /// Initialises the loading of a previous game saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadGame_Click(object sender, EventArgs e)
        {
            if (_savedModelsExist)
            {
                GameServiceModel selectedGame = GameHelper.GetGame(cmbSavedGames.SelectedItem.ToString(), _applicationModel.Games);
                _gameService.RestoreGame(selectedGame);
                _mainForm.Refresh();
                ParentForm.Dispose();
            }
        }
        #endregion
    }
}

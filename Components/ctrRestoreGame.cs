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
        /// All Games currently saved
        /// </summary>
        private List<GameModel> _savedGameModels;
        /// <summary>
        /// Used to determine wether any games exist
        /// </summary>
        private bool _savedModelsExist = false;
        private readonly GameService _gameService;
        public ctrRestoreGame(GameService gameService)
        {
            _gameService = gameService;
            InitializeComponent();
            OutputSavedGames();
        }
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
                GameModel CurrentGame = GameHelper.GetGame(cmbSavedGames.SelectedItem.ToString(), _savedGameModels);
                _gameService.RestoreGame(CurrentGame);
                ParentForm.Dispose();
            }
        }
        #endregion
    }
}

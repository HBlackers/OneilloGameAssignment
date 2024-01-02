using O_neilloGame.Common.Enums;
using O_neilloGame.Components;
using O_neilloGame.Properties;
using O_neilloGame.Services;

namespace O_neilloGame.Forms
{
    /// <summary>
    /// Modal Form that output save game feature and help info feature
    /// </summary>
    public partial class MiniForm : Form
    {
        #region Properties
        private readonly GameService _gameService;
        private readonly SettingsService _settingsService;
        /// <summary>
        /// Instance of SaveForm
        /// </summary>
        private ctrSaveGame _saveGamePrompt;
        /// <summary>
        /// Instance of RestoreGameForm
        /// </summary>
        private ctrRestoreGame _restoreGamePrompt;
        /// <summary>
        /// Instance of the About Form
        /// </summary>
        private ctrAbout _aboutGamePrompt;
        /// <summary>
        /// Determines the MiniForms Purpose e.g. what feature to load up
        /// </summary>
        private ModalFormType.Purpose _pupose;
        /// <summary>
        /// Parent form
        /// </summary>
        private Form _mainForm;
        #endregion
        #region Constructor
        public MiniForm(GameService gameService,SettingsService settingsService,ModalFormType.Purpose purpose,Form mainForm)
        {
            
            _gameService = gameService;
            _settingsService = settingsService;
            InitializeComponent();
            _pupose = purpose;
            _mainForm = mainForm;
            LoadContent();
            Icon = Resources.PageIcon;
        }
        #endregion
        #region IdentifyFormFeature
        /// <summary>
        /// Loads up the feature 
        /// </summary>
        private void LoadContent()
        {
            switch (_pupose)
            {
                case ModalFormType.Purpose.SaveGame:
                    InitiateSave();
                    break;
                case ModalFormType.Purpose.RestoreGame:
                    InitiateRestore();
                    break;
                case ModalFormType.Purpose.About:
                    InitiateAbout();
                    break;
            }
        }
        #endregion
        #region LoadFeatures
        /// <summary>
        /// Initialises Save Feature
        /// </summary>
        private void InitiateSave()
        {
            _saveGamePrompt = new ctrSaveGame(_gameService,_settingsService);
            flpContent.Controls.Add(_saveGamePrompt);
            Text = "Save Game";
        }
        /// <summary>
        /// Initialises Restore Feature
        /// </summary>
        private void InitiateRestore()
        {
            _restoreGamePrompt = new ctrRestoreGame(_gameService,_settingsService,_mainForm);
            flpContent.Controls.Add(_restoreGamePrompt);
            Text = "Restore Game";
        }
        /// <summary>
        /// Initialises Restore Feature
        /// </summary>
        private void InitiateAbout()
        {
            _aboutGamePrompt = new ctrAbout();
            flpContent.Controls.Add(_aboutGamePrompt);
            Text = "About";
        }
        #endregion
    }
}

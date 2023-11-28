
using O_neilloGame.Services;

namespace O_neilloGame.Models
{
    public class SettingsServiceModel
    {
        #region Properties
        public bool Speak;
        public bool ShowInfoPanel;
        #endregion
        #region Constructors
        public SettingsServiceModel(SettingsService settingsService)
        {
            Speak = settingsService.Speak;
            ShowInfoPanel = settingsService.ShowInfoPanel;
        }
        public SettingsServiceModel() { }
        #endregion
    }
}

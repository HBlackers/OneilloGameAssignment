using O_neilloGame.Components;
using O_neilloGame.Models;
using O_NeilloGame.Components;
using System.Speech.Synthesis;


namespace O_neilloGame.Services
{
    public class SettingsService
    {
        public bool Speak;
        public bool ShowInfoPanel;
        public SpeechSynthesizer Synthesizer = new SpeechSynthesizer()
        {
            Volume = 100,
            Rate = 1
        };
        #region Speak
        /// <summary>
        /// Speaks the user's turn
        /// </summary>
        public void StateTurn(ctrPlayer player)
        {
            if (Speak && player.PlayerTurn)
            { 
                Synthesizer.SpeakAsync(player.PlayerName + " Turn");
            }
        }
        /// <summary>
        /// Speaks the location of a the token clicked
        /// </summary>
        /// <param name="tokenClicked">sqaure clicked by user</param>
        public void StateTokenPlaced(ctrToken tokenClicked) 
        {
            if (Speak)
            {
                Synthesizer.SpeakAsync("Token placed at row" + tokenClicked.XCoord + "column" + tokenClicked.YCoord);
            }
        }
        #endregion
        public void RestoreSettings(SettingsServiceModel settingsServiceModel) 
        {
            //if no saved settings exist , sets the settings to their default
            if (settingsServiceModel == null)
            {
                Speak = false;
                ShowInfoPanel = true;
            }
            else 
            {
                Speak = settingsServiceModel.Speak;
                ShowInfoPanel = settingsServiceModel.ShowInfoPanel;
            }
        }
    }
}

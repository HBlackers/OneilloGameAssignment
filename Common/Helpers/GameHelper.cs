using Newtonsoft.Json;
using O_neilloGame.Models;

namespace O_neilloGame.Common.Helpers
{
    /// <summary>
    /// Provides functionality to save and overwrite games
    /// </summary>
    public static class GameHelper
    {
        /// <summary>
        /// Reads Game_Data.json and collects all saved games
        /// </summary>
        /// <returns>List of saved games or null if no data is found</returns>
        public static ApplicationModel? GetSavedApplication()
        {
            try
            {
                string Json = File.ReadAllText("ApplicationModel.json");
                //only returns the games not the settings as they are not needed
                return JsonConvert.DeserializeObject<ApplicationModel>(Json);
            }
            catch (JsonSerializationException)
            {
                return null;
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }
        /// <summary>
        /// Saves all games and the saved settings
        /// </summary>
        /// <param name="applicationModel">List of games to be written to the file</param>
        public static void SaveGame(ApplicationModel applicationModel)
        {
            string Data = JsonConvert.SerializeObject(applicationModel);
            string file = "ApplicationModel.json";
            File.WriteAllText(file, Data);
        }
        /// <summary>
        /// Checks wether the game to be saved name already exists
        /// </summary>
        /// <param name="currentGame">Current game to be saved</param>
        /// <param name="savedGames">List of all games that have already been saved</param>
        /// <returns>true/false depending on wether a duplicate exists</returns>
        public static bool CheckDuplicates(GameServiceModel currentGame, List<GameServiceModel> savedGames)
        {
            return savedGames.Any(x => x.GameName == currentGame.GameName);
        }
        /// <summary>
        /// Overwrite an existing game of the same game name as the current game 
        /// </summary>
        /// <param name="currentGame">Instance of the current game to be saved</param>
        /// <param name="savedGames">All of the games currently saved within Game_Data.json</param>
        public static void OverwriteSave(GameServiceModel currentGame, List<GameServiceModel> savedGames)
        {
            for (int i = 0; i < savedGames.Count; i++)
            {
                if (savedGames[i].GameName == currentGame.GameName)
                {
                    savedGames[i] = currentGame;
                    break;
                }
            }
        }
        /// <summary>
        /// Overwrite a game saved selected by the user
        /// </summary>
        /// <param name="selectedGameName">Name of the saved game selected by the user</param>
        /// <param name="currentGame">Instance of the current game to save</param>
        /// <param name="savedGames">All of the games currently saved within Game_Data.json</param>
        public static void OverwriteSave(string selectedGameName, GameServiceModel currentGame, List<GameServiceModel> savedGames)
        {
            for (int i = 0; i < savedGames.Count; i++)
            {
                if (savedGames[i].GameName == selectedGameName)
                {
                    savedGames[i] = currentGame;
                    break;
                }
            }
        }
        /// <summary>
        /// Gets the Game Model Selected by the user
        /// </summary>
        /// <param name="selectedGameName">Name of the game the user has selected</param>
        /// <param name="savedGames">List of saved games</param>
        public static GameServiceModel GetGame(string selectedGameName, List<GameServiceModel> savedGames)
        {
            int Index;
            for (Index = 0; Index < savedGames.Count; Index++)
            {
                if (savedGames[Index].GameName == selectedGameName)
                {
                    break;
                }
            }
            return savedGames[Index];
        }
    }
}

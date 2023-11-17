using Newtonsoft.Json;
using O_neilloGame.Models;
using System.CodeDom;

namespace O_neilloGame.Common.Helpers
{
    /// <summary>
    /// Provides functionality to save and overwrite games
    /// </summary>
    public static class GameHelper
    {
        /// <summary>
        /// Reads Game_Data.json and collects all saved data
        /// </summary>
        /// <returns>List of saved games or null if no data is found</returns>
        public static List<GameModel>? GetSavedGames()
        {
            string Json = File.ReadAllText("Game_Data.json");
            try
            {
                return JsonConvert.DeserializeObject<List<GameModel>>(Json);
            }
            catch (JsonSerializationException)
            {
                return null;
            }
        }
        /// <summary>
        /// Saves the game instance
        /// </summary>
        /// <param name="games">List of games to be written to the file</param>
        public static void SaveGame(List<GameModel> games)
        {
            string Data = JsonConvert.SerializeObject(games);
            string file = "Game_Data.json";
            File.WriteAllText(file, Data);
        }
        /// <summary>
        /// Checks wether the game to be saved name already exists
        /// </summary>
        /// <param name="currentGame">Current game to be saved</param>
        /// <param name="savedGames">List of all games that have already been saved</param>
        /// <returns>true/false depending on wether a duplicate exists</returns>
        public static bool CheckDuplicates(GameModel currentGame, List<GameModel> savedGames)
        {
            return savedGames.Any(x => x.GameName == currentGame.GameName);
        }
        /// <summary>
        /// Overwrite an existing game of the same game name as the current game 
        /// </summary>
        /// <param name="currentGame">Instance of the current game to be saved</param>
        /// <param name="savedGames">All of the games currently saved within Game_Data.json</param>
        public static void OverwriteSave(GameModel currentGame, List<GameModel> savedGames)
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
        public static void OverwriteSave(string selectedGameName, GameModel currentGame, List<GameModel> savedGames)
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
        public static GameModel GetGame(string selectedGameName, List<GameModel> savedGames)
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

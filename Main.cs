﻿using O_neilloGame;
using O_neilloGame.Components;
using O_neilloGame.Models;
using O_neilloGame.Services;
using O_NeilloGame.Components;
using Newtonsoft.Json;
namespace O_NeilloGame
{
    public partial class Main : Form
    {
        private readonly GameService _gameService;
        public Player Player1Info;
        public Player Player2Info;
        public Main(GameService gameService)
        {
            InitializeComponent();
            _gameService = gameService;
            Player1Info = new Player(1, "Player1", true, TokenTypes.black, _gameService);
            Player2Info = new Player(2, "Player2", false, TokenTypes.white, _gameService);
            LoadGame();
        }
        private void LoadGame()
        {
            flpGameInfo.Controls.Add(Player1Info);
            flpGameInfo.Controls.Add(Player2Info);
            _gameService.GenerateBoard(tlpGameBoard, Player1Info, Player2Info);
            _gameService.GetLegalMoves(Player1Info);
        }
        #region MainMenu
        #region Menu Help
        private void Information_Click(object sender, EventArgs e)
        {
            flpGameInfo.Visible = !flpGameInfo.Visible;
            informationPanelToolStripMenuItem.Checked = flpGameInfo.Visible;

        }

        private void Speak_Click(object sender, EventArgs e)
        {
            //Sets speak property to the oppossite of what it currently is for both players
            Player1Info.Speak = !Player1Info.Speak;
            Player2Info.Speak = !Player2Info.Speak;
            //changes the checked box
            speakToolStripMenuItem.Checked = !speakToolStripMenuItem.Checked;
            //states the players turn
            Player1Info.StateTurn();
            Player2Info.StateTurn();
        }
        #endregion
        #endregion
        #region Menu Game
        #region GameManagement
        private void WipeGame() 
        {
            _gameService.GameBoard = new ctrToken[8,8];
            Player1Info = new Player(1, "Player1", true, TokenTypes.black, _gameService);
            Player2Info = new Player(2, "Player2", false, TokenTypes.white, _gameService);
            flpGameInfo.Controls.Clear();
            tlpGameBoard.Controls.Clear();
            LoadGame();
        }
        private void SaveGame()
        {
            GameModel CurrentGame = new GameModel(_gameService);
            string Data = JsonConvert.SerializeObject(CurrentGame);
            string file = "game_data.json";
            File.WriteAllText(file, Data);
        }
        private void NewGame()
        {
            string Message = "Would you like to save the game";
            string Caption = "Start New Game";
            MessageBoxButtons Buttons = MessageBoxButtons.YesNoCancel;
            DialogResult Confirm = MessageBox.Show(Message, Caption, Buttons);

            if (Confirm == DialogResult.Yes)
            {
                SaveGame();
                WipeGame();
            }
            else if (Confirm == DialogResult.No)
            {
                WipeGame();
            }
        }
        #endregion
        #endregion

        private void NewGame_Click(object sender, EventArgs e)
        {
            NewGame();            
        }
    }
}
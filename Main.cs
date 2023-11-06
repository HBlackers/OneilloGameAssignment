using O_neilloGame;
using O_neilloGame.Services;
using O_NeilloGame.Components;

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
        public void LoadGame()
        {
            flpGameInfo.Controls.Add(Player1Info);
            flpGameInfo.Controls.Add(Player2Info);
            _gameService.GenerateBoard(tlpGameBoard, Player1Info, Player2Info);
            _gameService.GetLegalMoves(Player1Info);
        }

        private void Information_Click(object sender, EventArgs e)
        {
            flpGameInfo.Visible = !flpGameInfo.Visible;
            informationPanelToolStripMenuItem.Checked = flpGameInfo.Visible;

        }

        private void Speak_Click(object sender, EventArgs e)
        {
           //Sets speak property to the oppossite of what it currently is for both players
           Player1Info.Speak = !Player1Info.Speak;
           Player2Info.Speak= !Player2Info.Speak;
           //changes the checked box
           speakToolStripMenuItem.Checked= !speakToolStripMenuItem.Checked;
           //states the players turn
           Player1Info.StateTurn();
           Player2Info.StateTurn();
        }
    }
}

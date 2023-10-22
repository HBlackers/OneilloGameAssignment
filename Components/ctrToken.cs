using O_NeilloGame.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O_neilloGame.Components
{
    public partial class ctrToken : UserControl
    {
        private enum TokenTypes
        {
            none,
            black,
            white
        }
        private TokenTypes _tokenColour = TokenTypes.none;
        private ctrGameInfo _player1;
        private ctrGameInfo _player2;

        public ctrToken(ctrGameInfo Player1, ctrGameInfo Player2)
        {
            _player1 = Player1;
            _player2 = Player2;
            InitializeComponent();
        }
        private async void TileClicked(object sender, EventArgs e)
        {
            if (_tokenColour == TokenTypes.none)
            {
                if (_player1._playerTurn)
                {
                    _tokenColour = TokenTypes.black;
                }
                else if (_player2._playerTurn)
                {
                    _tokenColour = TokenTypes.white;
                }
                await ChangeTokenDisplayColour(_tokenColour);
                _player1._playerTurn = !_player1._playerTurn;
                _player2._playerTurn = !_player2._playerTurn;
            }
        }
        private async Task ChangeTokenDisplayColour(TokenTypes Colour)
        {
            switch (Colour)
            {
                case TokenTypes.black:
                    imgTile.Image = Image.FromFile("FilePath");
                    break;
                case TokenTypes.white:
                    imgTile.Image = Image.FromFile("FilePath");
                    break;
                default:
                    break;
            }
        }
    }
}

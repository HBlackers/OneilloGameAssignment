using O_neilloGame.Components;
using O_neilloGame.Properties;
using O_NeilloGame.Components;

namespace O_neilloGame.Services
{
    public class GameService
    {
        #region Properties
        /// <summary>
        /// 2D array storing instances that represent where tokens can be placed
        /// </summary>
        public ctrToken[,] GameBoard = new ctrToken[8,8];
        /// <summary>
        /// All the possible directions you can go according to the x axis
        /// </summary>
        private int[] _directionsx = { -1, -1, -1, 0, 1, 1, 1, 0 };
        /// <summary>
        /// All possible directions according to y axis
        /// </summary>
        private int[] _directionsY = { -1, 0, 1, 1, 1, 0, -1, -1 };
        #endregion
        #region GenerateGameBoard
        public void GenerateBoard(TableLayoutPanel tlp,Player Player1, Player Player2)
        {
            //add tokens to backend board and front end
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    //add instances to mygameboard
                    GameBoard[row, column] = new ctrToken(Player1, Player2, this) { Enabled = true, XCoord = row, YCoord = column };                    //adds token to specifc column index and row index of tlp
                    tlp.Controls.Add(GameBoard[row, column], row, column);
                }
            }
            //set four blocks in the middle to have token
            ChangeTokenDisplayColour(Player2, GameBoard[3, 3]);
            ChangeTokenDisplayColour(Player1, GameBoard[3, 4]);
            ChangeTokenDisplayColour(Player1, GameBoard[4, 3]);
            ChangeTokenDisplayColour(Player2, GameBoard[4, 4]);
        }
        #endregion
        #region LegalMovesOnBoard
        /// <summary>
        /// Iterates through the entire game board and calculates the legal moves for the current player
        /// </summary>
        /// <param name="player">Instance of player whos turn it is</param>
        public void GetLegalMoves(Player player)
        {
            ResetLegalMoves();
            //for every row and column in my gameboard
            for (int row = 0; row < 8; row++)
            {
                for (int column  = 0; column < 8; column++)
                {
                    // if we find an empty board cell
                    if (GameBoard[row, column].TokenColour == TokenTypes.none)
                    {
                        bool isValidMove = false;
                        for (int i = 0; i < 8; i++)
                        {
                            //iterate through every direction
                            int dx = _directionsx[i];
                            int dy = _directionsY[i];
                            //directions according to the index of the current empty cell we are checking is a valid move
                            int newX = row + dx;
                            int newY = column + dy;
                            // if the we are checking an edge piece of the cell we are checking which is around the empty cell is is an enemy player colour
                            if (newX >= 0 && newX < 8 && newY >= 0 && newY < 8 && 
                                GameBoard[newX, newY].TokenColour != player.PlayerColour && GameBoard[newX, newY].TokenColour != TokenTypes.none)
                            {
                                int Depth = 1;
                                while (true)
                                {
                                    //the depth of the direction we are checking e.g how far upwards etc
                                    newX = row + (Depth * dx);
                                    newY = column + (Depth * dy);
                                    //if the depth of that direction hits the edge of the board or we hit an empty board cell
                                    if (newX < 0 || newX >= 8 || newY < 0 || newY >= 8 || GameBoard[newX, newY].TokenColour == TokenTypes.none)
                                    {
                                        break;
                                    }
                                    //if the token colour is the current players colour that means the empty board cell is a legal move
                                    if (GameBoard[newX, newY].TokenColour == player.PlayerColour)
                                    {
                                        isValidMove = true;
                                        break;
                                    }
                                    Depth++;
                                }
                            }
                        }
                        //activates the board cell so the player can click on it 
                        if (isValidMove)
                        {
                            //make the cell a legal move and highlight it so the user can see it
                            GameBoard[row, column].BackColor = Color.WhiteSmoke;
                            GameBoard[row, column].Legal = true;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Resets the boards legal moves - occurs inside GetLegalMoves
        /// </summary>
        private void ResetLegalMoves() 
        {
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    GameBoard[row,column].Legal = false;
                    GameBoard[row, column].BackColor = Color.Black;
                }
            }
        }
        #endregion
        #region ChangingTokensOnBoard
        /// <summary>
        /// Searches in each direction of a clicked token for valid tokens that need to flipped 
        /// if they are trapped by 2 of the oppossite colour in each given direction
        /// </summary>
        /// <param name="TokenClicked">The token the current player has picked</param>
        /// <returns>returns a list of tokens that are to be flipped</returns>
        public List<ctrToken> FindFlippableTokens(ctrToken TokenClicked)
        {
            List<ctrToken> TokensToFlip = new List<ctrToken>();
            //for each direction
            for (int i = 0; i < 8; i++)
            {
                //specific directions
                int dx = _directionsx[i];
                int dy = _directionsY[i];
                //in the direction in relation to the token clicked coords
                int newX = TokenClicked.XCoord + dx;
                int newY = TokenClicked.YCoord + dy;
                // if the directions does not exceed or is not the edge of the board
                if (newX >= 0 && newX < 8 && newY >= 0 && newY < 8)
                {
                    bool SameColourFound = false;
                    int depth = 1; // Depth starts at 2 because there should be two tokens of the same color in between.
                    List<ctrToken> PossibleTokensToFlip = new List<ctrToken>();
                    while (true)
                    {
                        //depth of the direction in relation to the token clicked coords
                        newX = TokenClicked.XCoord + (depth * dx);
                        newY = TokenClicked.YCoord + (depth * dy);
                        // Check if the cell exceeds the gameboards boundary or is the same colour as the token clicked then we are finished
                        if (newX < 0 || newX >= 8 || newY < 0 || newY >= 8)
                        {
                            break;
                        }
                        //if we hit our token colour then we have caught everything surrounding
                        if (GameBoard[newX, newY].TokenColour == TokenClicked.TokenColour)
                        {
                            SameColourFound = true;
                            break;
                        }
                        //adds enemy and empty board cells
                        if (GameBoard[newX, newY].TokenColour != TokenClicked.TokenColour && GameBoard[newX,newY].TokenColour != TokenTypes.none)
                        {
                            PossibleTokensToFlip.Add(GameBoard[newX, newY]);
                        }
                        depth++;
                    }
                    if (SameColourFound)
                    {
                        foreach (var Token in PossibleTokensToFlip)
                        {
                            TokensToFlip.Add(Token);
                        }
                    }
                    PossibleTokensToFlip.Clear();
                }
            }
            return TokensToFlip;
        }
        /// <summary>
        /// Change the colour displayed inside specific token 
        /// </summary>
        /// <param name="Player">The current Player</param>
        /// <param name="Token">Specific token to change the colour/param>
        public static void ChangeTokenDisplayColour(Player Player, ctrToken Token)
        {
            switch (Player.PlayerColour)
            {
                case TokenTypes.black:
                    Token.imgTile.Image = Resources.BlackToken;
                    break;
                case TokenTypes.white:
                    Token.imgTile.Image = Resources.WhiteToken;
                    break;
            }
            Token.TokenColour = Player.PlayerColour;
            Token.Legal = false;
            Token.imgTile.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        #endregion
        #region GameFinished
        /// <summary>
        /// Checks GameBoard if there are still legal moves on the board for the current player whos turn it is
        /// </summary>
        /// <returns>false if a legal move found, true if none are found</returns>
        public bool CheckMovesForCurrentPlayer(Player Player) 
        {
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    if (GameBoard[row,column].Legal)
                    {
                        return true;
                    }
                }
            }
            MessageBox.Show($"{Player.PlayerName} has no legal moves");
            return false;
        }
        /// <summary>
        /// Checks which player has the most tokens and sets the winner
        /// </summary>
        /// <param name="Player1"></param>
        /// <param name="Player2"></param>
        public void GetWinner(Player Player1 , Player Player2) 
        {
            if (Player1.TokensOnBoards > Player2.TokensOnBoards)
            {
                Player1.Winner = true;
                Player1.lblPlayerTurn.Text = "Winner!";
            }
            else 
            {
                Player2.Winner = true;
                Player2.lblPlayerTurn.Text = "Winner!";
            }
        }
        #endregion
    }
}

    
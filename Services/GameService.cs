using O_neilloGame.Common.Enums;
using O_neilloGame.Components;
using O_neilloGame.Models;
using O_neilloGame.Properties;
using O_NeilloGame.Components;

namespace O_neilloGame.Services
{
    /// <summary>
    /// Handles all of game logic
    /// </summary>
    public class GameService
    {
        #region Properties
        /// <summary>
        /// 2D array storing instances that represent where tokens can be placed
        /// </summary>
        public ctrToken[,] GameBoard = new ctrToken[8, 8];
        /// <summary>
        /// All the possible directions you can go according to the x axis
        /// </summary>
        private int[] _directionsx = { -1, -1, -1, 0, 1, 1, 1, 0 };
        /// <summary>
        /// All possible directions according to y axis
        /// </summary>
        private int[] _directionsY = { -1, 0, 1, 1, 1, 0, -1, -1 };
        /// <summary>
        /// Name of the instance of game
        /// </summary>
        public string GameName;
        /// <summary>
        /// Instance of players in the game
        /// </summary>
        public Player Player1;
        /// <summary>
        /// Instance of players in the game
        /// </summary>
        public Player Player2;
        /// <summary>
        /// Model of GameBoard
        /// </summary>
        public TokenModel[,] GameBoardModel = new TokenModel[8, 8];
        #endregion
        #region GenerateGameBoard
        public void GenerateBoard(TableLayoutPanel tlp, Player player1, Player player2)
        {
            //add tokens to backend board and front end
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    //add instances to mygameboard
                    GameBoard[row, column] = new ctrToken(player1, player2, this) { Enabled = true, XCoord = row, YCoord = column };
                    //adds token to specifc column index and row index of tlp
                    tlp.Controls.Add(GameBoard[row, column], row, column);
                }
            }
            //set four blocks in the middle to have token
            ChangeTokenDisplayColour(player2, GameBoard[3, 3]);
            ChangeTokenDisplayColour(player1, GameBoard[3, 4]);
            ChangeTokenDisplayColour(player1, GameBoard[4, 3]);
            ChangeTokenDisplayColour(player2, GameBoard[4, 4]);
            Player1 = player1;
            Player2 = player2;
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
                for (int column = 0; column < 8; column++)
                {
                    // if we find an empty board cell
                    if (GameBoard[row, column].TokenColour == TokenTypes.TokenType.none)
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
                                GameBoard[newX, newY].TokenColour != player.PlayerColour && GameBoard[newX, newY].TokenColour != TokenTypes.TokenType.none)
                            {
                                int Depth = 1;
                                while (true)
                                {
                                    //the depth of the direction we are checking e.g how far upwards etc
                                    newX = row + (Depth * dx);
                                    newY = column + (Depth * dy);
                                    //if the depth of that direction hits the edge of the board or we hit an empty board cell
                                    if (newX < 0 || newX >= 8 || newY < 0 || newY >= 8 || GameBoard[newX, newY].TokenColour == TokenTypes.TokenType.none)
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
                    GameBoard[row, column].Legal = false;
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
                        // Check if the cell exceeds the gameboards boundary or the token colour is empty then we break out
                        if (newX < 0 || newX >= 8 || newY < 0 || newY >= 8 || GameBoard[newX, newY].TokenColour == TokenType.none)
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
                        if (GameBoard[newX, newY].TokenColour != TokenClicked.TokenColour && GameBoard[newX, newY].TokenColour != TokenType.none)
                        {
                            PossibleTokensToFlip.Add(GameBoard[newX, newY]);
                        }
                        depth++;
                    }
                    //adds the multiple tokens in between two of the players colour to the true list
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
                case TokenTypes.TokenType.black:
                    Token.imgTile.Image = Resources.BlackToken;
                    break;
                case TokenTypes.TokenType.white:
                    Token.imgTile.Image = Resources.WhiteToken;
                    break;
            }
            Token.TokenColour = Player.PlayerColour;
            Token.imgTile.SizeMode = PictureBoxSizeMode.Zoom;
            Token.Legal = false;
        }
        /// <summary>
        /// Change the colour displayed inside the specific token - used in the restore process
        /// </summary>
        /// <param name="tokenColour">Used to directly update the token colours</param>
        /// <param name="token">Sqaure on the board</param>
        public static void ChangeTokenDisplayColour(TokenTypes.TokenType tokenColour, ctrToken token)
        {
            switch (tokenColour)
            {
                case TokenTypes.TokenType.black:
                    token.imgTile.Image = Resources.BlackToken;
                    break;
                case TokenTypes.TokenType.white:
                    token.imgTile.Image = Resources.WhiteToken;
                    break;
            }
            token.TokenColour = tokenColour;
            token.imgTile.SizeMode = PictureBoxSizeMode.Zoom;
            token.Legal = false;
        }
        #endregion
        #region GameFinished
        /// <summary>
        /// Checks GameBoard if there are still legal moves on the board for the current player whos turn it is
        /// </summary>
        /// <returns>false if a legal move found, true if none are found</returns>
        public bool CheckMovesForCurrentPlayer(Player player)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    if (GameBoard[row, column].Legal)
                    {
                        return true;
                    }
                }
            }
            MessageBox.Show($"{player.PlayerName} has no legal moves");
            return false;
        }
        /// <summary>
        /// Checks which player has the most tokens and sets the winner
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        public void GetWinner(Player player1, Player player2)
        {
            if (player1.TokensOnBoards > player2.TokensOnBoards)
            {
                player1.Winner = true;
                player1.lblPlayerTurn.Text = "Winner";
                player1.lblPlayerTurn.Visible = true;
                player2.lblPlayerTurn.Visible = false;
            }
            else
            {
                player2.Winner = true;
                player2.lblPlayerTurn.Text = "Winner";
                player2.lblPlayerTurn.Visible = true;
                player1.lblPlayerTurn.Visible = false;
            }
        }
        #endregion
        #region SetName
        /// <summary>
        /// Used to initialise the game name
        /// </summary>
        /// <param name="gameName"></param>
        public void SetGameName(string gameName)
        {
            GameName = gameName;
        }
        #endregion
        #region CreateModels
        /// <summary>
        /// creates models of the game objects needed to restore a game instance
        /// </summary>
        public void CreateModels()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    GameBoardModel[row, column] = new TokenModel(GameBoard[row, column], new PlayerModel(Player1), new PlayerModel(Player2));
                }
            }
        }
        #endregion
        #region RestoreGame
        /// <summary>
        /// Restores the players 
        /// </summary>
        /// <param name="game"></param>
        private void RestorePlayers(GameModel game) 
        {
            Player1.PlayerColour = game.GameBoard[3, 4].Player1.PlayerColour;
            Player1.RestoreTokensOnBoard(game.GameBoard[3, 4].Player1.PlayerNum);
            Player1.RestorePlayerName(game.GameBoard[3, 4].Player1.PlayerName);
            Player1.RestoreplayerTurn(game.GameBoard[3, 4].Player1.PlayerTurn);
            Player1.RestoreTokensOnBoard(game.GameBoard[3, 4].Player1.TokensOnBoards);
            Player1.Winner = game.GameBoard[3, 4].Player1.Winner;
            Player1.Speak = game.GameBoard[3, 4].Player1.Speak;

            Player2.PlayerColour = game.GameBoard[3, 3].Player2.PlayerColour;
            Player2.RestoreTokensOnBoard(game.GameBoard[3, 4].Player2.PlayerNum);
            Player2.RestorePlayerName(game.GameBoard[3, 4].Player2.PlayerName);
            Player2.RestoreplayerTurn(game.GameBoard[3, 4].Player2.PlayerTurn);
            Player2.RestoreTokensOnBoard(game.GameBoard[3, 4].Player2.TokensOnBoards);
            Player2.Speak = game.GameBoard[3, 3].Player2.Speak;
            Player2.Winner = game.GameBoard[3, 3].Player2.Winner;
        }
        /// <summary>
        /// Restores the entire game from a previous save
        /// </summary>
        /// <param name="game"></param>
        public void RestoreGame(GameModel game) 
        {
            RestorePlayers(game);
            game.GameName = GameName;
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    //Restores the state of each Token
                    ChangeTokenDisplayColour(game.GameBoard[row, column].TokenColour, GameBoard[row, column]);
                    GameBoard[row, column].XCoord = game.GameBoard[row, column].XCoord;
                    GameBoard[row, column].YCoord = game.GameBoard[row, column].YCoord;
                    //Restores the properties of the player instance passed inside each Token
                    GameBoard[row, column].Player1.PlayerColour = game.GameBoard[row, column].Player1.PlayerColour;
                    GameBoard[row, column].Player1.PlayerNum = game.GameBoard[row, column].Player1.PlayerNum;
                    GameBoard[row, column].Player1.PlayerName = game.GameBoard[row, column].Player1.PlayerName;
                    GameBoard[row, column].Player1.PlayerTurn = game.GameBoard[row, column].Player1.PlayerTurn;
                    GameBoard[row, column].Player1.Speak = game.GameBoard[row, column].Player1.Speak;
                    GameBoard[row, column].Player1.TokensOnBoards = game.GameBoard[row, column].Player1.TokensOnBoards;
                    GameBoard[row, column].Player1.Winner = game.GameBoard[row, column].Player1.Winner;

                    GameBoard[row, column].Player2.PlayerColour = game.GameBoard[row, column].Player2.PlayerColour;
                    GameBoard[row, column].Player2.PlayerNum = game.GameBoard[row, column].Player2.PlayerNum;
                    GameBoard[row, column].Player2.PlayerName = game.GameBoard[row, column].Player2.PlayerName;
                    GameBoard[row, column].Player2.PlayerTurn = game.GameBoard[row, column].Player2.PlayerTurn;
                    GameBoard[row, column].Player2.Speak = game.GameBoard[row, column].Player2.Speak;
                    GameBoard[row, column].Player2.TokensOnBoards = game.GameBoard[row, column].Player2.TokensOnBoards;
                    GameBoard[row, column].Player2.Winner = game.GameBoard[row, column].Player2.Winner;
                }
            }
            //Gets the legal moves so the game can continue 
            GetLegalMoves(Player1.PlayerTurn ? Player1 : Player2);
        }
        #endregion
    }
}

    
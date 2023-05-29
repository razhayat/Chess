using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
	public partial class Game : Form
	{
		private Board Board;

		public Game()
		{
			InitializeComponent();

			Load += Game_Load;
		}

		private void Game_Load(object sender, EventArgs e)
		{
			Piece.PieceMoved += Piece_PieceMoved;

			Board = new Board(this, ClientRectangle.Height, ClientRectangle.Height, Color.White, Color.Black);

			FillBoard();
		}

		private void Piece_PieceMoved(object sender, EventArgs e)
		{
			P1PointsLbl.Text = Board.Player1.TotalPoints.ToString();
			P2PointsLbl.Text = Board.Player2.TotalPoints.ToString();

			Player[] players = new Player[] { Board.Player1, Board.Player2 };
			for (int i = 0; i < players.Length; i++)
			{
				if (players[i].KingIsThreatened() && players[i].TotalMoves() == 0)
				{
					EndGame();
				}
			}
		}

		private void NewGameBtn_Click(object sender, EventArgs e)
		{
			NewGame();
		}

		private void FillBoard()
		{
			string s = string.Empty;

			string[] cmds = new string[] { "Ro", "Kn", "Bi", "Qu", "Ki", "Bi", "Kn", "Ro" };
			for (int i = 0; i < cmds.Length; i++)
			{
				s += $"P2{cmds[i]};Ri1;";
			}
			s += "Do1;";
			for (int i = 0; i < Board.Cols; i++)
			{
				s += "P2Pa;Le1;";
			}

			s += "Up1;Up1;";

			for (int i = 0; i < cmds.Length; i++)
			{
				s += $"P1{cmds[i]};Ri1;";
			}
			s += "Up1;";
			for (int i = 0; i < Board.Cols; i++)
			{
				s += "P1Pa;Le1;";
			}

			Board.FillTiles(s);
		}

		private void EndGame()
		{
			GameEndedLabel.Visible = true;

			NewGameBtn.Focus();
		}

		private void NewGame()
		{
			GameEndedLabel.Visible = false;

			Board.Player1.NewGame(true);
			Board.Player2.NewGame(false);

			foreach (Tile tile in Board)
			{
				tile.RemoveHighlight();
			}

			FillBoard();

			P1PointsLbl.Text = "0";
			P2PointsLbl.Text = "0";
		}
	}
}

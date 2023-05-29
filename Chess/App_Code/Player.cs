using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
	public class Player
	{
		public List<Piece> ActivePieces;
		public List<Piece> RemovedPieces;

		public Board Board;
		public Player Opponent;

		public int TotalPoints;
		public Color Color;

		public readonly bool AttackDirectionUp;

		public bool IsMyTurn { get; private set; }

		public Player(Board board, Color color, bool attackDirectionUp, bool isMyTurn)
		{
			TotalPoints = 0;
			Color = color;
			Board = board;

			AttackDirectionUp = attackDirectionUp;

			IsMyTurn = isMyTurn;

			ActivePieces = new List<Piece>();
			RemovedPieces = new List<Piece>();

			Piece.PieceMoved += Piece_PieceMoved;
		}

		private void Piece_PieceMoved(object sender, EventArgs e)
		{
			Piece piece = sender as Piece;

			IsMyTurn = piece.IsEnemyPlayer(this);
		}

		public bool KingIsThreatened()
		{
			foreach (Piece piece in Opponent.ActivePieces)
			{
				if (piece.ThreateningKing) return true;
			}
			return false;
		}

		public int TotalMoves()
		{
			int sum = 0;
			foreach (Piece piece in ActivePieces)
			{
				sum += piece.AvailableMoves().Count();
			}
			return sum;
		}

		public void NewGame(bool isMyTurn)
		{
			TotalPoints = 0;

			ActivePieces = new List<Piece>();
			RemovedPieces = new List<Piece>();

			IsMyTurn = isMyTurn;
		}
	}
}
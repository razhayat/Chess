using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Chess
{
	public abstract class Piece
	{
		public static event EventHandler PieceMoved;

		public abstract int Points { get; }
		public abstract string AsText { get; }

		public bool Moved { get; private set; } = false;
		public bool Removed { get; private set; } = false;
		public bool ThreateningKing => AllMoves().Select(t => t.Position).Any(pos => IsEnemyPiece(Board[pos].Piece) && Board[pos].Piece is King);

		public Color Color => Player.Color;

		public Tile Tile { get; private set; }
		public Position Position => Tile.Position;

		public Board Board;
		public Player Player;

		protected Piece(Tile tile, Board board, Player player)
		{
			Tile = tile;

			Board = board;
			Player = player;
		}

		public void Remove()
		{
			if (Removed) return;

			Player.Opponent.TotalPoints += Points;

			Player.ActivePieces.Remove(this);
			Player.RemovedPieces.Add(this);

			Tile.Piece = null;

			Removed = true;
		}

		public void MoveTo(Tile tile)
		{
			Tile.Piece = null;

			tile.Piece?.Remove();
			tile.Piece = this;
			Tile = tile;

			Moved = true;

			PieceMoved?.Invoke(this, EventArgs.Empty);
		}

		public List<Tile> AvailableMoves()
		{
			List<Tile> moves = AllMoves();

			for (int i = moves.Count - 1; i >= 0; i--)
			{
				Position pos = moves[i].Position;

				if (Board[pos].Piece == null) continue;

				if (Board[pos].Piece.Color == Color)
				{
					moves.RemoveAt(i);
				}
				else if (Board[pos].Piece is King)
				{
					moves.RemoveAt(i);
				}
			}

			Tile currentTile = Tile;
			for (int i = moves.Count - 1; i >= 0; i--)
			{
				Tile moveTile = moves[i];
				Piece movePiece = moveTile.Piece;

				if (movePiece != null)
				{
					Player.Opponent.RemovedPieces.Add(movePiece);
					Player.Opponent.ActivePieces.Remove(movePiece);
				}
				Tile.Piece = null;
				moveTile.Piece = this;
				Tile = moveTile;

				if (Player.KingIsThreatened())
				{
					moves.RemoveAt(i);
				}

				if (movePiece != null)
				{
					Player.Opponent.RemovedPieces.Remove(movePiece);
					Player.Opponent.ActivePieces.Add(movePiece);
				}
				Tile = currentTile;
				moveTile.Piece = movePiece;
				Tile.Piece = this;
			}

			return moves;
		}
		protected abstract List<Tile> AllMoves();

		public bool IsEnemyPlayer(Player other)
		{
			return Player.Opponent == other;
		}
		public bool IsEnemyPiece(Piece other)
		{
			if (other == null) return false;

			return IsEnemyPlayer(other.Player);
		}
	}
}
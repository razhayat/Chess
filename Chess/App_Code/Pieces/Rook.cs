using System.Collections.Generic;

namespace Chess
{
	class Rook : Piece
	{
		public override int Points => 5;
		public override string AsText => "♖";

		public Rook(Tile tile, Board board, Player player)
			: base(tile, board, player) { }

		protected override List<Tile> AllMoves()
		{
			List<Tile> moves = new List<Tile>();

			void AddMoves(int rowOff, int colOff)
			{
				int rowOffScaler = 1;
				int colOffScaler = 1;
				while (Board.TileExists(Position.Row + rowOff * rowOffScaler, Position.Col + colOff * colOffScaler))
				{
					Tile tile = Board[Position.Row + rowOff * rowOffScaler, Position.Col + colOff * colOffScaler];
					moves.Add(tile);

					if (tile.Piece != null) return;

					rowOffScaler++;
					colOffScaler++;
				}
			}

			// up
			AddMoves(-1, 0);

			// down
			AddMoves(1, 0);

			// left
			AddMoves(0, 1);

			// right
			AddMoves(0, -1);

			return moves;
		}
	}
}

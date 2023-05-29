using System.Collections.Generic;

namespace Chess
{
	class Queen : Piece
	{
		public override int Points => 9;
		public override string AsText => "♕";

		public Queen(Tile tile, Board board, Player player)
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
			// up - right
			AddMoves(-1, 1);
			// right
			AddMoves(0, -1);
			// down - right
			AddMoves(1, 1);
			// down
			AddMoves(1, 0);
			// down - left
			AddMoves(1, -1);
			// left
			AddMoves(0, 1);
			// up - left
			AddMoves(-1, -1);

			return moves;
		}
	}
}

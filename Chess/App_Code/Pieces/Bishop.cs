using System.Collections.Generic;

namespace Chess
{
	class Bishop : Piece
	{
		public override int Points => 3;
		public override string AsText => "♗";

		public Bishop(Tile tile, Board board, Player player)
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

			// up - right
			AddMoves(-1, 1);

			// up - left
			AddMoves(-1, -1);

			// down - right
			AddMoves(1, 1);

			// down - left
			AddMoves(1, -1);

			return moves;
		}
	}
}

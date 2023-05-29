using System.Collections.Generic;

namespace Chess
{
	class Knight : Piece
	{
		public override int Points => 3;
		public override string AsText => "♘";

		public Knight(Tile tile, Board board, Player player)
			: base(tile, board, player) { }

		protected override List<Tile> AllMoves()
		{
			List<Tile> moves = new List<Tile>();

			void AddMove(int rowOff, int colOff)
			{
				if (Board.TileExists(Position.Row + rowOff, Position.Col + colOff))
				{
					moves.Add(Board[Position.Row + rowOff, Position.Col + colOff]);
				}
			}

			AddMove(2, 1);
			AddMove(2, -1);
			AddMove(1, 2);
			AddMove(1, -2);
			AddMove(-1, 2);
			AddMove(-1, -2);
			AddMove(-2, 1);
			AddMove(-2, -1);

			return moves;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
	public class King : Piece
	{
		public override int Points => 0;
		public override string AsText => "♔";

		public King(Tile tile, Board board, Player player)
			: base(tile, board, player) { }

		protected override List<Tile> AllMoves()
		{
			List<Tile> moves = new List<Tile>();

			for (int rowOff = -1; rowOff <= 1; rowOff++)
			{
				for (int colOff = -1; colOff <= 1; colOff++)
				{
					if (colOff == 0 && rowOff == 0) continue;

					if (Board.TileExists(Position.Row + rowOff, Position.Col + colOff))
					{
						moves.Add(Board[Position.Row + rowOff, Position.Col + colOff]);
					}
				}
			}

			return moves;
		}
	}
}

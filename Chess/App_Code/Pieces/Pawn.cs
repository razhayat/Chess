using System.Collections.Generic;

namespace Chess
{
	public class Pawn : Piece
	{
		public override int Points => 1;
		public override string AsText => "♙";

		public Pawn(Tile tile, Board board, Player player)
			: base(tile, board, player) { }

		protected override List<Tile> AllMoves()
		{
			List<Tile> moves = new List<Tile>();

			Tile AddTile(int rowOffset, int colOffset, bool eat)
			{
				int row = Position.Row + rowOffset;
				int col = Position.Col + colOffset;
				if (Board.TileExists(row, col))
				{
					Tile tile = Board[row, col];
					
					if (eat && tile.Piece != null)
					{
						moves.Add(tile);
					}

					if (!eat && tile.Piece == null)
					{
						moves.Add(tile);
					}

					return tile;
				}
				return null;
			}

			int offset = Player.AttackDirectionUp ? -1 : 1;

			Tile forward = AddTile(offset, 0, false);

			if (forward != null)
			{
				// sides
				AddTile(offset, 1, true);
				AddTile(offset, -1, true);

				if (forward.Piece == null && !Moved)
				{
					AddTile(offset * 2, 0, false);
				}
			}

			return moves;
		}
	}
}

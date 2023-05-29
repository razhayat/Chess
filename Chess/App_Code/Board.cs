using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;

namespace Chess
{
	public class Board : IEnumerable<Tile>
	{
		public const int Rows = 8;
		public const int Cols = 8;

		public readonly int Width;
		public readonly int Height;

		public Player Player1;
		public Player Player2;

		public Tile this[int row, int col]
		{
			get => Tiles[row, col];
			private set => Tiles[row, col] = value;
		}
		public Tile this[Position pos]
		{
			get => this[pos.Row, pos.Col];
			private set => this[pos.Row, pos.Col] = value;
		}

		private readonly Tile[,] Tiles;

		private readonly Game Form;

		public Board(Game form, int width, int height, Color player1Color, Color player2Color)
		{
			Width = width;
			Height = height;

			Form = form;

			Tiles = new Tile[Rows, Cols];

			CreateTiles(ColorTranslator.FromHtml("#6F73D2"), ColorTranslator.FromHtml("#9DACE1"));

			Player1 = new Player(this, player1Color, true, true);
			Player2 = new Player(this, player2Color, false, false);

			Player1.Opponent = Player2;
			Player2.Opponent = Player1;
		}

		public bool TileExists(int row, int col)
		{
			return row >= 0 && row < Rows && col >= 0 && col < Cols;
		}

		public IEnumerator<Tile> GetEnumerator()
		{
			foreach (Tile tile in Tiles)
			{
				yield return tile;
			}
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return Tiles.GetEnumerator();
		}

		private void CreateTiles(Color tileColor1, Color tileColor2)
		{
			Color tileColor = tileColor1;

			for (int i = 0; i < Rows; i++)
			{
				for (int j = 0; j < Cols; j++)
				{
					Position pos = new Position(i, j);
					this[pos] = new Tile(Form, this, pos, null, tileColor);

					tileColor = tileColor == tileColor1 ? tileColor2 : tileColor1;
				}
				tileColor = tileColor == tileColor1 ? tileColor2 : tileColor1;
			}
		}

		public void FillTiles(string s)
		{
			for (int i = 0; i < Rows; i++)
			{
				for (int j = 0; j < Cols; j++)
				{
					Tiles[i, j].Piece = null;
				}
			}

			int row = 0;
			int col = 0;

			string[] cmds = s.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string cmd in cmds)
			{
				Tile tile = this[row, col];

				if (cmd.StartsWith("Ri"))
				{
					col = (Cols + col + int.Parse(cmd.Substring(2))) % Cols;
					
				}
				else if (cmd.StartsWith("Le"))
				{
					col = (Cols + col - int.Parse(cmd.Substring(2))) % Cols;
				}
				else if (cmd.StartsWith("Up"))
				{
					row = (Rows + row - int.Parse(cmd.Substring(2))) % Rows;
				}
				else if (cmd.StartsWith("Do"))
				{
					row = (Rows + row + int.Parse(cmd.Substring(2))) % Rows;
				}
				else
				{
					Player player = null;
					if (cmd.StartsWith("P1"))
					{
						player = Player1;
					}
					else if (cmd.StartsWith("P2"))
					{
						player = Player2;
					}

					Piece piece = null;
					if (cmd.EndsWith("Bi"))
					{
						piece = new Bishop(tile, this, player);
					}
					else if (cmd.EndsWith("Kn"))
					{
						piece = new Knight(tile, this, player);
					}
					else if (cmd.EndsWith("Ki"))
					{
						piece = new King(tile, this, player);
					}
					else if (cmd.EndsWith("Pa"))
					{
						piece = new Pawn(tile, this, player);
					}
					else if (cmd.EndsWith("Qu"))
					{
						piece = new Queen(tile, this, player);
					}
					else if (cmd.EndsWith("Ro"))
					{
						piece = new Rook(tile, this, player);
					}
					player.ActivePieces.Add(piece);
					tile.Piece = piece;
				}
			}
		}
	}
}

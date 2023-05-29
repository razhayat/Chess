using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
	public class Tile
	{
		public Game Form;
		public Board Board;
		public Position Position;

		private Piece piece;
		public Piece Piece
		{
			get => piece;
			set
			{
				piece = value;
				if (piece == null)
				{
					Label.Text = "";
				}
				else
				{
					Label.Text = piece.AsText;
					ForeColor = piece.Color;
				}
			}
		}


		public Color ForeColor
		{
			get => Label.ForeColor;
			set => Label.ForeColor = value;
		}

		public bool HighLighted { get; private set; }
		public bool Selected { get; private set; }

		private readonly Color BackColor;
		private readonly Label Label;

		public Tile(Game form, Board board, Position position, Piece piece, Color backColor)
		{
			int w = board.Width / Board.Cols;
			int h = board.Height / Board.Rows;
			Label = new Label
			{
				AutoSize = false,
				TextAlign = ContentAlignment.MiddleCenter,
				Location = new Point(w * position.Col, h * position.Row),
				Size = new Size(w, h),
				Font = new Font("David", 50),
				BackColor = backColor
			};
			form.Controls.Add(Label);


			Form = form;
			Board = board;
			Position = position;
			Piece = piece;
			BackColor = backColor;

			Label.Click += Label_Click;
		}

		private void Label_Click(object sender, EventArgs e)
		{
			if (HighLighted)
			{
				HighlightedClick();
			}
			else if (Piece == null)
			{
				EmptyTileClick();
			}
			else
			{
				NotEmptyTileClick();
			}
		}

		private void HighlightedClick()
		{
			Tile selectedTile = Board.First(t => t.Selected);
			selectedTile.Piece.MoveTo(this);

			foreach (Tile tile in Board)
			{
				tile.RemoveHighlight();
				tile.Selected = false;
			}
		}
		private void EmptyTileClick()
		{
			foreach (Tile tile in Board)
			{
				tile.RemoveHighlight();
				tile.Selected = false;
			}
		}
		private void NotEmptyTileClick()
		{
			if (!Piece.Player.IsMyTurn)
			{
				EmptyTileClick();
				return;
			}

			foreach (Tile tile in Board)
			{
				tile.RemoveHighlight();
				tile.Selected = false;
			}

			Selected = true;
			var ls = Piece.AvailableMoves();
			foreach (Tile tile in ls)
			{
				tile.SetHighlighted();
			}
		}

		public void SetHighlighted()
		{
			HighLighted = true;

			Label.BackColor = Color.Red;
		}
		public void RemoveHighlight()
		{
			HighLighted = false;

			Label.BackColor = BackColor;
		}
	}
}

namespace Tetris.Classes
{
	using Common.Enums;
	using global::Tetris.Classes.Interfaces;
	using global::Tetris.Common;
	using Raylib_cs;
	using System.Collections.Generic;

	using static Raylib_cs.Raylib;
	using static Common.Constants;

	public abstract class Block : IDrawable
	{
		private Block_Names id;
		private Color_Index colorId;
		private int cellSize;
		private int rotationState;
		private int rowOffset;
		private int colOffset;

		private Dictionary<int, IEnumerable<Position>> cells;
		private readonly List<Color> colors;

		public Block()
		{
			this.Id = Block_Names.NULL_BLOCK;
			this.colorId = Color_Index.EMPTY_INDEX;
			this.CellSize = CELL_SIZE;
			this.RotationState = 0;
			this.RowsOffset = 0;
			this.ColOffset = 0;
			this.colors = Colors.GetSellColors;
		}

		internal Block_Names Id
		{
			get => id;
			set => id = value;
		}

		internal Color_Index ColorId
		{
			get => colorId;
			set => colorId = value;
		}

		public int CellSize
		{
			get => cellSize;
			set => cellSize = value;
		}
		public int RotationState
		{
			get => rotationState;
			set => rotationState = value;
		}

		public int RowsOffset
		{
			get => rowOffset;
			set => rowOffset = value;
		}

		public int ColOffset
		{
			get => colOffset;
			set => colOffset = value;
		}

		public Dictionary<int, IEnumerable<Position>> Cells
		{
			get => cells;
			set => cells = value;
		}

		public void Draw(int offsetX = 11, int offsetY = 11)
		{
			IEnumerable<Position> tiles = this.GetCellPositions();

			foreach (Position item in tiles)
			{
				Color c = this.colors[(int)this.colorId];
				DrawRectangle((item.Col * this.CellSize + offsetX), (item.Row * this.CellSize + offsetY), this.CellSize! - 1, this.CellSize - 1, c);
			}
		}

		public IEnumerable<Position> GetCellPositions()
		{
			IEnumerable<Position> tiles = this.cells[this.RotationState];
			List<Position> moveTiles = new List<Position>();

			foreach (Position item in tiles)
			{
				Position newPosition = new Position(item.Row + this.RowsOffset, item.Col + this.ColOffset);
				moveTiles.Add(newPosition);
			}

			return moveTiles;
		}

		public void Move(int row, int col)
		{
			this.RowsOffset += row;
			this.ColOffset += col;
		}

		public void Rotate()
		{
			this.RotationState = ++this.RotationState % this.Cells.Count;
		}

		public void UndoRotate()
		{
			this.RotationState -= 1;
			if (this.RotationState < 0)
			{
				this.RotationState = this.Cells.Count - 1;
			}
		}
	}
}
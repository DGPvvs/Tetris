namespace Tetris.Classes
{
	using global::Tetris.Common.Enums;
	using Raylib_cs;

	using static Raylib_cs.Raylib;

	public class Grid
	{
		private byte[,] grids;
		private int nulRows;
		private int numCols;
		private int cellSize;
		private List<Color> colors;

		public Grid()
		{
			this.Grids = new byte[20, 10];

			{
				this.NulRows = 20;
				this.NumCols = 10;
				this.CellSize = 30;
				this.Initialize();
				this.Colors = Common.Colors.GetSellColors;
			}

		}

		public byte[,] Grids
		{
			get => grids;
			set => grids = value!;
		}
		public int NulRows
		{
			get => nulRows;
			set => nulRows = value;
		}
		public int NumCols
		{
			get => numCols;
			set => numCols = value;
		}
		public int CellSize
		{
			get => cellSize;
			set => cellSize = value;
		}
		public List<Color> Colors
		{
			get => colors;
			set => colors = value;
		}

		public void Initialize()
		{
			for (int row = 0; row < this.NulRows; row++)
			{
				for (int col = 0; col < this.NumCols; col++)
				{
					this.Grids[row, col] = 0;
				}
			}
		}

		public void Draw()
		{
			for (int row = 0; row < this.NulRows; row++)
			{
				for (int col = 0; col < this.NumCols; col++)
				{
					int cellValue = this.Grids[row, col];
					switch (this.Grids[row, col])
					{
						case (int)Block_Names.L_BLOCK:
							cellValue = (int)Color_Index.L_INDEX;
							break;

						case (int)Block_Names.J_BLOCK:
							cellValue = (int)Color_Index.J_INDEX;
							break;

						case (int)Block_Names.I_BLOCK:
							cellValue = (int)Color_Index.I_INDEX;
							break;

						case (int)Block_Names.O_BLOCK:
							cellValue = (int)Color_Index.O_INDEX;
							break;

						case (int)Block_Names.S_BLOCK:
							cellValue = (int)Color_Index.S_INDEX;
							break;

						case (int)Block_Names.T_BLOCK:
							cellValue = (int)Color_Index.T_INDEX;
							break;

						case (int)Block_Names.Z_BLOCK:
							cellValue = (int)Color_Index.Z_INDEX;
							break;
						default:
							break;
					}
					DrawRectangle(col * cellSize + 11, row * cellSize + 11, cellSize - 1, cellSize - 1, this.colors[cellValue]);
				}
			}
		}

		public bool IsCellOutside(int row, int col) => !(row >= 0 && row < this.NulRows && col >= 0 && col < this.NumCols);

		public bool IsCellEmpty(int row, int col) => this.Grids[row, col] == (int)Block_Names.NULL_BLOCK;

		public int ClearFullRows()
		{
			int completed = 0;
			for (int row = this.NulRows - 1; row >= 0; row--)
			{
				if (this.IsRowFull(row))
				{
					this.ClearRow(row);
					completed++;
				}
				else if (completed > 0)
				{
					this.MoveRowDown(row, completed);
				}
			}

			return completed;
		}

		private bool IsRowFull(int row)
		{
			for (int col = 0; col < this.NumCols; col++)
			{
				if (this.Grids[row, col] == (byte)Block_Names.NULL_BLOCK)
				{
					return false;
				}
			}

			return true;
		}

		private void ClearRow(int row)
		{
			for (int col = 0; col < this.NumCols; col++)
			{
				this.Grids[row, col] = (byte)Block_Names.NULL_BLOCK;
			}
		}

		private void MoveRowDown(int row, int numRows)
		{
			for (int col = 0; col < this.NumCols; col++)
			{
				this.Grids[row + numRows, col] = this.Grids[row, col];
				this.Grids[row, col] = (byte)Block_Names.NULL_BLOCK;
			}
		}
	}
}
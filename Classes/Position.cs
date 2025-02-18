﻿namespace Tetris.Classes
{
	public class Position
	{
		private int row;
		private int col;

        public Position(int row, int col)
        {
            this.Row = row;
			this.Col = col;
        }

        public int Row
		{
			get => this.row;
			set => this.row = value;
		}

        public int Col 
		{
			get => this.col;
			set => this.col = value;
		}
	}
}

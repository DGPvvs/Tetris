namespace Tetris.Classes
{
	using Raylib_cs;

	using static Raylib_cs.Raylib;
	using static Common.Constants;
	using System;
	using global::Tetris.Common.Enums;

	public class Game
	{
		private Grid grids;

		private Block currentBlock;
		private Block nextBlock;

		private bool gameOver;
		private int score;

		private Music music;
		private Sound rotateSound;
		private Sound clearSound;

		private readonly int[] scoreArr = [0, 100, 300, 500, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600];

		public Game()
		{
			this.Grids = new Grid();
			this.CurrentBlock = this.GetRandomBlock();
			this.NextBlock = this.GetRandomBlock();
			this.GameOver = false;
			this.Score = 0;
			InitAudioDevice();

			this.Music = LoadMusicStream(MUSIC_PATH);
			PlayMusicStream(this.Music);

			this.ClearSound = LoadSound(CLEAR_SOUND_PATH);
			this.RotateSound = LoadSound(ROTATE_SOUND_PATH);
		}

		public Music Music
		{
			get => music;
			set => music = value;
		}
		public Grid Grids
		{
			get => grids;
			set => grids = value;
		}

		public Block CurrentBlock
		{
			get => currentBlock;
			set => currentBlock = value;
		}
		public Block NextBlock
		{
			get => nextBlock;
			set => nextBlock = value;
		}
		public bool GameOver
		{
			get => gameOver;
			set => gameOver = value;
		}
		public int Score
		{
			get => score;
			set => score = value;
		}
		public Sound ClearSound
		{
			get => clearSound;
			set => clearSound = value;
		}
		public Sound RotateSound
		{
			get => rotateSound;
			set => rotateSound = value;
		}

		public void HandleInput()
		{
			int keyPressed = GetKeyPressed();

			if (this.GameOver && !keyPressed.Equals(0))
			{
				this.GameOver = false;
				this.Reset();
			}

			switch (keyPressed)
			{
				case (int)KeyboardKey.Left:
					this.MoveBlockLeft();
					break;

				case (int)KeyboardKey.Right:
					this.MoveBlockRight();
					break;

				case (int)KeyboardKey.Down:
					this.MoveBlockDown();
					this.UpdateScore(0, 1);
					break;

				case (int)KeyboardKey.Up:
					this.RotateBlock();
					break;

				default:
					break;
			}
		}

		public void MoveBlockDown()
		{
			if (!this.GameOver)
			{
				this.CurrentBlock.Move(1, 0);
				if (this.IsBlockOutside() || !this.BlockFits())
				{
					this.CurrentBlock.Move(-1, 0);
					this.LockBlock();
				}
			}
		}

		public void Draw()
		{
			this.Grids.Draw();
			this.CurrentBlock.Draw();
			switch (this.NextBlock.Id)
			{
				case Block_Names.I_BLOCK:
					this.NextBlock.Draw(255, 290);
					break;

				case Block_Names.O_BLOCK:
					this.NextBlock.Draw(255, 280);
					break;

				default:
					this.NextBlock.Draw(270, 270);
					break;
			}
		}

		private Block GetRandomBlock()
		{
			Random rnd = new Random();

			int randomIndex = rnd.Next(1, (int)(Block_Index.Z_INDEX + 1));

			switch ((Block_Index)randomIndex)
			{
				case Block_Index.L_INDEX:
					return new LBlock();

				case Block_Index.J_INDEX:
					return new JBlock();

				case Block_Index.I_INDEX:
					return new IBlock();

				case Block_Index.O_INDEX:
					return new OBlock();

				case Block_Index.S_INDEX:
					return new SBlock();

				case Block_Index.T_INDEX:
					return new TBlock();

				case Block_Index.Z_INDEX:
					return new ZBlock();

				default:
					return null;
			}
		}

		public int[] ScoreArr => scoreArr;

		private bool IsBlockOutside()
		{
			IEnumerable<Position> tiles = this.CurrentBlock.GetCellPositions();
			foreach (Position item in tiles)
			{
				if (this.Grids.IsCellOutside(item.Row, item.Col))
				{
					return true;
				}
			}
			return false;
		}

		private void RotateBlock()
		{
			this.CurrentBlock.Rotate();
			if (this.IsBlockOutside() || !this.BlockFits())
			{
				this.CurrentBlock.UndoRotate();
			}
			else
			{
				PlaySound(this.RotateSound);
			}
		}

		private void LockBlock()
		{
			IEnumerable<Position> tiles = this.CurrentBlock.GetCellPositions();
			foreach (Position item in tiles)
			{
				this.Grids.Grids[item.Row, item.Col] = (byte)this.CurrentBlock.Id;
			}

			this.CurrentBlock = this.NextBlock;
			this.NextBlock = this.GetRandomBlock();

			if (!this.BlockFits())
			{
				this.GameOver = true;
			}

			int rowsCleared = this.Grids.ClearFullRows();
			if (rowsCleared > 0)
			{
				PlaySound(this.ClearSound);
			}

			this.UpdateScore(rowsCleared, 0);
		}

		private bool BlockFits()
		{
			IEnumerable<Position> tiles = this.CurrentBlock.GetCellPositions();
			foreach (Position item in tiles)
			{
				if (!(this.Grids.IsCellEmpty(item.Row, item.Col)))
				{
					return false;
				}
			}

			return true;
		}

		private void Reset()
		{
			this.Grids.Initialize();
			this.CurrentBlock = this.GetRandomBlock();
			this.NextBlock = this.GetRandomBlock();
			this.Score = 0;
		}

		private void UpdateScore(int linesClear, int moveDownPoints)
		{
			this.Score += this.ScoreArr[linesClear];
			this.Score += moveDownPoints;
		}

		private void MoveBlockLeft()
		{
			if (!this.GameOver)
			{
				this.CurrentBlock.Move(0, -1);
				if (this.IsBlockOutside() || !this.BlockFits())
				{
					this.CurrentBlock.Move(0, 1);
				}
			}
		}

		private void MoveBlockRight()
		{
			if (!this.GameOver)
			{
				this.CurrentBlock.Move(0, 1);
				if (this.IsBlockOutside() || !this.BlockFits())
				{
					this.CurrentBlock.Move(0, -1);
				}
			}
		}
	}
}
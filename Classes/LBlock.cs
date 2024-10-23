namespace Tetris.Classes
{
	using global::Tetris.Common.Enums;
	using System.Collections.Generic;

	public class LBlock : Block
	{
        public LBlock() : base()
        {
			this.Id = Block_Names.L_BLOCK;
			this.ColorId = Color_Index.L_INDEX;
			Dictionary<int, IEnumerable<Position>> tempMap = new Dictionary<int, IEnumerable<Position>>(4);

			int rotateIndex = (int)ROTATION_STATE.ROTATION_STATE_0;

			tempMap.Add(rotateIndex,
				new List<Position>()
				{
					new Position(0, 2),
					new Position(1, 0),
					new Position(1, 1),
					new Position(1, 2)
				});

			rotateIndex = (int)ROTATION_STATE.ROTATION_STATE_1;

			tempMap.Add(rotateIndex,
				new List<Position>()
				{
					new Position(0, 1),
					new Position(1, 1),
					new Position(2, 1),
					new Position(2, 2)
				});

			rotateIndex = (int)ROTATION_STATE.ROTATION_STATE_2;

			tempMap.Add(rotateIndex,
				new List<Position>()
				{
					new Position(1, 0),
					new Position(1, 1),
					new Position(1, 2),
					new Position(2, 0)
				});

			rotateIndex = (int)ROTATION_STATE.ROTATION_STATE_3;

			tempMap.Add(rotateIndex,
				new List<Position>()
				{
					new Position(0, 0),
					new Position(0, 1),
					new Position(1, 1),
					new Position(2, 1)
				});

			this.Cells = tempMap;
			this.Move(0, 3);
		}

	}
}

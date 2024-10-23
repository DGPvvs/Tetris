using Tetris.Common.Enums;

namespace Tetris.Classes
{
	using System.Collections.Generic;

	public class OBlock : Block
	{
		public OBlock()
		{
			this.Id = Block_Names.O_BLOCK;
			this.ColorId = Color_Index.O_INDEX;
			Dictionary<int, IEnumerable<Position>> tempMap = new Dictionary<int, IEnumerable<Position>>();

			int rotateIndex = (int)ROTATION_STATE.ROTATION_STATE_0;

			tempMap.Add(rotateIndex,
				new List<Position>()
				{
					new Position(0, 0),
					new Position(0, 1),
					new Position(1, 0),
					new Position(1, 1)
				});

			rotateIndex = (int)ROTATION_STATE.ROTATION_STATE_1;

			tempMap.Add(rotateIndex,
				new List<Position>()
				{
					new Position(0, 0),
					new Position(0, 1),
					new Position(1, 0),
					new Position(1, 1)
				});

			rotateIndex = (int)ROTATION_STATE.ROTATION_STATE_2;

			tempMap.Add(rotateIndex,
				new List<Position>()
				{
					new Position(0, 0),
					new Position(0, 1),
					new Position(1, 0),
					new Position(1, 1)
				});

			rotateIndex = (int)ROTATION_STATE.ROTATION_STATE_3;

			tempMap.Add(rotateIndex,
				new List<Position>()
				{
					new Position(0, 0),
					new Position(0, 1),
					new Position(1, 0),
					new Position(1, 1)
				});

			this.Cells = tempMap;
			this.Move(0, 4);
		}

	}
}

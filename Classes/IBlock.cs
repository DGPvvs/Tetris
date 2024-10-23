using Tetris.Common.Enums;

namespace Tetris.Classes
{
	public class IBlock : Block
	{
		public IBlock() : base()
		{
			this.Id = Block_Names.I_BLOCK;
			this.ColorId = Color_Index.I_INDEX;

			Dictionary<int, IEnumerable<Position>> tempMap = new Dictionary<int, IEnumerable<Position>>();

			int rotateIndex = (int)ROTATION_STATE.ROTATION_STATE_0;
			tempMap.Add(rotateIndex,
				new List<Position>()
				{
					new Position(1, 0),
					new Position(1, 1),
					new Position(1, 2),
					new Position(1, 3)
				});

			rotateIndex = (int)ROTATION_STATE.ROTATION_STATE_1;

			tempMap.Add(rotateIndex,
				new List<Position>()
				{
					new Position(0, 2),
					new Position(1, 2),
					new Position(2, 2),
					new Position(3, 2)
				});

			rotateIndex = (int)ROTATION_STATE.ROTATION_STATE_2;

			tempMap.Add(rotateIndex,
				new List<Position>()
				{
					new Position(2, 0),
					new Position(2, 1),
					new Position(2, 2),
					new Position(2, 3)
				});

			rotateIndex = (int)ROTATION_STATE.ROTATION_STATE_3;

			tempMap[rotateIndex] =
			[
				new Position(0, 1),
				new Position(1, 1),
				new Position(2, 1),
				new Position(3, 1)
			];

			this.Cells = tempMap;
			this.Move(-1, 3);
		}
	}
}
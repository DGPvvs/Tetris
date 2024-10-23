namespace Tetris.Classes
{
	using global::Tetris.Common.Enums;

	public class ZBlock : Block
	{
		public ZBlock()
		{
			this.Id = Block_Names.Z_BLOCK;
			this.ColorId = Color_Index.Z_INDEX;
			Dictionary<int, IEnumerable<Position>> tempMap = new Dictionary<int, IEnumerable<Position>>();

			int rotateIndex = (int)ROTATION_STATE.ROTATION_STATE_0;

			tempMap.Add(rotateIndex,
				new List<Position>()
				{
					new Position(0, 0),
					new Position(0, 1),
					new Position(1, 1),
					new Position(1, 2)
				});

			rotateIndex = (int)ROTATION_STATE.ROTATION_STATE_1;

			tempMap.Add(rotateIndex,
				new List<Position>()
				{
					new Position(0, 2),
					new Position(1, 1),
					new Position(1, 2),
					new Position(2, 1)
				});

			rotateIndex = (int)ROTATION_STATE.ROTATION_STATE_2;

			tempMap.Add(rotateIndex,
				new List<Position>()
				{
					new Position(1, 0),
					new Position(1, 1),
					new Position(2, 1),
					new Position(2, 2)
				});

			rotateIndex = (int)ROTATION_STATE.ROTATION_STATE_3;

			tempMap.Add(rotateIndex,
				new List<Position>()
				{
					new Position(0, 1),
					new Position(1, 0),
					new Position(1, 1),
					new Position(2, 0)
				});

			this.Cells = tempMap;
			this.Move(0, 3);
		}
	}
}

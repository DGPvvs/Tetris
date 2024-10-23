
namespace Tetris.Classes
{
	using global::Tetris.Common.Enums;

	public class JBlock : Block
	{
		public JBlock() : base()
		{
			this.Id = Block_Names.J_BLOCK;
			this.ColorId = Color_Index.J_INDEX;
			Dictionary<int, IEnumerable<Position>> tempMap = new Dictionary<int, IEnumerable<Position>>();

			int rotateIndex = (int)ROTATION_STATE.ROTATION_STATE_0;

			tempMap.Add(rotateIndex,
				new List<Position>()
				{
					new Position(0, 0),
					new Position(1, 0),
					new Position(1, 1),
					new Position(1, 2)
				});

			rotateIndex = (int)ROTATION_STATE.ROTATION_STATE_1;

			tempMap.Add(rotateIndex,
				new List<Position>()
				{
					new Position(0, 1),
					new Position(0, 2),
					new Position(1, 1),
					new Position(2, 1)
				});

			rotateIndex = (int)ROTATION_STATE.ROTATION_STATE_2;

			tempMap.Add(rotateIndex,
				new List<Position>()
				{
					new Position(1, 0),
					new Position(1, 1),
					new Position(1, 2),
					new Position(2, 2)
				});

			rotateIndex = (int)ROTATION_STATE.ROTATION_STATE_3;

			tempMap.Add(rotateIndex,
				new List<Position>()
				{
					new Position(0, 1),
					new Position(1, 1),
					new Position(2, 0),
					new Position(2, 1)
				});

			this.Cells = tempMap;
			this.Move(0, 3);
		}

	}
}

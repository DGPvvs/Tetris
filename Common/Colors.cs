namespace Tetris.Common
{
	using Raylib_cs;

	public static class Colors
	{
		public static readonly Color darkGray = new Color(26, 31, 40, 255);
		public static readonly Color green = new Color(47, 230, 23, 255);
		public static readonly Color red = new Color(232, 18, 18, 255);
		public static readonly Color orange = new Color(226, 116, 17, 255);
		public static readonly Color yellow = new Color(237, 234, 4, 255);
		public static readonly Color purple = new Color(166, 0, 247, 255);
		public static readonly Color cyan = new Color(21, 204, 209, 255);
		public static readonly Color blue = new Color(13, 64, 216, 255);
		public static readonly Color lightBlue = new Color(59, 85, 162, 255);
		public static readonly Color darkBlue = new Color(44, 44, 127, 255);

		public static List<Color> GetSellColors => new List<Color>()
		{
			darkGray,
			green,
			red,
			orange,
			yellow,
			purple,
			cyan,
			darkBlue
		};
	}
}

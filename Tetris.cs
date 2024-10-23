namespace Tetris
{
	using global::Tetris.Classes;
	using Raylib_cs;
	using System.Numerics;
	using System.Text;

	using static Common.Colors;
	using static Common.Constants;
	using static Raylib_cs.Raylib;

	public class Tetris
	{
		static int Main(string[] args)
		{
			double lastUpdateTime = 0;
			InitWindow(WIDTH_SIZE, HEIGHT_SIZE, TITLE);
			SetTargetFPS(TARGET_FPS);
						
			//Font font;

			//unsafe
			//{
			//	StringBuilder sb = new StringBuilder();

			//	sbyte* name = GetApplicationDirectory();
			//	int i = 0;
			//	while (name[i] != '\0')
			//	{
			//		sb.Append((char)name[i]);
			//		i++;
			//	}

			//	sb.Append(FONT_PATH);
			//	byte[] bytes = Encoding.ASCII.GetBytes(sb.ToString());

			//	unsafe
			//	{
			//		fixed (byte* p = bytes)
			//		{
			//			sbyte* sp = (sbyte*)p;
			//			font = LoadFontEx(sp, 64, &codepoints, 0);
			//		}
			//	}
			//}

			Font font;
			unsafe
			{
				StringBuilder sbFont = new StringBuilder();

				sbyte* name = GetApplicationDirectory();
				int i = 0;
				while (name[i] != '\0')
				{
					sbFont.Append((char)name[i]);
					i++;
				}

				sbFont.Append("../../../font / monogram.ttf");

				byte[] bytesFont = Encoding.ASCII.GetBytes(sbFont.ToString());

				unsafe
				{
					fixed (byte* p = bytesFont)
					{
						int codepoint = 0;
						sbyte* sp = (sbyte*)p;
						font = LoadFontEx(sp, 64, &codepoint, 0);
					}
				}
			}

			Game game = new();			

			while (!WindowShouldClose())
			{
				UpdateMusicStream(game.Music);

				game.HandleInput();

				if (EventTriggered(.6, ref lastUpdateTime))
				{
					game.MoveBlockDown();
				}

				BeginDrawing();
				ClearBackground(darkBlue);
				

				DrawTextEx(font, "Score", new Vector2(365, 15), 38, 2, Color.White);
				DrawTextEx(font, "Next", new Vector2(370, 175), 38, 2, Color.White);

				if (game.GameOver)
				{
					DrawTextEx(font, "GAME OVER", new Vector2(320, 450), 33, 1, Color.White);
				}

				DrawRectangleRounded(new Rectangle(320, 55, 170, 60), .3f, 6, lightBlue);

				Vector2 textSize;

				unsafe
				{
					StringBuilder sb = new StringBuilder().Append(FONT_PATH);

					char[] arr = game.Score.ToString().ToCharArray();

					sbyte[] arr1 = new sbyte[arr.Length];

					for (int i = 0; i < arr1.Length; i++)
					{
						arr1[i] = (sbyte)arr[i];
					}

					fixed (sbyte* fixedPtr = arr1)
					{
						textSize = MeasureTextEx(font, fixedPtr, 38, 2);
					}

					fixed (sbyte* fixedPtr = arr1)
					{
						textSize = MeasureTextEx(font, fixedPtr, 38, 2);
						DrawTextEx(font, fixedPtr, new Vector2(320 + (170 - textSize.X) / 2, 65), 38, 2, Color.White);
					}
				}

				DrawRectangleRounded(new Rectangle(320, 215, 170, 180), .3f, 6, lightBlue);

				game.Draw();

				EndDrawing();
			}

			CloseWindow();

			return 0;
		}

		static bool EventTriggered(double interval, ref double lastUpdateTime)
		{
			double currentTime = GetTime();
			if (currentTime - lastUpdateTime >= interval)
			{
				lastUpdateTime = currentTime;
				return true;
			}

			return false;
		}
	}
}

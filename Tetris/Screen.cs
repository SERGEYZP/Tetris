/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 19.02.2017
 * Time: 12:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Tetris
{
	/// <summary>
	/// Screen is Singleton.
	/// </summary>
	public class Screen : DrawContext
	{
		readonly static int width = 80;
		readonly static int height = 25;
		static Screen instance = new Screen();

		public static int Width {
			get {
				return width;
			}
		}

		public static int Height {
			get {
				return height;
			}
		}

		public static Screen Instance {
			get {
				return instance;
			}
		}
		
		protected Screen()
		{
		}
		
		
		public static void SetWindowSettings()
		{
			Console.SetBufferSize(width, height);
			Console.CursorVisible = false;
		}
		
		public static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}
		
		public static void WriteText(String text, int param, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text, param);
		}
		
		public static void DrawGameOverMessage(int score)
		{
			int xOffset = (width - 30) / 2; //30 - длина нижеприведенных строк
			int yOffset = (height - 6) / 2; //6 - число нижеприведенных строк
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset);
			WriteText("==============================", xOffset, yOffset++);
			WriteText("|                            |", xOffset, yOffset++);			
			WriteText("| И Г Р А    О К О Н Ч Е Н А |", xOffset, yOffset++);
			WriteText("|        Score: {0,4}         |", score, xOffset, yOffset++);
			WriteText("|                            |", xOffset, yOffset++);
			WriteText("==============================", xOffset, yOffset++);
		}
	}
}

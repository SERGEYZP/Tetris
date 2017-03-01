/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 25.07.2016
 * Time: 15:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Tetris
{
	/// <summary>
	/// Description of Point.
	/// </summary>
	public class Point
	{
		public int x;
		public int y;
		public char sym;
		public ConsoleColor color;
		
		public Point(int x, int y, char sym, ConsoleColor color)
		{
			this.x = x;
			this.y = y;
			this.sym = sym;
			this.color = color;
		}
		
		public Point(Point p)
		{
			x = p.x;
			y = p.y;
			sym = p.sym;
			color = p.color;
		}

		
		public void Draw()
		{
			Console.ForegroundColor = color;
			Console.SetCursorPosition(x, y);
			Console.Write(sym);
		}
		
		void Draw(char ch)
		{
			Console.ForegroundColor = color;
			Console.SetCursorPosition(x, y);
			Console.Write(ch);
		}
		
		public void Erase()
		{
			Draw(' ');
		}

		public bool IsHit(Point p)
		{
			return x == p.x && y == p.y;
		}
	}
}

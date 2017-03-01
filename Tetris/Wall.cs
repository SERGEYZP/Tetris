/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 25.07.2016
 * Time: 15:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tetris
{
	/// <summary>
	/// Description of Wall.
	/// </summary>
	public class Wall
	{
		public List<Figure> wList;
		
		public Wall(int x, int y, int width, int height, char sym, ConsoleColor color)
		{
			wList = new List<Figure>();
			
			VerticalLine leftLine = new VerticalLine(y, y - height + 1, x, sym, color);
			VerticalLine rightLine = new VerticalLine(y, y - height + 1, x + width - 1, sym, color);
			HorizontalLine bottomLine = new HorizontalLine(x + 1, x + width - 1 - 1, y, sym, color);
			
			wList.Add(leftLine);
			wList.Add(rightLine);
			wList.Add(bottomLine);
			
			Draw();
		}
		
		public void Draw()
		{
			foreach(Figure wall in wList)
				wall.Draw();
		}
	}
}

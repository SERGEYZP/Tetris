/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 25.07.2016
 * Time: 15:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Tetris
{
	/// <summary>
	/// Description of VerticalLine.
	/// </summary>
	public class VerticalLine : Figure
	{
		public VerticalLine(int yBegin, int yEnd, int x, char sym, ConsoleColor color) : base (x, yBegin, sym)
		{
			if(yEnd > yBegin)
			{
				for(int y = yBegin; y <= yEnd; ++y)
					pList.Add(new Point(x, y, sym, color));
			}
			else
			{
				for(int y = yEnd; y <= yBegin; ++y)
					pList.Add(new Point(x, y, sym, color));
			}
		}
	}
}

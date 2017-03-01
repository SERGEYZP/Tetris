/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 25.07.2016
 * Time: 15:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Tetris
{
	/// <summary>
	/// Description of HorizontalLine.
	/// </summary>
	public class HorizontalLine : Figure
	{
		public HorizontalLine(int xBegin, int xEnd, int y, char sym, ConsoleColor color) : base(xBegin, y, sym)
		{
			if(xEnd > xBegin)
			{
				for(int x = xBegin; x <= xEnd; ++x)
					pList.Add(new Point(x, y, sym, color));
			}
			else
			{
				for(int x = xEnd; x <= xBegin; ++x)
					pList.Add(new Point(x, y, sym, color));
			}
		}
	}
}

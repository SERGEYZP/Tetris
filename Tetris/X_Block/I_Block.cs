/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 27.07.2016
 * Time: 16:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Tetris.X_Block
{
	/// <summary>
	/// Description of I_Block.
	/// </summary>
	public class I_Block : Block
	{
		public I_Block(int x, int y, char sym) : base(x, y, sym)
		{
			mass = new int[,] {
				{0, 1, 0, 0},
				{0, 1, 0, 0},
				{0, 1, 0, 0},
				{0, 1, 0, 0} };
			CreatePointsFromMass(mass.GetUpperBound(0) + 1, sym, ConsoleColor.Magenta, x, y);
		}
	}
}

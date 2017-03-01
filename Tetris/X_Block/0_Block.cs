/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 27.07.2016
 * Time: 16:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Tetris.X_Block
{
	/// <summary>
	/// Description of O_Block.
	/// </summary>
	public class O_Block : Block
	{
		public O_Block(int x, int y, char sym) : base(x, y, sym)
		{
			mass = new int[,] {
				{1, 1},
				{1, 1} };
			CreatePointsFromMass(mass.GetUpperBound(0) + 1, sym, ConsoleColor.Yellow, x, y);
		}
	}
}

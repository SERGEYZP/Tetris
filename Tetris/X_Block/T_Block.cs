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
	/// Description of T_Block.
	/// </summary>
	public class T_Block : Block
	{
		public T_Block(int x, int y, char sym) : base(x, y, sym)
		{
			mass = new int[,] {
				{0, 0, 0},
				{1, 1, 1},
				{0, 1, 0} };
			CreatePointsFromMass(mass.GetUpperBound(0) + 1, sym, ConsoleColor.Cyan, x, y);
		}
	}
}

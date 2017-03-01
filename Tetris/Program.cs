/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 25.07.2016
 * Time: 15:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Tetris
{
	class Program
	{
		public static void Main(string[] args)
		{
			Game game = new Game();
			game.MainLoop();
		}
	}
}
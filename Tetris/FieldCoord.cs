/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 19.02.2017
 * Time: 11:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;


namespace Tetris
{
	/// <summary>
	/// Description of FieldCoord.
	/// </summary>
	public class FieldCoord
	{
		public readonly int x; //левый нижний угол
		public readonly int y; //левый нижний угол
		public const int width = 10;
		public const int height = 20;

		public FieldCoord()
		{
			x = (Screen.Width - width) / 2;
			y = Screen.Height - (Screen.Height - height) / 2 - 2;
			Debug.Assert(((Screen.Width - width) / 2 ) > 13, "Game field too wide!!!");
			Debug.Assert((Screen.Height - height) > 0, "Game field too tall!!!");
		}
		
		public int X {
			get {
				return x;
			}
		}

		public int Y {
			get {
				return y;
			}
		}

		public int Width {
			get {
				return width;
			}
		}

		public int Height {
			get {
				return height;
			}
		}
	}
}

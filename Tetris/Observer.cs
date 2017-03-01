/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 28.02.2017
 * Time: 20:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Tetris
{
	/// <summary>
	/// Description of Observer.
	/// </summary>
	public abstract class Observer
	{
		protected Observer()
		{
		}
		
		public abstract void Notify();
	}
}

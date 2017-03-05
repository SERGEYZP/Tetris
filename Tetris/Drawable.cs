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
	/// Description of Drawable.
	/// </summary>
	public abstract class Drawable
	{
		protected Drawable(bool IsTemporaryCopy = false)
		{
			if(!IsTemporaryCopy)
				Screen.Instance.AddDrawableObj(this);
		}
		
		public abstract void Draw();
		public abstract void Erase();
		public abstract bool IsEqual(Drawable obj);
	}
}

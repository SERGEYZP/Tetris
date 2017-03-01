/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 25.07.2016
 * Time: 15:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tetris
{
	/// <summary>
	/// Description of Figure.
	/// </summary>
	public class Figure : Observer
	{
		public List<Point> pList;
		public int x;
		public int y;
		protected char sym;
		
		public Figure(int x, int y, char sym)
		{
			pList = new List<Point>();
			this.x = x;
			this.y = y;
			this.sym = sym;
			Screen.Instance.AddObserver(this);
		}
		
		void Draw()
		{
			foreach(Point p in pList)
				p.Draw();
		}
		
		void Erase()
		{
			foreach(Point p in pList)
				p.Erase();	
		}

		public void MoveLeft()
		{
			x--;
			foreach(Point p in pList)
				p.x--;
		}
		
		public void MoveRight()
		{
			x++;
			foreach(Point p in pList)
				p.x++;
		}
		
		public void MoveDown()
		{
			y++;
			foreach(Point p in pList)
				p.y++;
		}
		
		public void MoveUp()
		{
			y--;
			foreach(Point p in pList)
				p.y--;
		}		
		
		public void MoveToX(int x)
		{
			var offset = x - this.x;
			this.x = x;
			foreach(Point p in pList)
				p.x += offset;
		}
		
		public void MoveToY(int y)
		{
			var offset = y - this.y;
			this.y = y;
			foreach(Point p in pList)
					p.y += offset;
		}
		
		public bool IsHit(Figure figure)
		{
			foreach(Point p in pList)
				if(figure.IsHit(p))
					return true;
			
			return false;
		}
		
		protected bool IsHit(Point point)
		{
			foreach(Point p in pList)
				if(point.IsHit(p))
					return true;
			
			return false;
		}
		
		public override void Notify()
		{
			Draw();
		}
	}
}

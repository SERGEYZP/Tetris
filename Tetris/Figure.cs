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
	public class Figure : Drawable
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
		}
		
		public Figure(Figure figure) : base(true)
		{
			pList = new List<Point>();
			foreach (var point in figure.pList)
				pList.Add(new Point(point));
			x = figure.x;
			y = figure.y;
			sym = figure.sym;
		}
		
		public override void Draw()
		{
			foreach(Point p in pList)
				p.Draw();
		}
		
		public override void Erase()
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
		
		#region implemented abstract members of Drawable
		
//		public override bool IsEqual(Drawable obj)
//		{
//			var figure = obj as Figure;
//			if(figure != null)
//				if(x == figure.x && y == figure.y)
//					return true;
//			return false;
//		}
		
		public override bool IsEqual(Drawable obj)
		{
			var figure = obj as Figure;
			if(figure != null)
				if(x == figure.x && y == figure.y && pList.Count == figure.pList.Count)
				{
					for (int i = 0; i < pList.Count; i++)
						if(!pList[i].IsEqual(figure.pList[i]))
							return false;
					
					return true;
				}
					
			return false;
		}
		
		#endregion
	}
}

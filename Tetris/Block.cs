/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 25.07.2016
 * Time: 16:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;

namespace Tetris
{
	/// <summary>
	/// Description of block.
	/// </summary>
	abstract public class Block : Figure
	{
		protected Direction orientation;
		protected int[,] mass; //массив, в котором единица указывает на наличие точки
		
		protected Block(int x, int y, char sym) : base(x, y, sym)
		{
			orientation = Direction.UP;
		}
		
		protected void CreatePointsFromMass(int massSize, char sym, ConsoleColor color, int x, int y)
		{
			pList.Clear();
			
			for(int i = 0; i < massSize; ++i)
				for(int j = 0; j < massSize; ++j)
					if(mass[i, j] != 0)
						pList.Add(new Point(x + j, y + i, sym, color));
		}
		
		public void DropDown(Field field)
		{
			while(!IsCollision(field))
				MoveDown();
			MoveUp();
		}
		
		public bool IsCollision(Field field)
		{
			return (IsHit(field) || IsOutsideField(field));
		}
		
		public void Rotate(Direction direction)
		{
			int massSize = mass.GetUpperBound(0) + 1;
			int[,] newMass = new int[massSize, massSize];
			
			for(int i = 0; i < massSize; ++i)
				for(int j = 0; j < massSize; ++j)
					switch(direction)
					{
						case Direction.CLOCKWISE:
							newMass[j, (massSize - 1 ) - i] = mass[i, j];
							break;
						case Direction.COUNTERCLOCKWISE:
							newMass[(massSize - 1) - j, i] = mass[i, j];
							break;
						default:
							new NotImplementedException();
							break;
					}
			
			mass = newMass;
			CreatePointsFromMass(massSize, sym, pList.First().color, x, y);
		}
		
		bool IsOutsideField(Field field)
		{
			foreach(Point p in pList)
				if(p.x < field.x || p.x > field.x + field.width - 1 || p.y > field.y || p.y < field.y - field.height + 1)
					return true;
			
			return false;
		}
	}
}

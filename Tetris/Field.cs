/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 26.07.2016
 * Time: 11:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tetris
{
	/// <summary>
	/// Description of Field.
	/// </summary>
	public class Field : Figure
	{
		HorizontalLine hLine; //невидимая линия, используемая для поиска заполненной линии на поле
		public int width;
		public int height;
		
		public Field(int x, int y, int width, int height, char sym) : base(x, y, sym)
		{
			hLine = new HorizontalLine(x, x + width - 1, y, ' ', ConsoleColor.White);
			Screen.Instance.RemoveDrawableObj(hLine); //отключить отрисовку
			this.width = width;
			this.height = height;
		}

		public void AppendBlock(Block block)
		{
			Screen.Instance.RemoveDrawableObj(block);
			
			foreach(Point p in block.pList)
				p.sym = sym;
			
			pList.AddRange(block.pList);
			block.pList.Clear();
		}

		public int DeleteFilledLines()
		{
			int lineNumber;
			int deletedLines = 0;
			
			do
			{
				lineNumber = FindFilledLineNumber();
				if(lineNumber != -1)
				{
					++deletedLines;
					DeleteLine(lineNumber);
					JoinFieldParts(lineNumber);
				}
			}
			while(lineNumber != -1);
			
			return deletedLines;
		}

		int FindFilledLineNumber()
		{
			int lineNumber = -1;
			
			for(int i = 0; i < height; i++)
			{
				int n = 0;
				foreach(Point pF in pList) //pF - point Field
					foreach(Point pHL in hLine.pList) //pHL - point Horisontal Line
						if(pF.IsHit(pHL))
							n++;
				
				if(n == 0)
					break;
				
				if(n == width)
				{
					lineNumber = y - hLine.pList.First().y;
					break;
				}
				
				hLine.MoveUp();
			}
			
			hLine.MoveToY(y); //вернуть на начальную позицию, здесь "y" это координата класса Field
			
			return lineNumber;
		}
		
		void DeleteLine(int lineNumber)
		{
			List<Point> pListCopy = new List<Point>(pList);
			int y_LineToDelete = y - lineNumber; //координата по Y линии, которую нужно удалить
			
			foreach(Point p in pListCopy)
				if(p.y == y_LineToDelete)
					pList.Remove(p);
		}

		void JoinFieldParts(int emptyLineNumber)
		{
			int y_EmptyLineNumber = y - emptyLineNumber; //координата по Y пустой (удаленной) линии
			foreach(Point p in pList)
				if(p.y < y_EmptyLineNumber)
					p.y++;
		}
	}
}

/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 28.02.2017
 * Time: 20:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Tetris
{
	/// <summary>
	/// Description of DrawableObjects.
	/// </summary>
	public class DrawableObjects
	{
		readonly List<IDrawable> drawableCurrFrameList; //все объекты текущего кадра
		readonly List<IDrawable> drawablePrevFrameList; //Field и Block объекты предыдущего кадра, т.к. рамки поля и GameInfo не нужно перерисовывать
		
		protected DrawableObjects()
		{
			drawableCurrFrameList = new List<IDrawable>();
			drawablePrevFrameList = new List<IDrawable>();
		}
		
		public void AddIDrawableObj(IDrawable obj)
		{
			drawableCurrFrameList.Add(obj);
		}
		
		public void RemoveIDrawableObj(IDrawable obj)
		{
			drawableCurrFrameList.Remove(obj);
		}
		
		public void Update()
		{
			ErasePrevFrame();
			DrawCurrFrame();
			CopyCurrToPrevFrameList();
		}

		void DrawCurrFrame()
		{
			foreach (var obj in drawableCurrFrameList)
				obj.Draw();
		}
		
		void ErasePrevFrame()
		{
			foreach (var obj in drawablePrevFrameList)
				obj.Erase();
		}
		
		void CopyCurrToPrevFrameList()
		{
			drawablePrevFrameList.Clear();
			foreach (var obj in drawableCurrFrameList)
				if (obj is Field || obj is Block) //только те объекты, которые двигаются
					drawablePrevFrameList.Add(new Figure((Figure)obj));
		}
	}
}

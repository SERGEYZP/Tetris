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
using System.Linq;

namespace Tetris
{
	/// <summary>
	/// Description of DrawableObjects.
	/// </summary>
	public class DrawableObjects
	{
		readonly List<Drawable> currFrameList; //объекты кадра, который нужно отрисовать
		readonly List<Drawable> prevFrameList; //объекты предыдущего кадра
		readonly List<Drawable> eraseList; //список объектов, которые переместились по экрану, нужно стереть их предыдущую отрисовку
		readonly List<Drawable> drawList; //что нужно отрисовать заново
		readonly List<Drawable> removeList; //объекты, которые нужно удалить из списка отрисовываемых
		
		protected DrawableObjects()
		{
			currFrameList = new List<Drawable>();
			prevFrameList = new List<Drawable>();
			eraseList = new List<Drawable>();
			drawList = new List<Drawable>();
			removeList = new List<Drawable>();
		}
		
		public void AddDrawableObj(Drawable obj)
		{
			currFrameList.Add(obj);
		}
		
		public void RemoveDrawableObj(Drawable obj)
		{
			removeList.Add(obj);
		}
		
		public void Update()
		{
			FindNewObjects();
			FindMovedObjects();
			EraseMovedObjectsInPrevPosition();
//			DrawAllObjects();
			DrawMovedObjectsInNewPosition();
			RemoveObjectsFromCurrFrameList();
			CopyCurrToPrevFrameList();
			PrepareListsForNextUsage();
		}

		void FindNewObjects()
		{
			var offset = currFrameList.Count - prevFrameList.Count;
			if(offset != 0)
				while(offset > 0)
				{
					var i = currFrameList.Count - offset--;
					if(!removeList.Contains(currFrameList[i]))
						drawList.Add(currFrameList[i]);
				}
		}
		
		void FindMovedObjects()
		{
			eraseList.AddRange(removeList); //стереть объекты, которые будут удалены
			
			for(int i = 0; i < prevFrameList.Count; i++)
			{
				var prevObj = prevFrameList[i];
				var currObj = currFrameList[i];
				
				if(!prevObj.IsEqual(currObj))
				{
					eraseList.Add(prevObj);
					drawList.Add(currObj);
				}
			}
		}
		
		void EraseMovedObjectsInPrevPosition()
		{
			foreach(var obj in eraseList)
				obj.Erase();
		}
		
//		void DrawAllObjects()
//		{
//			foreach(var obj in currFrameList)
//				obj.Draw();
//		}

		void DrawMovedObjectsInNewPosition()
		{
			foreach(var obj in drawList)
				obj.Draw();
		}
		
		void RemoveObjectsFromCurrFrameList()
		{
			foreach(var obj in removeList)
				currFrameList.Remove(obj);
		}
		
		void CopyCurrToPrevFrameList()
		{
			prevFrameList.Clear();
			
			foreach(var obj in currFrameList)
			{
//				var objType = obj.GetType();
				if(obj is Figure)
					prevFrameList.Add(new Figure(obj as Figure));
				else if (obj is GameInfo)
					prevFrameList.Add(new GameInfo(obj as GameInfo));
				else
					throw new NotImplementedException("You add new type of object??? Add it to DrawableObjects.CopyCurrToPrevFrameList()");
			}
		}

		void PrepareListsForNextUsage()
		{
			eraseList.Clear();
			drawList.Clear();
			removeList.Clear();
		}
	}
}
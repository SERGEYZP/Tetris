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
	/// Description of Observable.
	/// </summary>
	public class Observable
	{
		readonly List<Observer> observers;
		
		protected Observable()
		{
			observers = new List<Observer>();
		}
		
		public void AddObserver(Observer observer)
		{
			observers.Add(observer);
		}
		
		public void RemoveObserver(Observer observer)
		{
			observers.Remove(observer);
		}
		
		public void Notify()
		{
			foreach(var observer in observers)
				observer.Notify();
		}
	}
}

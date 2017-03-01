﻿/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 19.02.2017
 * Time: 10:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Tetris
{
	/// <summary>
	/// Description of GameInfo.
	/// </summary>
	public class GameInfo
	{
		int score;
		int level;
		readonly int maxLevel;
		#pragma warning disable 414 //отключаем ошибочное предупреждение о неиспользуемой переменной
			bool isGameOver;
		#pragma warning restore 414
		
		readonly int infoPositionOnScreenX;
		readonly int infoPositionOnScreenY;
		const int levelUpScore = 25; //соколько очков соответствует одному уровню
		
		public GameInfo(FieldCoord fieldCoord, int startLevel, int maxLevel)
		{
			level = startLevel;
			this.maxLevel = maxLevel;
			score = 0;
			isGameOver = false;
			infoPositionOnScreenX = fieldCoord.X + fieldCoord.Width + 3;
			infoPositionOnScreenY = fieldCoord.Y - fieldCoord.Height + 6;
			Draw();
		}

		public int Score {
			get { return score; }
		}

		public int Level {
			get { return level;	}
		}
		
		public bool IsGameOver {
			get;
			set;
		}
		
		void CalculateScore(int deletedLines)
		{
			switch(deletedLines)
			{
				case 1:
					score += 1;
					break;
				case 2:
					score += 3;
					break;
				case 3:
					score += 7;
					break;
				case 4:
					score += 15;
					break;
				default:
					throw new NotImplementedException();
			}
		}
		
		void CalculateLevel()
		{
			int prevLevel = level;
			level = (int)(score / levelUpScore) + 1;
			if(level > maxLevel)
				level = maxLevel;
			if(level != prevLevel)
				Console.Beep();
		}
		
		public void UpdateInfo(int deletedLines = 0)
		{
			if(deletedLines != 0) {
				CalculateScore(deletedLines);
				CalculateLevel();
				Draw();
			}
		}
		
		public void Draw()
		{
			Console.ForegroundColor = ConsoleColor.White;
			Screen.WriteText("Level: {0,4}", level, infoPositionOnScreenX, infoPositionOnScreenY);
			Screen.WriteText("Score: {0,4}", score, infoPositionOnScreenX, infoPositionOnScreenY + 1);
		}
	}
}

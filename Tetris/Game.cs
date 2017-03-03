/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 31.07.2016
 * Time: 10:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading;

namespace Tetris
{
	/// <summary>
	/// Description of Game.
	/// </summary>
	public class Game
	{
		FieldCoord fieldCoord; //Field parameters
		
		//Game parameters
		const int startLevel = 1;
		const int maxLevel = 10;
		const int mainLoopPeriod = 100; //мсек, период логического движка игры
					//maxLevel * tickTime = период падения блока на одну клетку вниз
		
		int i; //счетчик для ожидания момента, когда нужно сдвинуть блок вниз
		ConsoleKeyInfo key;


		
		readonly Wall wall;
		readonly Field field;
		readonly BlocksManager blocksManager;
		readonly GameInfo gameInfo;
		
		public Game()
		{
			i = startLevel;
			key = default(ConsoleKeyInfo);
			fieldCoord = new FieldCoord();
			Screen.SetWindowSettings();
			gameInfo = new GameInfo(fieldCoord, startLevel, maxLevel);
			wall = new Wall(fieldCoord.X - 1, fieldCoord.Y + 1, fieldCoord.Width + 2, fieldCoord.Height + 1, '+', ConsoleColor.Gray);
			field = new Field(fieldCoord.X, fieldCoord.Y, fieldCoord.Width, fieldCoord.Height, '#');
			blocksManager = new BlocksManager(fieldCoord);
		}
		
		void FlushConsoleInputBuffer()
		{
			while(Console.KeyAvailable) 
				Console.ReadKey(true);
		}

		public void MainLoop()
		{
			while(true)
			{
				Thread.Sleep(mainLoopPeriod);
				
				PerformGameTick();
				
				if(gameInfo.IsGameOver)
					break;
			}
			
			//TODO (попробовал через паттерн Observer, экран начинает мигать!!!)в классе Screen создать список (интерфейс IDrawable) с фигурами (Figure), и пробегаясь по списку их отрисовывать, перед этим очистив экран
			Screen.DrawGameOverMessage(gameInfo.Score);
			Console.ReadKey(true);
		}

		void PerformGameTick()
		{ 
			ReadUserInput();
			ExecuteUserLogic();
			ExecuteWorldLogic();
			UpdateScreen();
		}
		
		void ReadUserInput()
		{
			if(Console.KeyAvailable)
			{
				key = Console.ReadKey(true); //TRUE - не отображать вводимый символ
				if(key.Key == ConsoleKey.Escape)
				{
					gameInfo.IsGameOver = true;
					return;
				}
				FlushConsoleInputBuffer(); //сбрасываем буффер консоли
			}
			else
				key = default(ConsoleKeyInfo); // key = 0;
		}
		
		void ExecuteUserLogic()
		{
			if(key.Key != 0) //если не ноль, значит что-то нажали
				HandleKey(key.Key);
		}

		void ExecuteWorldLogic()
		{
			if(++i >= maxLevel) //ожидаем, когда нужно будет сдвинуть блок вниз
			{
				i = gameInfo.Level;
				//принудительно отправляем клавишу "Стрелка Вниз"
				if(!HandleKey(ConsoleKey.DownArrow)) //если не сдвинулся, то снизу уже мешают
				{
					field.AppendBlock(blocksManager.CurrentBlock); //поглотить блок
					
					int deletedLines = field.DeleteFilledLines(); //удалить возможные заполненные линии
					gameInfo.UpdateInfo(deletedLines);
					blocksManager.CreateNewBlock();
					
					if(blocksManager.CurrentBlock.IsHit(field))
						gameInfo.IsGameOver = true;
				}
			}
		}

		void UpdateScreen()
		{
			Console.Clear();
			Screen.Instance.Notify();
		}
		
		bool HandleKey(ConsoleKey key)
		{
			bool moveDone = true;
			Block currentBlock = blocksManager.CurrentBlock;
			
			switch(key) //TODO что-то с этим сделать!!!
			{
				case ConsoleKey.UpArrow:
					currentBlock.Rotate(Direction.CLOCKWISE);
					if(currentBlock.IsCollision(field)) { //если коллизия, то попробовать сдвинуть влево
						currentBlock.MoveLeft(); //сдвинули влево
						if(currentBlock.IsCollision(field)) { //если снова коллизия, то вернуть на место и попробовать сдвинуть вправо
							currentBlock.MoveRight(); //вернули на место
							currentBlock.MoveRight(); //сдвинули вправо
							if(currentBlock.IsCollision(field)) { //если снова коллизия, то вернуть на место и попробовать сдвинуть вверх
								currentBlock.MoveLeft(); //вернули на место
								currentBlock.MoveUp(); //сдвинули вверх
								if(currentBlock.IsCollision(field)) { //если снова коллизия, то вернуть на место
									currentBlock.MoveDown(); //вернули на место
									currentBlock.Rotate(Direction.COUNTERCLOCKWISE); //развернули в первоначальное положение
									moveDone = false;
								}
							}
						}
					}
					break;
				case ConsoleKey.LeftArrow:
					currentBlock.MoveLeft();
					if(currentBlock.IsCollision(field))
					{
						currentBlock.MoveRight();
						moveDone = false;
					}
					break;
				case ConsoleKey.RightArrow:
					currentBlock.MoveRight();
					if(currentBlock.IsCollision(field))
					{
						currentBlock.MoveLeft();
						moveDone = false;
					}
					break;
				case ConsoleKey.DownArrow:
					currentBlock.MoveDown();
					if(currentBlock.IsCollision(field))
					{
						currentBlock.MoveUp();
						moveDone = false;
					}
					break;
				case ConsoleKey.Spacebar:
					currentBlock.DropDown(field);
					i = maxLevel; //чтобы "поле" сразу "съело" блок
					break;
			}
			
			return moveDone;
		}
	}
}

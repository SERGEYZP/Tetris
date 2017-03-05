/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 21.02.2017
 * Time: 18:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Tetris
{
	/// <summary>
	/// Description of BlocksManager.
	/// </summary>
	public class BlocksManager
	{
		readonly int fieldCenterX;
		readonly BlockCreator blockCreator;
		Block currentBlock, nextBlock;

		public Block CurrentBlock {
			get {
				return currentBlock;
			}
		}
		
		public BlocksManager(FieldCoord fieldCoord)
		{
			fieldCenterX = fieldCoord.X + fieldCoord.Width/2 - 1; //центр поля по горизонтали
			blockCreator = new BlockCreator(fieldCoord.X + fieldCoord.Width + 3, fieldCoord.Y - fieldCoord.Height + 1, '*'); //стартовая позиция для блока - справа вверху за пределами поля
			nextBlock = blockCreator.CreateBlock();
			CreateNewBlock();
		}
		
		public void CreateNewBlock()
		{
			SetNextBlockAsCurrentBlock();
			CreateNextBlock();
		}

		void SetNextBlockAsCurrentBlock()
		{
			currentBlock = nextBlock;
			currentBlock.MoveToX(fieldCenterX);
		}

		void CreateNextBlock()
		{
			nextBlock = blockCreator.CreateBlock();
		}
	}
}

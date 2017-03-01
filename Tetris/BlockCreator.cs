/*
 * Created by SharpDevelop.
 * User: Fixer
 * Date: 25.07.2016
 * Time: 16:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using Tetris.X_Block;

namespace Tetris
{
	/// <summary>
	/// Description of BlockCreator.
	/// </summary>
	public class BlockCreator
	{
		readonly int blockStartPosiotionX;
		readonly int blockStartPositionY;
		readonly char sym;
		
		readonly Random random;
		
		public BlockCreator(int blockStartPosiotionX, int blockStartPosiotionY, char sym)
		{
			this.blockStartPosiotionX = blockStartPosiotionX;
			this.blockStartPositionY = blockStartPosiotionY;
			this.sym = sym;
			random = new Random();
		}
		
		public Block CreateBlock()
		{
			BlockType type = (BlockType)random.Next(0, (int)BlockType.Count);
			switch(type)
			{
				case BlockType.I:
					return new I_Block(blockStartPosiotionX, blockStartPositionY, sym);
				case BlockType.J:
					return new J_Block(blockStartPosiotionX, blockStartPositionY, sym);
				case BlockType.L:
					return new L_Block(blockStartPosiotionX, blockStartPositionY, sym);
				case BlockType.O:
					return new O_Block(blockStartPosiotionX, blockStartPositionY, sym);
				case BlockType.S:
					return new S_Block(blockStartPosiotionX, blockStartPositionY, sym);
				case BlockType.T:
					return new T_Block(blockStartPosiotionX, blockStartPositionY, sym);
				case BlockType.Z:
					return new Z_Block(blockStartPosiotionX, blockStartPositionY, sym);
				default:
					throw new NotImplementedException();
			}
		}
	}
}

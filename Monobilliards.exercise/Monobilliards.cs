using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Monobilliards
{
	public class Monobilliards : IMonobilliards
	{
		public bool IsCheater(IList<int> inspectedBalls)
		{
            var queue = new Queue<int>();
            var stack = new Stack<int>();
            int length;

            foreach(var ball in inspectedBalls)
            {
                if (stack.Count == 0 || Math.Abs(stack.Peek() - ball) == 1)
                    stack.Push(ball);
                else
                {
                    length = stack.Count;
                    for (int i = 0; i < length; i++)
                    {
                        queue.Enqueue(stack.Pop());
                    }
                    stack.Push(ball);
                }
            }

            length = stack.Count;
            for (int i = 0; i < length; i++)
            {
                queue.Enqueue(stack.Pop());
            }

            if (queue.Count > 0)
            {
                if (queue.First() != 1)
                {
                    queue = new Queue<int>(queue.Reverse());
                }

                int counter = 1;
                foreach (var ball in queue)
                {
                    if (counter != ball) return true;
                    counter++;
                }
            }
            return false;
		}
	}
}
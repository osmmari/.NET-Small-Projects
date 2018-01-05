using System.Collections.Generic;

namespace func.brainfuck
{
    public class BrainfuckLoopCommands
    {
        public static void RegisterTo(IVirtualMachine vm)
        {
            var loops = FindLoops(vm.Instructions);

            vm.RegisterCommand('[', b =>
            {
                if (b.Memory[b.MemoryPointer] == 0) b.InstructionPointer = loops[b.InstructionPointer];
            });

            vm.RegisterCommand(']', b =>
            {
                if (b.Memory[b.MemoryPointer] != 0) b.InstructionPointer = loops[b.InstructionPointer];
            });
        }

        private static Dictionary<int, int> FindLoops(string program)
        {
            var loops = new Dictionary<int, int>();
            var startPositions = new Stack<int>();

            for (var i = 0; i < program.Length; i++)
            {
                if (program[i] == '[')
                    startPositions.Push(i);

                if (program[i] == ']')
                {
                    var startPosition = startPositions.Pop();
                    var closePosition = i;

                    loops.Add(startPosition, closePosition);
                    loops.Add(closePosition, startPosition);
                }
            }

            return loops;
        }
    }
}
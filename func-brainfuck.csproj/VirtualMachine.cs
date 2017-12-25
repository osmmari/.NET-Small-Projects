using System;
using System.Collections.Generic;

namespace func.brainfuck
{
	public class VirtualMachine : IVirtualMachine
	{
        private byte[] memory;
        private int memoryPointer = 0;
        private string instructions;
        private int instructionPointer = 0;
        private Dictionary<char, Action<IVirtualMachine>> commands = new Dictionary<char, Action<IVirtualMachine>>();

        public VirtualMachine(string program, int memorySize)
		{
            instructions = program;
            memory = new byte[memorySize];
		}

		public void RegisterCommand(char symbol, Action<IVirtualMachine> execute)
		{
            commands.Add(symbol, execute);
        }

		public string Instructions { get { return instructions; } }
		public int InstructionPointer
        {
            get { return instructionPointer; }
            set { instructionPointer = value; } 
        }
		public byte[] Memory { get { return memory; } }
		public int MemoryPointer { get { return memoryPointer; } set { memoryPointer = value; } }

        public void Run()
		{
			while(InstructionPointer < instructions.Length && InstructionPointer >= 0)
            {
                var symbol = Instructions[InstructionPointer];
                if (commands.ContainsKey(symbol))
                    commands[symbol](this);
                InstructionPointer++;
            }
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace func.brainfuck
{
	public class BrainfuckBasicCommands
	{
        static readonly char[] constant = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890".ToCharArray();

        public static void RegisterTo(IVirtualMachine vm, Func<int> read, Action<char> write)
		{
			vm.RegisterCommand('.', b => { write((char) (b.Memory[b.MemoryPointer])); });
			vm.RegisterCommand('+', b => 
            {
                if (b.Memory[b.MemoryPointer] == 255)
                    b.Memory[b.MemoryPointer] = 0;
                else b.Memory[b.MemoryPointer]++;
            });
			vm.RegisterCommand('-', b => 
            {
                if (b.Memory[b.MemoryPointer] == 0)
                    b.Memory[b.MemoryPointer] = 255;
                else b.Memory[b.MemoryPointer]--;
            });
            vm.RegisterCommand(',', b => { b.Memory[b.MemoryPointer] = (byte) read(); });
            vm.RegisterCommand('>', b => 
            {
                if (b.MemoryPointer == b.Memory.Length - 1)
                    b.MemoryPointer = 0;
                else b.MemoryPointer++;
            });
            vm.RegisterCommand('<', b => 
            {
                if (b.MemoryPointer == 0)
                    b.MemoryPointer = b.Memory.Length - 1;
                else b.MemoryPointer--;
            });

            foreach(var ch in constant)
            {
                vm.RegisterCommand(ch, b => { b.Memory[b.MemoryPointer] = (byte)ch; });
            }
        }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace func.brainfuck
{
	public class BrainfuckBasicCommands
	{
		public static void RegisterTo(IVirtualMachine vm, Func<int> read, Action<char> write)
		{
			vm.RegisterCommand('.', b => { });
			vm.RegisterCommand('+', b => {});
			vm.RegisterCommand('-', b => {});
			//...
		}
	}
}
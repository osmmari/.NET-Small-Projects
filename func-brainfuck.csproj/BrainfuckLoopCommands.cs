using System.Collections.Generic;

namespace func.brainfuck
{
	public class BrainfuckLoopCommands
	{
		public static void RegisterTo(IVirtualMachine vm)
		{
			vm.RegisterCommand('[', b => { });
			vm.RegisterCommand(']', b => { });
		}
	}
}
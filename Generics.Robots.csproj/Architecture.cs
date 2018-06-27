using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Generics.Robots
{
    public interface IRobotAI<out AI> //where AI : IMoveCommand
    {
        AI GetCommand();
    }

    public abstract class RobotAI<AI> : IRobotAI<AI> //where AI : IMoveCommand
    {
        protected int counter = 1;

        public abstract AI GetCommand();
    }

    public class ShooterAI : RobotAI<ShooterCommand>
    {
        public override ShooterCommand GetCommand()
        {
            return ShooterCommand.ForCounter(counter++);
        }
    }

    public class BuilderAI : RobotAI<BuilderCommand>
    {
        public override BuilderCommand GetCommand()
        {
            return BuilderCommand.ForCounter(counter++);
        }
    }

    public interface IDevice<Command>
    {
        string ExecuteCommand(Command command);
    }

    public abstract class Device<Command> : IDevice<Command> //where Command : IMoveCommand
    {
        public abstract string ExecuteCommand(Command command);
    }

    public class Mover : Device<IMoveCommand>
    {
        public override string ExecuteCommand(IMoveCommand command)
        {
            if (command == null)
                throw new ArgumentException();
            return $"MOV {command.Destination.X}, {command.Destination.Y}";
            //return String.Format("MOV {0}, {1}", command.Destination.X, command.Destination.Y);
        }
    }

    public class Robot
    {
        IRobotAI<IMoveCommand> ai;
        IDevice<IMoveCommand> device;

        public Robot(IRobotAI<IMoveCommand> ai, IDevice<IMoveCommand> executor)
        {
            this.ai = ai;
            this.device = executor;
        }

        public IEnumerable<string> Start(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                var command = ai.GetCommand();
                if (command == null)
                    break;
                yield return device.ExecuteCommand(command);
            }
        }

        public static Robot Create(IRobotAI<IMoveCommand> ai, IDevice<IMoveCommand> executor)
        {
            return new Robot(ai, executor);
        }
    }
}

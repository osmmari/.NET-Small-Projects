using System;
using System.Collections.Generic;
//using System.Collections;
//using System.Linq;

namespace Clones
{
    public class CloneVersionSystem : ICloneVersionSystem
    {
        private List<Clone> clones;


        public CloneVersionSystem()
        {
            clones = new List<Clone>();
        }

        public string Execute(string query)
        {
            if (clones.Count == 0)
            {
                clones.Add(new Clone(new Stack(), new Stack()));
            }
            if (query.Length > 0)
            {
                string[] command = query.Split();
                if (command.Length > 1)
                {
                    var id = Convert.ToInt32(command[1]);
                    if (id <= clones.Count && id > 0)
                    {
                        switch (command[0])
                        {
                            case "learn":
                                Learn(id, Convert.ToInt32(command[2]));
                                break;
                            case "rollback":
                                Rollback(id);
                                break;
                            case "relearn":
                                Relearn(id);
                                break;
                            case "clone":
                                NewClone(id);
                                break;
                            case "check":
                                return Check(id);
                            default:
                                break;
                        }
                    }
                }
            }
            return null;
        }

        private void Learn(int id, int program)
        {
            clones[id - 1].history = new Stack();
            if (!clones[id - 1].knowledges.Contains(program))
                clones[id - 1].knowledges.Push(program);
        }

        private void Rollback(int id)
        {
            if (clones[id - 1].knowledges.IsNotNull())
            {
                var lastProgram = clones[id - 1].knowledges.Pop();
                clones[id - 1].history.Push(lastProgram);
            }
        }

        private void Relearn(int id)
        {
            if (clones[id - 1].history.IsNotNull())
            {
                var lastProgram = clones[id - 1].history.Pop();
                clones[id - 1].knowledges.Push(lastProgram);
            }
        }

        private void NewClone(int id)
        {

            Clone newClone = new Clone(clones[id - 1]);
            clones.Add(newClone);
        }

        private string Check(int id)
        {
            if (clones[id - 1].knowledges.IsNotNull())
            {
                return clones[id - 1].knowledges.Peek().ToString();
            }
            return "basic";
        }
    }

    public class Clone
    {
        public Stack knowledges;
        public Stack history;

        public Clone(Stack knowledges_, Stack history_)
        {
            knowledges = knowledges_;
            history = history_;
        }

        public Clone(Clone anotherClone)
        {
            history = new Stack();
            knowledges = new Stack();
            history.Clone(anotherClone.history);
            knowledges.Clone(anotherClone.knowledges);
        }
    }

    public class StackItem
    {
        public int Value { get; set; }
        public StackItem Next { get; set; }
    }

    public class Stack
    {
        StackItem bottom;
        StackItem peek;

        public Stack()
        {
            bottom = null;
            peek = null;
        }

        public void Push(int value)
        {
            if (bottom == null)
                peek = bottom = new StackItem { Value = value, Next = null };
            else
            {
                var item = new StackItem { Value = value, Next = peek };
                peek = item;
            }
        }

        public int Pop()
        {
            if (bottom == null) throw new InvalidOperationException();
            var result = peek.Value;
            peek = peek.Next;
            if (peek == null)
                bottom = null;
            return result;
        }

        public int Peek()
        {
            return peek.Value;
        }

        public bool Contains(int value)
        {
            if (peek != null)
            {
                StackItem stackItem = peek;
                while (stackItem != null)
                    if (stackItem.Value != value)
                        stackItem = stackItem.Next;
                    else return true;
            }
            return false;
        }

        public bool IsNotNull()
        {
            if (peek != null)
            {
                StackItem stackItem = peek;
                if (stackItem != null)
                    return true;
            }
            return false;
        }

        public void Clone(Stack anotherStack)
        {
            this.bottom = anotherStack.bottom;
            this.peek = anotherStack.peek;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumster.Figures
{
    public class UndoRedoManager
    {
        public event EventHandler StateChanged = delegate { };

        public bool CanUndo { get { return UndoStack.Count > 0; } }
        public bool CanRedo { get { return RedoStack.Count > 0; } }

        Stack<Command> UndoStack { get; set; }
        Stack<Command> RedoStack { get; set; }

        public UndoRedoManager()
        {
            UndoStack = new Stack<Command>();
            RedoStack = new Stack<Command>();
        }

        public void Undo()
        {
            if (UndoStack.Count > 0)
            {
                //изымаем команду из стека
                var command = UndoStack.Pop();
                //отменяем действие команды
                command.UnExecute();
                //заносим команду в стек Redo
                RedoStack.Push(command);
                //сигнализируем об изменениях
                StateChanged(this, EventArgs.Empty);
            }
        }

        public void Redo()
        {
            if (RedoStack.Count > 0)
            {
                //изымаем команду из стека
                var command = RedoStack.Pop();
                //выполняем действие команды
                command.Execute();
                //заносим команду в стек Undo
                UndoStack.Push(command);
                //сигнализируем об изменениях
                StateChanged(this, EventArgs.Empty);
            }
        }

        //выполняем команду
        public void Execute(Command command)
        {
            //выполняем команду
            command.Execute();
            //заносим в стек Undo
            UndoStack.Push(command);
            //очищаем стек Redo
            RedoStack.Clear();
            //сигнализируем об изменениях
            StateChanged(this, EventArgs.Empty);
        }

        //public IEnumerable<string> UndoItems
        //{
        //    get { return UndoStack.Select(c => c.Name); }
        //}
        //
        //public IEnumerable<string> RedoItems
        //{
        //    get { return RedoStack.Select(c => c.Name); }
        //}

        public void Undo(int count)
        {
            for (int i = 0; i < count; i++)
                Undo();
        }

        public void Redo(int count)
        {
            for (int i = 0; i < count; i++)
                Redo();
        }
    }
}

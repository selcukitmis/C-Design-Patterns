using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();
            var modified = new ModifiedState();
            var deleted = new DeletedState();
            modified.DoAction(context);

            var state = context.GetState();
            Console.WriteLine(state.ToString());

            Console.ReadLine();
        }
    }

    interface IState
    {
        void DoAction(Context context);

    }

    class ModifiedState : IState
    {

        public void DoAction(Context context)
        {
            Console.WriteLine("State: Modified");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Modified!";
        }
    }

    class DeletedState : IState
    {

        public void DoAction(Context context)
        {
            Console.WriteLine("State: DeletedState");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Deleted!";
        }

    }

    class AddedState : IState
    {

        public void DoAction(Context context)
        {
            Console.WriteLine("State: AddedState");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Added!";
        }

    }

    class Context
    {
        private IState _state;
        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        }
    }
}

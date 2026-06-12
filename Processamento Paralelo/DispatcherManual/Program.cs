using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DispatcherManual
{
    internal class ManualDispatcher
    {
        ConcurrentQueue<Action> actions = new ConcurrentQueue<Action>();
        public void QueueAction(Action action)
        {
            actions.Enqueue(action);
        }

        public void ProcessQueue()
        {
            while(actions.TryDequeue(out Action action))
            {
                action.Invoke();
            }
        }
    }

    internal class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            ManualDispatcher dispatcher = new ManualDispatcher();
            int x = 0;
            while (true)
            {
                Task.Run(() =>
                {
                    dispatcher.QueueAction(() => {
                        Thread.Sleep(random.Next(100,500));
                        Interlocked.Increment(ref x);
                        Console.WriteLine(x); 
                    });
                });
                dispatcher.ProcessQueue();
            }
        }
    }
}

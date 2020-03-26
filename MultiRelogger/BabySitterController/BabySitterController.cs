using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BigSister
{
    static partial class BSController
    {
        public static List<BabySitter> BabySitters = new List<BabySitter>();
        public static List<Settings> BabySitterSettings = new List<Settings>();

        private static volatile Queue<BabySitter> _tasks = new Queue<BabySitter>();
        private static Thread doWork;
        public static void QueueForControl(BabySitter sitter)
        {
            if(!_tasks.Contains(sitter))
                _tasks.Enqueue(sitter);

            if (doWork == null || !doWork.IsAlive)
                Init();
        }
        public static bool IsInQueue(BabySitter sitter)
        {
            return _tasks.Contains(sitter);
        }
        public static bool IsMyTurn(BabySitter sitter)
        {
            return _tasks.Peek()==sitter;
        }
        public static void Init()
        {
            if(doWork != null && doWork.IsAlive)
                return;
            doWork = new Thread(DoWork);
            doWork.Start();
        }
        public static void DoWork()
        {
            while (true)
            {
                if(_tasks.Count > 0)
                {
                    BabySitter sitter = _tasks.Peek();
                    sitter.HasControl = true;
                    sitter.StartFreshWowAndBotSequence(true);
                    Thread.Sleep(2000);
                    while (sitter.HasControl)
                        Thread.Sleep(1000);
                    Thread.Sleep(2000);
                    //only dequeue now so that others can still see it as queued
                    _tasks.Dequeue();
                }
                Thread.Sleep(1000);
            }
        }

    }
}

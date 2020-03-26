using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BigSister
{
    class BabySitterSync
    {
        private List<BabySitter> _sitters;

        public BabySitterSync(List<BabySitter> sits)
        {
            _sitters = sits;
        }
        public  BabySitterSync()
        {
            
        }

        public void DoSequentialStart()
        {
            //dont use for now
            foreach (BabySitter bs in _sitters)
            {
                // giving you control
                bs.HasControl = true;
                if(!bs.Watching)
                    bs.BabySit();
                Thread.Sleep(100);
                while (bs.HasControl)
                    Thread.Sleep(1000);
            }
        }

        private List<BabySitter> _queue = new List<BabySitter>();
        private BabySitter _currentCustumer;
        public void QueueMeForControl(BabySitter sit)
        {
            if(!_queue.Contains(sit))
                _queue.Add(sit);

            if(_currentCustumer == null)
                _currentCustumer = sit;
        }
        public void UpdateQueueList()
        {
            if (_queue.Count <= 0)
                return;

            if (_currentCustumer == null)
            {
                _currentCustumer = _queue[0];
                _queue.RemoveAt(0);
            }

            if(_currentCustumer.Status == BabySitter.Action.Finished)
            {
                // current custumer is finished, move to next one
                if (_currentCustumer == _queue[0])
                    _queue.RemoveAt(0);
                _currentCustumer = _queue[0];
            }
        }
        public bool IsItMyTurn(BabySitter sit)
        {
            //ur the only one in queue, go ahead
            if(_queue.Count<2)
                return true;

            if (_currentCustumer == sit)
                return true;

            UpdateQueueList();
            return false;
        }
    }
}

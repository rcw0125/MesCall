using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using AppSvrIF;

namespace NCCaller
{
    public class AliveNotifier
    {
        private Thread m_Thread = null;
        private Session m_Session = null;
        private bool m_bQuit = false;

        public AliveNotifier(Session l3session)
        {
        }

        public Session L3Session
        {
            get { return m_Session; }
            set { m_Session = value; }
        }

        public bool ShouldQuit
        {
            get { return m_bQuit; }
        }

        public void Start()
        {
            m_bQuit = false;
            if (m_Thread == null)
            {
                m_Thread = new Thread(new ParameterizedThreadStart(this.ThreadFunc));
                m_Thread.Start(this);
            }
        }

        public void Stop()
        {
            if (m_Thread == null)
                return;

            m_bQuit = true;
            while (m_Thread.ThreadState == ThreadState.Running)
            {
                Thread.Sleep(5000);
            }
        }

        public void ThreadFunc(object param)
        {
            AliveNotifier notifier = param as AliveNotifier;
            if (notifier == null)
                return;

            if (notifier.L3Session == null)
                return;

            while (!notifier.ShouldQuit)
            {
                object obj = null;
                int i = 0;
                notifier.L3Session.Get(@"XGMESLogic\BaseDataMag\CCommunicationStatus\NC", "WatchDog", ref obj);
                if (obj != null)
                {
                    i = Convert.ToInt32(obj);
                    i = i % 9999 + 1;
                }
                if (i != 0)
                {
                    notifier.L3Session.Set(@"XGMESLogic\BaseDataMag\CCommunicationStatus\NC", "WatchDog", i);
                }
                Thread.Sleep(5000);
            }
        }
    }
}

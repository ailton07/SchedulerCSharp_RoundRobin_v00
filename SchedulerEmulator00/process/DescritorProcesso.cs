using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchedulerEmulator00.process
{
    public class DescritorProcesso
    {
        // Identificacao do Processo
        private int id = 0;
        bool isDone = false;
        //TASK_RUNNING      0
        //TASK_RUNNING_REAL   1
        //TASK_INTERRUPTIBLE    2
        //TASK_STOPPED          3
        int state = 0; 
        // Controle do Proceso
        public ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        public ManualResetEvent _pauseEvent = new ManualResetEvent(true);

        private Thread thread;

        public Thread Thread
        {
            get
            {
                return thread;
            }

            set
            {
                thread = value;
            }
        }

        public DescritorProcesso(int id)
        {
            Id = id;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public bool IsDone
        {
            get
            {
                return isDone;
            }

            set
            {
                isDone = value;
            }
        }

        public int State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }
    }
}

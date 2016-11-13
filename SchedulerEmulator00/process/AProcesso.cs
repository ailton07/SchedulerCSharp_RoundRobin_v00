using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchedulerEmulator00.process
{
    public abstract class AProcesso
    {
        public DescritorProcesso descritorProcesso;
        
        abstract public void Prologue();

        // Parte do logica do processo
        private Processo processo;



        // Getter and setter



        public Processo Processo
        {
            get
            {
                return processo;
            }

            set
            {
                processo = value;
            }
        }

        public DescritorProcesso DescritorProcesso
        {
            get
            {
                return descritorProcesso;
            }

            set
            {
                descritorProcesso = value;
            }
        }
    }
}

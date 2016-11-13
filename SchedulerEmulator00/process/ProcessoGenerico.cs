using SchedulerEmulator00.process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchedulerEmulator00.process
{
    // Fontes: http://stackoverflow.com/questions/142826/is-there-a-way-to-indefinitely-pause-a-thread
    // Define os comportamentos genericos dos processos
    public class ProcessoGenerico : AProcesso
    {

        public ProcessoGenerico(int id)
        {
            DescritorProcesso = new DescritorProcesso(id);
            Processo = new Processo(id, ref descritorProcesso);

        }

        public override void Prologue()
        {
            // Thread running, mas nao executando. Apenas aguardando sinal
            Console.WriteLine("Thread '{0}'  TASK_RUNNING", DescritorProcesso.Id);
            DescritorProcesso.State = 0;
            //Resume();

            DescritorProcesso.State = 1;
            Processo.doMyJob();
        }

        public void Pause()
        {
            DescritorProcesso._pauseEvent.Reset();
        }

        public void Resume()
        {
            DescritorProcesso._pauseEvent.Set();
        }

        public void processoExecutando()
        {
            Console.WriteLine("/*********************************/");
            Console.WriteLine("/*****Processo {0} Executando*****/", DescritorProcesso.Id);
            Console.WriteLine();
        }

    }
}

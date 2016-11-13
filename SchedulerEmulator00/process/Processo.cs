using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchedulerEmulator00.process
{
    // Modela o comportamento lógico do processo

    public class Processo 
    {
        int id;
        DescritorProcesso descritorProcesso;

        public int Id { get; set; }

        public Processo(int id, ref DescritorProcesso descritorProcesso)
        {
            this.id = id;
            this.descritorProcesso = descritorProcesso;

        }


        public void doMyJob()
        {
            for(int i = 0; i< 10; i++)
            {
                // Checagem de interrupcao
                descritorProcesso._pauseEvent.WaitOne(Timeout.Infinite);

                Console.WriteLine("DoMyJob "+id + " executando laco: "+i);
                Thread.Sleep(1000);
            }
            // Fim do processo
            descritorProcesso.IsDone = true;
        }
    }
}

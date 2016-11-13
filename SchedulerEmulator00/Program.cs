using SchedulerEmulator00.process;
using SchedulerEmulator00.scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerEmulator00
{
    class Program
    {
       
        static void Main(string[] args)
        {
            List<ProcessoGenerico> processos = new List<ProcessoGenerico>();
            int numeroProcessos = 3;

            criaProcessos(numeroProcessos, ref processos);

            RoundRobin scheduler = new RoundRobin(processos);
            scheduler.execute();
            Console.ReadLine();

        }

        private static void criaProcessos(int n, ref List<ProcessoGenerico>  processos)
        {
            for(int i = 0; i < n; i++ )
            {
                ProcessoGenerico p = new ProcessoGenerico(i);
                processos.Add(p);

            }
        }
    }
}

using SchedulerEmulator00.process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchedulerEmulator00.scheduler
{
    public class RoundRobin
    {
        List<ProcessoGenerico> processos;
        List<ProcessoGenerico> processosToExecute = new List<ProcessoGenerico>();

        int quantum = 1500;

        public List<ProcessoGenerico> Processos
        {
            get
            {
                return processos;
            }

            set
            {
                processos = value;
            }
        }

        public RoundRobin(List<ProcessoGenerico> processos)
        {
            Processos = processos;
        }

        public void execute()
        {
            schedulerExecutando();
            loadProcessos();

            // Processo 0 é iniciado
            // Após 2 Quantums Processo 1 é iniciado
            // Após 3 Quantuns Processo 2 é iniciado

            processosToExecute.Add(processos[0]);

            
            Thread.Sleep(quantum/2); // Delay


            //int nCount = 0;
            //while(isSomethingAlive())
            //{
            //    if(processosToExecute.Count >0)
            //    {
            //        foreach (var p in processosToExecute)
            //        {
            //            if (p.DescritorProcesso.IsDone == false && p.DescritorProcesso.State == 0) // executado pela primeira vez
            //            {

            //                p.DescritorProcesso.Thread.Start();
            //                Thread.Sleep(quantum); // Tempo de execução para o processo
            //                nCount++;
            //                //Console.WriteLine("Teste");
            //                p.Pause();
            //                p.DescritorProcesso.State = 2;
            //                Console.WriteLine("Round-Robin pausou processo: " + p.DescritorProcesso.Id);

            //            }
            //            else if (p.DescritorProcesso.IsDone == false && p.DescritorProcesso.State == 2)// executado pela segunda ou + vez
            //            {
            //                Console.WriteLine("Round-Robin retomou a execucao do processo: " + p.DescritorProcesso.Id);
            //                p.Resume();
            //                p.DescritorProcesso.State = 0;
            //                nCount++;
            //                //Console.WriteLine("Teste");
            //                Thread.Sleep(quantum); // Tempo de execução para o processo
            //                p.Pause();

            //                p.DescritorProcesso.State = 2;
            //                Console.WriteLine("Round-Robin pausou processo: " + p.DescritorProcesso.Id);
            //            }
            //            else if (p.DescritorProcesso.IsDone == true)
            //            {
            //                p.DescritorProcesso.State = 3;
            //                processosToExecute.Remove(p);
            //                Console.WriteLine("Round-Robin removeu da lista para ser executado o processo: " + p.DescritorProcesso.Id);
            //                break;
            //            }

            //            if (processosToExecute.Count == 0)
            //                break;

            //            // Adicao dos processos
            //            if(nCount==2)
            //            {
            //                processosToExecute.Add(processos[1]);
            //                break;
            //            }

            //            if(nCount ==5)
            //            {
            //                processosToExecute.Add(processos[2]);
            //                break;
            //            }

            //        }
            //    }

            //}

            int nCount  = 0;
            while (isSomethingAlive())
            {
                if (processosToExecute.Count > 0)
                {
                    for (int i = 0; i < processosToExecute.Count; i++)
                    {
                        ProcessoGenerico p = processosToExecute[i];

                        if (p.DescritorProcesso.IsDone == false && p.DescritorProcesso.State == 0) // executado pela primeira vez
                        {

                            p.DescritorProcesso.Thread.Start();
                            Thread.Sleep(quantum); // Tempo de execução para o processo
                            nCount++;
                            //Console.WriteLine("Teste");
                            p.Pause();
                            p.DescritorProcesso.State = 2;
                            Console.WriteLine("Round-Robin pausou processo: " + p.DescritorProcesso.Id);

                        }
                        else if (p.DescritorProcesso.IsDone == false && p.DescritorProcesso.State == 2)// executado pela segunda ou + vez
                        {
                            Console.WriteLine("Round-Robin retomou a execucao do processo: " + p.DescritorProcesso.Id);
                            p.Resume();
                            p.DescritorProcesso.State = 0;
                            nCount++;
                            //Console.WriteLine("Teste");
                            Thread.Sleep(quantum); // Tempo de execução para o processo
                            p.Pause();

                            p.DescritorProcesso.State = 2;
                            Console.WriteLine("Round-Robin pausou processo: " + p.DescritorProcesso.Id);
                        }
                        if (p.DescritorProcesso.IsDone == true)
                        {
                            p.DescritorProcesso.State = 3;
                            //processosToExecute.Remove(p);
                            processosToExecute.RemoveAt(i);
                            Console.WriteLine("Round-Robin removeu da lista para ser executado o processo: " + p.DescritorProcesso.Id);
                            i = i - 1;
                            
                        }

                        if (processosToExecute.Count == 0)
                            break;

                        // Adicao dos processos
                        if (nCount == 2)
                        {
                            processosToExecute.Add(processos[1]);
                            
                        }

                        if (nCount == 5)
                        {
                            processosToExecute.Add(processos[2]);
                            
                        }

                    }
                }

            }



            // execute
            // pause
            // checkList







            //Processos[0].Pause();

        }

        public void loadProcessos()
        {
            int i = 0;
            foreach (ProcessoGenerico p in Processos)
            {
                p.DescritorProcesso.Thread = new Thread(p.Prologue);
                i++;
            }

        }

        public bool isSomethingAlive()
        {
            foreach (ProcessoGenerico p in processosToExecute)
            {
                if (p.DescritorProcesso.State != 3)
                    return true;
            }
            return false;
        }

        public void schedulerExecutando()
        {
            Console.WriteLine("/*********************************/");
            Console.WriteLine("/*****Scheduler Executando********/");
            Console.WriteLine();

        }
    }
}

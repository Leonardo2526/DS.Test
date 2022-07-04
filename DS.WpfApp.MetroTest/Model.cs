using DS.WpfApp.MetroTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DS.WpfApp.MetroTest
{
    internal class Model
    {
        public Model(ApplicationViewModel applicationViewModel)
        {
            this.applicationViewModel = applicationViewModel;
        }

        private static bool processCompleted;
        private readonly ApplicationViewModel applicationViewModel;
        ManualResetEvent waitHandle = new ManualResetEvent(false);

        #region Methods

        public async Task RunProcessAsync()
        {
            MessageBox.Show("Application started.");

            try
            {
                applicationViewModel.s_cts.CancelAfter(1000);
                await StopMethod();
                MessageBox.Show("Process completed!");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("\nTasks cancelled: timed out.\n");
            }
            finally
            {
                applicationViewModel.s_cts.Dispose();
            }

            //Console.WriteLine("Application ending.");
            //s_cts.CancelAfter(1000);
            //await Task.Delay(5000);
            //MessageBox.Show("Process completed!");
            //await Task.Run(() => RunProcess());
            //await Task.Run(()=> Task3());
        }

        public async Task ListenAsync(CancellationToken token)
        {
            try
            {
                while (true)
                {
                    await Task.Run(() =>
                    {
                        if (!token.IsCancellationRequested)
                        {
                            return;
                        }
                        Task1();
                    }); 
                    //await Task.Delay(300000, token);
                }
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Cancelled");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                MessageBox.Show("Terminate");
                waitHandle.Set();
            }
        }

        private async Task StopMethod()
        {
            var stopwatch = Stopwatch.StartNew();
            await Task.Delay(5000);
            stopwatch.Stop();
        }

        public void RunProcess()
        {
            while (applicationViewModel.ProcessLaunched && !processCompleted)
            {
                Task2();
            }
        }

        public void Task1()
        {

            string s = "null";
            for (int i = 0; i <= 50000000; i++)
            {
                if (applicationViewModel.s_cts.IsCancellationRequested)
                {
                    applicationViewModel.Text ="Process stopped manually";
                    return;
                }
                s = i.ToString();
            }
            applicationViewModel.Text ="Process completed";
            MessageBox.Show(s);
            processCompleted = true;
        }

        public void  WrapTask(CancellationTokenSource _cancellationTokenSource)
        {
            Task.Run(() => Task2(), _cancellationTokenSource.Token);
            if (_cancellationTokenSource.IsCancellationRequested)
                return;
           
        }

        public void WrapTask1(CancellationTokenSource s_cts)
        {
            s_cts.CancelAfter(1000);

            Task1();
        }

        public void Task2()
        {
            applicationViewModel.currentThreads.Add(Thread.CurrentThread);

            Thread.Sleep(3000);

            MessageBox.Show("Process completed!");
            processCompleted = true;
            applicationViewModel.ProcessLaunched = false;
        }

        public static async Task Task3()
        {
            await Task.Delay(3000);
            processCompleted = true;
            MessageBox.Show("Process completed!");
        }

        #endregion

    }
}

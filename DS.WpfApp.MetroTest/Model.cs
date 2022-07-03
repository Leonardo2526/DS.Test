using DS.WpfApp.MetroTest.ViewModel;
using System;
using System.Collections.Generic;
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


        #region Methods

        public async Task RunProcessAsync()
        {
            await Task.Run(() => RunProcess(applicationViewModel));
            //await Task.Run(()=> Task1());
        }

        public void RunProcess(ApplicationViewModel applicationViewModel)
        {
            while (applicationViewModel.ProcessLaunched && !processCompleted)
            {
                Task2();
            }
        }

        public void Task1()
        {
            string s = "null";
            for (int i = 0; i <= 10000000; i++)
            {
                s = i.ToString();
            }
            MessageBox.Show("Process completed!");
            MessageBox.Show(s);
            processCompleted = true;
        }

        public void Task2()
        {
            applicationViewModel.currentThread = Thread.CurrentThread;

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

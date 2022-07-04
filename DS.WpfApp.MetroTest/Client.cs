using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DS.WpfApp.MetroTest
{
    public class TickMe
    {
        private CancellationTokenSource _cancellationTokenSource;

        public async Task Start()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            int i = 0;
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                await Task.Delay(5000, _cancellationTokenSource.Token);
                MessageBox.Show("tik" + i);
                i++;
            }

            _cancellationTokenSource = null;
        }

        public void Stop()
        {
            _cancellationTokenSource?.Cancel();
        }
    }

    public class Client
    {
        protected TickMe _instance;

        public async Task Run()
        {
            _instance = new TickMe();
            await _instance.Start();
        }

        public void Kill()
        {
            _instance.Stop();
        }
    }
}

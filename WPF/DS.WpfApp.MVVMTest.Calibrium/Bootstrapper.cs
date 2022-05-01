using Caliburn.Micro;
using DS.WpfApp.Test.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DS.WpfApp.Test
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();

        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.DisplayRootViewFor<ShellViewModel>();
        }
    }
}

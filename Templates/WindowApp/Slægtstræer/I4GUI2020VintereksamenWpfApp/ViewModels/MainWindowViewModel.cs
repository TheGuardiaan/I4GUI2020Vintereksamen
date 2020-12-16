using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace I4GUI2020VintereksamenWpfApp.ViewModels
{
    class MainWindowViewModel : BindableBase
    {


            


        



        ICommand _AppShutdown;
        public ICommand AppShutdown
        {
            get { return _AppShutdown ?? (_AppShutdown = new DelegateCommand<string>(AppShutdown_Execute)); }
        }
        private void AppShutdown_Execute(string argFilename)
        {
            Application.Current.Shutdown();
        }
    }
}

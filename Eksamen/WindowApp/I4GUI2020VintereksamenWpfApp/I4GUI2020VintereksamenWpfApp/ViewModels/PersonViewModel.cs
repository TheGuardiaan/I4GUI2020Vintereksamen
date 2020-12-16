using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace I4GUI2020VintereksamenWpfApp.ViewModels
{
    class PersonViewModel : BindableBase
    {
        private string _firstName = "Bent";

        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); } 
        }


        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        private DateTime? _lastUpdated;

        public DateTime? LastUpdated
        {
            get { return _lastUpdated; }
            set { SetProperty(ref _lastUpdated, value); }
        }


        public ICommand UpDateCommand { get; set; }

        public PersonViewModel()
        {
            UpDateCommand = new DelegateCommand(Executed, CanExecute).ObservesProperty(() => FirstName).ObservesProperty(() => LastName);
        }

        private bool CanExecute()
        {
            return !String.IsNullOrWhiteSpace(FirstName) && !String.IsNullOrWhiteSpace(LastName);
        }

        private void Executed()
        {
            LastUpdated = DateTime.Now;
        }
    }
}

using I4GUI2020VintereksamenWpfApp.Model;
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
    public class AddPersonViewModel : BindableBase
    {
        private Person newPerson;
        public AddPersonViewModel(Person person)
        {
            newPerson = person;
        }

        public Person NewPerson
        {
            get => newPerson;
            set => SetProperty(ref newPerson, value);

        }

        private ICommand saveCommand;
        public ICommand SaveCommand => saveCommand ?? (saveCommand = new DelegateCommand(
                                               SaveCommandExecute, SaveCommandCanExecute)
                                           .ObservesProperty(() => NewPerson.FirstName)
                  .ObservesProperty(() => NewPerson.LastName));

        

        private void SaveCommandExecute()
        {
            
        }


        private bool SaveCommandCanExecute()
        {
            return true;
        }




    }
}

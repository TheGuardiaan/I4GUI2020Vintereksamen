using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I4GUI2020VintereksamenWpfApp.Model
{
    public class Person : BindableBase
    {

        private string _firstName;
        private string _lastName;
        private DateTime _date;
        private int _minus;
        private BreathPrMin _breath;

        public Person()
        {
        }

        

        public string FirstName 
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        public string LastName 
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        public string FullName => $"{FirstName} {LastName}";


        

        public DateTime Date
        {
            get { return _date = DateTime.Now; }
            
            set { _date = DateTime.Now; }
        }


        

        public int Minus
        {
            get { return _minus; }
            set { SetProperty(ref _minus, value); }
        }



        public BreathPrMin Breath
        {
            get { return _breath = BreathPrMin.Low; }
            set { SetProperty(ref _breath, value); }
        }


        public enum BreathPrMin
        {
            Low = 5,
            Medium = 6,
            High = 7
        }


    }



}

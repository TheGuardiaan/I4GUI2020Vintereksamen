using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I4GUI2020VintereksamenWpfApp.Model
{
    class Person : BindableBase
    {
        private int _personId;
        public int personId 
        {
            get { return _personId; }
            set { SetProperty(ref _personId, value); }
        }




        private string _firstName;
        public string firstName 
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _lastName;
        public string lastName 
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        private Gender _gender;
        public Gender gender 
        {
            get { return _gender; }
            set { SetProperty(ref _gender, value); }
        }



        private DateTime _dob;
        public DateTime dob 
        {
            get { return _dob; }
            set { SetProperty(ref _dob, value); }
        }

        private string _bornPlace;
        public string bornPlace 
        {
            get { return _bornPlace; }
            set { SetProperty(ref _bornPlace, value); }
        }

        private DateTime _dodead;
        public DateTime dodead 
        {
            get { return _dodead; }
            set { SetProperty(ref _dodead, value); }
        }

        private string _deadPlace;
        public string deadPlace 
        {
            get { return _deadPlace; }
            set { SetProperty(ref _deadPlace, value); }
        }


        private string _photo;
        public string photo 
        {
            get { return _photo; }
            set { SetProperty(ref _photo, value); }
        }

        private string _comments;
        public string comments 
        {
            get { return _comments; }
            set { SetProperty(ref _comments, value); }
        }



        private List<long> _mother;
        public List<long> mother 
        {
            get { return _mother; }
            set { SetProperty(ref _mother, value); }
        }

        private List<long> _father;
        public List<long> father 
        {
            get { return _father; }
            set { SetProperty(ref _father, value); }
        }

        private List<long> _partners;
        public List<long> partners 
        {
            get { return _partners; }
            set { SetProperty(ref _partners, value); }
        }

        private List<long> _children;
        public List<long> children 
        {
            get { return _children; }
            set { SetProperty(ref _children, value); }
        }




    }

    public enum Gender
    {
        Male,
        Female,
        Unknown
    }

}

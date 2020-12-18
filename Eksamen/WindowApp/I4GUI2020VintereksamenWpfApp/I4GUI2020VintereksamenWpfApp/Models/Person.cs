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
        private Gender _gender;
        private DateTime _dob;
        private string _bornPlace;
        private DateTime _doDead;
        private string _deadPlace;
        private string _photo;
        private string _comments;

        
        public Person()
        {
        }

        public Person(string firstName, string lastName, Gender gender, DateTime dob, string bornPlace, DateTime doDead, string deadPlace, string photo, string comments)
        {
            _firstName = firstName;
            _lastName = lastName;
            _gender = gender;
            _dob = dob;
            _bornPlace = bornPlace;
            _doDead = doDead;
            _deadPlace = deadPlace;
            _photo = photo;
            _comments = comments;
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

        public string FullName1 => $"{FirstName} {LastName}";


        public Gender Gender
        {
            get { return _gender; }
            set { SetProperty(ref _gender, value); }
        }



        public DateTime Dob
        {
            get { return _dob; }
            set { SetProperty(ref _dob, value); }
        }

        public string BornPlace
        {
            get { return _bornPlace; }
            set { SetProperty(ref _bornPlace, value); }
        }

        public DateTime DoDead
        {
            get { return _doDead; }
            set { SetProperty(ref _doDead, value); }
        }

        public string DeadPlace
        {
            get { return _deadPlace; }
            set { SetProperty(ref _deadPlace, value); }
        }


        public string Photo
        {
            get { return _photo; }
            set { SetProperty(ref _photo, value); }
        }

        public string Comments
        {
            get { return _comments; }
            set { SetProperty(ref _comments, value); }
        }



        private List<long> _mother;
        public List<long> Mother
        {
            get { return _mother; }
            set { SetProperty(ref _mother, value); }
        }

        private List<long> _father;
        public List<long> Father
        {
            get { return _father; }
            set { SetProperty(ref _father, value); }
        }

        private List<long> _partners;
        public List<long> Partners
        {
            get { return _partners; }
            set { SetProperty(ref _partners, value); }
        }

        private List<long> _children;
        public List<long> Children
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

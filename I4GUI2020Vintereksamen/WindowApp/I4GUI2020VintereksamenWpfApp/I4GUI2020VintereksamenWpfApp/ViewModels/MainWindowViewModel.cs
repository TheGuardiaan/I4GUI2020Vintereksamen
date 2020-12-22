using I4GUI2020VintereksamenWpfApp.Model;
using I4GUI2020VintereksamenWpfApp.Views;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace I4GUI2020VintereksamenWpfApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {




        //private int _completedCount = 0;
        public ObservableCollection<Person> _persons;
        private string _filePath = "";
        private string _fileName = "";
        private bool _dataCheck = false; //Sikre at der ikke minste data ved lukning af app // If true der er komme ny data

        
        private string _title = "BreathingExercises";


        public MainWindowViewModel()
        {
            string iDate = "05/05/1960";
            DateTime dob = Convert.ToDateTime(iDate);
            string xDate = "07/11/2019";
            DateTime dod = Convert.ToDateTime(xDate);

            _persons = new ObservableCollection<Person>
            {

                //new Person("", "", iDate, 20, BreathPrMin.Low)

            };

        }

      



        [XmlArray, XmlArrayItem(typeof(Person))]
        public ObservableCollection<Person> Persons
        {
            get => _persons;
            set => SetProperty(ref _persons, value);
        }


        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public bool DataCheck
        {
            get => _dataCheck;
            set => SetProperty(ref _dataCheck, value);
        }

        public string FilePath
        {
            get => _filePath;
            set => SetProperty(ref _filePath, value);
        }

        public string FileName
        {
            get => _fileName;
            set => SetProperty(ref _fileName, value);
        }



        

        //-----------------Add Person--------------------
                
        private ICommand addCommand;
        public ICommand AddCommand => addCommand ?? (addCommand = new DelegateCommand(() =>
        {
            Person newPerson = new Person();
            var vm = new AddPersonViewModel(newPerson);
            var dlg = new AddPersonWindow();
            dlg.DataContext = vm;
            dlg.Owner = App.Current.MainWindow;

            if (dlg.ShowDialog() == true)
            {
                
                Persons.Add(newPerson);
                DataCheck = true;


            }

        }));







        //-----------------Close app--------------------
        ICommand _AppShutdown;
        public ICommand AppShutdown
        {
            get
            {
                return _AppShutdown ?? (_AppShutdown = new DelegateCommand<string>(AppShutdown_Execute));
            }
        }
        private void AppShutdown_Execute(string argFilename)
        {
            if (DataCheck)
            {
                var result = MessageBox.Show("You have data that has not yet been saved - Do you want to continue?", "WARNING",
                    MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

                if (result == MessageBoxResult.No)
                {
                    return;
                }
            }
            Application.Current.Shutdown();
        }


        
        //-----------------New file--------------------
        private ICommand newCommand;

        public ICommand NewCommand => newCommand ?? (newCommand = new DelegateCommand(() =>
        {
            if (DataCheck)
            {
                MessageBoxResult result = MessageBox.Show("You have data that has not yet been saved - Do you want to continue?", "WARNING",
                    MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

                if (result == MessageBoxResult.No)
                {
                    return;
                }
            }

            FilePath = "";
            FileName = "";
            Persons.Clear();
            DataCheck = false;
            Title = "Untitled - " + _title;

        }));


    
        //-----------------Open file--------------------
        private ICommand openCommand;

        public ICommand OpenCommand => openCommand ?? (openCommand = new DelegateCommand(() =>
        {

            var dialog = new OpenFileDialog
            {
                Filter = "XML Document|*.xml|Text Document|*.txt|All Files|*.*",
                DefaultExt = "xml"
            };
            if (FilePath == "")
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                dialog.InitialDirectory = Path.GetDirectoryName(FilePath);

            if (dialog.ShowDialog(App.Current.MainWindow) == true)
            {
                if (DataCheck)
                {
                    MessageBoxResult result = MessageBox.Show("You have data that has not yet been saved - Do you want to continue?", "WARNING",
                        MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

                    if (result == MessageBoxResult.No)
                    {
                        return;
                    }
                }

                FilePath = dialog.FileName;
                FileName = Path.GetFileName(FilePath);

                ObservableCollection<Person> tempDebtors = new ObservableCollection<Person>();

                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Person>));

                try
                {
                    TextReader reader = new StreamReader(FilePath);
                    tempDebtors = (ObservableCollection<Person>)serializer.Deserialize(reader);
                    reader.Close();
                    Persons = tempDebtors;
                    DataCheck = false;
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Could not open the file", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

        }));


        //-----------------Save as file--------------------
        private ICommand saveAsCommand;
        public ICommand SaveAsCommand => saveAsCommand ?? (saveAsCommand = new DelegateCommand(() =>
        {
            var dialog = new SaveFileDialog
            {
                Filter = "XML Document|*.xml|Text Document|*.txt|All Files|*.*",
                DefaultExt = "xml"
            };
            if (_filePath == "")
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                dialog.InitialDirectory = Path.GetDirectoryName(FilePath);

            if (dialog.ShowDialog(App.Current.MainWindow) == true)
            {
                FilePath = dialog.FileName;
                FileName = Path.GetFileName(FilePath);
                SaveFile();
                Title = FileName + " - " + _title;
            }
        }));



        //-----------------Save file--------------------
        private ICommand saveCommand;
        public ICommand SaveCommand => saveCommand ?? (saveCommand = new DelegateCommand(SaveFile, SaveFile_CanExecute)
                                           .ObservesProperty(() => FileName)
                                           .ObservesProperty(() => FilePath)
                                           .ObservesProperty(() => DataCheck));

        private bool SaveFile_CanExecute()
        {
            if (DataCheck && !string.IsNullOrWhiteSpace(FileName) &&
                !string.IsNullOrWhiteSpace(FilePath))
                return true;
            return false;
        }

        private void SaveFile()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Person>));
                TextWriter writer = new StreamWriter(FilePath);
                serializer.Serialize(writer, Persons);
                writer.Close();

                DataCheck = false;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Could not open the file", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

       


    }
}

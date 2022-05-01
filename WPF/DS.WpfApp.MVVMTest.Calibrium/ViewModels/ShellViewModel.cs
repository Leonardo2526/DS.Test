using Caliburn.Micro;
using DS.WpfApp.Test.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DS.WpfApp.Test.ViewModels
{
    //public class ShellViewModel : Screen
    public class ShellViewModel : Conductor<object>
    {
        private string _firstName = "Tim";
        private PersonModel _selectedPerson;
        private string _lastName;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();

        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
            People.Add(new PersonModel { FirstName = "Danil", LastName = "Saraev" });
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                //NotifyOfPropertyChange();

                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }


        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }


        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public bool CanClearText(string firstName, string lastName)
        {
            return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);
        }

        public void ClearText(string firstName, string lastName)
        {
            FirstName = "";
            LastName = "";
        }


        public void LoadPage1()
        {
            ActivateItemAsync(new FirstChildViewModel());
        }

        public void LoadPage2()
        {            
            ActivateItemAsync(new SecondChildViewModel());
        }
    }
}

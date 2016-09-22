using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace TestApp
{
    public class ViewModel : ObservableObject
    {
        public ObservableCollection<Model> Items { get; set; }

        private Model _selectedItem;
        public Model SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged(nameof(SelectedItem));
            }
        }

        public ViewModel()
        {
            Items = new ObservableCollection<Model>
            {
                new Model {Name="Login1" },
                new Model {Name="Login2" },
                new Model {Name="Login3" },
                new Model {Name="Login4" },
                new Model {Name="Login5" },
            };
        }
    }

    public class TestViewModel : ObservableObject
    {
        public ObservableCollection<Model> Items { get; set; }

        private Model _selectedItem;
        public Model SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged(nameof(SelectedItem));
            }
        }

        public TestViewModel()
        {
            Items = new ObservableCollection<Model>
            {
                new Model {Name="Test1" },
                new Model {Name="Test2" },
                new Model {Name="Test3" },
                new Model {Name="Test4" },
                new Model {Name="Test5" },
            };
        }
    }

    public class Model : ObservableObject
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }
    }
}

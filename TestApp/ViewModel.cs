using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class ViewModel
    {
        public ObservableCollection<Model> Items { get; set; }

        public ViewModel()
        {
            Items = new ObservableCollection<Model>
            {
                new Model {Name="Name1" },
                new Model {Name="Name2" },
                new Model {Name="Name3" },
                new Model {Name="Name4" },
                new Model {Name="Name5" },
            };
        }
    }

    public class Model
    {
        public string Name { get; set; }
    }
}

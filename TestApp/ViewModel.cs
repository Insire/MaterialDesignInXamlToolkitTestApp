using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace TestApp
{
    public class ViewModel : ObservableObject
    {
        private string _result;
        public string Result
        {
            get { return _result; }
            private set
            {
                _result = value;
                RaisePropertyChanged(nameof(Result));
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            private set
            {
                _isBusy = value;
                RaisePropertyChanged(nameof(IsBusy));
            }
        }

        public ObservableCollection<Model> Items { get; private set; }
        public CancellationTokenSource Source { get; private set; }

        public ICommand WorkCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public ICommand WorkResultCommand { get; private set; }

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
            WorkCommand = new RelayCommand<object>(Work, CanWork);
            WorkResultCommand = new RelayCommand(WorkResult, CanWork);
            CancelCommand = new RelayCommand(Cancel, CanCancel);

            Source = new CancellationTokenSource();

            Items = new ObservableCollection<Model>
            {
                new Model {Name="Login1" },
                new Model {Name="Login2" },
                new Model {Name="Login3" },
                new Model {Name="Login4" },
                new Model {Name="Login5" },
            };
        }

        private bool CanCancel()
        {
            return Source?.IsCancellationRequested == false
                && IsBusy;
        }

        private void Cancel()
        {
            Source.Cancel();
        }

        private bool CanWork(object item)
        {
            return !IsBusy;
        }

        private bool CanWork()
        {
            return !IsBusy;
        }

        private async void Work(object item)
        {
            IsBusy = true;
            try
            {
                await WorkInternalAsync(item);
                Result += $"Success{Environment.NewLine}";
            }
            catch (OperationCanceledException)
            {
                Result += $"Canceled{Environment.NewLine}";
            }
            finally
            {
                IsBusy = false;
                CommandManager.InvalidateRequerySuggested();
            }
        }

        private Task WorkInternalAsync(object item)
        {
            Source = new CancellationTokenSource();
            return Task.Run(() =>
           {
               Task.Delay(2000).Wait();
               Source.Token.ThrowIfCancellationRequested();

               var model = item as Model;
               if (model == null)
                   Result += $"Running{Environment.NewLine}";
               else
                   Result += $"Running {model.Name}{Environment.NewLine}";
           });
        }

        private async void WorkResult()
        {
            IsBusy = true;
            try
            {
                Result += await WorkResultInternalAsync();
                Result += $"Success{Environment.NewLine}";
            }
            catch (OperationCanceledException)
            {
                Result += $"Canceled{Environment.NewLine}";
            }
            finally
            {
                IsBusy = false;
                CommandManager.InvalidateRequerySuggested();
            }
        }

        private async Task<string> WorkResultInternalAsync()
        {
            Source = new CancellationTokenSource();
            return await Task.Run(() =>
            {
                Task.Delay(2000).Wait();
                Source.Token.ThrowIfCancellationRequested();

                return $"Running{Environment.NewLine}";
            });
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

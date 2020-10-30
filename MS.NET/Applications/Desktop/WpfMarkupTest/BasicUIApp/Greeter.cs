using System;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;

namespace BasicUIApp
{
    public class Greeter : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(Greeter), new PropertyMetadata("Welcome User"));

        private string _person = "User";
        public string Person
        {
            get => _person;
            set
            {
                _person = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Person"));
            }
        }

        private string _period = "Morning";
        public string Period
        {
            get => _period;
            set
            {
                _period = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Period)));
            }
        }

        public ICommand Greet => new GreetCommand { Parent = this };

        class GreetCommand : ICommand
        {
            internal Greeter Parent;

            event EventHandler ICommand.CanExecuteChanged
            {
                add
                {
                    Parent.PropertyChanged += new PropertyChangedEventHandler(value);
                }

                remove
                {
                    Parent.PropertyChanged -= new PropertyChangedEventHandler(value);
                }
            }

            bool ICommand.CanExecute(object parameter)
            {
                return Parent.Person.Length > 0;
            }

            void ICommand.Execute(object parameter)
            {
                Parent.Message = $"Good {Parent.Period} {Parent.Person}";
            }
        }


    }
}

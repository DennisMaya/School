using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Assignment4Problem1.Command;

namespace Assignment4Problem1.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ICommand Addition { get; set; }
        public ICommand Subtraction { get; set; }
        public ICommand Multiplication { get; set; }
        public ICommand Division { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        private string _number1;
        public string Number1
        {
            get { return _number1; }
            set { _number1 = value; OnPropertyChanged("Number1"); }
        }

        private string _number2;
        public string Number2
        {
            get { return _number2; }
            set { _number2 = value; OnPropertyChanged("Number1"); }
        }

        private string result;

        public string Result
        {
            get { return result; }
            set { result = value; OnPropertyChanged("Result"); }
        }

        public ViewModel()
        {
            Addition = new RelayCommand(Add, canexecute);
            Subtraction = new RelayCommand(Subtract, canexecute);
            Division = new RelayCommand(Divide, canexecute);
            Multiplication = new RelayCommand(Multiply, canexecute);

        }

        private bool canexecute(object parameter)
        {
            if (!string.IsNullOrEmpty(Number1) && !string.IsNullOrEmpty(Number2))
            {
                return true;
            }
            return false;

        }
        private void Add(object parameter)
        {
            Result = (Convert.ToDouble(Number1) + Convert.ToDouble(Number2)).ToString();
        }

        private void Subtract(object parameter)
        {
            Result = (Convert.ToDouble(Number1) - Convert.ToDouble(Number2)).ToString();
        }
        private void Divide(object parameter)
        {
            Result = (Convert.ToDouble(Number1) / Convert.ToDouble(Number2)).ToString();
        }

        private void Multiply(object parameter)
        {
            Result = (Convert.ToDouble(Number1) * Convert.ToDouble(Number2)).ToString();
        }

    }
}


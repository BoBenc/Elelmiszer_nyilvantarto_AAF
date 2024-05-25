using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Elelmiszer_nyilvantarto_WPF
{
    public class Storage : INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnProperty(); }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnProperty(); }
        }
        private int number;
        public int Number
        {
            get { return number; }
            set { number = value; OnProperty(); }
        }
        public Storage(string name, int number)
        {
            Name = name;
            Number = number;
        }
        public Storage() { }
        public override string? ToString()
        {
            return Name != null ? $"{Name} : {Number} darab" : "";
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnProperty([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

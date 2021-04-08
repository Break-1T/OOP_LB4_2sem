using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Task6.Annotations;

namespace Task6
{
    class ViewModel:INotifyPropertyChanged
    {
        private int _firstRunner;
        private int _secondRunner;
        private int _thirdRunner;
        private int _fourthRunner;
        private int _fifthRunner;
        private int _sixthRunner;
        private int _seventhRunner;


        public int FirstRunner
        {
            get => _firstRunner;
            set
            {
                _firstRunner = value;
                OnPropertyChanged("FirstRunner");
            }
        }
        public int SecondRunner
        {
            get => _secondRunner;
            set
            {
                _secondRunner = value;
                OnPropertyChanged("SecondRunner");
            }
        }
        public int ThirdRunner
        {
            get => _thirdRunner;
            set
            {
                _thirdRunner = value;
                OnPropertyChanged("ThirdRunner");
            }
        }
        public int FourthRunner
        {
            get => _fourthRunner;
            set
            {
                _fourthRunner = value;
                OnPropertyChanged("FourthRunner");
            }
        }
        public int FifthRunner
        {
            get => _fifthRunner;
            set
            {
                _fifthRunner = value;
                OnPropertyChanged("FifthRunner");
            }
        }
        public int SixthRunner
        {
            get => _sixthRunner;
            set
            {
                _sixthRunner = value;
                OnPropertyChanged("SixthRunner");
            }
        }
        public int SeventhRunner
        {
            get => _seventhRunner;
            set
            {
                _seventhRunner = value;
                OnPropertyChanged("SeventhRunner");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

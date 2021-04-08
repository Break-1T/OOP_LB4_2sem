using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task6.Annotations;

namespace Task6
{
    class ViewModel:INotifyPropertyChanged
    {
        public ViewModel()
        {
            Count = 1;
            rand = new Random();
            
            FirstR = new Thread(Run1);
            SecondR = new Thread(Run2);
            ThirdR = new Thread(Run3);
            FourthR = new Thread(Run4);
            FifthR = new Thread(Run5);
            SixthR = new Thread(Run6);
            SeventhR = new Thread(Run7);
            CountR = new Thread(CountRunner);
            
            allThreads = new List<Thread>() {FifthR, SecondR, ThirdR, FourthR, FifthR, SixthR, SeventhR};
            allRunners = new List<double>() { FirstRunner,SecondRunner,ThirdRunner,FourthRunner,FifthRunner,SixthRunner,SeventhRunner};
        }

        private Random rand;
        private int Count;
        
        #region Main fields and propertys
        
        private double _firstRunner;
        private double _secondRunner;
        private double _thirdRunner;
        private double _fourthRunner;
        private double _fifthRunner;
        private double _sixthRunner;
        private double _seventhRunner;


        public double FirstRunner
        {
            get => _firstRunner;
            set
            {
                _firstRunner = value;
                OnPropertyChanged("FirstRunner");
            }
        }
        public double SecondRunner
        {
            get => _secondRunner;
            set
            {
                _secondRunner = value;
                OnPropertyChanged("SecondRunner");
            }
        }
        public double ThirdRunner
        {
            get => _thirdRunner;
            set
            {
                _thirdRunner = value;
                OnPropertyChanged("ThirdRunner");
            }
        }
        public double FourthRunner
        {
            get => _fourthRunner;
            set
            {
                _fourthRunner = value;
                OnPropertyChanged("FourthRunner");
            }
        }
        public double FifthRunner
        {
            get => _fifthRunner;
            set
            {
                _fifthRunner = value;
                OnPropertyChanged("FifthRunner");
            }
        }
        public double SixthRunner
        {
            get => _sixthRunner;
            set
            {
                _sixthRunner = value;
                OnPropertyChanged("SixthRunner");
            }
        }
        public double SeventhRunner
        {
            get => _seventhRunner;
            set
            {
                _seventhRunner = value;
                OnPropertyChanged("SeventhRunner");
            }
        }

        private List<double> allRunners;

        #endregion
        
        #region Threads

        public Thread FirstR { get; set; }
        public Thread SecondR { get; set; }
        public Thread ThirdR { get; set; }
        public Thread FourthR { get; set; }
        public Thread FifthR { get; set; }
        public Thread SixthR { get; set; }
        public Thread SeventhR { get; set; }
        private Thread CountR;
        private List<Thread> allThreads;
        
        #endregion
        
        #region Run methods

        private void Run1()
        {
            var pause = GetPausesList();
            while (FirstRunner < 100)
            {
                FirstRunner += 5;
                foreach (var i in pause)
                {
                    if (FirstRunner>i-5 && FirstRunner<i+5)
                    {
                        Thread.Sleep(500);
                    }
                }
                Thread.Sleep(500);
            }
        }
        private void Run2()
        {
            var pause = GetPausesList();
            while (SecondRunner < 100)
            {
                SecondRunner += 5;
                foreach (var i in pause)
                {
                    if (SecondRunner > i - 5 && SecondRunner < i + 5)
                    {
                        Thread.Sleep(500);
                    }
                }
                Thread.Sleep(500);
            }
        }
        private void Run3()
        {
            var pause = GetPausesList();
            while (ThirdRunner < 100)
            {
                ThirdRunner += 5;
                foreach (var i in pause)
                {
                    if (ThirdRunner > i - 5 && ThirdRunner < i + 5)
                    {
                        Thread.Sleep(500);
                    }
                }
                Thread.Sleep(500);
            }
        }
        private void Run4()
        {
            var pause = GetPausesList();
            while (FourthRunner < 100)
            {
                FourthRunner += 5;
                foreach (var i in pause)
                {
                    if (FourthRunner > i - 5 && FourthRunner < i + 5)
                    {
                        Thread.Sleep(500);
                    }
                }
                Thread.Sleep(500);
            }
        }
        private void Run5()
        {
            var pause = GetPausesList();
            while (FifthRunner < 100)
            {
                FifthRunner += 5;
                foreach (var i in pause)
                {
                    if (FifthRunner > i - 5 && FifthRunner < i + 5)
                    {
                        Thread.Sleep(500);
                    }
                }
                Thread.Sleep(500);
            }
        }
        private void Run6()
        {
            var pause = GetPausesList();
            while (SixthRunner < 100)
            {
                SixthRunner += 5;
                foreach (var i in pause)
                {
                    if (SixthRunner > i - 5 && SixthRunner < i + 5)
                    {
                        Thread.Sleep(500);
                    }
                }
                Thread.Sleep(500);
            }
        }
        private void Run7()
        {
            var pause = GetPausesList();
            while (SeventhRunner < 100)
            {
                SeventhRunner += 5;
                foreach (var i in pause)
                {
                    if (SeventhRunner > i - 5 && SeventhRunner < i + 5)
                    {
                        Thread.Sleep(500);
                    }
                }
                Thread.Sleep(500);
            }
        }

        #endregion

        public void Start()
        {
            Parallel.Invoke(
                () => FirstR.Start(),
                () => SecondR.Start(),
                () => ThirdR.Start(),
                () => FourthR.Start(),
                () => FifthR.Start(),
                () => SixthR.Start(),
                () => SeventhR.Start(),
                () => CountR.Start()
            );
        }

        private void CountRunner()
        {
            while (true)
            {
                foreach (var i in allThreads)
                {
                    if (!i.IsAlive)
                    {
                        i.Name = $"Финишировал {Count}-м";
                        Count++;
                    }
                }
            }
        }
        private List<int> GetPausesList()
        {
            int NumOfPauses = rand.Next(0, 10);
            List<int> nums = new List<int>();
            for (int i = 0; i < NumOfPauses; i++)
                nums.Add(rand.Next(0,100));
            return nums;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using Assignment.Commands;
using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Threading;

namespace Assignment.ViewModels
{
    public class LoadersViewModel : ViewModelBase
    {
        private readonly Random randomNumber = new Random();

        private readonly DispatcherTimer timer;
        public ICommand CancelCommand { get; private set; }

        // List of threads, which will take value of three, as stated in the ReadMe
        public List<ThreadWorker> Threads { get; private set; }

        public double TotalProgress
        {
            get
            {
                var active = Threads.Where(t => t.IsActive).ToList();

                // Set value to zero if none of threads are in progress
                if (!active.Any())
                {
                    return 0;
                }

                return active.Average(t => t.Progress);
            }
        }

        private void CancelThread(object parameter)
        {
            if (parameter is ThreadWorker worker)
            {
                worker.Cancel();
            }
        }

        public LoadersViewModel()
        {
            // Setting the number of threads, as well as their starting percentages values
            Threads = new List<ThreadWorker>
            {
                new ThreadWorker(randomNumber.Next(10, 51)),
                new ThreadWorker(randomNumber.Next(10, 51)),
                new ThreadWorker(randomNumber.Next(10, 51)),
            };

            foreach (var thread in Threads)
            {
                thread.PropertyChanged += (s, e) => OnPropertyChanged(nameof(TotalProgress));
            }

            CancelCommand = new RelayCommand(CancelThread);

            timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };

            // Increment percentages
            timer.Tick += (s, e) =>
            {
                foreach (var thread in Threads)
                {
                    thread.Tick();
                }

                OnPropertyChanged(nameof(TotalProgress));
            };
            timer.Start();
        }
    }
}

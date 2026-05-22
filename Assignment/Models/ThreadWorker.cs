using System.ComponentModel;

namespace Assignment.Models
{
    public class ThreadWorker : INotifyPropertyChanged
    {
        private int elapsed;

        private bool isActive = true;

        public int Duration { get; set; }

        public ThreadWorker(int duration)
        {
            Duration = duration;
        }

        public int Elapsed
        {
            get => elapsed;
            set
            {
                elapsed = value;
                OnPropertyChanged(nameof(Elapsed));
                OnPropertyChanged(nameof(Progress));
            }
        }

        // Mathematical equation for getting percetages, using ternary operator
        public double Progress => Duration > 0 ? System.Math.Min((double)Elapsed / Duration * 100.0, 100.0) : 0;

        public bool IsActive
        {
            get => isActive;
            private set
            {
                isActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }

        // Increment time if adequate conditions are met
        public void Tick()
        {
            if (IsActive && Elapsed < Duration)
                Elapsed++;
        }

        // Simple change of state
        public void Cancel()
        {
            IsActive = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

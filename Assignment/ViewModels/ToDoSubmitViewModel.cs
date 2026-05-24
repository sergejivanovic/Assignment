using Assignment.Commands;
using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Assignment.ViewModels
{
    public class ToDoSubmitViewModel : ViewModelBase
    {
        private string _itemName { get; set; }
        private int _selectedPriority { get; set; }
        private readonly Action<Item> _submit;

        public string ItemName
        {
            get => _itemName;
            set
            {
                _itemName = value;
                OnPropertyChanged("ItemName");
            }
        }
        public int SelectedPriority
        {
            get => _selectedPriority;
            set
            {
                _selectedPriority = value;
                OnPropertyChanged("SelectedPriority");
            }
        }

        public List<int> Priorities { get; private set; }

        public ICommand SubmitCommand { get; private set; }

        public ToDoSubmitViewModel(Action<Item> submitItems) 
        {
            SubmitCommand = new RelayCommand(SubmitItem);
            Priorities = new List<int> { 1, 2, 3};
            _submit = submitItems;
            SelectedPriority = 1;
        }

        private void SubmitItem(object obj)
        {
            if (string.IsNullOrWhiteSpace(ItemName))
            {
                return;
            }

            _submit(new Item { Name = ItemName, Priority = SelectedPriority });
            ItemName = string.Empty;
        }
    }
}

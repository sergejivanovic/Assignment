using Assignment.Models;
using System.Collections.ObjectModel;

namespace Assignment.ViewModels
{
    public class ToDoListViewModel
    {
        public ToDoSubmitViewModel ToDoSubmitViewModel { get; set; }

        public ObservableCollection<Item> Items { get; private set; }

        public ToDoListViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            ToDoSubmitViewModel = new ToDoSubmitViewModel(AddItem);
            Items = new ObservableCollection<Item>();
        }

        // Logic for adding newly created items in correct order, depending on the priority
        private void AddItem(Item item)
        {
            int index = Items.Count;

            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Priority > item.Priority)
                {
                    index = i;
                    break;
                }
            }

            Items.Insert(index, item);
        }
    }
}

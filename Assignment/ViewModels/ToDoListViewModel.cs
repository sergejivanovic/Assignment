namespace Assignment.ViewModels
{
    public class ToDoListViewModel
    {
        public ToDoSubmitViewModel ToDoSubmitViewModel { get; set; }

        public ToDoListViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            ToDoSubmitViewModel = new ToDoSubmitViewModel();
        }
    }
}

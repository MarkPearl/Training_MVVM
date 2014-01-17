using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace WPFTrainingExercise_01
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<ItemViewModel> Items { get; set; }
        public ItemViewModel SelectedItem { get; set; }

        public ICommand Add { get; set; }
        public ICommand Edit { get; set; }
        public ICommand Delete { get; set; }

        public MainViewModel()
        {
            PopulateItems();
            CreateCommands();
        }

        private void CreateCommands()
        {
            Add = new RelayCommand(AddSomething);
            Delete = new RelayCommand(DeleteSomething, () => SelectedItem != null);
            Edit = new RelayCommand(EditSelected, () => SelectedItem != null);
        }

        private void PopulateItems()
        {
            Items = new ObservableCollection<ItemViewModel>();
            Items.Add(new ItemViewModel() {Name = DateTime.Now.ToLongTimeString()});
        }

        private void DeleteSomething()
        {
            Items.Remove(SelectedItem);
        }

        private void EditSelected()
        {
            MessageBox.Show(SelectedItem.Name);
        }

        private void AddSomething()
        {
            MessageBox.Show("New Item");
            Items.Add(new ItemViewModel() { Name = DateTime.Now.ToLongTimeString() });
        }
    }
}
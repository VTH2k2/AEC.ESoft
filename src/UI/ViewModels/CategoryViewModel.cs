using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UI.Helpers;
using UI.Models;
using UI.Services;
namespace UI.ViewModels
{
    public class CategoryViewModel : INotifyPropertyChanged
    {
        private readonly CategoryService _service;

        public CategoryViewModel()
        {
            _service = new CategoryService();
            Categories = new ObservableCollection<Category>();

            LoadCommand = new RelayCommand(LoadData);
        }

        public ObservableCollection<Category> Categories { get; set; }
        public RelayCommand LoadCommand { get; set; }
        public async Task LoadData()
        {
            var data = await _service.GetAll();

            Categories.Clear();
            foreach (var item in data)
            {
                Categories.Add(item);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

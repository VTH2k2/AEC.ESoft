using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    public class StaffViewModel
    {
        public CategoryViewModel CategoryVM { get; }

        public ObservableCollection<ProductViewModel> Products { get; set; }

        public ObservableCollection<CardItemViewModel> CartItems { get; set; }

        public StaffViewModel()
        {
            CategoryVM = new CategoryViewModel();

            Products = new ObservableCollection<ProductViewModel>
            {
                new ProductViewModel
                {
                    Name = "Premium Cotton Tee",
                    Price = 32,
                    ImagePath = "/Images/shirt.jpg"
                },
                new ProductViewModel
                {
                    Name = "Velocity Runner Pro",
                    Price = 120,
                    ImagePath = "/Images/shoes.jpg"
                }
            };

            CartItems = new ObservableCollection<CardItemViewModel>();

            _ = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await CategoryVM.LoadData();
        }
    }
}
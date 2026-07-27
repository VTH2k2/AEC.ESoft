using System.Collections.ObjectModel;

public class ProductViewModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ImagePath { get; set; }
}

public class PosViewModel
{
    public ObservableCollection<ProductViewModel> Products { get; set; }

    public PosViewModel()
    {
        Products = new ObservableCollection<ProductViewModel>
        {
            new()
            {
                Name = "Premium Cotton Tee",
                Price = 32,
                ImagePath = "/Images/shirt.jpg"
            },

            new()
            {
                Name = "Velocity Runner Pro",
                Price = 120,
                ImagePath = "/Images/shoes.jpg"
            }
        };
    }
}
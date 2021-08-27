using RotateCollectionDemo.ViewModels;
using Xamarin.Forms;

namespace RotateCollectionDemo
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel vm = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}

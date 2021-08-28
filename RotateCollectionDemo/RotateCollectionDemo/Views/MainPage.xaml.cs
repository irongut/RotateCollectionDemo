using RotateCollectionDemo.ViewModels;
using Xamarin.Forms;

namespace RotateCollectionDemo
{
    public partial class MainPage : ContentPage
    {
        private double width;
        private double height;

        private readonly MainViewModel vm = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            vm.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            vm.OnDisappearing();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (this.width != width || this.height != height)
            {
                this.width = width;
                this.height = height;

                vm.SetLayout();
            }
        }
    }
}

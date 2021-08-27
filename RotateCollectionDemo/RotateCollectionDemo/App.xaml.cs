using RotateCollectionDemo.Styles;
using Xamarin.Forms;

namespace RotateCollectionDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            LoadStyles();
            MainPage = new MainPage();
        }

        public void LoadStyles()
        {
            ResourceDictionary appDictionary = Application.Current.Resources;
            ResourceDictionary styles = new DefaultStyles();
            appDictionary.MergedDictionaries.Add(styles);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

using RotateCollectionDemo.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RotateCollectionDemo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly Random random = new Random();

        private readonly ItemsLayout portLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical)
        {
            ItemSpacing = 15
        };

        private readonly ItemsLayout landLayout = new LinearItemsLayout(ItemsLayoutOrientation.Horizontal)
        {
            ItemSpacing = 15
        };

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<DataItem> Data { get; }

        public DateTime LastUpdated => DateTime.Now;

        private DataTemplate collectionTemplate;
        public DataTemplate CollectionTemplate { get => collectionTemplate; set => SetProperty(ref collectionTemplate, value); }

        private ItemsLayout collectionLayout;
        public ItemsLayout CollectionLayout { get => collectionLayout; set => SetProperty(ref collectionLayout, value); }

        public MainViewModel()
        {
            Data = new ObservableCollection<DataItem>();
            GenerateData();
        }

        private void GenerateData()
        {
            Data.Clear();
            for (int i = 0; i < random.Next(6, 10); i++)
            {
                DataItem item = new DataItem();
                if (random.Next(2) < 1)
                {
                    item.Name = "Zombie Boy";
                    item.FirstLine = "Pestilentia est plague haec";
                    item.SecondLine = "Summus brains sit​​";
                    item.FirstImage = "resource://RotateCollectionDemo.Resources.zombie.boy.svg";
                }
                else
                {
                    item.Name = "Zombie Girl";
                    item.FirstLine = "Decaying ambulabat mortuos";
                    item.SecondLine = "Apathetic malus voodoo";
                    item.FirstImage = "resource://RotateCollectionDemo.Resources.zombie.girl.svg";
                }
                item.SecondImage = random.Next(2) < 1
                    ? "resource://RotateCollectionDemo.Resources.zombie.hand.svg"
                    : "resource://RotateCollectionDemo.Resources.pumpkin.svg";
                Data.Add(item);
            }
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        public void OnAppearing()
        {
            MessagingCenter.Subscribe<App>(this, "AppOnResume", (_) => SetLayout());
        }

        public virtual void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<App>(this, "AppOnResume");
        }

        public void SetLayout()
        {
            DisplayInfo displayInfo = DeviceDisplay.MainDisplayInfo;
            if (displayInfo.Width > displayInfo.Height)
            {
                // landscape
                CollectionTemplate = App.Current.Resources.TryGetValue("landTemplate", out object value)
                    ? (DataTemplate)value
                    : throw new Exception("landTemplate not found!");
                CollectionLayout = landLayout;
            }
            else
            {
                // portrait
                CollectionTemplate = App.Current.Resources.TryGetValue("portTemplate", out object value)
                    ? (DataTemplate)value
                    : throw new Exception("portTemplate not found!");
                CollectionLayout = portLayout;
            }
        }
    }
}

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
        private readonly Random _random = new Random();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<DataItem> Data { get; }

        public DateTime LastUpdated => DateTime.Now;

        private DataTemplate collectionTemplate;
        public DataTemplate CollectionTemplate { get => collectionTemplate; set => SetProperty(ref collectionTemplate, value); }

        public MainViewModel()
        {
            Data = new ObservableCollection<DataItem>();
            GenerateData();
        }

        private void GenerateData()
        {
            Data.Clear();
            for (int i = 0; i < _random.Next(6, 10); i++)
            {
                DataItem item = new DataItem();
                if (_random.Next(2) < 1)
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
                item.SecondImage = _random.Next(2) < 1
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
            var displayInfo = DeviceDisplay.MainDisplayInfo;
            if (displayInfo.Width > displayInfo.Height)
            {
                CollectionTemplate = App.Current.Resources.TryGetValue("landTemplate", out object value)
                    ? (DataTemplate)value
                    : throw new Exception("landTemplate not found!");
            }
            else
            {
                CollectionTemplate = App.Current.Resources.TryGetValue("portTemplate", out object value)
                    ? (DataTemplate)value
                    : throw new Exception("portTemplate not found!");
            }
        }
    }
}

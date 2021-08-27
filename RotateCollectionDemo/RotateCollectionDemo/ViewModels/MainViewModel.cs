using RotateCollectionDemo.Models;
using System;
using System.Collections.ObjectModel;

namespace RotateCollectionDemo.ViewModels
{
    public class MainViewModel
    {
        private readonly Random _random = new Random();

        public ObservableCollection<DataItem> Data { get; }

        public DateTime LastUpdated => DateTime.Now;

        public MainViewModel()
        {
            Data = new ObservableCollection<DataItem>();
            GenerateData();
        }

        private void GenerateData()
        {
            Data.Clear();
            for (int i = 0; i < _random.Next(5, 9); i++)
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
    }
}

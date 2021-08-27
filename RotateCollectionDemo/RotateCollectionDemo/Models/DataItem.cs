namespace RotateCollectionDemo.Models
{
    public class DataItem
    {
        private string name;
        public string Name { get => name; set => SetProperty(ref name, value); }

        private string firstLine;
        public string FirstLine { get => firstLine; set => SetProperty(ref firstLine, value); }

        private string secondLine;
        public string SecondLine { get => secondLine; set => SetProperty(ref secondLine, value); }

        private string firstImage;
        public string FirstImage { get => firstImage; set => SetProperty(ref firstImage, value); }

        private string secondImage;
        public string SecondImage { get => secondImage; set => SetProperty(ref secondImage, value); }

        protected bool SetProperty<T>(ref T field, T newValue)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                return true;
            }

            return false;
        }
    }
}

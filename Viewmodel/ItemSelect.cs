namespace myweb.Viewmodel
{
    public class ItemSelect
    {
        public string Name { get; set; }
        public int Cost { get; set; }

        public DateTime currentDate = DateTime.Now.Date;
        public int Food { get; set; }
        public int Transport { get; set; }
        public int Clothes { get; set; }
        public int Other { get; set; }

    }
}

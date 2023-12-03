using System.ComponentModel.DataAnnotations;

namespace myweb.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Cost { get; set; }
        [DisplayFormat(DataFormatString = "{yyyy-MM}")]
        public DateTime CurrentDate { get; set; }
        public int Food { get; set; }
        public int Transport { get; set; }
        public int Clothes { get; set; }
        public int Other { get; set; }
        public int Total { get; set; }

        public int currentMonth {get; set; }

    }
}

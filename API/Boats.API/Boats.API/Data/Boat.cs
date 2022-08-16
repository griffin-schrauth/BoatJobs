using System.ComponentModel.DataAnnotations;

namespace Boats.API.Data
{
    public class Boat
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string JobTitle { get; set; }
        public string JobDesciption { get; set; }
        public string Date { get; set; }
        public float Amount { get; set; }
    }
}

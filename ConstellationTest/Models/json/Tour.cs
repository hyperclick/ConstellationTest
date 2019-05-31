using System;

namespace ConstellationTest.Models
{
    public class Tour
    {
        public int id { get; set; }
        public string title { get; set; }
        public string header { get; set; }
        public string description { get; set; }
        public string[] route { get; set; }
        public DateTime periodStart { get; set; }
        public DateTime periodEnd { get; set; }
        public float minPrice { get; set; }
        public Photocard photoCard { get; set; }
        public Photoalbum[] photoAlbum { get; set; }
    }

}
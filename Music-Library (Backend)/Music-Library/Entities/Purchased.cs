namespace Music_Library.Entities
{
    public class Purchased
    {
        public int ID { get; set; }
        public int? UID { get; set; }
        public string? Album_id { get; set; }
        public string? Album_name { get; set; }
        public string? Release_date { get; set; }
        public DateTime? Purchase_date { get; set; }
        public string? Artist_name { get; set; }
        public string? Photo_url { get; set; }
        public Boolean? Favorite { get; set; }

    }
}

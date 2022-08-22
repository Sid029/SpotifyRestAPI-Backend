namespace Music_Library.Entities
{
    public class Artist
    {
        public int ID { get; set; }
        public string Artist_id { get; set; }
        public string Artist_name { get; set; }
        public string Photo_url { get; set; }
        public int User_ID { get; set; }
        public bool Following { get; set; }
    }
}

﻿namespace Music_Library.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? Creationdate { get; set; }
    }
}

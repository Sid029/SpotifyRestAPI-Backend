namespace Music_Library.Model
{
    public class UserResponse
    {
        public int id { get; set; }
        public string token { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public int TokenExpiration { get; set; }
        public bool IsError { get; set; } = false;
        public string Message { get; set; }

    }
    }

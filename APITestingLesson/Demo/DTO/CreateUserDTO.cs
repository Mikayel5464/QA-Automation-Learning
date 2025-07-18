using System;

namespace APIDemo
{
    public class CreateUserDTO
    {
        public string name { get; set; }
        public string job { get; set; }
        public long id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}

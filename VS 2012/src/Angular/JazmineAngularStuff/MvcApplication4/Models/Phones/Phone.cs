using System;

namespace MvcApplication4.Models.Phones
{
    public class Phone
    {
        public Guid PhoneId { get; set; }

        public string Description { get; set; }

        public Brand Brand { get; set; }

        public int Age { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }
    }
}
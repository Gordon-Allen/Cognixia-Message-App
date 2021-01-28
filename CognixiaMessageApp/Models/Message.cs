using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;

namespace CognixiaMessageApp.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required]
        [Display(Name = "Your Name")]

        public string Username { get; set; }

        [Required]
        [Display(Name = "Your Message")]
        [MinLength(2, ErrorMessage = "Your message has to be at least (2) characters in length")]
        public string Text { get; set; }

        public string Zipcode { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public DateTime Created_At { get; set; } = DateTime.Now;
        public DateTime Updated_At { get; set; } = DateTime.Now;

        public Message()
        {
            LocationPopulate();
        }
        private void LocationPopulate()
        {
            var client = new HttpClient();
            var json = client.GetStringAsync("http://ipinfo.io/json").Result;
            var result = JsonConvert.DeserializeObject<Location>(json);
            Zipcode = result.Postal;
            City = result.City;
            State = result.Region;
        }
    }
}



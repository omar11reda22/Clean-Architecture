using unknown.Models;

namespace unknown.DTOs
{
    public class StudentDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public int countryid { get; set; }
        public List<int> coursesid { get; set; }   
        public List<string> Course { get; set; }
    }
}

namespace Muresan_Razvan_Lab2.Models
{
    public class AuthorViewModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<BookViewModel>? WrittenBooks { get; set; }

    }
}

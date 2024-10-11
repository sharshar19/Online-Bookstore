using Online_Bookstore.Models;

namespace Online_Bookstore.Services
{
    public interface IBookIRepository
    {
        public void CreateBook(Book book);
        public IEnumerable<Book> GetBooks();
        public Book? GetBookById(int id);
        public void UpdateBook(Book book);
        public bool DeleteBook(int id);
    }
}

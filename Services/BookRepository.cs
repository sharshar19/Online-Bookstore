using Microsoft.AspNetCore.Identity;
using Online_Bookstore.Models;

namespace Online_Bookstore.Services
{
    public class BookRepository : IBookIRepository
    {
        private readonly BookContext _bookContext;
        public BookRepository(BookContext bookContext)
        {
            this._bookContext = bookContext;
           
        }
        public void CreateBook(Book book)
        {
            _bookContext.books.Add(book);
            _bookContext.SaveChanges();
            return;
        }

        public bool DeleteBook(int id)
        {
            var book = GetBookById(id);

            if (book == null || book.BookId != id)
            {
                return false;
            }

            _bookContext.books.Remove(book);
            _bookContext.SaveChanges();
            
            return true;
        }

        public Book? GetBookById(int id)
        {
            return _bookContext.books.FirstOrDefault(x => x.BookId == id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return (from _book in _bookContext.books select _book);
        }

        public void UpdateBook(Book book)
        {
            int bookId = book.BookId;
            var dbBook = GetBookById(bookId);
            dbBook = book;
            dbBook.BookId = bookId;
            _bookContext.SaveChanges();
            return;
        }
    }
}

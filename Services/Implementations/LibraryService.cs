using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.Interfaces;

namespace LibraryManagementSystem.Services.Implementations
{
    public class LibraryService : ILibraryService
    {
        private readonly List<Book> _books = new();
        private readonly List<Member> _members = new();

        private int _bookIdCounter = 1;
        private int _memberIdCounter = 1;

        public IEnumerable<Book> GetBooks() => _books;
        public Book? GetBook(int id) => _books.FirstOrDefault(b => b.BookId == id);

        public void AddBook(Book book)
        { 
            book.BookId = _bookIdCounter++;
            _books.Add(book);
        }

        public void UpdateBook(int id, Book updatedBook)
        {
            var existingBook = GetBook(id);
            if (existingBook != null)
            {
                existingBook.Title = updatedBook.Title;
                existingBook.Author = updatedBook.Author;
                existingBook.ISBN = updatedBook.ISBN;
            }
        }
        public void DeleteBook(int id) => _books.RemoveAll(b => b.BookId == id);
        
        public IEnumerable<Member> GetMembers() => _members;
        public Member? GetMember(int id) => _members.FirstOrDefault(m => m.MemberId == id);

        public void AddMember(Member member)
        {
            member.MemberId = _memberIdCounter++;
            _members.Add(member);
        }

        public void UpdateMember(int id, Member updatedMember)
        {
            var exisitingMember = GetMember(id);
            if (exisitingMember != null)
            {
                exisitingMember.Name = updatedMember.Name;
                exisitingMember.Email = updatedMember.Email;
            }
        }
        public void DeleteMember(int id) => _members.RemoveAll(m => m.MemberId == id);
    }
}

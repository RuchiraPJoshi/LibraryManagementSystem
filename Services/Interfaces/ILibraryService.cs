using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services.Interfaces
{
    public interface ILibraryService
    {
        IEnumerable<Book> GetBooks();
        Book? GetBook(int id);
        void AddBook(Book book);
        void UpdateBook(int id, Book updatedBook);
        void DeleteBook(int id);

        IEnumerable<Member> GetMembers();
        Member? GetMember(int id);
        void AddMember(Member member);
        void UpdateMember(int id, Member updatedMember);
        void DeleteMember(int id);
    }
}

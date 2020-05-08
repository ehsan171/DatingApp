using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IScreenplayRepository
    {
        Task<User> Register(User user, string password);
        Task<Student> RegisterStudent(Student student);
        Task<Screenplay> RegisterScreenplay(Screenplay student);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
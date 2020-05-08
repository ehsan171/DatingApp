using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class ScreenplayRepository : IScreenplayRepository
    {
        Student student;
        private readonly DataContext _context;
        public ScreenplayRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<User> Login(string username, string password)
        {
           
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var ComputedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < ComputedHash.Length; i++)
                {
                    if (ComputedHash[i] != passwordHash[i])  return false;
                }
            }
            return true;
        }

        public async Task<User> Register (User user, string password)
        {
        //    student.Name="dfdff";
           byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
        
        
        public async Task<Student> RegisterStudent (Student student)
        {
        //    student.Name="dfdff";
           
        
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return student;
        }
        
        
        public async Task<Screenplay> RegisterScreenplay (Screenplay screenplay)
        {
        //    student.Name="dfdff";
        //    INSERT INTO Screenplays(Title,TotalNumberEpisodes,OrgStructureId,StatusId)
        //     VALUES ('dsdd',1,2,3);
        screenplay.BaravordNo="999999";
        screenplay.OrgStructureId = 2;
        // screenplay.TotalNumberEpisodes =1;
        screenplay.StatusId= 3;
        
            await _context.Screenplays.AddAsync(screenplay);
            await _context.SaveChangesAsync();

            return screenplay;
        }
        
        
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
             
            if (await _context.Users.AnyAsync(x => x.Username == username))
                return true;
            
            return false;
        }
    }
}
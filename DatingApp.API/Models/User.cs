using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string photoUrl { get; set; }
        public int? OrgId { get; set; }
        public DateTime Created { get; set; }
#nullable enable
        public DateTime? LastActive { get; set; }
#nullable enable
        public ICollection<Photo>? Photos { get; set; }
#nullable enable
        public string? Firstname { get; set; }
#nullable enable
        public string? Lastname { get; set; }
    }
}
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Backend.Models.Entities
{
    public class UserEntity : Entity
    {
        public string? Name { get; set; }
        public DateTimeOffset? BirthDay { get; set; }
        public string? Gender { get; set; }
        public string? Image { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [ForeignKey("AccountId")]
        public AccountEntity? Account { get; set; }

        [StringLength(36)]
        public string? AccountId { get; set; }

        [ForeignKey("RoleId")]
        public RoleEntity? Role { get; set; }

        [StringLength(36)]
        public string? RoleId { get; set; }

        public ICollection<FavoriteEntity> Favorites { get; set; }
        public ICollection<UserPlaylistEntity> UserPlaylists { get; set; }

    }
}

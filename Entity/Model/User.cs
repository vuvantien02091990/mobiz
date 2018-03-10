namespace Entity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public string Avatar { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public bool? AccessDeTail { get; set; }

        public int PhoneNumber { get; set; }
    }
}

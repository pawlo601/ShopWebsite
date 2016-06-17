using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.User
{
    [Table("Passwords", Schema = "User")]
    public class Password : IValidatableObject
    {
        #region variables

        [Key]
        [Column("password_id")]
        [XmlAttribute("id")] //for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("user_id")]
        [XmlAttribute("user_id")] //for xml
        [Required(ErrorMessage = "User id cannot be empty.")]
        public int UserId { get; set; }

        [Column("hashed_password")]
        [XmlAttribute("hashed_password")] //for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password cannot be empty.")]
        public string HashedPassword { get; set; }

        [Column("password_salt")]
        [XmlAttribute("password_salt")] //for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password salt cannot be empty.")]
        public string PasswordSalt { get; set; }

        [Column("create_time")]
        [XmlAttribute("create_time")] //for xml
        [Required(ErrorMessage = "Create time cannot be empty.")]
        public DateTime CreateTime { get; set; }

        #endregion

        #region methods
        public Password()
        {
        }

        public Password(int id, int userId, string hashedPassword, string passwordSalt, DateTime createTime)
        {
            Id = id;
            UserId = userId;
            HashedPassword = hashedPassword;
            PasswordSalt = passwordSalt;
            CreateTime = createTime;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(UserId,
                new ValidationContext(this, null, null) { MemberName = "UserId" },
                results);
            if (UserId < 1)
            {
                results.Add(new ValidationResult("UserId should be given.", new[] { "UserId" }));
            }
            Validator.TryValidateProperty(HashedPassword,
                new ValidationContext(this, null, null) { MemberName = "HashedPassword" },
                results);
            Validator.TryValidateProperty(PasswordSalt,
                new ValidationContext(this, null, null) { MemberName = "PasswordSalt" },
                results);
            Validator.TryValidateProperty(CreateTime,
                new ValidationContext(this, null, null) { MemberName = "CreateTime" },
                results);
            return results;
        }
        #endregion
    }
}

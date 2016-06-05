using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Model.Entities.User
{
    public class Permission : IValidatableObject, IIntroduceable
    {//todo implements
        #region variables
        [Key]
        public int Permission_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string PermissionDescription { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        #endregion

        #region methods
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new System.NotImplementedException();
        }

        public int GetId()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
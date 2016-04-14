using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Xml.Serialization;

namespace ShopWebsite.Model.Entities.Product
{
    [Table("Units", Schema = "Product")]
    public class Unit : IValidatableObject
    {
        #region variables
        [Key]
        [Column("id")]
        [XmlAttribute("id")]//for xml
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("unit_name")]
        [XmlAttribute("unit_name")]//for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unit name cannot be empty.")]
        [MinLength(3, ErrorMessage = "Length of unit name should be greater than or equal to 3.")]
        [MaxLength(10, ErrorMessage = "Length of unit name should be less than or equal to 10.")]
        public string Name { get; set; }

        [Column("unit_shortcut")]
        [XmlAttribute("unit_name")]//for xml
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unit shortcut cannot be empty.")]
        [MinLength(1, ErrorMessage = "Length of unit shortcut should be greater than or equal to 1.")]
        [MaxLength(5, ErrorMessage = "Length of unit shortcut should be less than or equal to 5.")]
        public string Shortcut { get; set; }
        #endregion

        private static Unit[] _tableUnits { get; set; }

        private Unit() { }

        public static Unit GetOneUnit()
        {
            Random rand = new Random();
            int r = rand.Next()%4;
            if (_tableUnits != null)
                return _tableUnits[r];
            _tableUnits=new Unit[4];
            _tableUnits[0] = new Unit() {Id = -1, Name = "Kilogram", Shortcut = "KG"};
            _tableUnits[1] = new Unit() { Id = -1, Name = "Sztuka", Shortcut = "SZT" };
            _tableUnits[2] = new Unit() { Id = -1, Name = "Litr", Shortcut = "L" };
            _tableUnits[3] = new Unit() { Id = -1, Name = "Para", Shortcut = "Para" };
            return _tableUnits[r];
        }

        public static Unit GetOneUnit(int id)
        {
            if (_tableUnits == null)
                return GetOneUnit();
            foreach (Unit unit in _tableUnits.Where(unit => unit.Id == id))
                return unit;
            return GetOneUnit();
        }

        public static void SetTableUnits(Unit[] table)
        {
            _tableUnits = table;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(Name,
                new ValidationContext(this, null, null) { MemberName = "Name" },
                results);
            Validator.TryValidateProperty(Shortcut,
                new ValidationContext(this, null, null) { MemberName = "Shortcut" },
                results);
            return results;
        }
    }
}

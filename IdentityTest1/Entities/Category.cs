using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTest1.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

//public virtual ICollection<PublicationCategory> PublicationCategories { get; set; }

// De algún sitio sale PublicationId
// borrar db a mano, migrations a mano
// Add-Migration Initial
// Update-Database
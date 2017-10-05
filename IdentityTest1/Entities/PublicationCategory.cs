using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTest1.Entities
{
    public class PublicationCategory
    {
        [Required]
        [ForeignKey("Publication")]
        public int PublicationId { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Publication Publication { get; set; }

        public virtual Category Category { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Entities.General
{
    //Base class for entities common properties
    public class Base<T>
    {
        [Key]
        public T Id { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

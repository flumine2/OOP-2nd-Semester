using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFor2ndLab.Models
{
    public abstract class Entity
    {
        [Required]
        public long Id { get; private set; }

        private static long _id_counter;

        protected Entity()
        {
            Id = _id_counter++;
        }

        protected Entity(long id)
        {
            Id = id;
        }
    }
}

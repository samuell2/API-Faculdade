using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula01.Domain
{
    public abstract class Entity
    {
        protected Entity()
        {
           
        }

        public int Id { get; set; }
    }
}

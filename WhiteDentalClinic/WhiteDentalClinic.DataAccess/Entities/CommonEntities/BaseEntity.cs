using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteDentalClinic.DataAccess.Entities.CommonEntities;

namespace WhiteDentalClinic.DataAccess.Entities
{
    public abstract class BaseEntity
    {
        [EnumDataType(typeof(Role))]
        public abstract Role Role { get; }
    }
}

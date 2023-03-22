using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteDentalClinic.Application.Models
{
    public class ApiGenericsResult<TEntity>
        where TEntity : class
    {
        private ApiGenericsResult(bool succeeded,TEntity result, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Result = result;
            Errors = errors;
        }
        public bool Succeeded { get; set; }
        public TEntity Result { get; }
        public IEnumerable<string> Errors { get; }

        public static ApiGenericsResult<TEntity> Success (TEntity result)
        {
            return new ApiGenericsResult<TEntity>(true, result, new List<string>());
        }
        public static ApiGenericsResult<TEntity> Failure (IEnumerable<string> errors)
        {
            return new ApiGenericsResult<TEntity>(false, default, errors);
        }
    }
}

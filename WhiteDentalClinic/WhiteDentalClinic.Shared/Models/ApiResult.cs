using System.Text.Json.Serialization;

namespace WhiteDentalClinic.Shared.Models
{
    public class ApiResult<TEntity>
        where TEntity : class
    {
        public ApiResult() { }

        [JsonConstructor]
        private ApiResult(bool succeeded, TEntity result, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Result = result;
            Errors = errors;
        }
        public bool Succeeded { get; set; }
        public TEntity Result { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public static ApiResult<TEntity> Success(TEntity result)
        {
            return new ApiResult<TEntity>(true, result, new List<string>());
        }
        public static ApiResult<TEntity> Failure(IEnumerable<string> errors)
        {
            return new ApiResult<TEntity>(false, default, errors);
        }
    }
}

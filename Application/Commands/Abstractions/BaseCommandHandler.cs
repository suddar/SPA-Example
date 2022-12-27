using FluentValidation;
using FluentValidation.Results;

namespace Application.Commands.Abstractions
{
    public abstract class BaseRequestHandler
    {
        protected readonly AppDbContext dbContext;
        protected readonly IMapper mapper;
        protected readonly IServiceProvider serviceProvider;
        public BaseRequestHandler(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            dbContext = serviceProvider.GetRequiredService<AppDbContext>();
            mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public ValidationResult Validate<TData>(BaseRequest request)
        {
            var data = request.DeserializeObject<TData>();

            #region Throw exception if data is null
            ArgumentNullException.ThrowIfNull(data);
            #endregion

            #region Get validator and validate data
            using IServiceScope scope = serviceProvider.CreateScope();
            var validator = scope.ServiceProvider.GetRequiredService<IValidator<TData>>();
            ValidationResult results = validator.Validate(data);
            return results;
            #endregion
        }
    }
}

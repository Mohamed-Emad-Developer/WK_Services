

using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace WK_Services.Ioc
{
    public class RegisterModelsServices
    {
        public static void RegisterModelServices(IServiceCollection services)
        {

            #region s
            //services.AddScoped<ICategoryService, CategoryService>();
            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IRequestHandler<AddCategoryCommand, bool>, AddCategoryCommandHandler>();
            //services.AddScoped<IRequestHandler<DeleteCategoryCommand, bool>, DeleteCategoryCommandHandler>();
            //services.AddScoped<IRequestHandler<UpdateCategoryCommand, bool>, UpdateCategoryCommandHandler>();
            //services.AddScoped<IRequestHandler<DuplicateCategoryCommand, bool>, DuplicateCategoryCommandHandler>();
            #endregion
             
        }
    }
}

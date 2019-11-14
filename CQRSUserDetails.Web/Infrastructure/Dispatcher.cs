using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSUserDetails.Web.Infrastructure
{
    public class Dispatcher : IDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public Dispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;   
        }

        public async Task SendAsync<T>(T command) where T : ICommand
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<T>>();
                await handler.HandleAsync(command);
            }
        }

        public async Task<T> QueryAsync<T>(IQuery<T> query)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(T));
                dynamic handler = scope.ServiceProvider.GetRequiredService(handlerType);

                return await handler.HandleAsync((dynamic)query);
            }
        }
    }
}
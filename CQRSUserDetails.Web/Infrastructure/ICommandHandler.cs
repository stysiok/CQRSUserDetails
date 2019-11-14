using System.Threading.Tasks;

namespace CQRSUserDetails.Web.Infrastructure
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
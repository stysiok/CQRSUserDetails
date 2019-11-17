using System.Threading.Tasks;

namespace CQRSUserDetails.Web.Infrastructure
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : class, IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
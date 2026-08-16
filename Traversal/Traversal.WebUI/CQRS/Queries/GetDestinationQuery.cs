using MediatR;
using Traversal.WebUI.CQRS.Result;

namespace Traversal.WebUI.CQRS.Queries
{
    public class GetDestinationQuery:IRequest<List<GetDestinationQueryResult>>
    {
    }
}

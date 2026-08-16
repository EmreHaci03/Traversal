using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Traversal.BusinessLayer.Abstract;
using Traversal.DataAccessLayer.Concrete;
using Traversal.WebUI.CQRS.Queries;
using Traversal.WebUI.CQRS.Result;

namespace Traversal.WebUI.CQRS.Handler
{
    public class GetDestinationQueryHandler : IRequestHandler<GetDestinationQuery, List<GetDestinationQueryResult>>
    {
        private readonly TraversalContext traversalContext;
        private readonly IMapper _mapper;

        public GetDestinationQueryHandler(IMapper mapper, TraversalContext traversalContext)
        {
            _mapper = mapper;
            this.traversalContext = traversalContext;
        }

        public async  Task<List<GetDestinationQueryResult>> Handle(GetDestinationQuery request, CancellationToken cancellationToken)
        {
            var values = await traversalContext.Destinations.ToListAsync();
            return _mapper.Map<List<GetDestinationQueryResult>>(values);
        }
    }
}

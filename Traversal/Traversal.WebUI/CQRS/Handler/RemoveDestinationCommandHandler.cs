using AutoMapper;
using MediatR;
using Traversal.BusinessLayer.Abstract;
using Traversal.WebUI.CQRS.Command;

namespace Traversal.WebUI.CQRS.Handler
{
    public class RemoveDestinationCommandHandler:IRequestHandler<RemoveDestinationCommand>
    {
        private readonly IDestinationService destinationService;
        private readonly IMapper _mapper;

        public RemoveDestinationCommandHandler(IMapper mapper, IDestinationService destinationService)
        {
            _mapper = mapper;
            this.destinationService = destinationService;
        }

        public async Task Handle(RemoveDestinationCommand request, CancellationToken cancellationToken)
        {
            var Destination =  destinationService.TGetById(request.Id);
             destinationService.TDelete(Destination);
        }
    }
}

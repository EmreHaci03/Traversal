using AutoMapper;
using MediatR;
using Traversal.BusinessLayer.Abstract;
using Traversal.EntityLayer.Entities;
using Traversal.WebUI.CQRS.Command;

namespace Traversal.WebUI.CQRS.Handler
{
    public class CreateDestinationCommandHandler : IRequestHandler<CreateDestinationCommand>
    {
        private readonly IDestinationService destinationService; 
        private readonly IMapper _mapper;

        public CreateDestinationCommandHandler(IDestinationService destinationService, IMapper mapper)
        {
            this.destinationService = destinationService;
            _mapper = mapper;
        }

        public Task Handle(CreateDestinationCommand request, CancellationToken cancellationToken)
        {
            var destination = _mapper.Map<Destination>(request);
            destination.Status = true;
            destinationService.TInsert(destination);
            return Task.CompletedTask;
        }
    }
}
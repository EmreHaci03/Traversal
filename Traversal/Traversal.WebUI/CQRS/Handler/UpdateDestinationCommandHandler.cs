using AutoMapper;
using MediatR;
using Traversal.BusinessLayer.Abstract;
using Traversal.EntityLayer.Entities;
using Traversal.WebUI.CQRS.Command;

namespace Traversal.WebUI.CQRS.Handler
{
    public class UpdateDestinationCommandHandler : IRequestHandler<UpdateDestinationCommand>
    {
        private readonly IDestinationService destinationService;
        private readonly IMapper _mapper;

        public UpdateDestinationCommandHandler(IDestinationService destinationService, IMapper mapper)
        {
            this.destinationService = destinationService;
            _mapper = mapper;
        }

        public async Task Handle(UpdateDestinationCommand request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<Destination>(request);
            destinationService.TUpdate(values);

        }
    }
}

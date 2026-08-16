using MediatR;

namespace Traversal.WebUI.CQRS.Command
{
    public class RemoveDestinationCommand:IRequest
    {
        public RemoveDestinationCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

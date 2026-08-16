using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.DataAccessLayer.Concrete;
using Traversal.DtoLayer.DTOS.CommentDtos;
using Traversal.EntityLayer.Entities;

namespace Traversal.WebUI.ViewComponents.DestinationComments
{
    public class DestinationCommentListViewComponent:ViewComponent
    {
        private readonly ICommentService commentService;
        private readonly IMapper _mapper;

        public DestinationCommentListViewComponent(ICommentService commentService, IMapper mapper)
        {
            this.commentService = commentService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(int DestinationId)
        {
            ViewBag.DestId = DestinationId;
            ViewBag.Count = commentService.TGetCommentCount(DestinationId);
            var values = commentService.TGetListByDestinationId(DestinationId) ?? new List<Comment>();
            var mapper = _mapper.Map<List<GetCommentByIdDto>>(values) ?? new List<GetCommentByIdDto>();
            return View(mapper);
        }
    }
}

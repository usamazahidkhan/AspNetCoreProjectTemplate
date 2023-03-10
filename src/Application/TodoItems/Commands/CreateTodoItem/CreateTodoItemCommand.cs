﻿//using ProjectTemplate.Application;
//using MediatR;

//namespace ProjectTemplate.Application
//{
//    public record CreateTodoItemCommand : IRequest<int>
//    {
//        public int ListId { get; init; }

//        public string? Title { get; init; }
//    }

//    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, int>
//    {
//        private readonly IApplicationDbContext _context;

//        public CreateTodoItemCommandHandler(IApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
//        {
//            var entity = new
//            {
//                ListId = request.ListId,
//                Title = request.Title,
//                Done = false
//            };

//            _context.TodoItems.Add(entity);

//            await _context.SaveChangesAsync(cancellationToken);

//            return entity.id;
//        }
//    }
//}

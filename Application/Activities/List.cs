using MediatR;
using Domain;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> {}
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
    private readonly DataContext _context;


            public Handler(DataContext context)
            {
      _context = context;
             
            }



            //CancellationToken allow as to cancel a request if it not longger need it.
            public async Task<List<Activity>> Handle(Query request, CancellationToken token)
            {
                // try{
                //     for(var i =0; i<10; i++){
                //         cancellationToken.ThrowIfCancellationRequested();
                //         await Task.Delay(1000, cancellationToken);
                //         _logger.LogInformation($"Task: {i} has completed");
                //     }
                // }
                // catch(System.Exception){

                //  _logger.LogInformation("Task was canceled");
                // }

                return await _context.Activities.ToListAsync();

            }
        }
    }
}
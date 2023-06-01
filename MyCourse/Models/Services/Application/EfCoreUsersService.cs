using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCourse.Models.Services.Infrastructure;
using MyCourse.Models.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace MyCourse.Models.Services.Application
{
    public class EfCoreUsersService : IUsersService
    {
        private readonly ILogger<EfCoreUsersService> logger;
        private readonly MyCourseDbContext dbContext;

        public EfCoreUsersService(ILogger<EfCoreUsersService> logger, MyCourseDbContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<ListViewModel<UsersViewModel>> GetUserAsync(int id)
        {
            IQueryable<UsersViewModel> queryLinq = dbContext.users
                .AsNoTracking()
                .Where(user => user.id == id)
                .Select(user => UsersDetailViewModel.FromEntity(user));
            
            ListViewModel<UsersViewModel> viewModel = new ListViewModel<UsersViewModel>{
                Results = await queryLinq.ToListAsync(),
                TotalCount = await queryLinq.CountAsync()
            };

            if (viewModel == null)
            {
                logger.LogWarning(@"User with id:{"+id+"} not found" );
            }

            return viewModel;
        }

        public async Task<UsersViewModel> GetUsersAsync()
        {
            IQueryable<UsersDetailViewModel> queryLinq = (IQueryable<UsersDetailViewModel>)dbContext.users
                .AsNoTracking()
                .Select(user => UsersDetailViewModel.FromEntity(user)); //Usando metodi statici come FromEntity, la query potrebbe essere inefficiente. Mantenere il mapping nella lambda oppure usare un extension method personalizzato

            UsersDetailViewModel viewModel = await queryLinq.FirstOrDefaultAsync();
            //.FirstOrDefaultAsync(); //Restituisce null se l'elenco è vuoto e non solleva mai un'eccezione
            //.SingleOrDefaultAsync(); //Tollera il fatto che l'elenco sia vuoto e in quel caso restituisce null, oppure se l'elenco contiene più di 1 elemento, solleva un'eccezione
            //.FirstAsync(); //Restituisce il primo elemento, ma se l'elenco è vuoto solleva un'eccezione
            //.SingleAsync(); //Restituisce il primo elemento, ma se l'elenco è vuoto o contiene più di un elemento, solleva un'eccezione

            if (viewModel == null)
            {
                logger.LogWarning("No users found" );
            }

            return viewModel;
        }

        public Task<ListViewModel<UsersViewModel>> GetUsersByCourseId(int courseId)
        {
            throw new NotImplementedException();
        }

        Task<ListViewModel<UsersViewModel>> IUsersService.GetUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
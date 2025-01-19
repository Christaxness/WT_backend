using Microsoft.EntityFrameworkCore;
using WTBackend.Activity.InterfaceActivity;
using WTBackend.Activity.Models;
using WTBackend.DbHelper;

namespace WTBackend.Activity.ActivityRepo
{
    public class ActivityRepository : IActivityRepo
    {
        private readonly KanbanDbContext _dbContext;
        public ActivityRepository(KanbanDbContext kanbanDbContext) { 
            _dbContext = kanbanDbContext;
        }
        public async Task<List<ActivityModel>> GetAllActivities()
        {
            return await _dbContext.activities.ToListAsync();
        }
    }
}

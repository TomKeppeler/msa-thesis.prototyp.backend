using buchhaltungs_service.Model.Entities;
using buchhaltungs_service.Model.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace buchhaltungs_service.Model.Repository.Activity
{
    public class ActivityRepository : RepositoryBase, IActivityRepository
    {
        public ActivityRepository(BuchhaltungsContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Entities.Activity>> GetAllActivities()
        {
            return await Context.Activity.ToListAsync();
        }

        public async Task<Entities.Activity> CreateActivity(Entities.Activity activity)
        {
            await Context.Activity.AddAsync(activity);
            await SaveAsync();
            return activity;
        }

        public async Task<Entities.Activity> GetActivityById(Guid id)
        {
            return await Context.Activity.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Entities.Activity> UpdateActivity(Entities.Activity activity)
        {
            Context.Activity.Update(activity);
            await SaveAsync();
            return activity;
        }

        public async Task DeleteActivity(Entities.Activity activity)
        {
            Context.Activity.Remove(activity);
            await SaveAsync();
        }
    }
}

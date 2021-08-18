﻿using AzureDevopsStateTracker.Data.Context;
using AzureDevopsStateTracker.Entities;
using AzureDevopsStateTracker.Interfaces.Internals;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevopsStateTracker.Data
{
    internal class WorkItemRepository : Repository<WorkItem>, IWorkItemRepository
    {
        public WorkItemRepository(AzureDevopsStateTrackerContext context) : base(context) { }

        public async Task<WorkItem> GetByWorkItemId(string workItemId)
        {
            return await DbSet
                          .Include(x => x.WorkItemsChanges)
                          .Include(x => x.TimeByStates)
                          .FirstOrDefaultAsync(x => x.Id == workItemId);
        }

        public async Task<IEnumerable<WorkItem>> ListByWorkItemId(IEnumerable<string> workItemsId)
        {
            return await DbSet
                          .Include(x => x.WorkItemsChanges)
                          .Include(x => x.TimeByStates)
                          .Where(x => workItemsId.Contains(x.Id))
                          .ToListAsync();
        }

        public async Task<IEnumerable<WorkItem>> ListByIterationPath(string iterationPath)
        {
            return await DbSet
                          .Include(x => x.WorkItemsChanges)
                          .Include(x => x.TimeByStates)
                          .Where(x => x.IterationPath == iterationPath)
                          .ToListAsync();
        }

        public void RemoveAllTimeByState(List<TimeByState> timeByStates)
        {
            Db.TimeByStates.RemoveRange(timeByStates);
        }
    }
}
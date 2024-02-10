using System.Collections.Generic;
using System.Linq;

namespace Task1.Models.Repository
{
    public class DbCallsLogSummaryRepository : IRepository<CallsLogSummary>
    {
        public AppDbContext Db { get; }
        public DbCallsLogSummaryRepository(AppDbContext _db)
        {
            Db = _db;
        }


        public void Add(CallsLogSummary entity)
        {
            Db.CallsLogSummary.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, CallsLogSummary entity)
        {
            var data = Find(Id);
            Db.CallsLogSummary.Remove(data);
            Db.SaveChanges();
        }

        public CallsLogSummary Find(int Id)
        {
            return Db.CallsLogSummary.SingleOrDefault(z => z.CallsLogSummaryId == Id);
        }

        public List<CallsLogSummary> Get()
        {
            return Db.CallsLogSummary.ToList();
        }

        public void Update(int Id, CallsLogSummary entity)
        {
            Db.CallsLogSummary.Update(entity);
            Db.SaveChanges();
        }
    }
}

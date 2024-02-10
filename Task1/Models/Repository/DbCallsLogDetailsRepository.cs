using System.Collections.Generic;
using System.Linq;

namespace Task1.Models.Repository
{
    public class DbCallsLogDetailsRepository : IRepository<CallsLogDetails>
    {
        public AppDbContext Db { get; }
        public DbCallsLogDetailsRepository(AppDbContext _db)
        {
            Db = _db;
        }


        public void Add(CallsLogDetails entity)
        {
            Db.CallsLogDetails.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int Id, CallsLogDetails entity)
        {
            var data = Find(Id);
            Db.CallsLogDetails.Remove(data);
            Db.SaveChanges();
        }

        public CallsLogDetails Find(int Id)
        {
            return Db.CallsLogDetails.SingleOrDefault(z => z.CallsLogDetailsId == Id);
        }

        public List<CallsLogDetails> Get()
        {
            return Db.CallsLogDetails.ToList();
        }

        public void Update(int Id, CallsLogDetails entity)
        {
            Db.CallsLogDetails.Update(entity);
            Db.SaveChanges();
        }
    }
}

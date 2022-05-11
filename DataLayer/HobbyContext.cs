using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class HobbyContext : IDB<Hobby, int>
    {
        private DBContext _context;
        public HobbyContext(DBContext context)
        {
            _context = context;
        }

        public void Create(Hobby item)
        {
            try
            {
                _context.Hobbies.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Hobby Read(int key)
        {
            try
            {
                return _context.Hobbies.Find(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Hobby> ReadAll()
        {
            try
            {
                return _context.Hobbies.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Hobby item)
        {
            try
            {
                Hobby hobbyFromDB = Read(item.Id);

                _context.Entry(hobbyFromDB).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(int key)
        {
            try
            {
                _context.Hobbies.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

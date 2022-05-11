using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class FieldContext : IDB<Field, int>
    {
        private DBContext _context;
        public FieldContext(DBContext context)
        {
            _context = context;
        }

        public void Create(Field item)
        {
            try
            {
                List<User> users = new List<User>();

                foreach (var u in item.Users)
                {
                    User usesrFromDB = _context.Users.Find(u.Id);

                    if (usesrFromDB != null)
                    {
                        users.Add(usesrFromDB);
                    }
                    else
                    {
                        users.Add(u);
                    }
                }

                item.Users = users;

                _context.Fields.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Field Read(int key)
        {
            try
            {
                return _context.Fields.Find(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Field> ReadAll()
        {
            try
            {
                return _context.Fields.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Field item)
        {
            try
            {
                Field fieldFromDB = Read(item.Id);

                _context.Entry(fieldFromDB).CurrentValues.SetValues(item);
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
                _context.Fields.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

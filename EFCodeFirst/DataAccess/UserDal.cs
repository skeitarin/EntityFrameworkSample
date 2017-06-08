using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.DataAccess
{
    public class UserDal
    {
        private MyContext _context;
        public UserDal() {
            _context = new MyContext();
            _context.Database.Log = (log) => System.Diagnostics.Trace.WriteLine(log); // 「出力」ウィンドウにSQLログを出力
        }
        ~UserDal() { _context.Dispose(); }

        public void Insert(Models.User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges(); // 保存
        }
        public IEnumerable<Models.User> GetAll()
        {
            return _context.Users
                    .AsEnumerable()
                    .Select(u => new Models.User() { Id = u.Id, Name = u.Name, Age = u.Age });
        }
        public void Delete(int? id = null)
        {
            IEnumerable<int> targets;
            if(id == null){
                targets = _context.Users.AsEnumerable().Select(u => u.Id);
            }else{
                targets = _context.Users.Where(u => u.Id == id).AsEnumerable().Select(u => u.Id);
            }
            foreach(var target in targets)
            {
                _context.Users.Remove(_context.Users.Where(u => u.Id == target).First());
            }
            _context.SaveChanges();
        }
    }
}

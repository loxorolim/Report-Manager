using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Persistence.Repositories
{
    public abstract class BaseRepository
    {

        protected string _connectionString {get;set;}

        public BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}

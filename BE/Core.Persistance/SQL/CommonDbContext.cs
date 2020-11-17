using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;

namespace MEDLIFE.PERSISTANCE.Data.SQL
{
    public class CommonDbContext : DbContext
    {

        public CommonDbContext(string name)
            : base(/*name*/)
        {
        }

        
    }
}

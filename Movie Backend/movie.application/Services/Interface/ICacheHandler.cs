using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movie.application.Services.Interface
{
    public interface ICacheHandler
    {
        void SaveSearchQuery (string query);
    }
}

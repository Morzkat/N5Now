using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Domain.Services
{
    public interface IElasticsearchService
    {
        Task AddOrUpdate<T>(T document, string id) where T : class;
    }
}

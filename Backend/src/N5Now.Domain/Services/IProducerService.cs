using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Domain.Services
{
    public interface IProducerService<T> where T : class
    {
        Task Publish(T message);
    }
}

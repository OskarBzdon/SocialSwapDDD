using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialSwap.Domain.AggregatesModel.ItemAggregate
{
    public interface IItemService : ICrudService<Item>
    {
        public IEnumerable<Item> MyList(string clientId);
    }
}

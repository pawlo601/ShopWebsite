using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebsite.Model.Entities.Order
{
    public class StatusOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public DateTime TimeOfChange { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yioulaieuwechat.Library.Models
{
    public  class CardType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual CardType Parent { get; set; }
        public virtual ICollection<CardDemo> CardDemos { get; set; }
    }
}

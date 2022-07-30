using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class StringResources
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Category { get; set; }
        public string Date { get; set; }
        public string Event { get; set; }
        public string Name { get; set; }
        public int LanguageId { get; set; }
    }
}

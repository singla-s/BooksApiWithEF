using System;
using System.Collections.Generic;

#nullable disable

namespace BooksApiWithEF.Models
{
    public partial class Logging
    {
        public int Id { get; set; }
        public DateTime? Timestamp { get; set; }
        public string SourceIp { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FeuersoftwareApiHandler.Models
{
    public class News
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset Start { get; set; }

        public DateTimeOffset End { get; set; }

        public IEnumerable<string> Groups { get; set; }

        public string Site { get; set; }

        public IEnumerable<string> MailingLists { get; set; }
    }
}

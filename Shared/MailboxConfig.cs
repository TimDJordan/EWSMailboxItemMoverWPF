using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    class mailbox
    {
        public string email { get; set; }
        public int refreshInterval { get; set; }
    }
    class rules
    {
        public List<aRule> someRules { get; set; }
    }
    class aRule
    {
        public string filter { get; set; }
        public List<string> filterDetail { get; set; }
        public string action { get; set; }
        public List<string> recipientDetails { get; set; }
        public bool stopProcessingMoreRules { get; set; }
    }
}

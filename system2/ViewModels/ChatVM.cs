using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using system2.Models;

namespace system2.ViewModels
{
    public class ChatVM
    {

        public Comments Comment { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
        public IEnumerable<Comments> Comments { get; set; }

    }
}

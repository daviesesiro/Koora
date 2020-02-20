using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Koora.Models.MyModels;
namespace Koora.Models.ViewModels
{
    public class ResultViewModel
    {
        public string EventName { get; set; }

        public IEnumerable<Nominee> Nominees { get; set; }
    }
}
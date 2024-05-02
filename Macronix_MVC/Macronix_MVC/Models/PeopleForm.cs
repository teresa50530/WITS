using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Macronix_MVC.Models
{
    public class PeopleForm
    {
     
            public string Name { get; set; }
            public string Age { get; set; }
            public string Date { get; set; }
        public string Id { get; set; }
        public bool IsEditMode { get; set; }  
    }
}
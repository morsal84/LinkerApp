using System;
using System.Collections.Generic;
using System.Text;

namespace Linker.Domain.Entities
{
    public class Link : BaseEntity
    {
        public string Url { get; set; }

        public string Abrevation { get; set; }

        public int Visits { get; set; }
    }
}

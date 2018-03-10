namespace Entity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Manufacturer
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public long ProductCategoryID { get; set; }

        public string MetaTitle { get; set; }

        public string Logo { get; set; }
    }
}

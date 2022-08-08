using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialsAPI.Data.Entities
{
    public class MaterialReview
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
    }
}

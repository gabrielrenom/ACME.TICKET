using System;

namespace ACME.Common.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
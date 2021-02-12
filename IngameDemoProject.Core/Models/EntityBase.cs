using System;
using System.Collections.Generic;
using System.Text;

namespace IngameDemoProject.Core.Models
{
    public class EntityBase
    {
        int Id { get; set; }
        string Name { get; set; }
        bool IsActive { get; set; }
        bool IsDeleted { get; set; }
    }
}

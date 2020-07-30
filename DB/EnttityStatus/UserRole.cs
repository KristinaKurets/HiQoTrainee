using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.EnttityStatus
{

    
    public enum UserRole:short
    {
      User = 1,
      Admin = 2
    }
}


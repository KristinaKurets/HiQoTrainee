using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.EnttityStatus
{
   
    public enum BookingStatus : short
    {   
        Booked = 1,
        Waiting = 2,
        Cancelled = 3,
        Rejected = 4,
        Used = 5,    
    }
}

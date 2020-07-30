using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.EnttityStatus
{

    public enum DeskStatus
    {
        Fixed = 1,
        Available = 2,
        Booked = 3,
        [Description("Out of service")]
        OutOfService=4
    }
}

using System.ComponentModel;

namespace DB.EntityStatus
{
    public enum DeskStatus :short
    {
        Fixed = 1,
        Available = 2,
        Booked = 3,
        [Description("Out of service")]
        OutOfService=4
    }
}

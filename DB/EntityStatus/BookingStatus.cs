namespace DB.EntityStatus
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

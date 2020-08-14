using DB.Entity;

namespace DtoCommon.DTO.Entities
{
    public class UserPositionDto
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public static implicit operator UserPositionDto(UserPosition userPosition)
        {
            return new UserPositionDto()
            {
                Id = userPosition.Id,
                Type = userPosition.Type
            };
        }

        public static explicit operator UserPosition(UserPositionDto userPosition)
        {
            return new UserPosition()
            {
                Type = userPosition.Type
            };
        }
    }
}
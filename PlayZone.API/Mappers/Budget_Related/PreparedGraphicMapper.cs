using PlayZone.API.DTOs.Budget_Related;
using Entities = PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.API.Mappers.Budget_Related;

public static class PreparedGraphicMapper
{
    public static PreparedGraphicDTO ToDTO(this Entities.PreparedGraphic entity)
    {
        return new PreparedGraphicDTO
        {
            Date = entity.Date,
            Prevision = entity.Prevision,
            Reel = entity.Reel
        };
    }
}

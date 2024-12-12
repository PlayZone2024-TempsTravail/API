using SocialRapportRazor = PlayZone.Razor.Models.SocialRapport;
using SocialRapportModel = PlayZone.BLL.Models.Rapport_Related.SocialRapport;
using SocialRapportEntity = PlayZone.DAL.Entities.Rapport_Related.SocialRapport;

namespace PlayZone.BLL.Mappers.Rapport_Related;

public static class SocialRapportMapper
{
    public static SocialRapportRazor ToRazor(this SocialRapportModel model)
    {
        return new SocialRapportRazor
        {
            Date = model.Date,
            Period = model.Period,
            UserId = model.UserId,
            NomComplet = model.NomComplet,
            Activite = model.Activite
        };
    }

    public static SocialRapportModel ToModel(this SocialRapportEntity entity)
    {
        return new SocialRapportModel
        {
            Date = entity.Date,
            Period = entity.Period,
            UserId = entity.UserId,
            NomComplet = entity.NomComplet,
            Activite = entity.Activite
        };
    }
}

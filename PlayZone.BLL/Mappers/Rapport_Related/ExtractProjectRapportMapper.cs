using ProjectRapportRazor = PlayZone.Razor.Models.ProjectRapport;
using ExtractProjectRapportModel = PlayZone.BLL.Models.Rapport_Related.ExtractProjectRapport;
using ExtractProjectRapportEntity = PlayZone.DAL.Entities.Rapport_Related.ExtractProjectRapport;

namespace PlayZone.BLL.Mappers.Rapport_Related;

public static class ExtractProjectRapportMapper
{
    public static ExtractProjectRapportModel ToModel(this ExtractProjectRapportEntity entity)
    {
        return new ExtractProjectRapportModel
        {
            ProjectId = entity.ProjectId,
            CategoryId = entity.CategoryId,
            LibelleId = entity.LibelleId,
            ProjectName = entity.ProjectName,
            CategoryName = entity.CategoryName,
            LibelleName = entity.LibelleName,
            Organisme = entity.Organisme,
            Motif = entity.Motif,
            Date = entity.Date,
            Montant = entity.Montant
        };
    }

    public static ProjectRapportRazor ToRazor(this ExtractProjectRapportModel model)
    {
        return new ProjectRapportRazor
        {
            ProjectId = model.ProjectId,
            CategoryId = model.CategoryId,
            LibelleId = model.LibelleId,
            ProjectName = model.ProjectName,
            CategoryName = model.CategoryName,
            LibelleName = model.LibelleName,
            Organisme = model.Organisme,
            Motif = model.Motif,
            Date = model.Date,
            Montant = model.Montant
        };
    }
}

﻿using PlayZone.DAL.Entities.Rapport_Related;

namespace PlayZone.DAL.Interfaces.Rapport_Related;

public interface IWorktimeRapportRepository
{
    public IEnumerable<WorktimeRapport> GetAll();
    public IEnumerable<WorktimeProject> GetTotalDaysProject(DateTime start, DateTime end);
}

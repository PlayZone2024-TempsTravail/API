using PlayZone.BLL.Interfaces.Budget_Related;
using PlayZone.BLL.Mappers.Budget_Related;
using PlayZone.BLL.Models.Budget_Related;
using PlayZone.DAL.Interfaces.Budget_Related;

namespace PlayZone.BLL.Services.Budget_Related;

public class LibeleService : ILibeleService
{
    private readonly ILibeleRepository _libeleRepository;
    public LibeleService(ILibeleRepository libeleRepository)
    {
        this._libeleRepository = libeleRepository;
    }

    public IEnumerable<PlayZone.BLL.Models.Budget_Related.Libele> GetAll()
    {
        return this._libeleRepository.GetAll().Select(u => u.ToModel());
    }

    public IEnumerable<TreeCategory> GetAllWithCategories()
    {
        List<TreeCategory> treeCategories = new List<TreeCategory>();

        foreach (var tuple in this._libeleRepository.GetAllWithCategories())
        {
            TreeCategory? treeCategory = treeCategories.FirstOrDefault(tc => tc.CategoryId == tuple.CategoryId);

            if (treeCategory == default)
            {
                treeCategory = new TreeCategory { CategoryId = tuple.CategoryId, CategoryName = tuple.CategoryName };
                treeCategory.Libeles = new List<TreeLibele>();
                treeCategories.Add(treeCategory);
            }

            treeCategory.Libeles.Add(new TreeLibele { LibeleId = tuple.LibeleId, LibeleName = tuple.LibeleName });
        }

        return treeCategories;
    }

    public Libele? GetById(int id)
    {
        return this._libeleRepository.GetById(id)?.ToModel();
    }

    public int Create(Libele libele)
    {
        return this._libeleRepository.Create(libele.ToEntity());
    }

    public bool Update(Libele libele)
    {
        return this._libeleRepository.Update(libele.ToEntity());
    }

    public bool Delete(int idLibele)
    {
        return this._libeleRepository.Delete(idLibele);
    }
}

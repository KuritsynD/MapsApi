using Maps.Base;

namespace Maps;

public interface IBaseRepositry<TDbModel> where TDbModel : BaseModel
{
    public List<TDbModel> GetAll();
    public TDbModel Get(Guid Id);
    public TDbModel Create(TDbModel model);
    public TDbModel Update(TDbModel model);
    public void Delete(Guid Id);
}
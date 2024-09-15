using Maps.Base;
using Microsoft.AspNetCore.Components.Forms;

namespace Maps;

public class BaseRepository<TDbModel> : IBaseRepositry<TDbModel> where TDbModel : BaseModel
{
    private ApplicationContext Context { get; set; }

    public BaseRepository(ApplicationContext Context)
    {
        this.Context = Context;
    }

    public TDbModel Create(TDbModel model)
    {
        Context.Set<TDbModel>().Add(model);
        Context.SaveChanges();
        return model;
    }

    public void Delete(Guid Id)
    {
        var toDelete = Context.Set<TDbModel>().FirstOrDefault(m => m.Id == Id);
        Context.Set<TDbModel>().Remove(toDelete);
        Context.SaveChanges();
    }

    public List<TDbModel> GetAll()
    {
        return Context.Set<TDbModel>().ToList();
    }

    public TDbModel Update(TDbModel model)
    {
        var toUpdate = Context.Set<TDbModel>().FirstOrDefault(m => m.Id == model.Id);
        if (toUpdate!=null)
        {
            toUpdate = model;
        }
        
        Context.Update(toUpdate);
        Context.SaveChanges();
        return toUpdate;
    }

    public TDbModel Get(Guid Id)
    {
        return Context.Set<TDbModel>().FirstOrDefault(m => m.Id == Id);
    }
    
}
using proje.Core.Concrete;
using proje.DataAccess.Abstract;
using proje.Entities;

namespace proje.DataAccess.Concrete
{
    public class PersonelRepository:EFBaseRepository<ProjeDbContext,Personel>,IPersonelRepository
    {
    }
}

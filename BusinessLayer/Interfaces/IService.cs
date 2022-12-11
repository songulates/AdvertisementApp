using CommonLayer;
using DtosLayer.Interfaces;
using DtosLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IService<CreateDto,UpdateDto,ListDto,T>
        where CreateDto : class, IDtos, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDtos, new()
        where T :BaseEntity

    {
        Task<IResponse<CreateDto>> CreateAsync(CreateDto dto);
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto);
        Task<IResponse<IDtos>> GetByIdAsync<IDtos>(int id);
        Task<IResponse> RemoveAsync(int id);
        Task<IResponse<List<ListDto>>> GetAllAsync();
        //değişen şeyler ilgili dtolar 3üne hizmet eden birşey yakalanırsa ona göre hareket edilebilir.
        //genericrepositoryle ilgili işimiz bitti
        //burda generic sevice in interface i yazıldı
        //sonra bu generic servicin clası yazılacak.Bu interface i implamente eden klas yazılacak
    }
}

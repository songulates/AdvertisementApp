using AutoMapper;
using BusinessLayer.Extensions;
using BusinessLayer.Interfaces;
using CommonLayer;
using DataAccesLayer.UnitOfWork;
using DtosLayer.Interfaces;
using EntitiesLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class Service<CreateDto, UpdateDto, ListDto,T> : IService<CreateDto, UpdateDto, ListDto,T>
          where CreateDto : class, IDtos, new()
         where UpdateDto : class, IUpdateDto, new()
         where ListDto : class, IDtos, new()
         where T : BaseEntity
    {
        //bu klas generic bir clas olcak
        //serviceden alınan dtolar ıservicedeki dtolara gönderilecek
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createvalidator;
        private readonly IValidator<UpdateDto> _updatevalidator;
        //uow ile ilgili db işlemlerini yap
        private readonly IUow _uow;

        public Service(IMapper mapper, IValidator<CreateDto> createvalidator, IValidator<UpdateDto> updatevalidator, IUow uow
            )
        {
            _mapper = mapper;
            _createvalidator = createvalidator;
            _updatevalidator = updatevalidator;
            _uow = uow;
        }

        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto dto)
        {
            //önce ilgili olay validmi değilmi bakalım bunu createvalidator ile kontrol edelim
            //validse uowden ilgili repoyu çağırlaım
            //metod cağır.ilgili entitiye maplenmiş dtoyu bu arkadaşa gönder başarılı ise response dön
            //T yerine dtoyu mapleyeceğiz
           
            var result = _createvalidator.Validate(dto);
            if (result.IsValid)
            {
                var createdEntity = _mapper.Map<T>(dto);
                await _uow.GetRepository<T>().CreateAsync(createdEntity);
                await _uow.SaveChangesAsync();
                return new Response<CreateDto>(ResponseType.Success, dto);
            }
            //valid değilse ilgili dto ve hata veriliyo
            //ilgili resultun hataları varsa bu hataları gelip response içerisidne UI a dönmek lazım
            return new Response<CreateDto>(dto, result.customValidationErrors());
        }

        public async Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            var data = await _uow.GetRepository<T>().GetAllAsync();
            var dto = _mapper.Map<List<ListDto>>(data);
            return new Response<List<ListDto>>(ResponseType.Success, dto);
            //BİR List dto bekliyoruz. geriye dto dönelim
        }

        public async Task<IResponse<IDtos>> GetByIdAsync<IDtos>(int id)
        {
            var data = await _uow.GetRepository<T>().GetByFilterAsync(x => x.Id == id);
            if (data == null)
                return new Response<IDtos>(ResponseType.NotFound, $"{id} ye sahip data bulunamadı");
            //null değilse maple
            var dto = _mapper.Map<IDtos>(data);
            return new Response<IDtos>(ResponseType.Success, dto);
        }

        public async Task<IResponse> RemoveAsync(int id)
        {
            var data = await _uow.GetRepository<T>().FindAsync(id);
            if (data == null)
                return new Response(ResponseType.NotFound, $"{id} ye sahip data bulunamadı");
            //null değilse maple
            _uow.GetRepository<T>().Remove(data);
            await _uow.SaveChangesAsync();
            return new Response(ResponseType.Success);
        }

        public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            var result = _updatevalidator.Validate(dto);
            if (result.IsValid)
            {
                var unchangeddata = await _uow.GetRepository<T>().FindAsync(dto.Id);
                //bunu maplanmiş haliyle gönderelim
                if (unchangeddata == null)
                    return new Response<UpdateDto>(ResponseType.NotFound, $"{dto.Id} sine sahip data bulunamadı");
                var entity = _mapper.Map<T>(dto);
                _uow.GetRepository<T>().Update(entity, unchangeddata);
                await _uow.SaveChangesAsync();
                return new Response<UpdateDto>(ResponseType.Success, dto);
            }
            //update de entity ve unchanged var
            //IUpdateDto bir ID değeri olsun diye yazpıldı.
            
            return new Response<UpdateDto>(dto, result.customValidationErrors());
        }
        //generic servis implamente edildi
        //mapping profile oluşruralımki birbirine çevirsind dataları
    }
}

using AutoMapper;
using BeautyLand.Application.Services.Administrator.Catalogs.Types.Dtos.TypeDto;
using BeautyLand.Application.Services.Databases.SQLDatabase;
using BeautyLand.Application.Services.Dtos.BaseDto;
using BeautyLand.Application.Services.Dtos.PaginationDto;
using BeautyLand.Domain.Catalogs.Type;
using BeautyLand.Subscription.ExceptionExtentions;
using BeautyLand.Subscription.Paginations;
using System.Collections.Generic;
using System.Linq;

namespace BeautyLand.Application.Services.Administrator.Catalogs.Types
{
    public class TypeService : ITypeService
    {
        private readonly ISQLDatabaseService _context;
        private readonly IMapper _mapper;
        public TypeService(ISQLDatabaseService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public BaseDto<TypeDto> Create(TypeDto type)
        {
            var model = _mapper.Map<Domain.Catalogs.Type.Type>(type);
            _context.Types.Add(model);
            _context.SaveChanges();
            return new BaseDto<TypeDto>(_mapper.Map<TypeDto>(model), new List<string> { "ثبت شد" }, true);
        }

        public BaseDto Delete(int id)
        {
            var type = _context.Types.Find(id);
            if (type == null)
            {
                throw new NotFoundExceptionExtention<Type, int>(type, id);
            }
            _context.Types.Remove(type);
            _context.SaveChanges();
            return new BaseDto(new List<string> { "حذف شد" }, true);
        }

        public BaseDto<TypeDto> Find(int id)
        {
            var type = _context.Types.Find(id);
            if (type == null)
            {
                throw new NotFoundExceptionExtention<Type, int>(type, id);
            }
            var model = _mapper.Map<TypeDto>(type);
            return new BaseDto<TypeDto>(model, null, true);
        }

        public PaginationDto<TypeGetCatalogDto> Index(int? parentId, int pageIndex, int pageSize)
        {
            var rowCount = 0;
            var types = _context.Types
                .Where(p => p.ParentId == parentId)
                .PagedResult(pageIndex, pageSize, out rowCount);
            if (types == null)
            {
                throw new NotFoundExceptionExtention<IQueryable<Type>, int?>(types, parentId);
            }
            var model = _mapper.ProjectTo<TypeGetCatalogDto>(types).ToList();
            return new PaginationDto<TypeGetCatalogDto>(pageIndex, pageSize, rowCount, model);
        }

        public BaseDto<TypeDto> Edit(TypeDto type)
        {
            var model = _context.Types.SingleOrDefault(p => p.Id == type.Id);
            _mapper.Map(type, model);
            _context.Types.Update(model);
            _context.SaveChanges();
            return new BaseDto<TypeDto>(_mapper.Map<TypeDto>(model), new List<string> { "ویرایش شد" }, true);

        }
    }
}

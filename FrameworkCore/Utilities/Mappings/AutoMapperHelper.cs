using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Utilities.Mappings
{
    public class AutoMapperHelper:IAutoMapperBase

    {
        public List<TDest> MapToSameList<TSource, TDest>(List<TSource> list) where TSource : new()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDest>());
            IMapper mapper = config.CreateMapper();
            return mapper.Map<List<TSource>, List<TDest>>(list);
        }

        public TDest MapToSameType<TSource, TDest>(TSource obj) where TSource : new()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDest>());
            IMapper mapper = config.CreateMapper();
            return mapper.Map<TSource, TDest>(obj);
        }
    }
}

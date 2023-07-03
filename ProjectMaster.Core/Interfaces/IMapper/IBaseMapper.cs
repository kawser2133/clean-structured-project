using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMaster.Core.Interfaces.IMapper
{
    public interface IBaseMapper<TSource, TDestination>
    {
        TDestination MapModel(TSource source);
        IEnumerable<TDestination> MapList(IEnumerable<TSource> source);
    }
}

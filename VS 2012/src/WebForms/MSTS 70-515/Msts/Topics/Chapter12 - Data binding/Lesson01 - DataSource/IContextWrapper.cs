using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msts.Topics.Chapter12___Data_binding.Lesson01___DataSource
{
    public interface IContextWrapper
    {
        Msts.DataAccess.EFData.PubsEntities GetEFContext();

        void ReleaseEFContext();
    }
}

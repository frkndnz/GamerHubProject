using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.ApiModel;

namespace BusinessLayer.Abstract
{
    public interface IApiService
    {
        Task<IEnumerable<ApiGame>> GetGamesFromApiAsync();
    }
}
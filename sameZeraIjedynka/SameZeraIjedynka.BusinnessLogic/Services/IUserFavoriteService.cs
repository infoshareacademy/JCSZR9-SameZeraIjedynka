using SameZeraIjedynka.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameZeraIjedynka.BusinnessLogic.Services
{
    public interface IUserFavoriteService
    {
        Task<List<Event>> GetFavoriteEvents(int userId, string sortOption = null);
        Task AddFavoriteEvent(int userId, int eventId);
        Task DeleteFavoriteEvent(int userId, int eventId);
    }
}

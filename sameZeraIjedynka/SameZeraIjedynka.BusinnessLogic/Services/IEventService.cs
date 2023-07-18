using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SameZeraIjedynka.Database.Entities;
using SameZeraIJedynka.BusinnessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameZeraIJedynka.BusinnessLogic.Services
{
    public interface IEventService
    {
        Task<int> Add(EventModel addEventRequest, IFormFile image);
        Task<IActionResult> Delete(EventModel model);
        Task<IQueryable<Event>> Index(string sortOption);
        Task<List<Event>> Search(string searchPattern);
        /*        Task<List<EventModel>> Search(string searchPattern);
Task<bool> Delete(int eventId);*/
    }
}

﻿using Microsoft.AspNetCore.Http;
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
        Task Add(EventModel addEventRequest, IFormFile image);
        Task<List<EventModel>> Search(string searchPattern);
        Task<bool> Delete(int eventId);
    }
}

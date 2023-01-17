using BusTicket.Web.Extensions;
using BusTicket.Web.Interfaces;
using BusTicket.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusTicket.Web.Services
{
    public class CachedRoadPointViewModelService : IRoadPointViewModelService
    {
        private readonly IMemoryCache _cache;
        private readonly RoadPointViewModelService _roadPointViewModelService;

        public CachedRoadPointViewModelService(IMemoryCache cache,
            RoadPointViewModelService roadPointViewModelService)
        {
            _cache = cache;
            _roadPointViewModelService = roadPointViewModelService;
        }

        public async Task<IEnumerable<RoadPointViewModel>> GetRoadPointsAsync()
        {
            return await _cache.GetOrCreateAsync(CacheHelpers.GeneratePointsCacheKey(), async entry =>
            {
                entry.SlidingExpiration = CacheHelpers.DefaultCacheDuration;
                return await _roadPointViewModelService.GetRoadPointsAsync();
            });
        }
    }
}

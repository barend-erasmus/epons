﻿using Epons.Domain.Helpers;
using System;
using System.Configuration;
using System.Linq;

namespace Epons.Domain.Repositories
{
    public class FacilityRepository
    {
        private readonly EntityFramework.EPONSContext _context;

        public FacilityRepository()
        {
            string host = ConfigurationManager.AppSettings["DatabaseHost"];
            string user = ConfigurationManager.AppSettings["DatabaseUser"];
            string name = ConfigurationManager.AppSettings["DatabaseName"];
            string password = ConfigurationManager.AppSettings["DatabasePassword"];

            string connectionString = $"data source={host};Initial Catalog={name};User ID={user};Password={Crypto.Decrypt(password)};";
            _context = new EntityFramework.EPONSContext(connectionString);
        }

        public EntityViews.Facility.Facility FindById(Guid id)
        {
            return _context.Details.Where((x) => x.FacilityId == id).Select((x) => new EntityViews.Facility.Facility()
            {
                Avatar = x.Avatar,
                Name = x.Name
            }).FirstOrDefault();
        }
    }
}
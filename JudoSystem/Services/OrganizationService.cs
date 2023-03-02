﻿using Contracts.Interfaces;
using Entities.Models;
using Google.Protobuf.WellKnownTypes;
using JudoSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JudoSystem.Services
{
    public class OrganizationService : IOrganizationService
    {
        private IRepositoryWrapper _repository;
        public OrganizationService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public List<Organization> Get()
        {
            var organizations = _repository.Organization.FindAll().ToList();
            return organizations;
        }

        public void Update(Organization organization)
        {
            _repository.Organization.Update(organization);
            _repository.Save();
        }
    }
}

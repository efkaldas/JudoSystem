using Contracts.Interfaces;
using Entities.Models;
using Google.Protobuf.WellKnownTypes;
using JudoSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using SautinSoft.Document.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using JudoSystem.Helpers;
using Microsoft.AspNetCore.Http;

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
        public Organization UpdateImage(int userId, IFormFile image)
        {
            var organization = _repository.Organization.FindByCondition(x => x.Users.Any(x => x.Id == userId)).FirstOrDefault();
            organization.Image = FileHelper.ConvertFileToBytes(image);

            _repository.Organization.Update(organization);
            _repository.Save();

            return organization;
        }

    }
}

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
        public void UpdateImage(int userId, IFormFile image)
        {
            //if (file.ContentType.ToString() != "image/png, image/jpeg")
            //    return null;

            var user = _repository.User.FindByCondition(x => x.Id == userId).FirstOrDefault();
            if (user != null)
                return;

            var imagePath = FileHelper.SaveFile(image);
            var organization = _repository.Organization.FindByCondition(x => x.Id == userId).FirstOrDefault();

            organization.Image = imagePath;

            _repository.Organization.Update(organization);
            _repository.Save();
        }

    }
}

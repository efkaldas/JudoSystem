﻿using Contracts.Interfaces;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private JudoDbContext _repoContext;
        private IUserRepository user;
        private IOrganizationTypeRepository organizationType;
        private IOrganizationRepository organization;
        private IGenderRepository gender;
        private IUserRoleRepository userRole;

        public IUserRepository User
        {
            get
            {
                if (user == null)
                {
                    user = new UserRepository(_repoContext);
                }

                return user;
            }
        }
        public IOrganizationRepository Organization
        {
            get
            {
                if (organization == null)
                {
                    organization = new OrganizationRepository(_repoContext);
                }

                return organization;
            }
        }
        public IOrganizationTypeRepository OrganizationType
        {
            get
            {
                if (organizationType == null)
                {
                    organizationType = new OrganizationTypeRepository(_repoContext);
                }

                return organizationType;
            }
        }
        public IUserRoleRepository Gender
        {
            get
            {
                if (userRole == null)
                {
                    userRole = new UserRoleRepository(_repoContext);
                }

                return userRole;
            }
        }
        public IGenderRepository UserRole
        {
            get
            {
                if (gender == null)
                {
                    gender = new GenderRepository(_repoContext);
                }

                return gender;
            }
        }

        public RepositoryWrapper(JudoDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}

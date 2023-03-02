using Contracts.Interfaces;
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
        private IOrganizationRepository organization;
        private IUserRoleRepository userRole;
        private IJudokaRepository judoka;
        private IDanKyu danKyu;
        private ICompetitions competitions;
        private IAgeGroup ageGroup;
        private ICompetitionsType competitionsType;
        private IWeightCategory weightCategory;
        private ICompetitorRepository competitorRepository;
        private ICompetitionsResults competitionsResultsRepository;

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

        public IUserRoleRepository UserRole
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
        public IJudokaRepository Judoka
        {
            get
            {
                if (judoka == null)
                {
                    judoka = new JudokaRepository(_repoContext);
                }

                return judoka;
            }
        }
        public IDanKyu DanKyu
        {
            get
            {
                if (danKyu == null)
                {
                    danKyu = new DanKyuRepository(_repoContext);
                }

                return danKyu;
            }
        }
        public ICompetitions Competitions
        {
            get
            {
                if (competitions == null)
                {
                    competitions = new CompetitionsRepository(_repoContext);
                }

                return competitions;
            }
        }
        public IAgeGroup AgeGroup
        {
            get
            {
                if (ageGroup == null)
                {
                    ageGroup = new AgeGroupRepository(_repoContext);
                }

                return ageGroup;
            }
        }
        public ICompetitionsType CompetitionsType
        {
            get
            {
                if (competitionsType == null)
                {
                    competitionsType = new CompetitionsTypeRepository(_repoContext);
                }

                return competitionsType;
            }
        }
        public IWeightCategory WeightCategory
        {
            get
            {
                if (weightCategory == null)
                {
                    weightCategory = new WeightCategoryRepository(_repoContext);
                }

                return weightCategory;
            }
        }
        public ICompetitorRepository Competitor
        {
            get
            {
                if (competitorRepository == null)
                {
                    competitorRepository = new CompetitorRepository(_repoContext);
                }

                return competitorRepository;
            }
        }
        public ICompetitionsResults CompetitionsResults
        {
            get
            {
                if (competitionsResultsRepository == null)
                {
                    competitionsResultsRepository = new CompetitionsResultsRepository(_repoContext);
                }

                return competitionsResultsRepository;
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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Taigate.Data.Data;
using Taigate.Data.Data.Entities;

namespace Taigate.Data.Service
{
    public class ExtendUserManager : UserManager<User>
    {
        private readonly AppDbContext _dbContext;

        public ExtendUserManager(AppDbContext dbContext,IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators, IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<ExtendUserManager> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _dbContext = dbContext;

        }
        public User GetUserBySystemName(string name)
        {
           return _dbContext.Users.FirstOrDefault(x => x.SystemName == name);
        }
        public User GetUserByGuid(string guid)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Guid == guid);
        }
    }
}
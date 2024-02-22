﻿using API.Data;
using API.Models;
using API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class AccountRepository : GeneralRepository<Account>, IAccountRepository
    {
        public AccountRepository(OvertimeServiceDbContext context) : base(context)
        {
        }
    }
}

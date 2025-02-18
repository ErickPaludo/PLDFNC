﻿using WebApiFinanc.Context;
using WebApiFinanc.Models;
using WebApiFinanc.Models.DTOs;
using WebApiFinanc.Repositories.Default;

namespace WebApiFinanc.Repositories.DebitoRepository_
{
    public class DebitoRepository : RepositoryDefault<DebitoDTO>, IDebitoRepository
    {
        public DebitoRepository(AppDbContext context) : base(context)
        {
        }
    }
}

﻿using System;
using SweeneyVidyaGames.Api.Persistence.Contexts;

namespace SweeneyVidyaGames.Api.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext context;

        public BaseRepository(AppDbContext context)
        {
            this.context = context;
        }
    }
}

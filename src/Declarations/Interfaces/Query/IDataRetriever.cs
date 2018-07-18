﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Declarations.DomainModel;

namespace Declarations.Interfaces.Query
{
    public interface IDataRetriever
    {
        Task<QueryResult<IList<GitRepository>>> GetRepositoriesByCity(string city);
        Task<QueryResult<IList<GitRepository>>> GetRepositoryByUser(string user);
        Task<QueryResult<GitUser>> GetUserGraphByLogin(string user, int depth, int amount);
    }
}
using Entities;
using System.Collections.Generic;

namespace Repositories.Contracts
{
    public interface IClientRepository
    {
        List<Client> GetAll();
    }
}
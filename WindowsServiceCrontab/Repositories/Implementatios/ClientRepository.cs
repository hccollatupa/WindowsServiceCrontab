using Entities;
using Repositories.Contracts;
using System.Collections.Generic;

namespace Repositories.Implementatios
{
    public class ClientRepository : IClientRepository
    {
        public List<Client> GetAll()
        {
            return new List<Client>(){
                new Client(){
                    Id = 1,
                    Names = "Hector",
                    FirstSurname = "Ccollatupa",
                    SecondSurname = "Fuentes"
                },
                new Client(){
                    Id = 2,
                    Names = "Jordan",
                    FirstSurname = "Muñoz",
                    SecondSurname = "Ccollatupa"
                },
                new Client(){
                    Id = 3,
                    Names = "Juan",
                    FirstSurname = "Pérez",
                    SecondSurname = ""
                }
            };
        }
    }
}
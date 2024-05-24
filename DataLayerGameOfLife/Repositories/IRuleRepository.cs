using DataLayerGameOfLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerGameOfLife.Repositories
{
    public interface IRuleRepository
    {

        IEnumerable<Rule> GetAll();
        Rule GetById(int id);

        Rule GetByName(string name);

        void Add(Rule rule);

        void Update(Rule rule);

        void Delete(int id);

    }
}

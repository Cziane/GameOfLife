using DataLayerGameOfLife.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerGameOfLife.Repositories
{
    public class RuleRepository : IRuleRepository
    {
        private readonly GameOfLifeContext _context;
        public RuleRepository() { 
            this._context = new GameOfLifeContext();
        }

        public void Add(Rule rule)
        {
           this._context.Rules.Add(rule);
            this._context.SaveChanges();
        }

        public void Delete(int id)
        {
            var rule = this._context.Rules.Find(id);
            if (rule != null)
            {
                this._context.Rules.Remove(rule);
                this._context.SaveChanges();
            }
        }

        public IEnumerable<Rule> GetAll()
        {
            return this._context.Rules.ToList();
        }

        public Rule GetById(int id)
        {
            return this._context.Rules.Find(id);
        }

        public Rule GetByName(string name)
        {
            return this._context.Rules.FirstOrDefault(r => r.Name == name);
        }

        public void Update(Rule rule)
        {
            this._context.Entry(rule).State = EntityState.Modified;
            this._context.SaveChanges();
        }
    }
}

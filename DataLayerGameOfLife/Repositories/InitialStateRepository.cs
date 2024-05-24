using DataLayerGameOfLife.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerGameOfLife.Repositories
{
    public class InitialStateRepository : IInitialStateRepository
    {
        private readonly GameOfLifeContext _context;

        public InitialStateRepository()
        {
            this._context = new GameOfLifeContext();
        }
        public void Add(InitialState initialState)
        {
            this._context.InitialStates.Add(initialState);
            this._context.SaveChanges();
        }

        public void Delete(int id)
        {
            var state = this._context.InitialStates.Find(id);

            if (state != null)
            {
                this._context.InitialStates.Remove(state);
                this._context.SaveChanges();
            }
        }

        public IEnumerable<InitialState> GetAll()
        {
            return this._context.InitialStates.ToList();
        }

        public InitialState GetById(int id)
        {
            return this._context.InitialStates.Find(id);
        }

        public InitialState GetByName(string name)
        {
            return this._context.InitialStates.FirstOrDefault(s => s.Name == name);
        }

        public void Update(InitialState initialState)
        {
            this._context.Entry(initialState).State = EntityState.Modified;
            this._context.SaveChanges();
        }
    }
}

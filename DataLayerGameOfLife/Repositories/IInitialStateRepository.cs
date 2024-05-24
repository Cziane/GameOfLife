using DataLayerGameOfLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerGameOfLife.Repositories
{
    public interface IInitialStateRepository
    {
        IEnumerable<InitialState> GetAll();
        InitialState GetById(int id);

        InitialState GetByName(string name);

        void Add(InitialState initialState);
        void Update(InitialState initialState);
        void Delete(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TP4.Logic
{
    public interface IABMLogic<T>
    {
        List<T> GetAll();
        void Insert(T entities);
        void Delete(int id);
        void Update(T entities, int id);
    }
}

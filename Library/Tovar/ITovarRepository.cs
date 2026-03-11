using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tovar
{
    public interface ITovarRepository
    {
        List<Tovar> ReadAllTovars();
        void AddTovar(Tovar tovar);
        void EditTovar(Tovar tovar);
        void RemoveTovar(Tovar tovar);
        bool HasOrder(string articul);
    }
}

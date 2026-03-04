using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    public interface ITovarView
    {
        void ShowTovarInfo(Library.Tovar.Tovar tovar);
        Library.Tovar.Tovar GetTovarInfo();
    }
}

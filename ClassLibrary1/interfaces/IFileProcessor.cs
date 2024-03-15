using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.interfaces
{
    public interface IFileProcessor
    {
        List<string> ReadAdresses(string filename);
    }
}

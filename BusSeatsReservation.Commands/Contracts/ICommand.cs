using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}


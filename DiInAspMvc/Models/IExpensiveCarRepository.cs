using System.Collections.Generic;

namespace DiInAspMvc.Models
{
    public interface IExpensiveCarsRepository
    {
        IEnumerable<Car> GetExpensive();
    }

}
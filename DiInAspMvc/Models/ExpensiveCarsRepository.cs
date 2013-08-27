using System.Collections.Generic;
using System.Linq;

namespace DiInAspMvc.Models
{
    public class ExpensiveCarsRepository : IExpensiveCarsRepository
    {
        private readonly IEnumerable<Car> cars = new[]
                                                     {
                                                        new Car
                                                            {
                                                                    Producer = "Lexus",
                                                                    Model = "IS",
                                                                    Price = 150000
                                                            },
                                                            new Car
                                                            {
                                                                    Producer = "Lexus",
                                                                    Model = "LS",
                                                                    Price = 250000
                                                            },
                                                            new Car
                                                            {
                                                                    Producer = "Cadillac",
                                                                    Model = "Eldorado",
                                                                    Price = 120000
                                                            },
                                                            new Car
                                                            {
                                                                    Producer = "Skoda",
                                                                    Model = "Fabia",
                                                                    Price = 50000
                                                            }     
                                                     };
        private const decimal CheapLimit = 10000;

        public IEnumerable<Car> GetExpensive()
        {
            return cars.Where(c => c.Price > CheapLimit);
        }
    }
}
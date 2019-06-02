using InterdisciplinarLTP6.Shared.Commands;
using System;

namespace InterdisciplinarLTP6.Domain.Commands.Inputs
{
    public class CreateEmployeeCommand : ICommand
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public string CarPlate { get; set; }
    }
}

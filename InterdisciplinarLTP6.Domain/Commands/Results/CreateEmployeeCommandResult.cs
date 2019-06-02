using InterdisciplinarLTP6.Shared.Commands;

namespace InterdisciplinarLTP6.Domain.Commands.Results
{
    public class CreateEmployeeCommandResult : ICommandResult
    {
        public bool Validation { get; set; }
    }
}

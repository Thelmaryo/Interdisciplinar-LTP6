using FluentValidator;
using System.Threading.Tasks;

namespace InterdisciplinarLTP6.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommand 
    {
        Task<ICommandResult> Handle(T command);
    }
}

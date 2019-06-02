using FluentValidator;
using InterdisciplinarLTP6.Domain.Commands.Inputs;
using InterdisciplinarLTP6.Domain.Commands.Results;
using InterdisciplinarLTP6.Domain.Entities;
using InterdisciplinarLTP6.Domain.Repositories;
using InterdisciplinarLTP6.Shared.Commands;
using System.Threading.Tasks;

namespace InterdisciplinarLTP6.Domain.Commands.Handlers
{
    public class EmployeeCommandHandler : Notifiable, ICommandHandler<CreateEmployeeCommand>
    {
        private readonly IRepositoryEmployee _EREP;
        private readonly IRepositoryVehicle _VREP;

        public EmployeeCommandHandler(IRepositoryEmployee EREP, IRepositoryVehicle VREP)
        {
            _EREP = EREP;
            _VREP = VREP;
        }

        public async Task<ICommandResult> Handle(CreateEmployeeCommand command)
        {
            var employee = new Employee(command.Name, command.LastName, command.CPF);
            var vehicle = GetVehicle(command.CarPlate);
            await Task.WhenAll(employee.Validation(), vehicle);
            // Adicionar Notificações
            AddNotifications(employee.Notifications);
            // Validar
            if (IsValid())
            {
                employee.AddVehicle(vehicle.Result);
                await _EREP.Create(employee);
            }
            return new CreateEmployeeCommandResult() { Validation = IsValid() };
        }

        private async Task<Vehicle> GetVehicle(string plate)
        {
            var vehicle = await _VREP.GetByPlate(plate);
            if (vehicle == null)
            {
                AddNotification("Veiculo", "Veiculo não faz parte da Empresa");
            }
            return vehicle;
        }
    }
}

using FluentValidator;
using InterdisciplinarLTP6.Shared.Entities;
using System;
using System.Threading.Tasks;

namespace InterdisciplinarLTP6.Domain.Entities
{
    public class Employee : Entity
    {
        public Employee()
        {

        }
        public Employee(string name, string lastName, string cpf)
        {
            Name = name;
            LastName = lastName;
            CPF = cpf;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            Vehicle = vehicle;
        }

        public async Task Validation()
        {
            await Task.WhenAll(NameValidation(), LastNameValidation(), CPFValidation());
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string CPF { get; private set; }
        public Vehicle Vehicle { get; private set; }

        private async Task NameValidation()
        {
            new ValidationContract<Employee>(this)
                .IsRequired(x => x.Name, "O Nome é obrigatório")
                .HasMaxLenght(x => x.Name, 25, "O Nome deve ter no máximo 25 caracteres")
                .HasMinLenght(x => x.Name, 3, "O Nome deve ter pelo menos 3 caracteres");
           
        }

        private async Task LastNameValidation()
        {
            new ValidationContract<Employee>(this)
                .IsRequired(x=>x.LastName, "O Sobrenome é obrigatório")
                .HasMaxLenght(x => x.LastName, 30, "O Sobrenome deve ter no máximo 30 caracteres")
                .HasMinLenght(x => x.LastName, 5, "O Sobrenome deve ter pelo menos 5 caracteres");
        }

        private async Task CPFValidation()
        {
            if (string.IsNullOrEmpty(CPF) || CPF.Length != 14)
            {
                AddNotification(CPF, "CPF Invalido!");
                return;
            }
            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var cpf = CPF.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            var tempCpf = cpf.Substring(0, 9);
            var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            var resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            var digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            if(!cpf.EndsWith(digito))
                AddNotification(CPF, "CPF Invalido!");
        }
    }
}

using ApiDeClientesTesteDevAgent.Domain.Customers;

namespace ApiDeClientesTesteDevAgent.Application.Customers
{
    public sealed class CustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<CustomerDto>> ListAsync(CancellationToken cancellationToken = default)
        {
            var customers = await _repository.ListAsync(cancellationToken);
            return customers.Select(ToDto).ToList();
        }

        public async Task<CustomerDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var customer = await _repository.GetByIdAsync(id, cancellationToken)
                ?? throw new KeyNotFoundException("Cliente não encontrado.");
            return ToDto(customer);
        }

        public async Task<CustomerDto> CreateAsync(CreateCustomerRequest request, CancellationToken cancellationToken = default)
        {
            ValidateRequest(request.Name, request.Email);
            var customer = new Customer(request.Name, request.Email, request.Phone);
            await _repository.AddAsync(customer, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return ToDto(customer);
        }

        public async Task<CustomerDto> UpdateAsync(Guid id, UpdateCustomerRequest request, CancellationToken cancellationToken = default)
        {
            ValidateRequest(request.Name, request.Email);
            var customer = await _repository.GetByIdAsync(id, cancellationToken)
                ?? throw new KeyNotFoundException("Cliente não encontrado.");
            customer.Rename(request.Name);
            customer.ChangeEmail(request.Email);
            customer.ChangePhone(request.Phone);
            if (request.Active) customer.Activate(); else customer.Deactivate();
            await _repository.SaveChangesAsync(cancellationToken);
            return ToDto(customer);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var customer = await _repository.GetByIdAsync(id, cancellationToken)
                ?? throw new KeyNotFoundException("Cliente não encontrado.");
            _repository.Remove(customer);
            await _repository.SaveChangesAsync(cancellationToken);
        }

        private static void ValidateRequest(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Trim().Length < 2)
                throw new ArgumentException("Nome deve ter pelo menos 2 caracteres.", nameof(name));
            if (!string.IsNullOrWhiteSpace(email) && !email.Contains('@'))
                throw new ArgumentException("E-mail inválido.", nameof(email));
        }

        private static CustomerDto ToDto(Customer customer) => new(customer.Id, customer.Name, customer.Email, customer.Phone, customer.Active, customer.CreatedAtUtc, customer.UpdatedAtUtc);
    }
}

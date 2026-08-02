using ApiDeClientesTesteDevAgent.Domain.Common;

namespace ApiDeClientesTesteDevAgent.Domain.Customers
{
    public sealed class Customer : Entity
    {
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public bool Active { get; private set; } = true;

        private Customer() { }

        public Customer(string name, string email, string phone = "")
        {
            Rename(name);
            ChangeEmail(email);
            ChangePhone(phone);
        }

        public void Rename(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Trim().Length < 2)
                throw new ArgumentException("Nome deve ter pelo menos 2 caracteres.", nameof(name));
            Name = name.Trim();
            Touch();
        }

        public void ChangeEmail(string email)
        {
            if (!string.IsNullOrWhiteSpace(email) && !email.Contains('@'))
                throw new ArgumentException("E-mail inválido.", nameof(email));
            Email = email?.Trim() ?? string.Empty;
            Touch();
        }

        public void ChangePhone(string phone)
        {
            Phone = phone?.Trim() ?? string.Empty;
            Touch();
        }

        public void Activate()
        {
            Active = true;
            Touch();
        }

        public void Deactivate()
        {
            Active = false;
            Touch();
        }
    }
}

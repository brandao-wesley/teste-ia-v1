namespace ApiDeClientesTesteDevAgent.Domain.Estoques
{
    public sealed class Estoque
    {
        private Estoque() { }
        public Estoque(string name, string document, string email = "")
        {
            Id = Guid.NewGuid();
            Rename(name); ChangeDocument(document); ChangeEmail(email);
            Active = true; CreatedAtUtc = DateTime.UtcNow;
        }
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Document { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public bool Active { get; private set; }
        public DateTime CreatedAtUtc { get; private set; }
        public DateTime? UpdatedAtUtc { get; private set; }
        public void Rename(string name) { if (string.IsNullOrWhiteSpace(name) || name.Trim().Length < 2) throw new ArgumentException("Nome inválido.", nameof(name)); Name=name.Trim(); Touch(); }
        public void ChangeDocument(string document) { if (string.IsNullOrWhiteSpace(document) || document.Trim().Length < 3) throw new ArgumentException("Documento inválido.", nameof(document)); Document=document.Trim(); Touch(); }
        public void ChangeEmail(string email) { if (!string.IsNullOrWhiteSpace(email) && !email.Contains('@')) throw new ArgumentException("E-mail inválido.", nameof(email)); Email=(email ?? "").Trim(); Touch(); }
        public void Activate() { Active=true; Touch(); }
        public void Deactivate() { Active=false; Touch(); }
        private void Touch() => UpdatedAtUtc = DateTime.UtcNow;
    }
}

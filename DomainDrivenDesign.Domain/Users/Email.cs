namespace DomainDrivenDesign.Domain.Users;

public sealed record Email
{
    public string Value { get; set; }
    public Email(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentNullException("Email Alanı Boş Bırakılamaz");
        if (value.Length < 3)
            throw new ArgumentException("Email alanı 3 harften az olamaz.");
        if (!value.Contains("@"))
            throw new ArgumentException("Geçerli bir email adresi giriniz.");
        Value = value;
    }
}

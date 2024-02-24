namespace DomainDrivenDesign.Domain.Users;

public sealed record Password
{
    public string Value { get; set; }
    public Password(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentNullException("Password Alanı Boş Bırakılamaz");
        if (value.Length < 6)
            throw new ArgumentException("Password alanı 6 harften az olamaz.");
      
        Value = value;
    }
}

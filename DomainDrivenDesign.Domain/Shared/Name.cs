namespace DomainDrivenDesign.Domain.Shared;

public sealed record Name
{
    public string Value { get; set; }
    public Name(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentNullException("İsim Alanı Boş Bırakılamaz");
        if (value.Length < 3)
            throw new ArgumentException("İsim alanı 3 harften az olamaz.");
        Value = value;
    }
}

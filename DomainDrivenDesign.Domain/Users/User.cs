using DomainDrivenDesign.Domain.Abstraction;
using DomainDrivenDesign.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Users;

public sealed class User:Entity
{
    private User(Guid id):base(id) { }
   
    private User(Guid id,Name name, Email email, Password password, Address address):base(id)
    {
        Name = name;
        Email = email;
        Password = password;
        Address = address;
    }

    public Name Name { get; private set; }
    public Email Email { get;private set; }
    public Password Password { get; private set; }
    public Address Address { get; private set; }  


    public static User CreateUser(string name,string password,string email, string country, string postalCode, string fullAdress, string city, string street)
    {
        User user = new(
            id:Guid.NewGuid(),
            name:new Name(name),
            email:new Email(email),
            password:new(password),
            address:new(country,city,street,fullAdress,postalCode)
            );
        return user;
    }
    
    public void ChangeName(string name)
    {
        Name=new Name(name);
    }
    public void ChangeAddress(string country,string postalCode,string fullAdress,string city,string street)
    {
        Address = new(country,city,street,fullAdress,postalCode);
    }
    public void ChangePassword(string password)
    {
        Password=new Password(password);
    }
}

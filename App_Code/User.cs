using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// this class contains information about a user.
/// </summary>
public class User
{
    private string firstName;
    private string lastName;
    private string id;
    private string email;
    private string gender;
    private bool isAdmin;
    public User(string firstName, string lastName, string id, string email, string gender, bool isAdmin)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.id = id;
        this.email = email;
        this.gender = gender;
        this.isAdmin = isAdmin;
    }
    public string GetFirstName()
    {
        return this.firstName;
    }
    public string GetLastName()
    {
        return this.lastName;
    }
    public string GetId()
    {
        return this.id;
    }
    public string GetEmail()
    {
        return this.email;
    }
    public string GetGender()
    {
        return this.gender;
    }
    public bool GetIsAdmin()
    {
        return this.isAdmin;
    }
}
namespace KhrDesktop.Models;

public partial class Employee
{
    public string Name
    {
        get { return this.LastName + " " + this.FirstName + " " + this.Surname; }
    }
}
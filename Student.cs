using System;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public int Rank { get; set; }

    public Student(string fn, string ln, int r)
    {
        FirstName = fn;
        LastName = ln;
        Rank = r;
    }

    public string ShowInfo()
    {
        string info = $"First Name: {FirstName}, Last Name: {LastName}, Rank: {Rank}";
        return info;
    }
}
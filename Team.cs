using System;
using System.Collections.Generic;

public class Team
{
    public string TeamName { get; set; }

    public List<Student> Members = new List<Student>();

    public Team(string name) => TeamName = name;



    public void AddMember(Student s) => Members.Add(s);

}
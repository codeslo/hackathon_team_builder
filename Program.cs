using System;
using System.Collections.Generic;
using System.IO;



namespace HackathonTeams
{
    class Program
    {
        static void Main(string[] args)
        {
            var Students = new List<Student>();
            FileStream fileStream = new FileStream("./Files/hackathon_teams.csv", FileMode.Open);

            using (StreamReader sr = File.OpenText("./Files/hackathon_teams.csv"))
            {
                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine();
                    var values = line.Split(',');
                    var student = new Student(values[0], values[1], Int32.Parse(values[2]));
                    Students.Add(student);
                }

            }

            // break students into groups by rank
            var RankOne = new List<Student>();
            var RankTwo = new List<Student>();
            var RankThree = new List<Student>();



            Students.ForEach(s =>
            {
                switch (s.Rank)
                {
                    case 1:
                        RankOne.Add(s);
                        break;
                    case 2:
                        RankTwo.Add(s);
                        break;
                    default:
                        RankThree.Add(s);
                        break;
                }
            });

            // shuffle ranks
            RankOne.Shuffle();
            RankTwo.Shuffle();
            RankThree.Shuffle();

            // build teams
            var TeamOne = new Team("Team One");
            var TeamTwo = new Team("Team Two");
            var TeamThree = new Team("Team Three");
            var TeamFour = new Team("Team Four");
            var TeamFive = new Team("Team Five");
            var TeamSix = new Team("Team Six");


            // make a team list
            var TeamList = new List<Team>();
            TeamList.Add(TeamOne);
            TeamList.Add(TeamTwo);
            TeamList.Add(TeamThree);
            TeamList.Add(TeamFour);
            TeamList.Add(TeamFive);
            TeamList.Add(TeamSix);

            // distribute rank three students to teams
            int currentTeam = 0;
            RankThree.ForEach(student =>
            {
                TeamList[currentTeam].AddMember(student);
                if (currentTeam < TeamList.Count - 1)
                {
                    currentTeam++;
                }
                else
                {
                    currentTeam = 0;
                }
            });

            // distribute rank two students to teams
            RankTwo.ForEach(student =>
            {
                TeamList[currentTeam].AddMember(student);
                if (currentTeam < TeamList.Count - 1)
                {
                    currentTeam++;
                }
                else
                {
                    currentTeam = 0;
                }
            });

            // distribute rank one students to teams
            RankOne.ForEach(student =>
            {
                TeamList[currentTeam].AddMember(student);
                if (currentTeam < TeamList.Count - 1)
                {
                    currentTeam++;
                }
                else
                {
                    currentTeam = 0;
                }
            });

            // write teams to file
            using (StreamWriter writer = System.IO.File.AppendText("./Files/teams.csv"))
            {
                TeamList.ForEach(team =>
                {
                    writer.WriteLine($"{team.TeamName},");
                    team.Members.ForEach(member =>
                    {
                        writer.WriteLine($"{member.FirstName} {member.LastName},");
                    });
                });
            }
        }
    }
}

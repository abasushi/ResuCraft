using Microsoft.Identity.Client;

namespace TUPApp.Models
{
    public class HomeViewModel
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string CareerObjective { get; set; }

        public List<Skill1> Skills { get; set;}
        public List<EducBG> EducationalBackground { get; set; }
        public List<EmerContact> EmergencyContact { get; set; }
        public List<Expi> Experience { get; set; }
        public List<Train> TrainingsAttended { get; set; }
    }
}

public class Skill1
{
    public int ID { get; set; }
    public string Skill { get; set; }
    public int StudentID { get; set; }
}

public class EducBG
{
    public int ID { get; set; }
    public string EducationalAttainment { get; set; }
    public string School { get; set; }
    public string YearStarted { get; set; }
    public string YearGraduated { get; set; }
    public string Address { get; set; }
    public int StudentID { get; set; }
}

public class EmerContact
{
    public int ID { get; set; }
    public string EmergencyName { get; set; }
    public string EmergencyNumber { get; set; }
    public string Relationship { get; set; }
    public int StudentID { get; set; }
}

public class Expi
{
    public int ID { get; set; }
    public string Experience1 { get; set; }
    public string YearStarted { get; set; }
    public string YearEnded { get; set; }
    public int StudentID { get; set; }
}

public class Train
{
    public int ID { get; set; }
    public string Training { get; set; }
    public string YearAttended { get; set; }
    public int StudentID { get; set; }
}
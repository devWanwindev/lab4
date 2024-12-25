using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

[Serializable]
public class Students
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public int School { get; set; }
    public int Score { get; set; }
    public Students()
    {

    }
    /*public Students(string lastnamed, string firstnamed, int schoold, int scored)
    {
        LastName = lastnamed;
        FirstName = firstnamed;
        School = schoold;
        Score = scored;
    }*/
}
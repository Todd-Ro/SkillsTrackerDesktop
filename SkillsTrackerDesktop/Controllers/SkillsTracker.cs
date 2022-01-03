using Microsoft.AspNetCore.Mvc;

namespace SkillsTrackerDesktop.Controllers
{
    [Route("/skills")]
    public class SkillsTracker : Controller
    {
        string[] languages = new string[] { "JavaScript", "C#", "TypeScript" };
        
        
        public IActionResult Index()
        {
            string header = "<h1>Skills Tracker</h1><br>";
            string langList = "<h2><ol>";
            foreach (string s in languages)
            {
                langList = langList + $"<li>{s}</li>";
            }
            langList += "</ol></h2>";
            return Content(header+langList, "text/html");
        }

        
        [HttpGet("form")]
        public IActionResult ProgressForm()
        {
            string monsterFormString;
            /*monsterFormString =
                "<form action='/skills/form' method='post'><label for='today'>Date: </label><input type='date' id='today' name='todaydate'><br>" +
                "<label for='jsskill'>Skill level in JavaScript: </label><select name='skill1' id='jsskill'><option value='learning basics'>Learning basics</option><option value='making apps'>Making apps</option><option value='master coder'>Master coder</option></select><br><br>" +
                "<input type='submit' value='Submit'></form>";*/

            string formStart = "<form action='/skills/form/display' method='post'><label for='today'>Date: </label><input type='date' id='today' name='todaydate'><br>";
            string optionSet = "<option value='learning basics'>Learning basics</option><option value='making apps'>Making apps</option><option value='master coder'>Master coder</option></select><br>";
            string formSkills = "";
            int i = 1;
            foreach (string s in languages)
            {
                string thisSkillLabel = "<label for=" + $"'{s}skill'>" + "Skill level in " + s + ": " + "</label>";
                string thisSkillSelect = "<select name='skill"+i+"' id="+ $"'{s}skill'>";
                formSkills += thisSkillLabel + thisSkillSelect + optionSet;
                i++;
            }
            formSkills += "<br>";
            //formSkills += "<label for='jsskill'>Skill level in JavaScript: </label><select name='skill1' id='jsskill'><option value='learning basics'>Learning basics</option><option value='making apps'>Making apps</option><option value='master coder'>Master coder</option></select><br><br>";
            string formSubmit = "<input type='submit' value='Submit'></form>";

            monsterFormString = formStart + formSkills + formSubmit;

            return Content(monsterFormString, "text/html");
        }

        [HttpPost("form/display")]
        public IActionResult DisplayFormResults(string todaydate, 
            string skill1 = "JavaScript", string skill2 = "C#", 
            string skill3 = "TypeScript")
        {
            string[] skills = new string[] { skill1, skill2, skill3 };
            string dateData = "<h1>" + todaydate + "</h1>";
            //string langList = "<h2><ol>";
            string tableSetup = "<table><tr><th>Language</th><th>Skill Level</th></tr>";
            string tableRows = "";
            for(int i = 0; i < languages.Length; i++)
            {
                tableRows += "<tr>" + "<td>" + languages[i] + ": " + "</td>" +
                    "<td>&nbsp;" + skills[i] + "</td>" + "</tr>";
            }
            string tableFinish = "</table>";
            //langList += "</ol></h2>";
            //return Content(dateData + langList, "text/html");
            return Content(dateData + tableSetup+tableRows+tableFinish, "text/html");
        }



    }
}

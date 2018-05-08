using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_ParserXMLtoDatabase.Model_XML
{
    class Root
    {
        public Troop Troop { get; set; }
        public Sight Sight { get; set; }
        public Density Density { get; set; }
        public Bible Bible { get; set; }
        public Historian Historian { get; set; }
        public Root() { }
        public Root(Troop troop, Sight sight, Density density, Bible bible, Historian historian)
        {
            this.Troop = troop;
            this.Sight = sight;
            this.Density = density;
            this.Bible = bible;
            this.Historian = historian;
        }
    }

    internal class Troop
    {
        public List<Oil> ListOfOil { get; set; }
        public string Charge { get; set; }
        public string Return { get; set; }
        public string Cucumber { get; set; }
        public string Twin { get; set; }
        public string Postpone { get; set; }
        public Troop(List<Oil> listOfOil, string charge, string @return, string cucumber, string twin, string postpone)
        {
            this.ListOfOil = listOfOil;
            this.Charge = charge;
            this.Return = @return;
            this.Cucumber = cucumber;
            this.Twin = twin;
            this.Postpone = postpone;
        }
    }

    public class Oil
    {
        public List<Information> ListOfInformation { get; set; }
        public string Cat { get; set; }
        public string Year { get; set; }
        public string Help { get; set; }
        public string Study { get; set; }
        public string Consideration { get; set; }
        public string Remedy { get; set; }
        public string Screw { get; set; }
        public Oil() { }
        public Oil(List<Information> listOfInformation, string cat, string year, string help, string study, string consideration, string remedy, string screw)
        {
            this.ListOfInformation = listOfInformation;
            this.Cat = cat;
            this.Year = year;
            this.Help = help;
            this.Study = study;
            this.Consideration = consideration;
            this.Remedy = remedy;
            this.Screw = screw;
        }

    }

    public class Information
    {
        public string Conservative { get; set; }
        public string Venus { get; set; }
        public string Know { get; set; }
        public string Save { get; set; }
        public string InnerText { get; set; }
        public Information() { }
        public Information(string conservative, string venus, string know, string save, string innerText)
        {
            this.Conservative = conservative;
            this.Venus = venus;
            this.Know = know;
            this.Save = save;
            this.InnerText = innerText;
        }
    }

    public class Sight
    {
        public List<Confine> ListOfConfine { get; set; }
        public string Depression { get; set; }
        public Sight() { }
        public Sight(List<Confine> listOfConfine, string depression)
        {
            this.ListOfConfine = listOfConfine;
            this.Depression = depression;
        }
    }

    public class Confine
    {
        public List<Force> ListOfForce { get; set; }
        public string Related { get; set; }
        public Confine() { }
        public Confine(List<Force> listOfForce, string related)
        {
            this.ListOfForce = listOfForce;
            this.Related = related;
        }
    }

    public class Force
    {
        public string InnerText { get; set; }
        public Force() { }
        public Force(string innerText)
        {
            this.InnerText = innerText;
        }
    }

    public class Density
    {
        public List<Gesture> ListOfGesture { get; set; }
        public string Nail { get; set; }
        public string Include { get; set; }
        public string Inspire { get; set; }
        public string Discourse { get; set; }
        public string Instinct { get; set; }
        public string Credibility { get; set; }
        public string Absorption { get; set; }
        public Density() { }
        public Density(List<Gesture> listOfGesture, string nail, string include, string inspire, string discourse, string instinct, string credibility, string absorption)
        {
            this.ListOfGesture = listOfGesture;
            this.Nail = nail;
            this.Include = include;
            this.Inspire = inspire;
            this.Discourse = discourse;
            this.Instinct = instinct;
            this.Credibility = credibility;
            this.Absorption = absorption;
        }

    }

    public class Gesture
    {
        public List<Hen> ListOfHen { get; set; }
        public Gesture() { }
        public Gesture(List<Hen> listOfHen)
        {
            this.ListOfHen = listOfHen;
        }
    }

    public class Hen
    {
        public string InnerText { get; set; }
        public Hen() { }
        public Hen(string innerText)
        {
            this.InnerText = innerText;
        }
    }

    public class Bible
    {
        public List<Sell> ListOfSell { get; set; }
        public string Waterfall { get; set; }
        public string Chemical { get; set; }
        public string Descent { get; set; }
        public string Act { get; set; }
        public string Appeal { get; set; }
        public string Shaft { get; set; }
        public Bible() { }
        public Bible(List<Sell> listOfSell, string waterfall, string chemical, string descent, string act, string appeal, string shaft)
        {
            this.ListOfSell = listOfSell;
            this.Waterfall = waterfall;
            this.Chemical = chemical;
            this.Descent = descent;
            this.Act = act;
            this.Appeal = appeal;
            this.Shaft = shaft;
        }
    }

    public class Sell
    {
        public List<Specified> ListOfSpecified { get; set; }
        public string Bow { get; set; }
        public string Send { get; set; }
        public string Shop { get; set; }
        public string File { get; set; }
        public Sell() { }
        public Sell(List<Specified> listOfSpecified, string bow, string send, string shop, string file)
        {
            this.ListOfSpecified = listOfSpecified;
            this.Bow = bow;
            this.Send = send;
            this.Shop = shop;
            this.File = file;
        }
    }

    public class Specified
    {
        public string Muscle { get; set; }
        public string Pipe { get; set; }
        public string InnerText { get; set; }
        public Specified() { }
        public Specified(string muscle, string pipe, string innerText)
        {
            this.Muscle = muscle;
            this.Pipe = pipe;
            this.InnerText = innerText;
        }
    }

    public class Historian
    {
        public List<Crash> ListOfCrash { get; set; }
        public Historian() { }
        public Historian(List<Crash> listOfCrash)
        {
            this.ListOfCrash = listOfCrash;
        }
    }

    public class Crash
    {
        public List<Different> ListOfDifferent { get; set; }
        public Crash() { }
        public Crash(List<Different> listOfDifferent)
        {
            this.ListOfDifferent = listOfDifferent;
        }
    }

    public class Different
    {
        public string InnerText { get; set; }
        public Different() { }
        public Different(string innerText)
        {
            this.InnerText = innerText;
        }
    }
}

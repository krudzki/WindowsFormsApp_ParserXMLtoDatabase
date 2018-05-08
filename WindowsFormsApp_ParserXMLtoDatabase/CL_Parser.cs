using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WindowsFormsApp_ParserXMLtoDatabase.Model_XML;

namespace WindowsFormsApp_ParserXMLtoDatabase
{
    class CL_Parser
    {
        MySqlConnection connection = new MySqlConnection("server=liza.umcs.lublin.pl;user=krudzki;database=krudzki;password=kwiecien0404;SslMode=none");

        public Root Parser(string filename)
        {
            
            MySqlCommand commandTEST = connection.CreateCommand();
            MySqlCommand command;
            
            string id;
            string name;

            int itemCount = 0;
            int itemDeepCount = 0;

            // Załadowanie dokumentu
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);

            // Przygotowanie struktury
            Root result = new Root();
            XmlNode elRoot, elTroop, elSight, elDensity, elBible, elHistorian;

            elRoot = doc.DocumentElement.SelectSingleNode("/root");
            elTroop = doc.DocumentElement.SelectSingleNode("/root/troop");
            elSight = doc.DocumentElement.SelectSingleNode("/root/sight");
            elDensity = doc.DocumentElement.SelectSingleNode("/root/density");
            elBible = doc.DocumentElement.SelectSingleNode("/root/bible");
            elHistorian = doc.DocumentElement.SelectSingleNode("/root/historian");

            /**
             * TROOP
             **/

            string charge = elTroop.Attributes["charge"].InnerText.ToString();
            string @return = elTroop.Attributes["return"].InnerText.ToString();
            string cucumber = elTroop.Attributes["cucumber"].InnerText.ToString();
            string twin = elTroop.Attributes["twin"].InnerText.ToString();
            string postpone = elTroop.Attributes["postpone"].InnerText.ToString();

            name = "troop";

            command = new MySqlCommand("CREATE TABLE " + name +" (" +
                "ID         int NOT NULL, " +
                "name       varchar(255) NOT NULL, " +
                "charge     varchar(255) NOT NULL, " +
                "return_    varchar(255) NOT NULL, " +
                "cucumber   varchar(255) NOT NULL, " +
                "twin       varchar(255) NOT NULL, " +
                "postpone   varchar(255) NOT NULL, " +
                "PRIMARY KEY (ID))", connection);

            TestMyQuery(commandTEST, command, name);
            ExecMyQuery(command, "Utworzono " + name);

            command = new MySqlCommand("INSERT INTO " + name + " (" +
                "name, charge, return_, cucumber, twin, postpone) " +
                "VALUES (" +
                "@name,@charge,@return,@cucumber,@twin,@postpone)", connection);

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@charge", MySqlDbType.VarChar).Value = charge;
            command.Parameters.Add("@return", MySqlDbType.VarChar).Value = @return;
            command.Parameters.Add("@cucumber", MySqlDbType.VarChar).Value = cucumber;
            command.Parameters.Add("@twin", MySqlDbType.VarChar).Value = twin;
            command.Parameters.Add("@postpone", MySqlDbType.VarChar).Value = postpone;

            ExecMyQuery(command, "Dodano do Twin!");


            Oil oil;
            Information information;
            XmlNodeList elOilList = elTroop.ChildNodes;
            XmlNodeList elInformationList;

            // stringi oil
            string cat, year, help, study, consideration, remedy, screw;

            name = "oil";

            command = new MySqlCommand("CREATE TABLE " + name + " (" +
                "ID             int NOT NULL, " +
                "name           varchar(255) NOT NULL, " +
                //"parent_ID      int NOT NULL, " +
                //"parent_name    varchar(255) NOT NULL, " +
                "cat            varchar(255) NOT NULL, " +
                "year           varchar(255) NOT NULL, " +
                "help           varchar(255) NOT NULL, " +
                "study          varchar(255) NOT NULL, " +
                "consideration  varchar(255) NOT NULL, " +
                "remedy         varchar(255) NOT NULL, " +
                "screw          varchar(255) NOT NULL, " +
                "PRIMARY KEY (ID))", connection);
                //"FOREIGN KEY (parent_ID, parent_name)" +
                //"   REFERENCES troop(ID, name))", connection);

            TestMyQuery(commandTEST, command, name);
            ExecMyQuery(command, "Utworzono " + name);

            // stringi information
            string conservative, venus, know, save, innerTextInformation;

            name = "information";

            command = new MySqlCommand("CREATE TABLE " + name + " (" +
                "ID                     int NOT NULL, " +
                "name                   varchar(255) NOT NULL, " +
                //"parent_ID              int NOT NULL, " +
                //"parent_name            varchar(255) NOT NULL, " +
                "conservative           varchar(255) NOT NULL, " +
                "venus                  varchar(255) NOT NULL, " +
                "know                   varchar(255) NOT NULL, " +
                "save                   varchar(255) NOT NULL, " +
                "innerTextInformation   varchar(255) NOT NULL, " +
                "PRIMARY KEY (ID))", connection);
            //"FOREIGN KEY (parent_ID, parent_name)" +
            //"   REFERENCES oil(ID, name))", connection);

            TestMyQuery(commandTEST, command, name);
            ExecMyQuery(command, "Utworzono " + name);

            List<Oil> ListOfOil = new List<Oil>();

            itemCount = 0;
            itemDeepCount = 0;

            foreach (XmlNode item in elOilList)
            {
                cat = item.Attributes["cat"].InnerText.ToString();
                year = item.Attributes["year"].InnerText.ToString();
                help = item.Attributes["help"].InnerText.ToString();
                study = item.Attributes["study"].InnerText.ToString();
                consideration = item.Attributes["consideration"].InnerText.ToString();
                remedy = item.Attributes["remedy"].InnerText.ToString();
                screw = item.Attributes["screw"].InnerText.ToString();
                List<Information> ListOfInformation = new List<Information>();
                elInformationList = item.ChildNodes;

                name = "oil";
                command = new MySqlCommand("INSERT INTO " + name + " (" +
                "ID, name, cat, year, help, study, consideration, remedy, screw) " +
                "VALUES (" +
                "@ID, @name, @cat, @year, @help, @study, @consideration, @remedy, @screw)", connection);

                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = itemCount;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@cat", MySqlDbType.VarChar).Value = cat;
                command.Parameters.Add("@year", MySqlDbType.VarChar).Value = year;
                command.Parameters.Add("@help", MySqlDbType.VarChar).Value = help;
                command.Parameters.Add("@study", MySqlDbType.VarChar).Value = study;
                command.Parameters.Add("@consideration", MySqlDbType.VarChar).Value = consideration;
                command.Parameters.Add("@remedy", MySqlDbType.VarChar).Value = remedy;
                command.Parameters.Add("@screw", MySqlDbType.VarChar).Value = screw;
                ExecMyQuery(command, "Dodano do Twin!");

                foreach (XmlNode deeperItem in elInformationList)
                {
                    conservative = deeperItem.Attributes["conservative"].InnerText.ToString();
                    venus = deeperItem.Attributes["venus"].InnerText.ToString();
                    know = deeperItem.Attributes["know"].InnerText.ToString();
                    save = deeperItem.Attributes["save"].InnerText.ToString();
                    innerTextInformation = deeperItem.InnerText.ToString();

                    name = "information";
                    command = new MySqlCommand("INSERT INTO " + name + " (" +
                    "ID, name, conservative, venus, know, save, innerTextInformation) " +
                    "VALUES (" +
                    "@ID, @name, @conservative, @venus, @know, @save, @innerTextInformation)", connection);

                    command.Parameters.Add("@ID", MySqlDbType.Int32).Value = itemDeepCount;
                    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                    command.Parameters.Add("@conservative", MySqlDbType.VarChar).Value = conservative;
                    command.Parameters.Add("@venus", MySqlDbType.VarChar).Value = venus;
                    command.Parameters.Add("@know", MySqlDbType.VarChar).Value = know;
                    command.Parameters.Add("@save", MySqlDbType.VarChar).Value = save;
                    command.Parameters.Add("@innerTextInformation", MySqlDbType.VarChar).Value = innerTextInformation;
                    ExecMyQuery(command, "Dodano do Twin!");

                    information = new Information(conservative, venus, know, save, innerTextInformation);

                    ListOfInformation.Add(information);
                    itemDeepCount++;
                }

                oil = new Oil(ListOfInformation, cat, year, help, study, consideration, remedy, screw);
                ListOfOil.Add(oil);
                itemCount++;
            }
            Troop troop = new Troop(ListOfOil, charge, @return, cucumber, twin, postpone);

            /**
             * SIGHT
             * */

            string depression = elSight.Attributes["depression"].InnerText.ToString();

            name = "sight";

            command = new MySqlCommand("CREATE TABLE " + name + " (" +
                "ID         int NOT NULL, " +
                "name       varchar(255) NOT NULL, " +
                "depression varchar(255) NOT NULL, " +
                "PRIMARY KEY (ID))", connection);

            TestMyQuery(commandTEST, command, name);
            ExecMyQuery(command, "Utworzono " + name);

            command = new MySqlCommand("INSERT INTO " + name + " (" +
                "name, depression) " +
                "VALUES (" +
                "@name,@depression)", connection);

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@depression", MySqlDbType.VarChar).Value = charge;

            ExecMyQuery(command, "Dodano do sight!");

            Confine confine;
            Force force;
            XmlNodeList elConfineList = elSight.ChildNodes;
            XmlNodeList elForceList;

            // stringi confine
            string related;

            name = "confine";

            command = new MySqlCommand("CREATE TABLE " + name + " (" +
                "ID             int NOT NULL, " +
                "name           varchar(255) NOT NULL, " +
                //"parent_ID      int NOT NULL, " +
                //"parent_name    varchar(255) NOT NULL, " +
                "related        varchar(255) NOT NULL, " +
                "PRIMARY KEY (ID))", connection);
            //"FOREIGN KEY (parent_ID, parent_name)" +
            //"   REFERENCES sight(ID, name))", connection);

            TestMyQuery(commandTEST, command, name);
            ExecMyQuery(command, "Utworzono " + name);

            // stringi force
            string innerTextForce;

            name = "force_";

            command = new MySqlCommand("CREATE TABLE " + name + " (" +
                "ID                     int NOT NULL, " +
                "name                   varchar(255) NOT NULL, " +
                //"parent_ID              int NOT NULL, " +
                //"parent_name            varchar(255) NOT NULL, " +
                "innerTextForce         varchar(255) NOT NULL, " +
                "PRIMARY KEY (ID))", connection);

            //command = new MySqlCommand("CREATE TABLE " + name + " (" +
            //    "ID             int NOT NULL, " +
            //    "name           varchar(255) NOT NULL, " +
            //    //"parent_ID      int NOT NULL, " +
            //    //"parent_name    varchar(255) NOT NULL, " +
            //    "innerTextForce varchar(255) NOT NULL, " +
            //    "PRIMARY KEY (ID))", connection);
            ////"FOREIGN KEY (parent_ID, parent_name)" +
            ////"   REFERENCES confine(ID, name))", connection);

            TestMyQuery(commandTEST, command, name);
            ExecMyQuery(command, "Utworzono " + name);

            List<Confine> ListOfconfine = new List<Confine>();

            itemCount = 0;
            itemDeepCount = 0;

            foreach (XmlNode item in elConfineList)
            {
                related = item.Attributes["related"].InnerText.ToString();

                name = "confine";
                command = new MySqlCommand("INSERT INTO " + name + " (" +
                "ID, name, related) " +
                "VALUES (" +
                "@ID, @name, @related)", connection);

                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = itemCount;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@related", MySqlDbType.VarChar).Value = related;
                ExecMyQuery(command, "Dodano do Twin!");

                List<Force> ListOfForce = new List<Force>();
                elForceList = item.ChildNodes;

                foreach (XmlNode deeperItem in elForceList)
                {
                    innerTextForce = deeperItem.InnerText.ToString();

                    name = "force_";
                    command = new MySqlCommand("INSERT INTO " + name + " (" +
                    "ID, name, innerTextForce) " +
                    "VALUES (" +
                    "@ID, @name, @innerTextForce)", connection);

                    command.Parameters.Add("@ID", MySqlDbType.Int32).Value = itemDeepCount;
                    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                    command.Parameters.Add("@innerTextForce", MySqlDbType.VarChar).Value = innerTextForce;
                    ExecMyQuery(command, "Dodano do Twin!");

                    force = new Force(innerTextForce);
                    ListOfForce.Add(force);
                    itemDeepCount++;
                }

                confine = new Confine(ListOfForce, related);
                ListOfconfine.Add(confine);
                itemCount++;
            }
            Sight sight = new Sight(ListOfconfine, depression);

            /**
             * DENSITY
             * */

            string nail = elDensity.Attributes["nail"].InnerText.ToString();
            string include = elDensity.Attributes["include"].InnerText.ToString();
            string inspire = elDensity.Attributes["inspire"].InnerText.ToString();
            string discourse = elDensity.Attributes["discourse"].InnerText.ToString();
            string instinct = elDensity.Attributes["instinct"].InnerText.ToString();
            string credibility = elDensity.Attributes["credibility"].InnerText.ToString();
            string absorption = elDensity.Attributes["absorption"].InnerText.ToString();

            name = "density";

            command = new MySqlCommand("CREATE TABLE " + name + " (" +
                "ID             int          NOT NULL, " +
                "name           varchar(255) NOT NULL, " +
                "nail           varchar(255) NOT NULL, " +
                "include        varchar(255) NOT NULL, " +
                "inspire        varchar(255) NOT NULL, " +
                "discourse      varchar(255) NOT NULL, " +
                "instinct       varchar(255) NOT NULL, " +
                "credibility    varchar(255) NOT NULL, " +
                "absorption     varchar(255) NOT NULL, " +
                "PRIMARY KEY (ID))", connection);

            TestMyQuery(commandTEST, command, name);
            ExecMyQuery(command, "Utworzono " + name);

            command = new MySqlCommand("INSERT INTO " + name + " (" +
                "name, nail, include, inspire, discourse, instinct, credibility, absorption) " +
                "VALUES (" +
                "@name, @nail,@include,@inspire,@discourse,@instinct,@credibility,@absorption)", connection);

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@nail", MySqlDbType.VarChar).Value = nail;
            command.Parameters.Add("@include", MySqlDbType.VarChar).Value = include;
            command.Parameters.Add("@inspire", MySqlDbType.VarChar).Value = inspire;
            command.Parameters.Add("@discourse", MySqlDbType.VarChar).Value = discourse;
            command.Parameters.Add("@instinct", MySqlDbType.VarChar).Value = instinct;
            command.Parameters.Add("@credibility", MySqlDbType.VarChar).Value = credibility;
            command.Parameters.Add("@absorption", MySqlDbType.VarChar).Value = absorption;

            ExecMyQuery(command, "Dodano do " + name + "!");

            Gesture gesture;
            Hen hen;
            XmlNodeList elGestureList = elDensity.ChildNodes;
            XmlNodeList elHenList;

            name = "gesture";

            command = new MySqlCommand("CREATE TABLE " + name + " (" +
                "ID             int NOT NULL, " +
                "name           varchar(255) NOT NULL, " +
                //"parent_ID      int NOT NULL, " +
                //"parent_name    varchar(255) NOT NULL, " +
                "PRIMARY KEY (ID))", connection);
            //"FOREIGN KEY (parent_ID, parent_name)" +
            //"   REFERENCES density(ID, name))", connection);

            TestMyQuery(commandTEST, command, name);
            ExecMyQuery(command, "Utworzono " + name);

            // stringi hen
            string innerTextHen;

            name = "hen";

            command = new MySqlCommand("CREATE TABLE " + name + " (" +
                "ID             int NOT NULL, " +
                "name           varchar(255) NOT NULL, " +
                //"parent_ID      int NOT NULL, " +
                //"parent_name    varchar(255) NOT NULL, " +
                "innerTextHen   varchar(255) NOT NULL, " +
                "PRIMARY KEY (ID))", connection);
            //"FOREIGN KEY (parent_ID, parent_name)" +
            //"   REFERENCES gesture(ID, name))", connection);

            TestMyQuery(commandTEST, command, name);
            ExecMyQuery(command, "Utworzono " + name);

            List<Gesture> ListOfGesture = new List<Gesture>();

            itemCount = 0;
            itemDeepCount = 0;

            foreach (XmlNode item in elGestureList)
            {
                name = "gesture";
                command = new MySqlCommand("INSERT INTO " + name + " (" +
                "ID, name) " +
                "VALUES (" +
                "@ID, @name)", connection);

                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = itemCount;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                ExecMyQuery(command, "Dodano do Twin!");

                List<Hen> ListOfHen = new List<Hen>();
                elHenList = item.ChildNodes;

                foreach (XmlNode deeperItem in elHenList)
                {
                    innerTextHen = deeperItem.InnerText.ToString();

                    name = "hen";
                    command = new MySqlCommand("INSERT INTO " + name + " (" +
                    "ID, name, innerTextHen) " +
                    "VALUES (" +
                    "@ID, @name, @innerTextHen)", connection);

                    command.Parameters.Add("@ID", MySqlDbType.Int32).Value = itemDeepCount;
                    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                    command.Parameters.Add("@innerTextHen", MySqlDbType.VarChar).Value = innerTextHen;
                    ExecMyQuery(command, "Dodano do Twin!");

                    hen = new Hen(innerTextHen);
                    ListOfHen.Add(hen);
                    itemDeepCount++;
                }

                gesture = new Gesture(ListOfHen);
                ListOfGesture.Add(gesture);
                itemCount++;
            }
            Density density = new Density(ListOfGesture, nail, include, inspire, discourse, instinct, credibility, absorption);

            /** 
             *  BIBLE
             *  */

            string waterfall = elBible.Attributes["waterfall"].InnerText.ToString();
            string chemical = elBible.Attributes["chemical"].InnerText.ToString();
            string descent = elBible.Attributes["descent"].InnerText.ToString();
            string act = elBible.Attributes["act"].InnerText.ToString();
            string appeal = elBible.Attributes["appeal"].InnerText.ToString();
            string shaft = elBible.Attributes["shaft"].InnerText.ToString();

            name = "bible";

            command = new MySqlCommand("CREATE TABLE " + name + " (" +
                "ID         int          NOT NULL, " +
                "name       varchar(255) NOT NULL, " +
                "waterfall  varchar(255) NOT NULL, " +
                "chemical   varchar(255) NOT NULL, " +
                "descent    varchar(255) NOT NULL, " +
                "act        varchar(255) NOT NULL, " +
                "appeal     varchar(255) NOT NULL, " +
                "shaft      varchar(255) NOT NULL, " +
                "PRIMARY KEY (ID))", connection);

            TestMyQuery(commandTEST, command, name);
            ExecMyQuery(command, "Utworzono " + name);

            command = new MySqlCommand("INSERT INTO " + name + " (" +
                "name, waterfall, chemical, descent, act, appeal, shaft) " +
                "VALUES (" +
                "@name, @waterfall,@chemical,@descent,@act,@appeal,@shaft)", connection);

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@waterfall", MySqlDbType.VarChar).Value = waterfall;
            command.Parameters.Add("@chemical", MySqlDbType.VarChar).Value = chemical;
            command.Parameters.Add("@descent", MySqlDbType.VarChar).Value = descent;
            command.Parameters.Add("@act", MySqlDbType.VarChar).Value = act;
            command.Parameters.Add("@appeal", MySqlDbType.VarChar).Value = appeal;
            command.Parameters.Add("@shaft", MySqlDbType.VarChar).Value = shaft;

            ExecMyQuery(command, "Dodano do "+ name +"!");

            Sell sell;
            Specified specified;
            XmlNodeList elSellList = elBible.ChildNodes;
            XmlNodeList elSpecifiedList;

            // stringi sell
            string bow, send, shop, file;

            name = "sell";

            command = new MySqlCommand("CREATE TABLE " + name + " (" +
                "ID             int NOT NULL, " +
                "name           varchar(255) NOT NULL, " +
                //"parent_ID      int NOT NULL, " +
                //"parent_name    varchar(255) NOT NULL, " +
                "bow            varchar(255) NOT NULL, " +
                "send           varchar(255) NOT NULL, " +
                "shop           varchar(255) NOT NULL, " +
                "file           varchar(255) NOT NULL, " +
                "PRIMARY KEY (ID))", connection);
            //"FOREIGN KEY (parent_ID, parent_name)" +
            //"   REFERENCES bible(ID, name))", connection);

            TestMyQuery(commandTEST, command, name);
            ExecMyQuery(command, "Utworzono " + name);

            // stringi specified
            string muscle, pipe, innerTextSpecified;

            name = "specified";

            command = new MySqlCommand("CREATE TABLE " + name + " (" +
                "ID                 int NOT NULL, " +
                "name               varchar(255) NOT NULL, " +
                //"parent_ID          int NOT NULL, " +
                //"parent_name        varchar(255) NOT NULL, " +
                "muscle             varchar(255) NOT NULL, " +
                "pipe               varchar(255) NOT NULL, " +
                "innerTextSpecified varchar(255) NOT NULL, " +
                "PRIMARY KEY (ID))", connection);
            //"FOREIGN KEY (parent_ID, parent_name)" +
            //"   REFERENCES sell(ID, name))", connection);

            TestMyQuery(commandTEST, command, name);
            ExecMyQuery(command, "Utworzono " + name);

            List<Sell> ListOfSell = new List<Sell>();

            itemCount = 0;
            itemDeepCount = 0;

            foreach (XmlNode item in elSellList)
            {
                bow = item.Attributes["bow"].InnerText.ToString();
                send = item.Attributes["send"].InnerText.ToString();
                shop = item.Attributes["shop"].InnerText.ToString();
                file = item.Attributes["file"].InnerText.ToString();

                name = "sell";
                command = new MySqlCommand("INSERT INTO " + name + " (" +
                "ID, name, bow, send, shop, file) " +
                "VALUES (" +
                "@ID, @name, @bow, @send, @shop, @file)", connection);

                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = itemCount;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@bow", MySqlDbType.VarChar).Value = bow;
                command.Parameters.Add("@send", MySqlDbType.VarChar).Value = send;
                command.Parameters.Add("@shop", MySqlDbType.VarChar).Value = shop;
                command.Parameters.Add("@file", MySqlDbType.VarChar).Value = file;
                ExecMyQuery(command, "Dodano do Twin!");

                List<Specified> ListOfSpecified = new List<Specified>();
                elSpecifiedList = item.ChildNodes;

                foreach (XmlNode deeperItem in elSpecifiedList)
                {
                    muscle = deeperItem.Attributes["muscle"].InnerText.ToString();
                    pipe = deeperItem.Attributes["pipe"].InnerText.ToString();
                    innerTextSpecified = deeperItem.InnerText.ToString();

                    name = "specified";
                    command = new MySqlCommand("INSERT INTO " + name + " (" +
                    "ID, name, muscle, pipe, innerTextSpecified) " +
                    "VALUES (" +
                    "@ID, @name, @muscle, @pipe, @innerTextSpecified)", connection);

                    command.Parameters.Add("@ID", MySqlDbType.Int32).Value = itemDeepCount;
                    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                    command.Parameters.Add("@muscle", MySqlDbType.VarChar).Value = muscle;
                    command.Parameters.Add("@pipe", MySqlDbType.VarChar).Value = pipe;
                    command.Parameters.Add("@innerTextSpecified", MySqlDbType.VarChar).Value = innerTextSpecified;
                    ExecMyQuery(command, "Dodano do Twin!");

                    specified = new Specified(muscle, pipe, innerTextSpecified);
                    ListOfSpecified.Add(specified);
                    itemDeepCount++;
                }

                sell = new Sell(ListOfSpecified, bow, send, shop, file);
                ListOfSell.Add(sell);
                itemCount++;
            }
            Bible bible = new Bible(ListOfSell, waterfall, chemical, descent, act, appeal, shaft);

            /** 
             * HISTORIAN
             * */

            name = "historian";

            command = new MySqlCommand("CREATE TABLE " + name + " (" +
                "ID         int          NOT NULL, " +
                "name       varchar(255) NOT NULL, " +
                "PRIMARY KEY (ID))", connection);

            TestMyQuery(commandTEST, command, name);
            ExecMyQuery(command, "Utworzono " + name);

            command = new MySqlCommand("INSERT INTO " + name + " (" +
                "name) " +
                "VALUES (" +
                "@name)", connection);

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;

            ExecMyQuery(command, "Dodano do " + name + "!");

            Crash crash;
            Different different;
            XmlNodeList elCrashList = elHistorian.ChildNodes;
            XmlNodeList elDifferentList;

            name = "crash";

            command = new MySqlCommand("CREATE TABLE " + name + " (" +
                "ID             int NOT NULL, " +
                "name           varchar(255) NOT NULL, " +
                //"parent_ID      int NOT NULL, " +
                //"parent_name    varchar(255) NOT NULL, " +
                "PRIMARY KEY (ID))", connection);
            //"FOREIGN KEY (parent_ID, parent_name)" +
            //"   REFERENCES historian(ID, name))", connection);

            TestMyQuery(commandTEST, command, name);
            ExecMyQuery(command, "Utworzono " + name);

            // stringi different
            string innerTextDifferent;

            name = "different";

            command = new MySqlCommand("CREATE TABLE " + name + " (" +
                "ID             int NOT NULL, " +
                "name           varchar(255) NOT NULL, " +
                //"parent_ID      int NOT NULL, " +
                //"parent_name    varchar(255) NOT NULL, " +
                "innerTextDifferent varchar(255) NOT NULL, " +
                "PRIMARY KEY (ID))", connection);
            //"FOREIGN KEY (parent_ID, parent_name)" +
            //"   REFERENCES crash(ID, name))", connection);

            TestMyQuery(commandTEST, command, name);
            ExecMyQuery(command, "Utworzono " + name);

            List<Crash> ListOfCrash = new List<Crash>();

            itemCount = 0;
            itemDeepCount = 0;

            foreach (XmlNode item in elCrashList)
            {
                name = "crash";
                command = new MySqlCommand("INSERT INTO " + name + " (" +
                "ID, name) " +
                "VALUES (" +
                "@ID, @name)", connection);

                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = itemCount;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                ExecMyQuery(command, "Dodano do Twin!");


                List<Different> ListOfDifferent = new List<Different>();
                elDifferentList = item.ChildNodes;

                foreach (XmlNode deeperItem in elDifferentList)
                {
                    innerTextDifferent = deeperItem.InnerText.ToString();

                    name = "different";
                    command = new MySqlCommand("INSERT INTO " + name + " (" +
                    "ID, name, innerTextDifferent) " +
                    "VALUES (" +
                    "@ID, @name, @innerTextDifferent)", connection);

                    command.Parameters.Add("@ID", MySqlDbType.Int32).Value = itemDeepCount;
                    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                    command.Parameters.Add("@innerTextDifferent", MySqlDbType.VarChar).Value = innerTextDifferent;
                    ExecMyQuery(command, "Dodano do Twin!");

                    different = new Different(innerTextDifferent);
                    ListOfDifferent.Add(different);
                    itemDeepCount++;
                }

                crash = new Crash(ListOfDifferent);
                ListOfCrash.Add(crash);
                itemCount++;
            }
            Historian historian = new Historian(ListOfCrash);

            Root root = new Root(troop, sight, density, bible, historian);

            return root;
        }



        private void TestMyQuery(MySqlCommand commandTEST, MySqlCommand command, string name)
        {
                connection.Open();
                    commandTEST.CommandText = "DROP TABLE IF EXISTS " + name;
                    commandTEST.ExecuteNonQuery();
                connection.Close();
        }

        private void ExecMyQuery(MySqlCommand command, string myMsg)
        {
            connection.Open();
                if (command.ExecuteNonQuery() == 1)
                {
                    //MessageBox.Show(myMsg);
                }
                else
                {
                    //MessageBox.Show("Query Not Executed");
                }
            connection.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CommandGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().TestMethod();
        }

        void TestMethod()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\Visual Studio Projects\VS Templates\XmlCodeGen\XmlCodeGen\Commands.xml");
            XmlNode schema = doc.SelectSingleNode("CommandSchema");
            Console.WriteLine(schema.Attributes["namespace"]);

            XmlNode composites = doc.SelectSingleNode("//Composites");
            XmlNode commands = doc.SelectSingleNode("//Commands");
            var cmds = new List<Command>();

            foreach (XmlNode node in composites.ChildNodes)
                cmds.Add(GetCommand(node, true));

            foreach (XmlNode node in commands.ChildNodes)
                cmds.Add(GetCommand(node, false));

            foreach (var cmd in cmds) // I know, string buffer...
            {
                if (cmd.isComposite)
                    Console.WriteLine("Composite command " + cmd.name);
                else
                    Console.WriteLine("Command " + cmd.name);
                Console.WriteLine("\tDisplay name " + cmd.displayName);

                foreach (var prop in cmd.properties)
                {
                    Console.WriteLine("\t" + prop.name);
                    Console.WriteLine("\t\tType " + prop.type);
                    Console.WriteLine("\t\tMapping " + prop.mapping ?? "Not mapped to db");
                }
            }

            Console.ReadKey();
        }

        Command GetCommand(XmlNode node, bool isComposite)
        {
            var cmd = new Command();
            cmd.isComposite = isComposite;
            cmd.name = node.Name;

            foreach (XmlAttribute attribute in node.Attributes)
            {
                if (attribute.Name.ToLowerInvariant().Equals("name"))
                {
                    cmd.displayName = attribute.Value;
                }
                else
                {
                    Console.WriteLine("\tUnsupported attribute " + attribute.Name);
                }
            }

            foreach (XmlNode property in node.ChildNodes)
            {
                var prop = new Property();
                prop.name = property.Name;

                foreach (XmlAttribute attribute in property.Attributes)
                {
                    if (attribute.Name.ToLowerInvariant().Equals("type"))
                    {
                        prop.type = attribute.Value;
                    }
                    else if (attribute.Name.ToLowerInvariant().Equals("map"))
                        prop.mapping = attribute.Value;
                    else
                    {
                        Console.WriteLine("\t\tUnsupported attribute " + attribute.Name);
                    }
                }

                cmd.properties.Add(prop);
            }

            return cmd;
        }
    }

    public class Command
    {
        public bool isComposite;
        public string name;
        public string displayName;
        public List<Property> properties = new List<Property>();
    }

    public class Property
    {
        public string type;
        public string name;
        public string mapping;
    }

}

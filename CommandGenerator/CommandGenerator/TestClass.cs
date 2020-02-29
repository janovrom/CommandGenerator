using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

public class CustomCommand
{
    public bool isComposite;
    public string name;
    public string displayName;
    public List<CustomProperty> properties = new List<CustomProperty>();
}

public class CustomProperty
{
    public string type;
    public string name;
    public string mapping;
}

public class TestClass { 
    CustomCommand GetCommand(XmlNode node, bool isComposite)
    {
        CustomCommand cmd = new CustomCommand();
        cmd.isComposite = isComposite;
        cmd.name = node.Name;

        foreach (XmlAttribute attribute in node.Attributes)
        {
            if (attribute.Name.ToLowerInvariant().Equals("name"))
            {
                cmd.displayName = attribute.Value;
            }
        }

        foreach (XmlNode property in node.ChildNodes)
        {
            var prop = new CustomProperty();
            prop.name = property.Name;

            foreach (XmlAttribute attribute in property.Attributes)
            {
                if (attribute.Name.ToLowerInvariant().Equals("type"))
                    prop.type = attribute.Value;
                else if (attribute.Name.ToLowerInvariant().Equals("map"))
                    prop.mapping = attribute.Value;
            }

            cmd.properties.Add(prop);
        }

        return cmd;
    }

    List<CustomCommand> Read(XmlDocument doc)
    {
        XmlNode schema = doc.SelectSingleNode("CommandSchema");

        XmlNode composites = doc.SelectSingleNode("//Composites");
        XmlNode commands = doc.SelectSingleNode("//Commands");
        List<CustomCommand> cmds = new List<CustomCommand>();

        foreach (XmlNode node in composites.ChildNodes)
            cmds.Add(GetCommand(node, true));

        foreach (XmlNode node in commands.ChildNodes)
            cmds.Add(GetCommand(node, false));

        return cmds;
    }

 }
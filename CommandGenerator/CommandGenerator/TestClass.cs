#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable IDE0051 // Private member is unused
#pragma warning disable IDE0017 // Object initialization can be simplified

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

public class CustomCommand
{
    public string name;
    public string cmdNamespace;
    public string parentName;
    public string parentNamespace;
    public string displayName;
    public bool isPersistable = false;
    public List<CustomProperty> properties = new List<CustomProperty>();
}

public class CustomProperty
{
    public string type;
    public string name;
    public string mapping;
    public bool canBeNull = true;
}

public class IdEntity
{
    public int Id;
    public Scene Entity;
}

public class SomeEntity1 : IdEntity { }
public class SomeEntity2 : IdEntity { }
public class SomeEntity3 : IdEntity { }
public class SomeEntity4 : IdEntity { }
public class SomeEntity5 : IdEntity { }

public abstract class SharedCmd
{

    public abstract string DisplayName { get; }
    public abstract bool IsPersistable { get; }
    public Scene Entity;
    public int Id { get; }

}

public abstract class MultiCmd : SharedCmd
{
}

public abstract class SingleCmd : SharedCmd
{
}

public class TestClass {
    CustomCommand GetCommand(XmlNode node, string parentName, string parentNamespace)
    {
        CustomCommand cmd = new CustomCommand();
        cmd.parentName = parentName;
        cmd.parentNamespace = parentNamespace;
        cmd.name = node.Name;

        bool namespaceFound = false;
        foreach (XmlAttribute attribute in node.Attributes)
        {
            if (attribute.Name.ToLowerInvariant().Equals("name"))
            {
                cmd.displayName = attribute.Value;
            }
            else if (attribute.Name.ToLowerInvariant().Equals("namespace"))
            {
                cmd.cmdNamespace = attribute.Value;
                namespaceFound = true;
            }
        }

        if (!namespaceFound)
            cmd.cmdNamespace = parentNamespace;

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
        List<CustomCommand> cmds = new List<CustomCommand>();
        foreach (XmlNode node in schema.ChildNodes)
        {
            string nodeNamespace = node.Attributes["namespace"].Value;
            string nodeName = node.Name;
            foreach (XmlNode cmd in node.ChildNodes)
                cmds.Add(GetCommand(cmd, nodeName, nodeNamespace));
        }

        return cmds;
    }

}

public class Scene
{
    public int Id;
}

namespace NHibernate.Mapping.ByCode.Conformist
{
    public static class NHibernateExtension
    {
        public static IList<T> List<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.ToList();
        }
    }

    public class Map
    {

        internal void Column(string v)
        {
        }

        internal void NotNullable(bool v)
        {
        }
    }

    public abstract class SubclassMapping<T>
    {
        public void DiscriminatorValue(string txt) { }

		protected void ManyToOne(Func<T, object> p1, Action<Map> p2)
		{
		}

        protected void Property(Func<T, object> p1, Action<Map> p2)
		{
		}
    }
}

#pragma warning restore IDE0060 // Remove unused parameter
#pragma warning restore IDE0051 // Private member is unused
#pragma warning restore IDE0017 // Object initialization can be simplified
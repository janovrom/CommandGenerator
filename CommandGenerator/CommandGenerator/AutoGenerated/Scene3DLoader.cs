using CommandGenerator.Services.Commands;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;

namespace CommandGenerator
{
	public partial class Scene3DLoader
	{


		private Dictionary<int, SomeEntity1> _someEntity1;
		private Dictionary<int, SomeEntity2> _someEntity2;
		private Dictionary<int, SomeEntity3> _someEntity3;
		private Dictionary<int, SomeEntity4> _someEntity4;
		private Dictionary<int, SomeEntity5> _someEntity5;

		partial void InitializeCommands()
		{
			// Initialize structures
			var cmdSetMultipleValuesCommand = _session.QueryOver<SetMultipleValuesCommand>().Where(x => x.Entity.Id == scene.Id).List();
			var cmdSetMultipleValuesCommand2 = _session.QueryOver<SetMultipleValuesCommand2>().Where(x => x.Entity.Id == scene.Id).List();
			var cmdSetMultipleValuesCommand3 = _session.QueryOver<SetMultipleValuesCommand3>().Where(x => x.Entity.Id == scene.Id).List();
			var cmdAddObjectCommand = _session.QueryOver<AddObjectCommand>().Where(x => x.Entity.Id == scene.Id).List();
			var cmdTestCommand = _session.QueryOver<TestCommand>().Where(x => x.Entity.Id == scene.Id).List();

			_someEntity1 = _session.QueryOver<SomeEntity1>().Where(x => x.Entity.Id == scene.Id).List().ToDictionary<SomeEntity1, int>(entity => entity.Id);
			_someEntity2 = _session.QueryOver<SomeEntity2>().Where(x => x.Entity.Id == scene.Id).List().ToDictionary<SomeEntity2, int>(entity => entity.Id);
			_someEntity3 = _session.QueryOver<SomeEntity3>().Where(x => x.Entity.Id == scene.Id).List().ToDictionary<SomeEntity3, int>(entity => entity.Id);
			_someEntity4 = _session.QueryOver<SomeEntity4>().Where(x => x.Entity.Id == scene.Id).List().ToDictionary<SomeEntity4, int>(entity => entity.Id);
			_someEntity5 = _session.QueryOver<SomeEntity5>().Where(x => x.Entity.Id == scene.Id).List().ToDictionary<SomeEntity5, int>(entity => entity.Id);

			// Unproxy commands and set the global dictionary
			foreach (SetMultipleValuesCommand cmd in cmdSetMultipleValuesCommand)
			{
				_commands[cmd.Id] = cmd;
				cmd.ChangedObject = _someEntity1[cmd.ChangedObject.Id];
			}

			foreach (SetMultipleValuesCommand2 cmd in cmdSetMultipleValuesCommand2)
			{
				_commands[cmd.Id] = cmd;
				cmd.ChangedObject = _someEntity2[cmd.ChangedObject.Id];
			}

			foreach (SetMultipleValuesCommand3 cmd in cmdSetMultipleValuesCommand3)
			{
				_commands[cmd.Id] = cmd;
				cmd.ChangedObject = _someEntity3[cmd.ChangedObject.Id];
			}

			foreach (AddObjectCommand cmd in cmdAddObjectCommand)
			{
				_commands[cmd.Id] = cmd;
				cmd.ChangedObject = _someEntity4[cmd.ChangedObject.Id];
				cmd.OldObject = _someEntity5[cmd.OldObject.Id];
			}

			foreach (TestCommand cmd in cmdTestCommand)
			{
				_commands[cmd.Id] = cmd;
			}

		}

	}
}

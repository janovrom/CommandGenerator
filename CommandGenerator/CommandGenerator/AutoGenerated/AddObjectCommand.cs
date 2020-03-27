using CommandGenerator.Services.Commands;
using CommandGenerator;

namespace CommandGenerator.Services.Commands
{

	public partial class AddObjectCommand : SingleCmd
	{
		public override string DisplayName => CommandGenerator.CommandResources.AddObjectCommandName;
		public override bool IsPersistable => false;
		public virtual SomeEntity4 ChangedObject { get; set; }// Mapping ManyToOne
		public virtual SomeEntity5 OldObject { get; set; }// Mapping ManyToOne
		public virtual object RandomValue { get; set; }// Mapping Not mapped to db


		protected AddObjectCommand() {}
		public AddObjectCommand(string test) {}
	}

}
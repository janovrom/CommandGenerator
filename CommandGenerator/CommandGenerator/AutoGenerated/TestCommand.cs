using CommandGenerator.Services.Commands;
using CommandGenerator;

namespace CommandGenerator.Services.Commands
{

	public partial class TestCommand : SingleCmd
	{
		public override string DisplayName => CommandGenerator.CommandResources.TestCommandName;
		public override bool IsPersistable => false;


		protected TestCommand() {}
		public TestCommand(string test) {}
	}

}
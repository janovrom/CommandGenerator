using CommandGenerator.Services.Commands;
using CommandGenerator;

namespace CommandGenerator.Services.Commands
{

	public partial class SetMultipleValuesCommand : MultiCmd
	{
		public override string DisplayName => CommandResources.SetMultipleValuesCommandName;
		public override bool IsPersistable => false;
		public virtual string ChangedObject { get; set; }// Mapping ManyToOne
		public virtual double OldValue { get; set; }// Mapping Property
		public virtual double NewValue { get; set; }// Mapping Property


		protected SetMultipleValuesCommand() {}
		public SetMultipleValuesCommand(string test) {}
	}

}
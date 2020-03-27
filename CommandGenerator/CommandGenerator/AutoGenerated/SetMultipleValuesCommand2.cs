using CommandGenerator.Services.Commands;
using CommandGenerator;

namespace CommandGenerator.Services.Commands
{

	public partial class SetMultipleValuesCommand2 : MultiCmd
	{
		public override string DisplayName => CommandGenerator.CommandResources.SetMultipleValuesCommand2Name;
		public override bool IsPersistable => false;
		public virtual SomeEntity2 ChangedObject { get; set; }// Mapping ManyToOne
		public virtual double OldValue { get; set; }// Mapping Property
		public virtual double NewValue { get; set; }// Mapping Property


		protected SetMultipleValuesCommand2() {}
		public SetMultipleValuesCommand2(string test) {}
	}

}
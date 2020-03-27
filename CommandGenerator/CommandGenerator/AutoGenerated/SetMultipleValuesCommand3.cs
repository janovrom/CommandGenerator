using CommandGenerator.Services.Commands;
using CommandGenerator;

namespace CommandGenerator.Services.Commands
{

	public partial class SetMultipleValuesCommand3 : MultiCmd
	{
		public override string DisplayName => CommandGenerator.CommandResources.SetMultipleValuesCommand3Name;
		public override bool IsPersistable => false;
		public virtual SomeEntity3 ChangedObject { get; set; }// Mapping ManyToOne
		public virtual double OldValue { get; set; }// Mapping Property
		public virtual double NewValue { get; set; }// Mapping Property


		protected SetMultipleValuesCommand3() {}
		public SetMultipleValuesCommand3(string test) {}
	}

}
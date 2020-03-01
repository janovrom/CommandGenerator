namespace CommandGenerator
{

	public partial class AddObjectCommand
	{
		public string DisplayName => CommandResources.AddObjectCommandName;
		public virtual string ChangedObject { get; set; }// Mapping manytoone
		public virtual object RandomValue { get; set; }// Mapping 


		protected AddObjectCommand() {}
		public AddObjectCommand(string test) {}
	}

}
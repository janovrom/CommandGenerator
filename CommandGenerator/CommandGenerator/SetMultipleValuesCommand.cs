public class SetMultipleValuesCommand
{
	public string DisplayName => "Set values";
	public virtual string ChangedObject { get; set; }// Mapping ManyToOne
	public virtual double OldValue { get; set; }// Mapping Property
	public virtual double NewValue { get; set; }// Mapping property


	protected SetMultipleValuesCommand() {}
	public SetMultipleValuesCommand(string test) {}
}
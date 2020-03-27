using NHibernate.Mapping.ByCode.Conformist;


namespace CommandGenerator.Services.Commands.Mappings
{

	public partial class TestCommandMapping : SubclassMapping<TestCommand>
	{

		public TestCommandMapping()
		{
			DiscriminatorValue("TestCommand");


			InitializeOther();
		}

		partial void InitializeOther();

	}
}

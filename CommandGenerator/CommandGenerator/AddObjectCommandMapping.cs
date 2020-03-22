using NHibernate.Mapping.ByCode.Conformist;


namespace CommandGenerator.Services.Commands.Mappings
{

	public partial class AddObjectCommandMapping : SubclassMapping<AddObjectCommand>
	{

		public AddObjectCommandMapping()
		{
			DiscriminatorValue("AddObjectCommand");

			ManyToOne(x => x.ChangedObject, map =>
			{
				map.NotNullable(true);
				map.Column("ChangedObject");
			});


			InitializeOther();
		}

		partial void InitializeOther();

	}
}

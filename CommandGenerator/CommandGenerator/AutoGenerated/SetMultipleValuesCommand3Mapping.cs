using NHibernate.Mapping.ByCode.Conformist;


namespace CommandGenerator.Services.Commands.Mappings
{

	public partial class SetMultipleValuesCommand3Mapping : SubclassMapping<SetMultipleValuesCommand3>
	{

		public SetMultipleValuesCommand3Mapping()
		{
			DiscriminatorValue("SetMultipleValuesCommand3");

			ManyToOne(x => x.ChangedObject, map =>
			{
				map.NotNullable(true);
				map.Column("ChangedObject");
			});

			Property(x => x.OldValue, map =>
			{
				map.Column("OldValue");
			});

			Property(x => x.NewValue, map =>
			{
				map.Column("NewValue");
			});


			InitializeOther();
		}

		partial void InitializeOther();

	}
}

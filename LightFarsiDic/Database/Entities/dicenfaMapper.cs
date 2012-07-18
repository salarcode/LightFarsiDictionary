using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using NHibernate.Mapping.ByCode;
using LightFarsiDic.Database.Base;

namespace LightFarsiDic.Database.Entities
{
	static partial class dicenfaMapper
	{
		internal static void MapToModel(ModelMapper mapper)
		{

			// Default mappings for EnglishToFarsi
			mapper.Class<EnglishToFarsi>(
				mp =>
				{
					mp.Table("EnglishToFarsi");

					mp.Property(
						x => x.English,
						map =>
						{
							map.Column("English");
							map.NotNullable(false);
						});
					mp.Property(
						x => x.Farsi,
						map =>
						{
							map.Column("Farsi");
							map.NotNullable(false);
						});



				});

			// Default mappings for FarsiToEnglish
			mapper.Class<FarsiToEnglish>(
				mp =>
				{
					mp.Table("FarsiToEnglish");

					mp.Property(
						x => x.Farsi,
						map =>
						{
							map.Column("Farsi");
							map.NotNullable(false);
						});
					mp.Property(
						x => x.English,
						map =>
						{
							map.Column("English");
							map.NotNullable(false);
						});



				});

		}
	}
}

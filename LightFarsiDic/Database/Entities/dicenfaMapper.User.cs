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
	/// <summary>
	/// This partial class won't be toched by the generator.
	/// </summary>
	internal static partial class dicenfaMapper
	{
		internal static void CustomMapToModel(ModelMapper mapper)
		{
			// put your custom mappings here
			mapper.Class<EnglishToFarsi>(
				mp => mp.Id(x=>x.English, x => x.Generator(Generators.Assigned)));
			mapper.Class<FarsiToEnglish>(
				mp => mp.Id(x => x.Farsi, x => x.Generator(Generators.Assigned)));
		}
	}
}
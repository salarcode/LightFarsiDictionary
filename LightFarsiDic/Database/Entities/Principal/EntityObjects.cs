using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using LightFarsiDic.Database.Base;

namespace LightFarsiDic.Database.Entities
{

	[DataContract]
	public partial class EnglishToFarsi : dicenfaBaseEntity
	{

		/// <summary>
		/// 
		/// </summary>
		[DisplayName("")]
		[DataMember]
		public virtual String English { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DisplayName("")]
		[DataMember]
		public virtual String Farsi { get; set; }


	}

	[DataContract]
	public partial class FarsiToEnglish : dicenfaBaseEntity
	{

		/// <summary>
		/// 
		/// </summary>
		[DisplayName("")]
		[DataMember]
		public virtual String Farsi { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DisplayName("")]
		[DataMember]
		public virtual String English { get; set; }


	}

}

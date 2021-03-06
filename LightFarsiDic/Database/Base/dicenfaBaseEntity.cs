using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace LightFarsiDic.Database.Base
{
	[Serializable]
	public partial class dicenfaBaseEntity : IDisposable
	{
		#region variables
		[XmlIgnore]
		[SoapIgnore]
		[IgnoreDataMember]
		[NonSerialized]
		private Hashtable _Items;
		#endregion

		#region properties
		[XmlIgnore]
		[SoapIgnore]
		[IgnoreDataMember]
		public virtual object this[string name]
		{
			get
			{
				if (_Items == null)
					return null;

				return _Items[name];
			}
			set
			{
				if (_Items == null)
					_Items = new Hashtable();
				_Items[name] = value;
			}
		}
		#endregion

		#region public methods
		/// <summary>
		/// Creates an unproxied clone of the entity, according to DataMember flag.
		/// </summary>
		public virtual dicenfaBaseEntity CloneUnproxied()
		{
			Type entityType = this.GetType();
			
			// new close instance
			var cloneEntity = (dicenfaBaseEntity)Activator.CreateInstance(entityType);
			CopyToClonedUnproxied(cloneEntity);

			return cloneEntity;
		}

		/// <summary>
		/// Creates an unproxied copy of the entity to the specified destination model, according to DataMember flag.
		/// </summary>
		private void CopyToClonedUnproxied(object destinationModel)
		{
			Type entityType = this.GetType();

			PropertyInfo[] entityProps;
			try
			{
				entityProps = entityType.GetProperties(BindingFlags.SetProperty | BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public);
			}
			catch
			{
				return;
			}

			var dataMemType = typeof(DataMemberAttribute);

			// copy the properties that marked as DataMember
			foreach (PropertyInfo srcProp in entityProps)
			{
				try
				{
					// don't copy not data members
					if (!srcProp.IsDefined(dataMemType, true))
						continue;

					// apply to the destination
					srcProp.SetValue(destinationModel, srcProp.GetValue(this, null), null);
				}
				catch { }
			}
		}

		/// <summary>
		/// Creates an unproxied copy of the entity to the specified destination model, according to DataMember flag.
		/// </summary>
		public virtual void CopyUnproxied(object destinationModel)
		{
			Type entityType = this.GetType();
			Type destType = destinationModel.GetType();

			PropertyInfo[] entityProps;
			PropertyInfo[] destProps;
			try
			{
				entityProps = entityType.GetProperties(BindingFlags.SetProperty | BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public);
				destProps = destType.GetProperties();
			}
			catch
			{
				return;
			}

			var dataMemType = typeof(DataMemberAttribute);

			// copy the properties that marked as DataMember
			foreach (PropertyInfo srcProp in entityProps)
			{
				try
				{
					// don't copy not data members
					if (!srcProp.IsDefined(dataMemType, true))
						continue;
					var destProp = destProps.FirstOrDefault(x => x.Name == srcProp.Name);
					if (destProp == null) continue;

					// apply to the destination
					destProp.SetValue(destinationModel, srcProp.GetValue(this, null), null);
				}
				catch { }
			}
		}
		
		public void Dispose()
		{
		}
		#endregion
	}
}

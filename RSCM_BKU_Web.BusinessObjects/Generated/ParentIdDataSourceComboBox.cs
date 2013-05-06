<<<<<<< HEAD
/*
===============================================================================
                    EntitySpaces 2009 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2009.2.1214.0
EntitySpaces Driver  : SQL
Date Generated       : 10/03/2011 10:06:03
===============================================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Xml.Serialization;


using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace RSCM_BKU_Web.BusinessObjects
{

	[Serializable]
	abstract public class esParentIdDataSourceComboBoxCollection : esEntityCollection
	{
		public esParentIdDataSourceComboBoxCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "ParentIdDataSourceComboBoxCollection";
		}

		#region Query Logic
		protected void InitQuery(esParentIdDataSourceComboBoxQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			query.es2.Connection = ((IEntityCollection)this).Connection;
		}

		protected bool OnQueryLoaded(DataTable table)
		{
			this.PopulateCollection(table);
			return (this.RowCount > 0) ? true : false;
		}
		
		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery(query as esParentIdDataSourceComboBoxQuery);
		}
		#endregion
		
		virtual public ParentIdDataSourceComboBox DetachEntity(ParentIdDataSourceComboBox entity)
		{
			return base.DetachEntity(entity) as ParentIdDataSourceComboBox;
		}
		
		virtual public ParentIdDataSourceComboBox AttachEntity(ParentIdDataSourceComboBox entity)
		{
			return base.AttachEntity(entity) as ParentIdDataSourceComboBox;
		}
		
		virtual public void Combine(ParentIdDataSourceComboBoxCollection collection)
		{
			base.Combine(collection);
		}
		
		new public ParentIdDataSourceComboBox this[int index]
		{
			get
			{
				return base[index] as ParentIdDataSourceComboBox;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(ParentIdDataSourceComboBox);
		}
	}



	[Serializable]
	abstract public class esParentIdDataSourceComboBox : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esParentIdDataSourceComboBoxQuery GetDynamicQuery()
		{
			return null;
		}

		public esParentIdDataSourceComboBox()
		{

		}

		public esParentIdDataSourceComboBox(DataRow row)
			: base(row)
		{

		}
		
		#region LoadByPrimaryKey
		
		#endregion
		
		
		
		#region Properties
		
		
		public override void SetProperties(IDictionary values)
		{
			foreach (string propertyName in values.Keys)
			{
				this.SetProperty(propertyName, values[propertyName]);
			}
		}

		public override void SetProperty(string name, object value)
		{
			if(this.Row == null) this.AddNew();
			
			esColumnMetadata col = this.Meta.Columns.FindByPropertyName(name);
			if (col != null)
			{
				if(value == null || value is System.String)
				{				
					// Use the strongly typed property
					switch (name)
					{							
						case "KaCode": this.str.KaCode = (string)value; break;							
						case "KaName": this.str.KaName = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{

						default:
							break;
					}
				}
			}
			else if(this.Row.Table.Columns.Contains(name))
			{
				this.Row[name] = value;
			}
			else
			{
				throw new Exception("SetProperty Error: '" + name + "' not found");
			}
		}
		
		
		/// <summary>
		/// Maps to ParentId_DataSource_ComboBox.KA_CODE
		/// </summary>
		virtual public System.String KaCode
		{
			get
			{
				return base.GetSystemString(ParentIdDataSourceComboBoxMetadata.ColumnNames.KaCode);
			}
			
			set
			{
				base.SetSystemString(ParentIdDataSourceComboBoxMetadata.ColumnNames.KaCode, value);
			}
		}
		
		/// <summary>
		/// Maps to ParentId_DataSource_ComboBox.KA_NAME
		/// </summary>
		virtual public System.String KaName
		{
			get
			{
				return base.GetSystemString(ParentIdDataSourceComboBoxMetadata.ColumnNames.KaName);
			}
			
			set
			{
				base.SetSystemString(ParentIdDataSourceComboBoxMetadata.ColumnNames.KaName, value);
			}
		}
		
		#endregion	

		#region String Properties


		[BrowsableAttribute( false )]
		public esStrings str
		{
			get
			{
				if (esstrings == null)
				{
					esstrings = new esStrings(this);
				}
				return esstrings;
			}
		}


		[Serializable]
		sealed public class esStrings
		{
			public esStrings(esParentIdDataSourceComboBox entity)
			{
				this.entity = entity;
			}
			
	
			public System.String KaCode
			{
				get
				{
					System.String data = entity.KaCode;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.KaCode = null;
					else entity.KaCode = Convert.ToString(value);
				}
			}
				
			public System.String KaName
			{
				get
				{
					System.String data = entity.KaName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.KaName = null;
					else entity.KaName = Convert.ToString(value);
				}
			}
			

			private esParentIdDataSourceComboBox entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esParentIdDataSourceComboBoxQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			query.es2.Connection = ((IEntity)this).Connection;
		}

		[System.Diagnostics.DebuggerNonUserCode]
		protected bool OnQueryLoaded(DataTable table)
		{
			bool dataFound = this.PopulateEntity(table);

			if (this.RowCount > 1)
			{
				throw new Exception("esParentIdDataSourceComboBox can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}



	[Serializable]
	abstract public class esParentIdDataSourceComboBoxQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return ParentIdDataSourceComboBoxMetadata.Meta();
			}
		}	
		

		public esQueryItem KaCode
		{
			get
			{
				return new esQueryItem(this, ParentIdDataSourceComboBoxMetadata.ColumnNames.KaCode, esSystemType.String);
			}
		} 
		
		public esQueryItem KaName
		{
			get
			{
				return new esQueryItem(this, ParentIdDataSourceComboBoxMetadata.ColumnNames.KaName, esSystemType.String);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("ParentIdDataSourceComboBoxCollection")]
	public partial class ParentIdDataSourceComboBoxCollection : esParentIdDataSourceComboBoxCollection, IEnumerable<ParentIdDataSourceComboBox>
	{
		public ParentIdDataSourceComboBoxCollection()
		{

		}
		
		public static implicit operator List<ParentIdDataSourceComboBox>(ParentIdDataSourceComboBoxCollection coll)
		{
			List<ParentIdDataSourceComboBox> list = new List<ParentIdDataSourceComboBox>();
			
			foreach (ParentIdDataSourceComboBox emp in coll)
			{
				list.Add(emp);
			}
			
			return list;
		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return  ParentIdDataSourceComboBoxMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new ParentIdDataSourceComboBoxQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new ParentIdDataSourceComboBox(row);
		}

		override protected esEntity CreateEntity()
		{
			return new ParentIdDataSourceComboBox();
		}
		
		
		override public bool LoadAll()
		{
			return base.LoadAll(esSqlAccessType.DynamicSQL);
		}	
		
		#endregion


		[BrowsableAttribute( false )]
		public ParentIdDataSourceComboBoxQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ParentIdDataSourceComboBoxQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(ParentIdDataSourceComboBoxQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public ParentIdDataSourceComboBox AddNew()
		{
			ParentIdDataSourceComboBox entity = base.AddNewEntity() as ParentIdDataSourceComboBox;
			
			return entity;
		}


		#region IEnumerable<ParentIdDataSourceComboBox> Members

		IEnumerator<ParentIdDataSourceComboBox> IEnumerable<ParentIdDataSourceComboBox>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as ParentIdDataSourceComboBox;
			}
		}

		#endregion
		
		private ParentIdDataSourceComboBoxQuery query;
	}


	/// <summary>
	/// Encapsulates the 'ParentId_DataSource_ComboBox' view
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("ParentIdDataSourceComboBox ()")]
	[Serializable]
	public partial class ParentIdDataSourceComboBox : esParentIdDataSourceComboBox
	{
		public ParentIdDataSourceComboBox()
		{

		}
	
		public ParentIdDataSourceComboBox(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return ParentIdDataSourceComboBoxMetadata.Meta();
			}
		}
		
		
		
		override protected esParentIdDataSourceComboBoxQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new ParentIdDataSourceComboBoxQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public ParentIdDataSourceComboBoxQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ParentIdDataSourceComboBoxQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(ParentIdDataSourceComboBoxQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private ParentIdDataSourceComboBoxQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class ParentIdDataSourceComboBoxQuery : esParentIdDataSourceComboBoxQuery
	{
		public ParentIdDataSourceComboBoxQuery()
		{

		}		
		
		public ParentIdDataSourceComboBoxQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "ParentIdDataSourceComboBoxQuery";
        }
		
			
	}


	[Serializable]
	public partial class ParentIdDataSourceComboBoxMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected ParentIdDataSourceComboBoxMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ParentIdDataSourceComboBoxMetadata.ColumnNames.KaCode, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = ParentIdDataSourceComboBoxMetadata.PropertyNames.KaCode;
			c.CharacterMaxLength = 15;
			_columns.Add(c);
				
			c = new esColumnMetadata(ParentIdDataSourceComboBoxMetadata.ColumnNames.KaName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = ParentIdDataSourceComboBoxMetadata.PropertyNames.KaName;
			c.CharacterMaxLength = 256;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public ParentIdDataSourceComboBoxMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID
		{
			get { return base._dataID; }
		}	
		
		public bool MultiProviderMode
		{
			get { return false; }
		}		

		public esColumnMetadataCollection Columns
		{
			get	{ return base._columns; }
		}
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string KaCode = "KA_CODE";
			 public const string KaName = "KA_NAME";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string KaCode = "KaCode";
			 public const string KaName = "KaName";
		}
		#endregion	

		public esProviderSpecificMetadata GetProviderMetadata(string mapName)
		{
			MapToMeta mapMethod = mapDelegates[mapName];

			if (mapMethod != null)
				return mapMethod(mapName);
			else
				return null;
		}
		
		#region MAP esDefault
		
		static private int RegisterDelegateesDefault()
		{
			// This is only executed once per the life of the application
			lock (typeof(ParentIdDataSourceComboBoxMetadata))
			{
				if(ParentIdDataSourceComboBoxMetadata.mapDelegates == null)
				{
					ParentIdDataSourceComboBoxMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ParentIdDataSourceComboBoxMetadata.meta == null)
				{
					ParentIdDataSourceComboBoxMetadata.meta = new ParentIdDataSourceComboBoxMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esDefault);
				mapDelegates.Add("esDefault", mapMethod);
				mapMethod("esDefault");
			}
			return 0;
		}			

		private esProviderSpecificMetadata esDefault(string mapName)
		{
			if(!_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();
				

				meta.AddTypeMap("KaCode", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("KaName", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "ParentId_DataSource_ComboBox";
				meta.Destination = "ParentId_DataSource_ComboBox";
				
				meta.spInsert = "proc_ParentId_DataSource_ComboBoxInsert";				
				meta.spUpdate = "proc_ParentId_DataSource_ComboBoxUpdate";		
				meta.spDelete = "proc_ParentId_DataSource_ComboBoxDelete";
				meta.spLoadAll = "proc_ParentId_DataSource_ComboBoxLoadAll";
				meta.spLoadByPrimaryKey = "proc_ParentId_DataSource_ComboBoxLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private ParentIdDataSourceComboBoxMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
=======

/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 11/22/2012 3:28:01 PM
===============================================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Data;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace RSCM_BKU_Web.BusinessObjects
{
	/// <summary>
	/// Encapsulates the 'ParentId_DataSource_ComboBox' view
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(ParentIdDataSourceComboBox))]	
	[XmlType("ParentIdDataSourceComboBox")]
	public partial class ParentIdDataSourceComboBox : esParentIdDataSourceComboBox
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new ParentIdDataSourceComboBox();
		}
		
		#region Static Quick Access Methods
		
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("ParentIdDataSourceComboBoxCollection")]
	public partial class ParentIdDataSourceComboBoxCollection : esParentIdDataSourceComboBoxCollection, IEnumerable<ParentIdDataSourceComboBox>
	{

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(ParentIdDataSourceComboBox))]
		public class ParentIdDataSourceComboBoxCollectionWCFPacket : esCollectionWCFPacket<ParentIdDataSourceComboBoxCollection>
		{
			public static implicit operator ParentIdDataSourceComboBoxCollection(ParentIdDataSourceComboBoxCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator ParentIdDataSourceComboBoxCollectionWCFPacket(ParentIdDataSourceComboBoxCollection collection)
			{
				return new ParentIdDataSourceComboBoxCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class ParentIdDataSourceComboBoxQuery : esParentIdDataSourceComboBoxQuery
	{
		public ParentIdDataSourceComboBoxQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "ParentIdDataSourceComboBoxQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(ParentIdDataSourceComboBoxQuery query)
		{
			return ParentIdDataSourceComboBoxQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator ParentIdDataSourceComboBoxQuery(string query)
		{
			return (ParentIdDataSourceComboBoxQuery)ParentIdDataSourceComboBoxQuery.SerializeHelper.FromXml(query, typeof(ParentIdDataSourceComboBoxQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esParentIdDataSourceComboBox : esEntity
	{
		public esParentIdDataSourceComboBox()
		{

		}
		
		#region LoadByPrimaryKey
		
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to ParentId_DataSource_ComboBox.KA_CODE
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String KaCode
		{
			get
			{
				return base.GetSystemString(ParentIdDataSourceComboBoxMetadata.ColumnNames.KaCode);
			}
			
			set
			{
				if(base.SetSystemString(ParentIdDataSourceComboBoxMetadata.ColumnNames.KaCode, value))
				{
					OnPropertyChanged(ParentIdDataSourceComboBoxMetadata.PropertyNames.KaCode);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ParentId_DataSource_ComboBox.KA_NAME
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String KaName
		{
			get
			{
				return base.GetSystemString(ParentIdDataSourceComboBoxMetadata.ColumnNames.KaName);
			}
			
			set
			{
				if(base.SetSystemString(ParentIdDataSourceComboBoxMetadata.ColumnNames.KaName, value))
				{
					OnPropertyChanged(ParentIdDataSourceComboBoxMetadata.PropertyNames.KaName);
				}
			}
		}		
		
		#endregion	

		#region .str() Properties
		
		public override void SetProperties(IDictionary values)
		{
			foreach (string propertyName in values.Keys)
			{
				this.SetProperty(propertyName, values[propertyName]);
			}
		}
		
		public override void SetProperty(string name, object value)
		{
			esColumnMetadata col = this.Meta.Columns.FindByPropertyName(name);
			if (col != null)
			{
				if(value == null || value is System.String)
				{				
					// Use the strongly typed property
					switch (name)
					{							
						case "KaCode": this.str().KaCode = (string)value; break;							
						case "KaName": this.str().KaName = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{

						default:
							break;
					}
				}
			}
            else if (this.ContainsColumn(name))
            {
                this.SetColumn(name, value);
            }
			else
			{
				throw new Exception("SetProperty Error: '" + name + "' not found");
			}
		}		

		public esStrings str()
		{
			if (esstrings == null)
			{
				esstrings = new esStrings(this);
			}
			return esstrings;
		}

		sealed public class esStrings
		{
			public esStrings(esParentIdDataSourceComboBox entity)
			{
				this.entity = entity;
			}
			
	
			public System.String KaCode
			{
				get
				{
					System.String data = entity.KaCode;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.KaCode = null;
					else entity.KaCode = Convert.ToString(value);
				}
			}
				
			public System.String KaName
			{
				get
				{
					System.String data = entity.KaName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.KaName = null;
					else entity.KaName = Convert.ToString(value);
				}
			}
			

			private esParentIdDataSourceComboBox entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return ParentIdDataSourceComboBoxMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public ParentIdDataSourceComboBoxQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ParentIdDataSourceComboBoxQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ParentIdDataSourceComboBoxQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(ParentIdDataSourceComboBoxQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private ParentIdDataSourceComboBoxQuery query;		
	}



	[Serializable]
	abstract public partial class esParentIdDataSourceComboBoxCollection : esEntityCollection<ParentIdDataSourceComboBox>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return ParentIdDataSourceComboBoxMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "ParentIdDataSourceComboBoxCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public ParentIdDataSourceComboBoxQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ParentIdDataSourceComboBoxQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ParentIdDataSourceComboBoxQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new ParentIdDataSourceComboBoxQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(ParentIdDataSourceComboBoxQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((ParentIdDataSourceComboBoxQuery)query);
		}

		#endregion
		
		private ParentIdDataSourceComboBoxQuery query;
	}



	[Serializable]
	abstract public partial class esParentIdDataSourceComboBoxQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return ParentIdDataSourceComboBoxMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "KaCode": return this.KaCode;
				case "KaName": return this.KaName;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem KaCode
		{
			get { return new esQueryItem(this, ParentIdDataSourceComboBoxMetadata.ColumnNames.KaCode, esSystemType.String); }
		} 
		
		public esQueryItem KaName
		{
			get { return new esQueryItem(this, ParentIdDataSourceComboBoxMetadata.ColumnNames.KaName, esSystemType.String); }
		} 
		
		#endregion
		
	}



	[Serializable]
	public partial class ParentIdDataSourceComboBoxMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected ParentIdDataSourceComboBoxMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ParentIdDataSourceComboBoxMetadata.ColumnNames.KaCode, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = ParentIdDataSourceComboBoxMetadata.PropertyNames.KaCode;
			c.CharacterMaxLength = 15;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ParentIdDataSourceComboBoxMetadata.ColumnNames.KaName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = ParentIdDataSourceComboBoxMetadata.PropertyNames.KaName;
			c.CharacterMaxLength = 256;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public ParentIdDataSourceComboBoxMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID
		{
			get { return base.m_dataID; }
		}	
		
		public bool MultiProviderMode
		{
			get { return false; }
		}		

		public esColumnMetadataCollection Columns
		{
			get	{ return base.m_columns; }
		}
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string KaCode = "KA_CODE";
			 public const string KaName = "KA_NAME";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string KaCode = "KaCode";
			 public const string KaName = "KaName";
		}
		#endregion	

		public esProviderSpecificMetadata GetProviderMetadata(string mapName)
		{
			MapToMeta mapMethod = mapDelegates[mapName];

			if (mapMethod != null)
				return mapMethod(mapName);
			else
				return null;
		}
		
		#region MAP esDefault
		
		static private int RegisterDelegateesDefault()
		{
			// This is only executed once per the life of the application
			lock (typeof(ParentIdDataSourceComboBoxMetadata))
			{
				if(ParentIdDataSourceComboBoxMetadata.mapDelegates == null)
				{
					ParentIdDataSourceComboBoxMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ParentIdDataSourceComboBoxMetadata.meta == null)
				{
					ParentIdDataSourceComboBoxMetadata.meta = new ParentIdDataSourceComboBoxMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esDefault);
				mapDelegates.Add("esDefault", mapMethod);
				mapMethod("esDefault");
			}
			return 0;
		}			

		private esProviderSpecificMetadata esDefault(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();			


				meta.AddTypeMap("KaCode", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("KaName", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "ParentId_DataSource_ComboBox";
				meta.Destination = "ParentId_DataSource_ComboBox";
				
				meta.spInsert = "proc_ParentId_DataSource_ComboBoxInsert";				
				meta.spUpdate = "proc_ParentId_DataSource_ComboBoxUpdate";		
				meta.spDelete = "proc_ParentId_DataSource_ComboBoxDelete";
				meta.spLoadAll = "proc_ParentId_DataSource_ComboBoxLoadAll";
				meta.spLoadByPrimaryKey = "proc_ParentId_DataSource_ComboBoxLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private ParentIdDataSourceComboBoxMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
>>>>>>> republish

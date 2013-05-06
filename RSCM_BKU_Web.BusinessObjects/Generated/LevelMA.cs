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
Date Generated       : 10/03/2011 10:05:36
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
	abstract public class esLevelMACollection : esEntityCollection
	{
		public esLevelMACollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "LevelMACollection";
		}

		#region Query Logic
		protected void InitQuery(esLevelMAQuery query)
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
			this.InitQuery(query as esLevelMAQuery);
		}
		#endregion
		
		virtual public LevelMA DetachEntity(LevelMA entity)
		{
			return base.DetachEntity(entity) as LevelMA;
		}
		
		virtual public LevelMA AttachEntity(LevelMA entity)
		{
			return base.AttachEntity(entity) as LevelMA;
		}
		
		virtual public void Combine(LevelMACollection collection)
		{
			base.Combine(collection);
		}
		
		new public LevelMA this[int index]
		{
			get
			{
				return base[index] as LevelMA;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(LevelMA);
		}
	}



	[Serializable]
	abstract public class esLevelMA : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esLevelMAQuery GetDynamicQuery()
		{
			return null;
		}

		public esLevelMA()
		{

		}

		public esLevelMA(DataRow row)
			: base(row)
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 id)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 id)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 id)
		{
			esLevelMAQuery query = this.GetDynamicQuery();
			query.Where(query.Id == id);
			return query.Load();
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 id)
		{
			esParameters parms = new esParameters();
			parms.Add("id",id);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
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
						case "Id": this.str.Id = (string)value; break;							
						case "Level": this.str.Level = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Int32)
								this.Id = (System.Int32?)value;
							break;
					

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
		/// Maps to levelMA.id
		/// </summary>
		virtual public System.Int32? Id
		{
			get
			{
				return base.GetSystemInt32(LevelMAMetadata.ColumnNames.Id);
			}
			
			set
			{
				base.SetSystemInt32(LevelMAMetadata.ColumnNames.Id, value);
			}
		}
		
		/// <summary>
		/// Maps to levelMA.level
		/// </summary>
		virtual public System.String Level
		{
			get
			{
				return base.GetSystemString(LevelMAMetadata.ColumnNames.Level);
			}
			
			set
			{
				base.SetSystemString(LevelMAMetadata.ColumnNames.Level, value);
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
			public esStrings(esLevelMA entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Id
			{
				get
				{
					System.Int32? data = entity.Id;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Id = null;
					else entity.Id = Convert.ToInt32(value);
				}
			}
				
			public System.String Level
			{
				get
				{
					System.String data = entity.Level;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Level = null;
					else entity.Level = Convert.ToString(value);
				}
			}
			

			private esLevelMA entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esLevelMAQuery query)
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
				throw new Exception("esLevelMA can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class LevelMA : esLevelMA
	{

		
		/// <summary>
		/// Used internally by the entity's hierarchical properties.
		/// </summary>
		protected override List<esPropertyDescriptor> GetHierarchicalProperties()
		{
			List<esPropertyDescriptor> props = new List<esPropertyDescriptor>();
			
		
			return props;
		}	
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostSave.
		/// </summary>
		protected override void ApplyPostSaveKeys()
		{
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostOneToOneSave.
		/// </summary>
		protected override void ApplyPostOneSaveKeys()
		{
		}
		
	}



	[Serializable]
	abstract public class esLevelMAQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return LevelMAMetadata.Meta();
			}
		}	
		

		public esQueryItem Id
		{
			get
			{
				return new esQueryItem(this, LevelMAMetadata.ColumnNames.Id, esSystemType.Int32);
			}
		} 
		
		public esQueryItem Level
		{
			get
			{
				return new esQueryItem(this, LevelMAMetadata.ColumnNames.Level, esSystemType.String);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("LevelMACollection")]
	public partial class LevelMACollection : esLevelMACollection, IEnumerable<LevelMA>
	{
		public LevelMACollection()
		{

		}
		
		public static implicit operator List<LevelMA>(LevelMACollection coll)
		{
			List<LevelMA> list = new List<LevelMA>();
			
			foreach (LevelMA emp in coll)
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
				return  LevelMAMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new LevelMAQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new LevelMA(row);
		}

		override protected esEntity CreateEntity()
		{
			return new LevelMA();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public LevelMAQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new LevelMAQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(LevelMAQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public LevelMA AddNew()
		{
			LevelMA entity = base.AddNewEntity() as LevelMA;
			
			return entity;
		}

		public LevelMA FindByPrimaryKey(System.Int32 id)
		{
			return base.FindByPrimaryKey(id) as LevelMA;
		}


		#region IEnumerable<LevelMA> Members

		IEnumerator<LevelMA> IEnumerable<LevelMA>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as LevelMA;
			}
		}

		#endregion
		
		private LevelMAQuery query;
	}


	/// <summary>
	/// Encapsulates the 'levelMA' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("LevelMA ({Id})")]
	[Serializable]
	public partial class LevelMA : esLevelMA
	{
		public LevelMA()
		{

		}
	
		public LevelMA(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return LevelMAMetadata.Meta();
			}
		}
		
		
		
		override protected esLevelMAQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new LevelMAQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public LevelMAQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new LevelMAQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(LevelMAQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private LevelMAQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class LevelMAQuery : esLevelMAQuery
	{
		public LevelMAQuery()
		{

		}		
		
		public LevelMAQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "LevelMAQuery";
        }
		
			
	}


	[Serializable]
	public partial class LevelMAMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected LevelMAMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(LevelMAMetadata.ColumnNames.Id, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = LevelMAMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			_columns.Add(c);
				
			c = new esColumnMetadata(LevelMAMetadata.ColumnNames.Level, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = LevelMAMetadata.PropertyNames.Level;
			c.CharacterMaxLength = 1;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public LevelMAMetadata Meta()
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
			 public const string Id = "id";
			 public const string Level = "level";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string Level = "Level";
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
			lock (typeof(LevelMAMetadata))
			{
				if(LevelMAMetadata.mapDelegates == null)
				{
					LevelMAMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (LevelMAMetadata.meta == null)
				{
					LevelMAMetadata.meta = new LevelMAMetadata();
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
				

				meta.AddTypeMap("Id", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Level", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "levelMA";
				meta.Destination = "levelMA";
				
				meta.spInsert = "proc_levelMAInsert";				
				meta.spUpdate = "proc_levelMAUpdate";		
				meta.spDelete = "proc_levelMADelete";
				meta.spLoadAll = "proc_levelMALoadAll";
				meta.spLoadByPrimaryKey = "proc_levelMALoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private LevelMAMetadata meta;
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
Date Generated       : 11/22/2012 3:22:26 PM
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
	/// Encapsulates the 'levelMA' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(LevelMA))]	
	[XmlType("LevelMA")]
	public partial class LevelMA : esLevelMA
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new LevelMA();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 id)
		{
			var obj = new LevelMA();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 id, esSqlAccessType sqlAccessType)
		{
			var obj = new LevelMA();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("LevelMACollection")]
	public partial class LevelMACollection : esLevelMACollection, IEnumerable<LevelMA>
	{
		public LevelMA FindByPrimaryKey(System.Int32 id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(LevelMA))]
		public class LevelMACollectionWCFPacket : esCollectionWCFPacket<LevelMACollection>
		{
			public static implicit operator LevelMACollection(LevelMACollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator LevelMACollectionWCFPacket(LevelMACollection collection)
			{
				return new LevelMACollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class LevelMAQuery : esLevelMAQuery
	{
		public LevelMAQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "LevelMAQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(LevelMAQuery query)
		{
			return LevelMAQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator LevelMAQuery(string query)
		{
			return (LevelMAQuery)LevelMAQuery.SerializeHelper.FromXml(query, typeof(LevelMAQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esLevelMA : esEntity
	{
		public esLevelMA()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 id)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 id)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 id)
		{
			LevelMAQuery query = new LevelMAQuery();
			query.Where(query.Id == id);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 id)
		{
			esParameters parms = new esParameters();
			parms.Add("Id", id);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to levelMA.id
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Id
		{
			get
			{
				return base.GetSystemInt32(LevelMAMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemInt32(LevelMAMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(LevelMAMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to levelMA.level
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Char? Level
		{
			get
			{
				return base.GetSystemChar(LevelMAMetadata.ColumnNames.Level);
			}
			
			set
			{
				if(base.SetSystemChar(LevelMAMetadata.ColumnNames.Level, value))
				{
					OnPropertyChanged(LevelMAMetadata.PropertyNames.Level);
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
						case "Id": this.str().Id = (string)value; break;							
						case "Level": this.str().Level = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Int32)
								this.Id = (System.Int32?)value;
								OnPropertyChanged(LevelMAMetadata.PropertyNames.Id);
							break;
						
						case "Level":
						
							if (value == null || value is System.Char)
								this.Level = (System.Char?)value;
								OnPropertyChanged(LevelMAMetadata.PropertyNames.Level);
							break;
					

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
			public esStrings(esLevelMA entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Id
			{
				get
				{
					System.Int32? data = entity.Id;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Id = null;
					else entity.Id = Convert.ToInt32(value);
				}
			}
				
			public System.String Level
			{
				get
				{
					System.Char? data = entity.Level;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Level = null;
					else entity.Level = Convert.ToChar(value);
				}
			}
			

			private esLevelMA entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return LevelMAMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public LevelMAQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new LevelMAQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(LevelMAQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(LevelMAQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private LevelMAQuery query;		
	}



	[Serializable]
	abstract public partial class esLevelMACollection : esEntityCollection<LevelMA>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return LevelMAMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "LevelMACollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public LevelMAQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new LevelMAQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(LevelMAQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new LevelMAQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(LevelMAQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((LevelMAQuery)query);
		}

		#endregion
		
		private LevelMAQuery query;
	}



	[Serializable]
	abstract public partial class esLevelMAQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return LevelMAMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Id": return this.Id;
				case "Level": return this.Level;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, LevelMAMetadata.ColumnNames.Id, esSystemType.Int32); }
		} 
		
		public esQueryItem Level
		{
			get { return new esQueryItem(this, LevelMAMetadata.ColumnNames.Level, esSystemType.Char); }
		} 
		
		#endregion
		
	}


	
	public partial class LevelMA : esLevelMA
	{

		
		
	}
	



	[Serializable]
	public partial class LevelMAMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected LevelMAMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(LevelMAMetadata.ColumnNames.Id, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = LevelMAMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(LevelMAMetadata.ColumnNames.Level, 1, typeof(System.Char), esSystemType.Char);
			c.PropertyName = LevelMAMetadata.PropertyNames.Level;
			c.CharacterMaxLength = 1;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public LevelMAMetadata Meta()
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
			 public const string Id = "id";
			 public const string Level = "level";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string Level = "Level";
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
			lock (typeof(LevelMAMetadata))
			{
				if(LevelMAMetadata.mapDelegates == null)
				{
					LevelMAMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (LevelMAMetadata.meta == null)
				{
					LevelMAMetadata.meta = new LevelMAMetadata();
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


				meta.AddTypeMap("Id", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Level", new esTypeMap("nvarchar", "System.Char"));			
				
				
				
				meta.Source = "levelMA";
				meta.Destination = "levelMA";
				
				meta.spInsert = "proc_levelMAInsert";				
				meta.spUpdate = "proc_levelMAUpdate";		
				meta.spDelete = "proc_levelMADelete";
				meta.spLoadAll = "proc_levelMALoadAll";
				meta.spLoadByPrimaryKey = "proc_levelMALoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private LevelMAMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
>>>>>>> republish

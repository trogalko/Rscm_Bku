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
Date Generated       : 10/03/2011 10:05:35
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
	abstract public class esGroupMACollection : esEntityCollection
	{
		public esGroupMACollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "GroupMACollection";
		}

		#region Query Logic
		protected void InitQuery(esGroupMAQuery query)
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
			this.InitQuery(query as esGroupMAQuery);
		}
		#endregion
		
		virtual public GroupMA DetachEntity(GroupMA entity)
		{
			return base.DetachEntity(entity) as GroupMA;
		}
		
		virtual public GroupMA AttachEntity(GroupMA entity)
		{
			return base.AttachEntity(entity) as GroupMA;
		}
		
		virtual public void Combine(GroupMACollection collection)
		{
			base.Combine(collection);
		}
		
		new public GroupMA this[int index]
		{
			get
			{
				return base[index] as GroupMA;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(GroupMA);
		}
	}



	[Serializable]
	abstract public class esGroupMA : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esGroupMAQuery GetDynamicQuery()
		{
			return null;
		}

		public esGroupMA()
		{

		}

		public esGroupMA(DataRow row)
			: base(row)
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int64 gtId)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(gtId);
			else
				return LoadByPrimaryKeyStoredProcedure(gtId);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int64 gtId)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(gtId);
			else
				return LoadByPrimaryKeyStoredProcedure(gtId);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int64 gtId)
		{
			esGroupMAQuery query = this.GetDynamicQuery();
			query.Where(query.GtId == gtId);
			return query.Load();
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int64 gtId)
		{
			esParameters parms = new esParameters();
			parms.Add("GT_ID",gtId);
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
						case "GtId": this.str.GtId = (string)value; break;							
						case "GtCode": this.str.GtCode = (string)value; break;							
						case "UserInsert": this.str.UserInsert = (string)value; break;							
						case "TglInsert": this.str.TglInsert = (string)value; break;							
						case "UserUpdate": this.str.UserUpdate = (string)value; break;							
						case "TglUpdate": this.str.TglUpdate = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "GtId":
						
							if (value == null || value is System.Int64)
								this.GtId = (System.Int64?)value;
							break;
						
						case "TglInsert":
						
							if (value == null || value is System.DateTime)
								this.TglInsert = (System.DateTime?)value;
							break;
						
						case "TglUpdate":
						
							if (value == null || value is System.DateTime)
								this.TglUpdate = (System.DateTime?)value;
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
		/// Maps to Group_MA.GT_ID
		/// </summary>
		virtual public System.Int64? GtId
		{
			get
			{
				return base.GetSystemInt64(GroupMAMetadata.ColumnNames.GtId);
			}
			
			set
			{
				base.SetSystemInt64(GroupMAMetadata.ColumnNames.GtId, value);
			}
		}
		
		/// <summary>
		/// Maps to Group_MA.GT_CODE
		/// </summary>
		virtual public System.String GtCode
		{
			get
			{
				return base.GetSystemString(GroupMAMetadata.ColumnNames.GtCode);
			}
			
			set
			{
				base.SetSystemString(GroupMAMetadata.ColumnNames.GtCode, value);
			}
		}
		
		/// <summary>
		/// Maps to Group_MA.USER_INSERT
		/// </summary>
		virtual public System.String UserInsert
		{
			get
			{
				return base.GetSystemString(GroupMAMetadata.ColumnNames.UserInsert);
			}
			
			set
			{
				base.SetSystemString(GroupMAMetadata.ColumnNames.UserInsert, value);
			}
		}
		
		/// <summary>
		/// Maps to Group_MA.TGL_INSERT
		/// </summary>
		virtual public System.DateTime? TglInsert
		{
			get
			{
				return base.GetSystemDateTime(GroupMAMetadata.ColumnNames.TglInsert);
			}
			
			set
			{
				base.SetSystemDateTime(GroupMAMetadata.ColumnNames.TglInsert, value);
			}
		}
		
		/// <summary>
		/// Maps to Group_MA.USER_UPDATE
		/// </summary>
		virtual public System.String UserUpdate
		{
			get
			{
				return base.GetSystemString(GroupMAMetadata.ColumnNames.UserUpdate);
			}
			
			set
			{
				base.SetSystemString(GroupMAMetadata.ColumnNames.UserUpdate, value);
			}
		}
		
		/// <summary>
		/// Maps to Group_MA.TGL_UPDATE
		/// </summary>
		virtual public System.DateTime? TglUpdate
		{
			get
			{
				return base.GetSystemDateTime(GroupMAMetadata.ColumnNames.TglUpdate);
			}
			
			set
			{
				base.SetSystemDateTime(GroupMAMetadata.ColumnNames.TglUpdate, value);
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
			public esStrings(esGroupMA entity)
			{
				this.entity = entity;
			}
			
	
			public System.String GtId
			{
				get
				{
					System.Int64? data = entity.GtId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.GtId = null;
					else entity.GtId = Convert.ToInt64(value);
				}
			}
				
			public System.String GtCode
			{
				get
				{
					System.String data = entity.GtCode;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.GtCode = null;
					else entity.GtCode = Convert.ToString(value);
				}
			}
				
			public System.String UserInsert
			{
				get
				{
					System.String data = entity.UserInsert;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.UserInsert = null;
					else entity.UserInsert = Convert.ToString(value);
				}
			}
				
			public System.String TglInsert
			{
				get
				{
					System.DateTime? data = entity.TglInsert;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TglInsert = null;
					else entity.TglInsert = Convert.ToDateTime(value);
				}
			}
				
			public System.String UserUpdate
			{
				get
				{
					System.String data = entity.UserUpdate;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.UserUpdate = null;
					else entity.UserUpdate = Convert.ToString(value);
				}
			}
				
			public System.String TglUpdate
			{
				get
				{
					System.DateTime? data = entity.TglUpdate;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TglUpdate = null;
					else entity.TglUpdate = Convert.ToDateTime(value);
				}
			}
			

			private esGroupMA entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esGroupMAQuery query)
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
				throw new Exception("esGroupMA can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class GroupMA : esGroupMA
	{

				
		#region KelAnggaranCollectionByGtCode - Zero To Many
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Kel_anggaran_Group_MA
		/// </summary>

		[XmlIgnore]
		public KelAnggaranCollection KelAnggaranCollectionByGtCode
		{
			get
			{
				if(this._KelAnggaranCollectionByGtCode == null)
				{
					this._KelAnggaranCollectionByGtCode = new KelAnggaranCollection();
					this._KelAnggaranCollectionByGtCode.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("KelAnggaranCollectionByGtCode", this._KelAnggaranCollectionByGtCode);
				
					if(this.GtCode != null)
					{
						this._KelAnggaranCollectionByGtCode.Query.Where(this._KelAnggaranCollectionByGtCode.Query.GtCode == this.GtCode);
						this._KelAnggaranCollectionByGtCode.Query.Load();

						// Auto-hookup Foreign Keys
						this._KelAnggaranCollectionByGtCode.fks.Add(KelAnggaranMetadata.ColumnNames.GtCode, this.GtCode);
					}
				}

				return this._KelAnggaranCollectionByGtCode;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._KelAnggaranCollectionByGtCode != null) 
				{ 
					this.RemovePostSave("KelAnggaranCollectionByGtCode"); 
					this._KelAnggaranCollectionByGtCode = null;
					
				} 
			} 			
		}

		private KelAnggaranCollection _KelAnggaranCollectionByGtCode;
		#endregion

		
		/// <summary>
		/// Used internally by the entity's hierarchical properties.
		/// </summary>
		protected override List<esPropertyDescriptor> GetHierarchicalProperties()
		{
			List<esPropertyDescriptor> props = new List<esPropertyDescriptor>();
			
			props.Add(new esPropertyDescriptor(this, "KelAnggaranCollectionByGtCode", typeof(KelAnggaranCollection), new KelAnggaran()));
		
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
			if(this._KelAnggaranCollectionByGtCode != null)
			{
				foreach(KelAnggaran obj in this._KelAnggaranCollectionByGtCode)
				{
					if(obj.es.IsAdded)
					{
						obj.GtCode = this.GtCode;
					}
				}
			}
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
	abstract public class esGroupMAQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return GroupMAMetadata.Meta();
			}
		}	
		

		public esQueryItem GtId
		{
			get
			{
				return new esQueryItem(this, GroupMAMetadata.ColumnNames.GtId, esSystemType.Int64);
			}
		} 
		
		public esQueryItem GtCode
		{
			get
			{
				return new esQueryItem(this, GroupMAMetadata.ColumnNames.GtCode, esSystemType.String);
			}
		} 
		
		public esQueryItem UserInsert
		{
			get
			{
				return new esQueryItem(this, GroupMAMetadata.ColumnNames.UserInsert, esSystemType.String);
			}
		} 
		
		public esQueryItem TglInsert
		{
			get
			{
				return new esQueryItem(this, GroupMAMetadata.ColumnNames.TglInsert, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem UserUpdate
		{
			get
			{
				return new esQueryItem(this, GroupMAMetadata.ColumnNames.UserUpdate, esSystemType.String);
			}
		} 
		
		public esQueryItem TglUpdate
		{
			get
			{
				return new esQueryItem(this, GroupMAMetadata.ColumnNames.TglUpdate, esSystemType.DateTime);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("GroupMACollection")]
	public partial class GroupMACollection : esGroupMACollection, IEnumerable<GroupMA>
	{
		public GroupMACollection()
		{

		}
		
		public static implicit operator List<GroupMA>(GroupMACollection coll)
		{
			List<GroupMA> list = new List<GroupMA>();
			
			foreach (GroupMA emp in coll)
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
				return  GroupMAMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new GroupMAQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new GroupMA(row);
		}

		override protected esEntity CreateEntity()
		{
			return new GroupMA();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public GroupMAQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new GroupMAQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(GroupMAQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public GroupMA AddNew()
		{
			GroupMA entity = base.AddNewEntity() as GroupMA;
			
			return entity;
		}

		public GroupMA FindByPrimaryKey(System.Int64 gtId)
		{
			return base.FindByPrimaryKey(gtId) as GroupMA;
		}


		#region IEnumerable<GroupMA> Members

		IEnumerator<GroupMA> IEnumerable<GroupMA>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as GroupMA;
			}
		}

		#endregion
		
		private GroupMAQuery query;
	}


	/// <summary>
	/// Encapsulates the 'Group_MA' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("GroupMA ({GtId})")]
	[Serializable]
	public partial class GroupMA : esGroupMA
	{
		public GroupMA()
		{

		}
	
		public GroupMA(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return GroupMAMetadata.Meta();
			}
		}
		
		
		
		override protected esGroupMAQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new GroupMAQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public GroupMAQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new GroupMAQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(GroupMAQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private GroupMAQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class GroupMAQuery : esGroupMAQuery
	{
		public GroupMAQuery()
		{

		}		
		
		public GroupMAQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "GroupMAQuery";
        }
		
			
	}


	[Serializable]
	public partial class GroupMAMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected GroupMAMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(GroupMAMetadata.ColumnNames.GtId, 0, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = GroupMAMetadata.PropertyNames.GtId;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 19;
			_columns.Add(c);
				
			c = new esColumnMetadata(GroupMAMetadata.ColumnNames.GtCode, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = GroupMAMetadata.PropertyNames.GtCode;
			c.CharacterMaxLength = 15;
			_columns.Add(c);
				
			c = new esColumnMetadata(GroupMAMetadata.ColumnNames.UserInsert, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = GroupMAMetadata.PropertyNames.UserInsert;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(GroupMAMetadata.ColumnNames.TglInsert, 3, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = GroupMAMetadata.PropertyNames.TglInsert;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(GroupMAMetadata.ColumnNames.UserUpdate, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = GroupMAMetadata.PropertyNames.UserUpdate;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(GroupMAMetadata.ColumnNames.TglUpdate, 5, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = GroupMAMetadata.PropertyNames.TglUpdate;
			c.IsNullable = true;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public GroupMAMetadata Meta()
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
			 public const string GtId = "GT_ID";
			 public const string GtCode = "GT_CODE";
			 public const string UserInsert = "USER_INSERT";
			 public const string TglInsert = "TGL_INSERT";
			 public const string UserUpdate = "USER_UPDATE";
			 public const string TglUpdate = "TGL_UPDATE";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string GtId = "GtId";
			 public const string GtCode = "GtCode";
			 public const string UserInsert = "UserInsert";
			 public const string TglInsert = "TglInsert";
			 public const string UserUpdate = "UserUpdate";
			 public const string TglUpdate = "TglUpdate";
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
			lock (typeof(GroupMAMetadata))
			{
				if(GroupMAMetadata.mapDelegates == null)
				{
					GroupMAMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (GroupMAMetadata.meta == null)
				{
					GroupMAMetadata.meta = new GroupMAMetadata();
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
				

				meta.AddTypeMap("GtId", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("GtCode", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("UserInsert", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("TglInsert", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("UserUpdate", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("TglUpdate", new esTypeMap("datetime", "System.DateTime"));			
				
				
				
				meta.Source = "Group_MA";
				meta.Destination = "Group_MA";
				
				meta.spInsert = "proc_Group_MAInsert";				
				meta.spUpdate = "proc_Group_MAUpdate";		
				meta.spDelete = "proc_Group_MADelete";
				meta.spLoadAll = "proc_Group_MALoadAll";
				meta.spLoadByPrimaryKey = "proc_Group_MALoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private GroupMAMetadata meta;
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
Date Generated       : 11/22/2012 3:22:25 PM
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
	/// Encapsulates the 'Group_MA' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(GroupMA))]	
	[XmlType("GroupMA")]
	public partial class GroupMA : esGroupMA
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new GroupMA();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int64 gtId)
		{
			var obj = new GroupMA();
			obj.GtId = gtId;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int64 gtId, esSqlAccessType sqlAccessType)
		{
			var obj = new GroupMA();
			obj.GtId = gtId;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("GroupMACollection")]
	public partial class GroupMACollection : esGroupMACollection, IEnumerable<GroupMA>
	{
		public GroupMA FindByPrimaryKey(System.Int64 gtId)
		{
			return this.SingleOrDefault(e => e.GtId == gtId);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(GroupMA))]
		public class GroupMACollectionWCFPacket : esCollectionWCFPacket<GroupMACollection>
		{
			public static implicit operator GroupMACollection(GroupMACollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator GroupMACollectionWCFPacket(GroupMACollection collection)
			{
				return new GroupMACollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class GroupMAQuery : esGroupMAQuery
	{
		public GroupMAQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "GroupMAQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(GroupMAQuery query)
		{
			return GroupMAQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator GroupMAQuery(string query)
		{
			return (GroupMAQuery)GroupMAQuery.SerializeHelper.FromXml(query, typeof(GroupMAQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esGroupMA : esEntity
	{
		public esGroupMA()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int64 gtId)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(gtId);
			else
				return LoadByPrimaryKeyStoredProcedure(gtId);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int64 gtId)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(gtId);
			else
				return LoadByPrimaryKeyStoredProcedure(gtId);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int64 gtId)
		{
			GroupMAQuery query = new GroupMAQuery();
			query.Where(query.GtId == gtId);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int64 gtId)
		{
			esParameters parms = new esParameters();
			parms.Add("GtId", gtId);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Group_MA.GT_ID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int64? GtId
		{
			get
			{
				return base.GetSystemInt64(GroupMAMetadata.ColumnNames.GtId);
			}
			
			set
			{
				if(base.SetSystemInt64(GroupMAMetadata.ColumnNames.GtId, value))
				{
					OnPropertyChanged(GroupMAMetadata.PropertyNames.GtId);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Group_MA.GT_CODE
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String GtCode
		{
			get
			{
				return base.GetSystemString(GroupMAMetadata.ColumnNames.GtCode);
			}
			
			set
			{
				if(base.SetSystemString(GroupMAMetadata.ColumnNames.GtCode, value))
				{
					OnPropertyChanged(GroupMAMetadata.PropertyNames.GtCode);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Group_MA.USER_INSERT
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String UserInsert
		{
			get
			{
				return base.GetSystemString(GroupMAMetadata.ColumnNames.UserInsert);
			}
			
			set
			{
				if(base.SetSystemString(GroupMAMetadata.ColumnNames.UserInsert, value))
				{
					OnPropertyChanged(GroupMAMetadata.PropertyNames.UserInsert);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Group_MA.TGL_INSERT
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? TglInsert
		{
			get
			{
				return base.GetSystemDateTime(GroupMAMetadata.ColumnNames.TglInsert);
			}
			
			set
			{
				if(base.SetSystemDateTime(GroupMAMetadata.ColumnNames.TglInsert, value))
				{
					OnPropertyChanged(GroupMAMetadata.PropertyNames.TglInsert);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Group_MA.USER_UPDATE
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String UserUpdate
		{
			get
			{
				return base.GetSystemString(GroupMAMetadata.ColumnNames.UserUpdate);
			}
			
			set
			{
				if(base.SetSystemString(GroupMAMetadata.ColumnNames.UserUpdate, value))
				{
					OnPropertyChanged(GroupMAMetadata.PropertyNames.UserUpdate);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Group_MA.TGL_UPDATE
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? TglUpdate
		{
			get
			{
				return base.GetSystemDateTime(GroupMAMetadata.ColumnNames.TglUpdate);
			}
			
			set
			{
				if(base.SetSystemDateTime(GroupMAMetadata.ColumnNames.TglUpdate, value))
				{
					OnPropertyChanged(GroupMAMetadata.PropertyNames.TglUpdate);
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
						case "GtId": this.str().GtId = (string)value; break;							
						case "GtCode": this.str().GtCode = (string)value; break;							
						case "UserInsert": this.str().UserInsert = (string)value; break;							
						case "TglInsert": this.str().TglInsert = (string)value; break;							
						case "UserUpdate": this.str().UserUpdate = (string)value; break;							
						case "TglUpdate": this.str().TglUpdate = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "GtId":
						
							if (value == null || value is System.Int64)
								this.GtId = (System.Int64?)value;
								OnPropertyChanged(GroupMAMetadata.PropertyNames.GtId);
							break;
						
						case "TglInsert":
						
							if (value == null || value is System.DateTime)
								this.TglInsert = (System.DateTime?)value;
								OnPropertyChanged(GroupMAMetadata.PropertyNames.TglInsert);
							break;
						
						case "TglUpdate":
						
							if (value == null || value is System.DateTime)
								this.TglUpdate = (System.DateTime?)value;
								OnPropertyChanged(GroupMAMetadata.PropertyNames.TglUpdate);
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
			public esStrings(esGroupMA entity)
			{
				this.entity = entity;
			}
			
	
			public System.String GtId
			{
				get
				{
					System.Int64? data = entity.GtId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.GtId = null;
					else entity.GtId = Convert.ToInt64(value);
				}
			}
				
			public System.String GtCode
			{
				get
				{
					System.String data = entity.GtCode;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.GtCode = null;
					else entity.GtCode = Convert.ToString(value);
				}
			}
				
			public System.String UserInsert
			{
				get
				{
					System.String data = entity.UserInsert;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.UserInsert = null;
					else entity.UserInsert = Convert.ToString(value);
				}
			}
				
			public System.String TglInsert
			{
				get
				{
					System.DateTime? data = entity.TglInsert;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TglInsert = null;
					else entity.TglInsert = Convert.ToDateTime(value);
				}
			}
				
			public System.String UserUpdate
			{
				get
				{
					System.String data = entity.UserUpdate;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.UserUpdate = null;
					else entity.UserUpdate = Convert.ToString(value);
				}
			}
				
			public System.String TglUpdate
			{
				get
				{
					System.DateTime? data = entity.TglUpdate;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TglUpdate = null;
					else entity.TglUpdate = Convert.ToDateTime(value);
				}
			}
			

			private esGroupMA entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return GroupMAMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public GroupMAQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new GroupMAQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(GroupMAQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(GroupMAQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private GroupMAQuery query;		
	}



	[Serializable]
	abstract public partial class esGroupMACollection : esEntityCollection<GroupMA>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return GroupMAMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "GroupMACollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public GroupMAQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new GroupMAQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(GroupMAQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new GroupMAQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(GroupMAQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((GroupMAQuery)query);
		}

		#endregion
		
		private GroupMAQuery query;
	}



	[Serializable]
	abstract public partial class esGroupMAQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return GroupMAMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "GtId": return this.GtId;
				case "GtCode": return this.GtCode;
				case "UserInsert": return this.UserInsert;
				case "TglInsert": return this.TglInsert;
				case "UserUpdate": return this.UserUpdate;
				case "TglUpdate": return this.TglUpdate;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem GtId
		{
			get { return new esQueryItem(this, GroupMAMetadata.ColumnNames.GtId, esSystemType.Int64); }
		} 
		
		public esQueryItem GtCode
		{
			get { return new esQueryItem(this, GroupMAMetadata.ColumnNames.GtCode, esSystemType.String); }
		} 
		
		public esQueryItem UserInsert
		{
			get { return new esQueryItem(this, GroupMAMetadata.ColumnNames.UserInsert, esSystemType.String); }
		} 
		
		public esQueryItem TglInsert
		{
			get { return new esQueryItem(this, GroupMAMetadata.ColumnNames.TglInsert, esSystemType.DateTime); }
		} 
		
		public esQueryItem UserUpdate
		{
			get { return new esQueryItem(this, GroupMAMetadata.ColumnNames.UserUpdate, esSystemType.String); }
		} 
		
		public esQueryItem TglUpdate
		{
			get { return new esQueryItem(this, GroupMAMetadata.ColumnNames.TglUpdate, esSystemType.DateTime); }
		} 
		
		#endregion
		
	}


	
	public partial class GroupMA : esGroupMA
	{

		#region KelAnggaranCollectionByGtCode - Zero To Many
		
		static public esPrefetchMap Prefetch_KelAnggaranCollectionByGtCode
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = RSCM_BKU_Web.BusinessObjects.GroupMA.KelAnggaranCollectionByGtCode_Delegate;
				map.PropertyName = "KelAnggaranCollectionByGtCode";
				map.MyColumnName = "GT_CODE";
				map.ParentColumnName = "GT_CODE";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void KelAnggaranCollectionByGtCode_Delegate(esPrefetchParameters data)
		{
			GroupMAQuery parent = new GroupMAQuery(data.NextAlias());

			KelAnggaranQuery me = data.You != null ? data.You as KelAnggaranQuery : new KelAnggaranQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.GtCode == me.GtCode);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Kel_anggaran_Group_MA
		/// </summary>

		[XmlIgnore]
		public KelAnggaranCollection KelAnggaranCollectionByGtCode
		{
			get
			{
				if(this._KelAnggaranCollectionByGtCode == null)
				{
					this._KelAnggaranCollectionByGtCode = new KelAnggaranCollection();
					this._KelAnggaranCollectionByGtCode.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("KelAnggaranCollectionByGtCode", this._KelAnggaranCollectionByGtCode);
				
					if (this.GtCode != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._KelAnggaranCollectionByGtCode.Query.Where(this._KelAnggaranCollectionByGtCode.Query.GtCode == this.GtCode);
							this._KelAnggaranCollectionByGtCode.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._KelAnggaranCollectionByGtCode.fks.Add(KelAnggaranMetadata.ColumnNames.GtCode, this.GtCode);
					}
				}

				return this._KelAnggaranCollectionByGtCode;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._KelAnggaranCollectionByGtCode != null) 
				{ 
					this.RemovePostSave("KelAnggaranCollectionByGtCode"); 
					this._KelAnggaranCollectionByGtCode = null;
					
				} 
			} 			
		}
			
		
		private KelAnggaranCollection _KelAnggaranCollectionByGtCode;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "KelAnggaranCollectionByGtCode":
					coll = this.KelAnggaranCollectionByGtCode;
					break;	
			}

			return coll;
		}		
		/// <summary>
		/// Used internally by the entity's hierarchical properties.
		/// </summary>
		protected override List<esPropertyDescriptor> GetHierarchicalProperties()
		{
			List<esPropertyDescriptor> props = new List<esPropertyDescriptor>();
			
			props.Add(new esPropertyDescriptor(this, "KelAnggaranCollectionByGtCode", typeof(KelAnggaranCollection), new KelAnggaran()));
		
			return props;
		}
		
		/// <summary>
		/// Called by ApplyPostSaveKeys 
		/// </summary>
		/// <param name="coll">The collection to enumerate over</param>
		/// <param name="key">"The column name</param>
		/// <param name="value">The column value</param>
		private void Apply(esEntityCollectionBase coll, string key, object value)
		{
			foreach (esEntity obj in coll)
			{
				if (obj.es.IsAdded)
				{
					obj.SetProperty(key, value);
				}
			}
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostSave.
		/// </summary>
		protected override void ApplyPostSaveKeys()
		{
			if(this._KelAnggaranCollectionByGtCode != null)
			{
				Apply(this._KelAnggaranCollectionByGtCode, "GtCode", this.GtCode);
			}
		}
		
	}
	



	[Serializable]
	public partial class GroupMAMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected GroupMAMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(GroupMAMetadata.ColumnNames.GtId, 0, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = GroupMAMetadata.PropertyNames.GtId;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 19;
			m_columns.Add(c);
				
			c = new esColumnMetadata(GroupMAMetadata.ColumnNames.GtCode, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = GroupMAMetadata.PropertyNames.GtCode;
			c.CharacterMaxLength = 15;
			m_columns.Add(c);
				
			c = new esColumnMetadata(GroupMAMetadata.ColumnNames.UserInsert, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = GroupMAMetadata.PropertyNames.UserInsert;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(GroupMAMetadata.ColumnNames.TglInsert, 3, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = GroupMAMetadata.PropertyNames.TglInsert;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(GroupMAMetadata.ColumnNames.UserUpdate, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = GroupMAMetadata.PropertyNames.UserUpdate;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(GroupMAMetadata.ColumnNames.TglUpdate, 5, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = GroupMAMetadata.PropertyNames.TglUpdate;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public GroupMAMetadata Meta()
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
			 public const string GtId = "GT_ID";
			 public const string GtCode = "GT_CODE";
			 public const string UserInsert = "USER_INSERT";
			 public const string TglInsert = "TGL_INSERT";
			 public const string UserUpdate = "USER_UPDATE";
			 public const string TglUpdate = "TGL_UPDATE";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string GtId = "GtId";
			 public const string GtCode = "GtCode";
			 public const string UserInsert = "UserInsert";
			 public const string TglInsert = "TglInsert";
			 public const string UserUpdate = "UserUpdate";
			 public const string TglUpdate = "TglUpdate";
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
			lock (typeof(GroupMAMetadata))
			{
				if(GroupMAMetadata.mapDelegates == null)
				{
					GroupMAMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (GroupMAMetadata.meta == null)
				{
					GroupMAMetadata.meta = new GroupMAMetadata();
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


				meta.AddTypeMap("GtId", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("GtCode", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("UserInsert", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("TglInsert", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("UserUpdate", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("TglUpdate", new esTypeMap("datetime", "System.DateTime"));			
				
				
				
				meta.Source = "Group_MA";
				meta.Destination = "Group_MA";
				
				meta.spInsert = "proc_Group_MAInsert";				
				meta.spUpdate = "proc_Group_MAUpdate";		
				meta.spDelete = "proc_Group_MADelete";
				meta.spLoadAll = "proc_Group_MALoadAll";
				meta.spLoadByPrimaryKey = "proc_Group_MALoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private GroupMAMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
>>>>>>> republish
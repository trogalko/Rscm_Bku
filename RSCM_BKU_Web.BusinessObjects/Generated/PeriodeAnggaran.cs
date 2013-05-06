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
	abstract public class esPeriodeAnggaranCollection : esEntityCollection
	{
		public esPeriodeAnggaranCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "PeriodeAnggaranCollection";
		}

		#region Query Logic
		protected void InitQuery(esPeriodeAnggaranQuery query)
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
			this.InitQuery(query as esPeriodeAnggaranQuery);
		}
		#endregion
		
		virtual public PeriodeAnggaran DetachEntity(PeriodeAnggaran entity)
		{
			return base.DetachEntity(entity) as PeriodeAnggaran;
		}
		
		virtual public PeriodeAnggaran AttachEntity(PeriodeAnggaran entity)
		{
			return base.AttachEntity(entity) as PeriodeAnggaran;
		}
		
		virtual public void Combine(PeriodeAnggaranCollection collection)
		{
			base.Combine(collection);
		}
		
		new public PeriodeAnggaran this[int index]
		{
			get
			{
				return base[index] as PeriodeAnggaran;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(PeriodeAnggaran);
		}
	}



	[Serializable]
	abstract public class esPeriodeAnggaran : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esPeriodeAnggaranQuery GetDynamicQuery()
		{
			return null;
		}

		public esPeriodeAnggaran()
		{

		}

		public esPeriodeAnggaran(DataRow row)
			: base(row)
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int64 id)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int64 id)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int64 id)
		{
			esPeriodeAnggaranQuery query = this.GetDynamicQuery();
			query.Where(query.Id == id);
			return query.Load();
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int64 id)
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
						case "StartPeriod": this.str.StartPeriod = (string)value; break;							
						case "EndPeriod": this.str.EndPeriod = (string)value; break;							
						case "IsClosed": this.str.IsClosed = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Int64)
								this.Id = (System.Int64?)value;
							break;
						
						case "StartPeriod":
						
							if (value == null || value is System.DateTime)
								this.StartPeriod = (System.DateTime?)value;
							break;
						
						case "EndPeriod":
						
							if (value == null || value is System.DateTime)
								this.EndPeriod = (System.DateTime?)value;
							break;
						
						case "IsClosed":
						
							if (value == null || value is System.Boolean)
								this.IsClosed = (System.Boolean?)value;
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
		/// Maps to PeriodeAnggaran.id
		/// </summary>
		virtual public System.Int64? Id
		{
			get
			{
				return base.GetSystemInt64(PeriodeAnggaranMetadata.ColumnNames.Id);
			}
			
			set
			{
				base.SetSystemInt64(PeriodeAnggaranMetadata.ColumnNames.Id, value);
			}
		}
		
		/// <summary>
		/// Maps to PeriodeAnggaran.Start_Period
		/// </summary>
		virtual public System.DateTime? StartPeriod
		{
			get
			{
				return base.GetSystemDateTime(PeriodeAnggaranMetadata.ColumnNames.StartPeriod);
			}
			
			set
			{
				base.SetSystemDateTime(PeriodeAnggaranMetadata.ColumnNames.StartPeriod, value);
			}
		}
		
		/// <summary>
		/// Maps to PeriodeAnggaran.End_Period
		/// </summary>
		virtual public System.DateTime? EndPeriod
		{
			get
			{
				return base.GetSystemDateTime(PeriodeAnggaranMetadata.ColumnNames.EndPeriod);
			}
			
			set
			{
				base.SetSystemDateTime(PeriodeAnggaranMetadata.ColumnNames.EndPeriod, value);
			}
		}
		
		/// <summary>
		/// Maps to PeriodeAnggaran.Is_Closed
		/// </summary>
		virtual public System.Boolean? IsClosed
		{
			get
			{
				return base.GetSystemBoolean(PeriodeAnggaranMetadata.ColumnNames.IsClosed);
			}
			
			set
			{
				base.SetSystemBoolean(PeriodeAnggaranMetadata.ColumnNames.IsClosed, value);
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
			public esStrings(esPeriodeAnggaran entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Id
			{
				get
				{
					System.Int64? data = entity.Id;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Id = null;
					else entity.Id = Convert.ToInt64(value);
				}
			}
				
			public System.String StartPeriod
			{
				get
				{
					System.DateTime? data = entity.StartPeriod;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.StartPeriod = null;
					else entity.StartPeriod = Convert.ToDateTime(value);
				}
			}
				
			public System.String EndPeriod
			{
				get
				{
					System.DateTime? data = entity.EndPeriod;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.EndPeriod = null;
					else entity.EndPeriod = Convert.ToDateTime(value);
				}
			}
				
			public System.String IsClosed
			{
				get
				{
					System.Boolean? data = entity.IsClosed;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsClosed = null;
					else entity.IsClosed = Convert.ToBoolean(value);
				}
			}
			

			private esPeriodeAnggaran entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esPeriodeAnggaranQuery query)
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
				throw new Exception("esPeriodeAnggaran can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class PeriodeAnggaran : esPeriodeAnggaran
	{

				
		#region KasCollectionByPeriodeId - Zero To Many
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_KAS_PeriodeAnggaran
		/// </summary>

		[XmlIgnore]
		public KasCollection KasCollectionByPeriodeId
		{
			get
			{
				if(this._KasCollectionByPeriodeId == null)
				{
					this._KasCollectionByPeriodeId = new KasCollection();
					this._KasCollectionByPeriodeId.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("KasCollectionByPeriodeId", this._KasCollectionByPeriodeId);
				
					if(this.Id != null)
					{
						this._KasCollectionByPeriodeId.Query.Where(this._KasCollectionByPeriodeId.Query.PeriodeId == this.Id);
						this._KasCollectionByPeriodeId.Query.Load();

						// Auto-hookup Foreign Keys
						this._KasCollectionByPeriodeId.fks.Add(KasMetadata.ColumnNames.PeriodeId, this.Id);
					}
				}

				return this._KasCollectionByPeriodeId;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._KasCollectionByPeriodeId != null) 
				{ 
					this.RemovePostSave("KasCollectionByPeriodeId"); 
					this._KasCollectionByPeriodeId = null;
					
				} 
			} 			
		}

		private KasCollection _KasCollectionByPeriodeId;
		#endregion

				
		#region RabCollectionByPeriodId - Zero To Many
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_RAB_PeriodeAnggaran
		/// </summary>

		[XmlIgnore]
		public RabCollection RabCollectionByPeriodId
		{
			get
			{
				if(this._RabCollectionByPeriodId == null)
				{
					this._RabCollectionByPeriodId = new RabCollection();
					this._RabCollectionByPeriodId.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("RabCollectionByPeriodId", this._RabCollectionByPeriodId);
				
					if(this.Id != null)
					{
						this._RabCollectionByPeriodId.Query.Where(this._RabCollectionByPeriodId.Query.PeriodId == this.Id);
						this._RabCollectionByPeriodId.Query.Load();

						// Auto-hookup Foreign Keys
						this._RabCollectionByPeriodId.fks.Add(RabMetadata.ColumnNames.PeriodId, this.Id);
					}
				}

				return this._RabCollectionByPeriodId;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._RabCollectionByPeriodId != null) 
				{ 
					this.RemovePostSave("RabCollectionByPeriodId"); 
					this._RabCollectionByPeriodId = null;
					
				} 
			} 			
		}

		private RabCollection _RabCollectionByPeriodId;
		#endregion

				
		#region TransCollectionByPeriodId - Zero To Many
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Trans_PeriodeAnggaran
		/// </summary>

		[XmlIgnore]
		public TransCollection TransCollectionByPeriodId
		{
			get
			{
				if(this._TransCollectionByPeriodId == null)
				{
					this._TransCollectionByPeriodId = new TransCollection();
					this._TransCollectionByPeriodId.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("TransCollectionByPeriodId", this._TransCollectionByPeriodId);
				
					if(this.Id != null)
					{
						this._TransCollectionByPeriodId.Query.Where(this._TransCollectionByPeriodId.Query.PeriodId == this.Id);
						this._TransCollectionByPeriodId.Query.Load();

						// Auto-hookup Foreign Keys
						this._TransCollectionByPeriodId.fks.Add(TransMetadata.ColumnNames.PeriodId, this.Id);
					}
				}

				return this._TransCollectionByPeriodId;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._TransCollectionByPeriodId != null) 
				{ 
					this.RemovePostSave("TransCollectionByPeriodId"); 
					this._TransCollectionByPeriodId = null;
					
				} 
			} 			
		}

		private TransCollection _TransCollectionByPeriodId;
		#endregion

		
		/// <summary>
		/// Used internally by the entity's hierarchical properties.
		/// </summary>
		protected override List<esPropertyDescriptor> GetHierarchicalProperties()
		{
			List<esPropertyDescriptor> props = new List<esPropertyDescriptor>();
			
			props.Add(new esPropertyDescriptor(this, "KasCollectionByPeriodeId", typeof(KasCollection), new Kas()));
			props.Add(new esPropertyDescriptor(this, "RabCollectionByPeriodId", typeof(RabCollection), new Rab()));
			props.Add(new esPropertyDescriptor(this, "TransCollectionByPeriodId", typeof(TransCollection), new Trans()));
		
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
			if(this._KasCollectionByPeriodeId != null)
			{
				foreach(Kas obj in this._KasCollectionByPeriodeId)
				{
					if(obj.es.IsAdded)
					{
						obj.PeriodeId = this.Id;
					}
				}
			}
			if(this._RabCollectionByPeriodId != null)
			{
				foreach(Rab obj in this._RabCollectionByPeriodId)
				{
					if(obj.es.IsAdded)
					{
						obj.PeriodId = this.Id;
					}
				}
			}
			if(this._TransCollectionByPeriodId != null)
			{
				foreach(Trans obj in this._TransCollectionByPeriodId)
				{
					if(obj.es.IsAdded)
					{
						obj.PeriodId = this.Id;
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
	abstract public class esPeriodeAnggaranQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return PeriodeAnggaranMetadata.Meta();
			}
		}	
		

		public esQueryItem Id
		{
			get
			{
				return new esQueryItem(this, PeriodeAnggaranMetadata.ColumnNames.Id, esSystemType.Int64);
			}
		} 
		
		public esQueryItem StartPeriod
		{
			get
			{
				return new esQueryItem(this, PeriodeAnggaranMetadata.ColumnNames.StartPeriod, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem EndPeriod
		{
			get
			{
				return new esQueryItem(this, PeriodeAnggaranMetadata.ColumnNames.EndPeriod, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem IsClosed
		{
			get
			{
				return new esQueryItem(this, PeriodeAnggaranMetadata.ColumnNames.IsClosed, esSystemType.Boolean);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("PeriodeAnggaranCollection")]
	public partial class PeriodeAnggaranCollection : esPeriodeAnggaranCollection, IEnumerable<PeriodeAnggaran>
	{
		public PeriodeAnggaranCollection()
		{

		}
		
		public static implicit operator List<PeriodeAnggaran>(PeriodeAnggaranCollection coll)
		{
			List<PeriodeAnggaran> list = new List<PeriodeAnggaran>();
			
			foreach (PeriodeAnggaran emp in coll)
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
				return  PeriodeAnggaranMetadata.Meta();
			}
		}
		
		
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new PeriodeAnggaranQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new PeriodeAnggaran(row);
		}

		override protected esEntity CreateEntity()
		{
			return new PeriodeAnggaran();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public PeriodeAnggaranQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new PeriodeAnggaranQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(PeriodeAnggaranQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public PeriodeAnggaran AddNew()
		{
			PeriodeAnggaran entity = base.AddNewEntity() as PeriodeAnggaran;
			
			return entity;
		}

		public PeriodeAnggaran FindByPrimaryKey(System.Int64 id)
		{
			return base.FindByPrimaryKey(id) as PeriodeAnggaran;
		}


		#region IEnumerable<PeriodeAnggaran> Members

		IEnumerator<PeriodeAnggaran> IEnumerable<PeriodeAnggaran>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as PeriodeAnggaran;
			}
		}

		#endregion
		
		private PeriodeAnggaranQuery query;
	}


	/// <summary>
	/// Encapsulates the 'PeriodeAnggaran' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("PeriodeAnggaran ({Id})")]
	[Serializable]
	public partial class PeriodeAnggaran : esPeriodeAnggaran
	{
		public PeriodeAnggaran()
		{

		}
	
		public PeriodeAnggaran(DataRow row)
			: base(row)
		{

		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return PeriodeAnggaranMetadata.Meta();
			}
		}
		
		
		
		override protected esPeriodeAnggaranQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new PeriodeAnggaranQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public PeriodeAnggaranQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new PeriodeAnggaranQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(PeriodeAnggaranQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private PeriodeAnggaranQuery query;
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class PeriodeAnggaranQuery : esPeriodeAnggaranQuery
	{
		public PeriodeAnggaranQuery()
		{

		}		
		
		public PeriodeAnggaranQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

        override protected string GetQueryName()
        {
            return "PeriodeAnggaranQuery";
        }
		
			
	}


	[Serializable]
	public partial class PeriodeAnggaranMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected PeriodeAnggaranMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(PeriodeAnggaranMetadata.ColumnNames.Id, 0, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = PeriodeAnggaranMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 19;
			_columns.Add(c);
				
			c = new esColumnMetadata(PeriodeAnggaranMetadata.ColumnNames.StartPeriod, 1, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = PeriodeAnggaranMetadata.PropertyNames.StartPeriod;
			_columns.Add(c);
				
			c = new esColumnMetadata(PeriodeAnggaranMetadata.ColumnNames.EndPeriod, 2, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = PeriodeAnggaranMetadata.PropertyNames.EndPeriod;
			c.IsNullable = true;
			_columns.Add(c);
				
			c = new esColumnMetadata(PeriodeAnggaranMetadata.ColumnNames.IsClosed, 3, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = PeriodeAnggaranMetadata.PropertyNames.IsClosed;
			_columns.Add(c);
				
		}
		#endregion	
	
		static public PeriodeAnggaranMetadata Meta()
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
			 public const string StartPeriod = "Start_Period";
			 public const string EndPeriod = "End_Period";
			 public const string IsClosed = "Is_Closed";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string StartPeriod = "StartPeriod";
			 public const string EndPeriod = "EndPeriod";
			 public const string IsClosed = "IsClosed";
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
			lock (typeof(PeriodeAnggaranMetadata))
			{
				if(PeriodeAnggaranMetadata.mapDelegates == null)
				{
					PeriodeAnggaranMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (PeriodeAnggaranMetadata.meta == null)
				{
					PeriodeAnggaranMetadata.meta = new PeriodeAnggaranMetadata();
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
				

				meta.AddTypeMap("Id", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("StartPeriod", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("EndPeriod", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("IsClosed", new esTypeMap("bit", "System.Boolean"));			
				
				
				
				meta.Source = "PeriodeAnggaran";
				meta.Destination = "PeriodeAnggaran";
				
				meta.spInsert = "proc_PeriodeAnggaranInsert";				
				meta.spUpdate = "proc_PeriodeAnggaranUpdate";		
				meta.spDelete = "proc_PeriodeAnggaranDelete";
				meta.spLoadAll = "proc_PeriodeAnggaranLoadAll";
				meta.spLoadByPrimaryKey = "proc_PeriodeAnggaranLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private PeriodeAnggaranMetadata meta;
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
	/// Encapsulates the 'PeriodeAnggaran' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(PeriodeAnggaran))]	
	[XmlType("PeriodeAnggaran")]
	public partial class PeriodeAnggaran : esPeriodeAnggaran
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new PeriodeAnggaran();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int64 id)
		{
			var obj = new PeriodeAnggaran();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int64 id, esSqlAccessType sqlAccessType)
		{
			var obj = new PeriodeAnggaran();
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
	[XmlType("PeriodeAnggaranCollection")]
	public partial class PeriodeAnggaranCollection : esPeriodeAnggaranCollection, IEnumerable<PeriodeAnggaran>
	{
		public PeriodeAnggaran FindByPrimaryKey(System.Int64 id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(PeriodeAnggaran))]
		public class PeriodeAnggaranCollectionWCFPacket : esCollectionWCFPacket<PeriodeAnggaranCollection>
		{
			public static implicit operator PeriodeAnggaranCollection(PeriodeAnggaranCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator PeriodeAnggaranCollectionWCFPacket(PeriodeAnggaranCollection collection)
			{
				return new PeriodeAnggaranCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class PeriodeAnggaranQuery : esPeriodeAnggaranQuery
	{
		public PeriodeAnggaranQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "PeriodeAnggaranQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(PeriodeAnggaranQuery query)
		{
			return PeriodeAnggaranQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator PeriodeAnggaranQuery(string query)
		{
			return (PeriodeAnggaranQuery)PeriodeAnggaranQuery.SerializeHelper.FromXml(query, typeof(PeriodeAnggaranQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esPeriodeAnggaran : esEntity
	{
		public esPeriodeAnggaran()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int64 id)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int64 id)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int64 id)
		{
			PeriodeAnggaranQuery query = new PeriodeAnggaranQuery();
			query.Where(query.Id == id);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int64 id)
		{
			esParameters parms = new esParameters();
			parms.Add("Id", id);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to PeriodeAnggaran.id
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int64? Id
		{
			get
			{
				return base.GetSystemInt64(PeriodeAnggaranMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemInt64(PeriodeAnggaranMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(PeriodeAnggaranMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to PeriodeAnggaran.Start_Period
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? StartPeriod
		{
			get
			{
				return base.GetSystemDateTime(PeriodeAnggaranMetadata.ColumnNames.StartPeriod);
			}
			
			set
			{
				if(base.SetSystemDateTime(PeriodeAnggaranMetadata.ColumnNames.StartPeriod, value))
				{
					OnPropertyChanged(PeriodeAnggaranMetadata.PropertyNames.StartPeriod);
				}
			}
		}		
		
		/// <summary>
		/// Maps to PeriodeAnggaran.End_Period
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? EndPeriod
		{
			get
			{
				return base.GetSystemDateTime(PeriodeAnggaranMetadata.ColumnNames.EndPeriod);
			}
			
			set
			{
				if(base.SetSystemDateTime(PeriodeAnggaranMetadata.ColumnNames.EndPeriod, value))
				{
					OnPropertyChanged(PeriodeAnggaranMetadata.PropertyNames.EndPeriod);
				}
			}
		}		
		
		/// <summary>
		/// Maps to PeriodeAnggaran.Is_Closed
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Boolean? IsClosed
		{
			get
			{
				return base.GetSystemBoolean(PeriodeAnggaranMetadata.ColumnNames.IsClosed);
			}
			
			set
			{
				if(base.SetSystemBoolean(PeriodeAnggaranMetadata.ColumnNames.IsClosed, value))
				{
					OnPropertyChanged(PeriodeAnggaranMetadata.PropertyNames.IsClosed);
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
						case "StartPeriod": this.str().StartPeriod = (string)value; break;							
						case "EndPeriod": this.str().EndPeriod = (string)value; break;							
						case "IsClosed": this.str().IsClosed = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Int64)
								this.Id = (System.Int64?)value;
								OnPropertyChanged(PeriodeAnggaranMetadata.PropertyNames.Id);
							break;
						
						case "StartPeriod":
						
							if (value == null || value is System.DateTime)
								this.StartPeriod = (System.DateTime?)value;
								OnPropertyChanged(PeriodeAnggaranMetadata.PropertyNames.StartPeriod);
							break;
						
						case "EndPeriod":
						
							if (value == null || value is System.DateTime)
								this.EndPeriod = (System.DateTime?)value;
								OnPropertyChanged(PeriodeAnggaranMetadata.PropertyNames.EndPeriod);
							break;
						
						case "IsClosed":
						
							if (value == null || value is System.Boolean)
								this.IsClosed = (System.Boolean?)value;
								OnPropertyChanged(PeriodeAnggaranMetadata.PropertyNames.IsClosed);
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
			public esStrings(esPeriodeAnggaran entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Id
			{
				get
				{
					System.Int64? data = entity.Id;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Id = null;
					else entity.Id = Convert.ToInt64(value);
				}
			}
				
			public System.String StartPeriod
			{
				get
				{
					System.DateTime? data = entity.StartPeriod;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.StartPeriod = null;
					else entity.StartPeriod = Convert.ToDateTime(value);
				}
			}
				
			public System.String EndPeriod
			{
				get
				{
					System.DateTime? data = entity.EndPeriod;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.EndPeriod = null;
					else entity.EndPeriod = Convert.ToDateTime(value);
				}
			}
				
			public System.String IsClosed
			{
				get
				{
					System.Boolean? data = entity.IsClosed;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsClosed = null;
					else entity.IsClosed = Convert.ToBoolean(value);
				}
			}
			

			private esPeriodeAnggaran entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return PeriodeAnggaranMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public PeriodeAnggaranQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new PeriodeAnggaranQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(PeriodeAnggaranQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(PeriodeAnggaranQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private PeriodeAnggaranQuery query;		
	}



	[Serializable]
	abstract public partial class esPeriodeAnggaranCollection : esEntityCollection<PeriodeAnggaran>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return PeriodeAnggaranMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "PeriodeAnggaranCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public PeriodeAnggaranQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new PeriodeAnggaranQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(PeriodeAnggaranQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new PeriodeAnggaranQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(PeriodeAnggaranQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((PeriodeAnggaranQuery)query);
		}

		#endregion
		
		private PeriodeAnggaranQuery query;
	}



	[Serializable]
	abstract public partial class esPeriodeAnggaranQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return PeriodeAnggaranMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Id": return this.Id;
				case "StartPeriod": return this.StartPeriod;
				case "EndPeriod": return this.EndPeriod;
				case "IsClosed": return this.IsClosed;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, PeriodeAnggaranMetadata.ColumnNames.Id, esSystemType.Int64); }
		} 
		
		public esQueryItem StartPeriod
		{
			get { return new esQueryItem(this, PeriodeAnggaranMetadata.ColumnNames.StartPeriod, esSystemType.DateTime); }
		} 
		
		public esQueryItem EndPeriod
		{
			get { return new esQueryItem(this, PeriodeAnggaranMetadata.ColumnNames.EndPeriod, esSystemType.DateTime); }
		} 
		
		public esQueryItem IsClosed
		{
			get { return new esQueryItem(this, PeriodeAnggaranMetadata.ColumnNames.IsClosed, esSystemType.Boolean); }
		} 
		
		#endregion
		
	}


	
	public partial class PeriodeAnggaran : esPeriodeAnggaran
	{

		#region KasCollectionByPeriodeId - Zero To Many
		
		static public esPrefetchMap Prefetch_KasCollectionByPeriodeId
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = RSCM_BKU_Web.BusinessObjects.PeriodeAnggaran.KasCollectionByPeriodeId_Delegate;
				map.PropertyName = "KasCollectionByPeriodeId";
				map.MyColumnName = "PERIODE_ID";
				map.ParentColumnName = "id";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void KasCollectionByPeriodeId_Delegate(esPrefetchParameters data)
		{
			PeriodeAnggaranQuery parent = new PeriodeAnggaranQuery(data.NextAlias());

			KasQuery me = data.You != null ? data.You as KasQuery : new KasQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.Id == me.PeriodeId);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_KAS_PeriodeAnggaran
		/// </summary>

		[XmlIgnore]
		public KasCollection KasCollectionByPeriodeId
		{
			get
			{
				if(this._KasCollectionByPeriodeId == null)
				{
					this._KasCollectionByPeriodeId = new KasCollection();
					this._KasCollectionByPeriodeId.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("KasCollectionByPeriodeId", this._KasCollectionByPeriodeId);
				
					if (this.Id != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._KasCollectionByPeriodeId.Query.Where(this._KasCollectionByPeriodeId.Query.PeriodeId == this.Id);
							this._KasCollectionByPeriodeId.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._KasCollectionByPeriodeId.fks.Add(KasMetadata.ColumnNames.PeriodeId, this.Id);
					}
				}

				return this._KasCollectionByPeriodeId;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._KasCollectionByPeriodeId != null) 
				{ 
					this.RemovePostSave("KasCollectionByPeriodeId"); 
					this._KasCollectionByPeriodeId = null;
					
				} 
			} 			
		}
			
		
		private KasCollection _KasCollectionByPeriodeId;
		#endregion

		#region RabCollectionByPeriodId - Zero To Many
		
		static public esPrefetchMap Prefetch_RabCollectionByPeriodId
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = RSCM_BKU_Web.BusinessObjects.PeriodeAnggaran.RabCollectionByPeriodId_Delegate;
				map.PropertyName = "RabCollectionByPeriodId";
				map.MyColumnName = "PERIOD_ID";
				map.ParentColumnName = "id";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void RabCollectionByPeriodId_Delegate(esPrefetchParameters data)
		{
			PeriodeAnggaranQuery parent = new PeriodeAnggaranQuery(data.NextAlias());

			RabQuery me = data.You != null ? data.You as RabQuery : new RabQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.Id == me.PeriodId);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_RAB_PeriodeAnggaran
		/// </summary>

		[XmlIgnore]
		public RabCollection RabCollectionByPeriodId
		{
			get
			{
				if(this._RabCollectionByPeriodId == null)
				{
					this._RabCollectionByPeriodId = new RabCollection();
					this._RabCollectionByPeriodId.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("RabCollectionByPeriodId", this._RabCollectionByPeriodId);
				
					if (this.Id != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._RabCollectionByPeriodId.Query.Where(this._RabCollectionByPeriodId.Query.PeriodId == this.Id);
							this._RabCollectionByPeriodId.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._RabCollectionByPeriodId.fks.Add(RabMetadata.ColumnNames.PeriodId, this.Id);
					}
				}

				return this._RabCollectionByPeriodId;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._RabCollectionByPeriodId != null) 
				{ 
					this.RemovePostSave("RabCollectionByPeriodId"); 
					this._RabCollectionByPeriodId = null;
					
				} 
			} 			
		}
			
		
		private RabCollection _RabCollectionByPeriodId;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "KasCollectionByPeriodeId":
					coll = this.KasCollectionByPeriodeId;
					break;
				case "RabCollectionByPeriodId":
					coll = this.RabCollectionByPeriodId;
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
			
			props.Add(new esPropertyDescriptor(this, "KasCollectionByPeriodeId", typeof(KasCollection), new Kas()));
			props.Add(new esPropertyDescriptor(this, "RabCollectionByPeriodId", typeof(RabCollection), new Rab()));
		
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
			if(this._KasCollectionByPeriodeId != null)
			{
				Apply(this._KasCollectionByPeriodeId, "PeriodeId", this.Id);
			}
			if(this._RabCollectionByPeriodId != null)
			{
				Apply(this._RabCollectionByPeriodId, "PeriodId", this.Id);
			}
		}
		
	}
	



	[Serializable]
	public partial class PeriodeAnggaranMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected PeriodeAnggaranMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(PeriodeAnggaranMetadata.ColumnNames.Id, 0, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = PeriodeAnggaranMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 19;
			m_columns.Add(c);
				
			c = new esColumnMetadata(PeriodeAnggaranMetadata.ColumnNames.StartPeriod, 1, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = PeriodeAnggaranMetadata.PropertyNames.StartPeriod;
			m_columns.Add(c);
				
			c = new esColumnMetadata(PeriodeAnggaranMetadata.ColumnNames.EndPeriod, 2, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = PeriodeAnggaranMetadata.PropertyNames.EndPeriod;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(PeriodeAnggaranMetadata.ColumnNames.IsClosed, 3, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = PeriodeAnggaranMetadata.PropertyNames.IsClosed;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public PeriodeAnggaranMetadata Meta()
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
			 public const string StartPeriod = "Start_Period";
			 public const string EndPeriod = "End_Period";
			 public const string IsClosed = "Is_Closed";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string StartPeriod = "StartPeriod";
			 public const string EndPeriod = "EndPeriod";
			 public const string IsClosed = "IsClosed";
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
			lock (typeof(PeriodeAnggaranMetadata))
			{
				if(PeriodeAnggaranMetadata.mapDelegates == null)
				{
					PeriodeAnggaranMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (PeriodeAnggaranMetadata.meta == null)
				{
					PeriodeAnggaranMetadata.meta = new PeriodeAnggaranMetadata();
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


				meta.AddTypeMap("Id", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("StartPeriod", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("EndPeriod", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("IsClosed", new esTypeMap("bit", "System.Boolean"));			
				
				
				
				meta.Source = "PeriodeAnggaran";
				meta.Destination = "PeriodeAnggaran";
				
				meta.spInsert = "proc_PeriodeAnggaranInsert";				
				meta.spUpdate = "proc_PeriodeAnggaranUpdate";		
				meta.spDelete = "proc_PeriodeAnggaranDelete";
				meta.spLoadAll = "proc_PeriodeAnggaranLoadAll";
				meta.spLoadByPrimaryKey = "proc_PeriodeAnggaranLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private PeriodeAnggaranMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
>>>>>>> republish

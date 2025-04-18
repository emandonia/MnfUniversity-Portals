﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MnfUniversity_Portals.UI
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="menofeya")]
	public partial class MISResultDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertED_STUD(ED_STUD instance);
    partial void UpdateED_STUD(ED_STUD instance);
    partial void DeleteED_STUD(ED_STUD instance);
    #endregion
		
		public MISResultDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["menofeyaConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MISResultDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MISResultDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MISResultDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MISResultDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ED_STUD> ED_STUDs
		{
			get
			{
				return this.GetTable<ED_STUD>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.natega2017")]
		public ISingleResult<natega2017Result> natega2017([global::System.Data.Linq.Mapping.ParameterAttribute(Name="NationalId", DbType="NVarChar(16)")] string nationalId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nationalId);
			return ((ISingleResult<natega2017Result>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.StudentInfo2017")]
		public ISingleResult<StudentInfo2017Result> StudentInfo2017([global::System.Data.Linq.Mapping.ParameterAttribute(Name="NationalId", DbType="NVarChar(16)")] string nationalId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nationalId);
			return ((ISingleResult<StudentInfo2017Result>)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ED_STUD")]
	public partial class ED_STUD : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private decimal _ED_STUD_ID;
		
		private string _STUD_CODE;
		
		private string _NATIONAL_NUMBER;
		
		private string _FULL_NAME_AR;
		
		private string _CL_FULL_NAME_AR;
		
		private string _STUD_NAME_AR;
		
		private string _CL_STUD_NAME_AR;
		
		private string _FATHER_NAME_AR;
		
		private string _CL_FATHER_NAME_AR;
		
		private string _GRANDFATHER_NAME_AR;
		
		private string _CL_GRANDFATHER_NAME_AR;
		
		private string _FAMILY_NAME_AR;
		
		private string _CL_FAMILY_NAME_AR;
		
		private string _FULL_NAME_EN;
		
		private string _STUD_NAME_EN;
		
		private string _FATHER_NAME_EN;
		
		private string _GRANDFATHER_NAME_EN;
		
		private string _FAMILY_NAME_EN;
		
		private string _FATHER_PROFESSION;
		
		private string _FATHER_NATIONAL_NUMBER;
		
		private string _MOTHER_NATIONAL_NUMBER;
		
		private string _MOTHER_NAME_AR;
		
		private string _CL_MOTHER_NAME_AR;
		
		private string _MOTHER_NAME_EN;
		
		private decimal _GS_CODE_GENDER_ID;
		
		private decimal _GS_CODE_RELIGION_ID;
		
		private string _BIRTH_REG_NUMBER;
		
		private System.Nullable<System.DateTime> _BIRTH_DATE;
		
		private System.Nullable<decimal> _GS_BIRTH_COUNTRY_NODE_ID;
		
		private decimal _GS_COUNTRY_INFO_ID_1;
		
		private System.Nullable<decimal> _GS_COUNTRY_INFO_ID_2;
		
		private decimal _AS_FACULTY_INFO_ID;
		
		private string _STUD_PHOTO;
		
		private string _USER_ITEC;
		
		private string _PASSWORD_ITEC;
		
		private string _ONLINE_PASSWORD;
		
		private string _S;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnED_STUD_IDChanging(decimal value);
    partial void OnED_STUD_IDChanged();
    partial void OnSTUD_CODEChanging(string value);
    partial void OnSTUD_CODEChanged();
    partial void OnNATIONAL_NUMBERChanging(string value);
    partial void OnNATIONAL_NUMBERChanged();
    partial void OnFULL_NAME_ARChanging(string value);
    partial void OnFULL_NAME_ARChanged();
    partial void OnCL_FULL_NAME_ARChanging(string value);
    partial void OnCL_FULL_NAME_ARChanged();
    partial void OnSTUD_NAME_ARChanging(string value);
    partial void OnSTUD_NAME_ARChanged();
    partial void OnCL_STUD_NAME_ARChanging(string value);
    partial void OnCL_STUD_NAME_ARChanged();
    partial void OnFATHER_NAME_ARChanging(string value);
    partial void OnFATHER_NAME_ARChanged();
    partial void OnCL_FATHER_NAME_ARChanging(string value);
    partial void OnCL_FATHER_NAME_ARChanged();
    partial void OnGRANDFATHER_NAME_ARChanging(string value);
    partial void OnGRANDFATHER_NAME_ARChanged();
    partial void OnCL_GRANDFATHER_NAME_ARChanging(string value);
    partial void OnCL_GRANDFATHER_NAME_ARChanged();
    partial void OnFAMILY_NAME_ARChanging(string value);
    partial void OnFAMILY_NAME_ARChanged();
    partial void OnCL_FAMILY_NAME_ARChanging(string value);
    partial void OnCL_FAMILY_NAME_ARChanged();
    partial void OnFULL_NAME_ENChanging(string value);
    partial void OnFULL_NAME_ENChanged();
    partial void OnSTUD_NAME_ENChanging(string value);
    partial void OnSTUD_NAME_ENChanged();
    partial void OnFATHER_NAME_ENChanging(string value);
    partial void OnFATHER_NAME_ENChanged();
    partial void OnGRANDFATHER_NAME_ENChanging(string value);
    partial void OnGRANDFATHER_NAME_ENChanged();
    partial void OnFAMILY_NAME_ENChanging(string value);
    partial void OnFAMILY_NAME_ENChanged();
    partial void OnFATHER_PROFESSIONChanging(string value);
    partial void OnFATHER_PROFESSIONChanged();
    partial void OnFATHER_NATIONAL_NUMBERChanging(string value);
    partial void OnFATHER_NATIONAL_NUMBERChanged();
    partial void OnMOTHER_NATIONAL_NUMBERChanging(string value);
    partial void OnMOTHER_NATIONAL_NUMBERChanged();
    partial void OnMOTHER_NAME_ARChanging(string value);
    partial void OnMOTHER_NAME_ARChanged();
    partial void OnCL_MOTHER_NAME_ARChanging(string value);
    partial void OnCL_MOTHER_NAME_ARChanged();
    partial void OnMOTHER_NAME_ENChanging(string value);
    partial void OnMOTHER_NAME_ENChanged();
    partial void OnGS_CODE_GENDER_IDChanging(decimal value);
    partial void OnGS_CODE_GENDER_IDChanged();
    partial void OnGS_CODE_RELIGION_IDChanging(decimal value);
    partial void OnGS_CODE_RELIGION_IDChanged();
    partial void OnBIRTH_REG_NUMBERChanging(string value);
    partial void OnBIRTH_REG_NUMBERChanged();
    partial void OnBIRTH_DATEChanging(System.Nullable<System.DateTime> value);
    partial void OnBIRTH_DATEChanged();
    partial void OnGS_BIRTH_COUNTRY_NODE_IDChanging(System.Nullable<decimal> value);
    partial void OnGS_BIRTH_COUNTRY_NODE_IDChanged();
    partial void OnGS_COUNTRY_INFO_ID_1Changing(decimal value);
    partial void OnGS_COUNTRY_INFO_ID_1Changed();
    partial void OnGS_COUNTRY_INFO_ID_2Changing(System.Nullable<decimal> value);
    partial void OnGS_COUNTRY_INFO_ID_2Changed();
    partial void OnAS_FACULTY_INFO_IDChanging(decimal value);
    partial void OnAS_FACULTY_INFO_IDChanged();
    partial void OnSTUD_PHOTOChanging(string value);
    partial void OnSTUD_PHOTOChanged();
    partial void OnUSER_ITECChanging(string value);
    partial void OnUSER_ITECChanged();
    partial void OnPASSWORD_ITECChanging(string value);
    partial void OnPASSWORD_ITECChanged();
    partial void OnONLINE_PASSWORDChanging(string value);
    partial void OnONLINE_PASSWORDChanged();
    partial void OnSChanging(string value);
    partial void OnSChanged();
    #endregion
		
		public ED_STUD()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ED_STUD_ID", DbType="Decimal(9,0) NOT NULL", IsPrimaryKey=true)]
		public decimal ED_STUD_ID
		{
			get
			{
				return this._ED_STUD_ID;
			}
			set
			{
				if ((this._ED_STUD_ID != value))
				{
					this.OnED_STUD_IDChanging(value);
					this.SendPropertyChanging();
					this._ED_STUD_ID = value;
					this.SendPropertyChanged("ED_STUD_ID");
					this.OnED_STUD_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STUD_CODE", DbType="NVarChar(30)")]
		public string STUD_CODE
		{
			get
			{
				return this._STUD_CODE;
			}
			set
			{
				if ((this._STUD_CODE != value))
				{
					this.OnSTUD_CODEChanging(value);
					this.SendPropertyChanging();
					this._STUD_CODE = value;
					this.SendPropertyChanged("STUD_CODE");
					this.OnSTUD_CODEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NATIONAL_NUMBER", DbType="NVarChar(16)")]
		public string NATIONAL_NUMBER
		{
			get
			{
				return this._NATIONAL_NUMBER;
			}
			set
			{
				if ((this._NATIONAL_NUMBER != value))
				{
					this.OnNATIONAL_NUMBERChanging(value);
					this.SendPropertyChanging();
					this._NATIONAL_NUMBER = value;
					this.SendPropertyChanged("NATIONAL_NUMBER");
					this.OnNATIONAL_NUMBERChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FULL_NAME_AR", DbType="NVarChar(150)")]
		public string FULL_NAME_AR
		{
			get
			{
				return this._FULL_NAME_AR;
			}
			set
			{
				if ((this._FULL_NAME_AR != value))
				{
					this.OnFULL_NAME_ARChanging(value);
					this.SendPropertyChanging();
					this._FULL_NAME_AR = value;
					this.SendPropertyChanged("FULL_NAME_AR");
					this.OnFULL_NAME_ARChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CL_FULL_NAME_AR", DbType="NVarChar(150)")]
		public string CL_FULL_NAME_AR
		{
			get
			{
				return this._CL_FULL_NAME_AR;
			}
			set
			{
				if ((this._CL_FULL_NAME_AR != value))
				{
					this.OnCL_FULL_NAME_ARChanging(value);
					this.SendPropertyChanging();
					this._CL_FULL_NAME_AR = value;
					this.SendPropertyChanged("CL_FULL_NAME_AR");
					this.OnCL_FULL_NAME_ARChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STUD_NAME_AR", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string STUD_NAME_AR
		{
			get
			{
				return this._STUD_NAME_AR;
			}
			set
			{
				if ((this._STUD_NAME_AR != value))
				{
					this.OnSTUD_NAME_ARChanging(value);
					this.SendPropertyChanging();
					this._STUD_NAME_AR = value;
					this.SendPropertyChanged("STUD_NAME_AR");
					this.OnSTUD_NAME_ARChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CL_STUD_NAME_AR", DbType="NVarChar(50)")]
		public string CL_STUD_NAME_AR
		{
			get
			{
				return this._CL_STUD_NAME_AR;
			}
			set
			{
				if ((this._CL_STUD_NAME_AR != value))
				{
					this.OnCL_STUD_NAME_ARChanging(value);
					this.SendPropertyChanging();
					this._CL_STUD_NAME_AR = value;
					this.SendPropertyChanged("CL_STUD_NAME_AR");
					this.OnCL_STUD_NAME_ARChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FATHER_NAME_AR", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string FATHER_NAME_AR
		{
			get
			{
				return this._FATHER_NAME_AR;
			}
			set
			{
				if ((this._FATHER_NAME_AR != value))
				{
					this.OnFATHER_NAME_ARChanging(value);
					this.SendPropertyChanging();
					this._FATHER_NAME_AR = value;
					this.SendPropertyChanged("FATHER_NAME_AR");
					this.OnFATHER_NAME_ARChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CL_FATHER_NAME_AR", DbType="NVarChar(50)")]
		public string CL_FATHER_NAME_AR
		{
			get
			{
				return this._CL_FATHER_NAME_AR;
			}
			set
			{
				if ((this._CL_FATHER_NAME_AR != value))
				{
					this.OnCL_FATHER_NAME_ARChanging(value);
					this.SendPropertyChanging();
					this._CL_FATHER_NAME_AR = value;
					this.SendPropertyChanged("CL_FATHER_NAME_AR");
					this.OnCL_FATHER_NAME_ARChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GRANDFATHER_NAME_AR", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string GRANDFATHER_NAME_AR
		{
			get
			{
				return this._GRANDFATHER_NAME_AR;
			}
			set
			{
				if ((this._GRANDFATHER_NAME_AR != value))
				{
					this.OnGRANDFATHER_NAME_ARChanging(value);
					this.SendPropertyChanging();
					this._GRANDFATHER_NAME_AR = value;
					this.SendPropertyChanged("GRANDFATHER_NAME_AR");
					this.OnGRANDFATHER_NAME_ARChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CL_GRANDFATHER_NAME_AR", DbType="NVarChar(50)")]
		public string CL_GRANDFATHER_NAME_AR
		{
			get
			{
				return this._CL_GRANDFATHER_NAME_AR;
			}
			set
			{
				if ((this._CL_GRANDFATHER_NAME_AR != value))
				{
					this.OnCL_GRANDFATHER_NAME_ARChanging(value);
					this.SendPropertyChanging();
					this._CL_GRANDFATHER_NAME_AR = value;
					this.SendPropertyChanged("CL_GRANDFATHER_NAME_AR");
					this.OnCL_GRANDFATHER_NAME_ARChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FAMILY_NAME_AR", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string FAMILY_NAME_AR
		{
			get
			{
				return this._FAMILY_NAME_AR;
			}
			set
			{
				if ((this._FAMILY_NAME_AR != value))
				{
					this.OnFAMILY_NAME_ARChanging(value);
					this.SendPropertyChanging();
					this._FAMILY_NAME_AR = value;
					this.SendPropertyChanged("FAMILY_NAME_AR");
					this.OnFAMILY_NAME_ARChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CL_FAMILY_NAME_AR", DbType="NVarChar(50)")]
		public string CL_FAMILY_NAME_AR
		{
			get
			{
				return this._CL_FAMILY_NAME_AR;
			}
			set
			{
				if ((this._CL_FAMILY_NAME_AR != value))
				{
					this.OnCL_FAMILY_NAME_ARChanging(value);
					this.SendPropertyChanging();
					this._CL_FAMILY_NAME_AR = value;
					this.SendPropertyChanged("CL_FAMILY_NAME_AR");
					this.OnCL_FAMILY_NAME_ARChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FULL_NAME_EN", DbType="NVarChar(150)")]
		public string FULL_NAME_EN
		{
			get
			{
				return this._FULL_NAME_EN;
			}
			set
			{
				if ((this._FULL_NAME_EN != value))
				{
					this.OnFULL_NAME_ENChanging(value);
					this.SendPropertyChanging();
					this._FULL_NAME_EN = value;
					this.SendPropertyChanged("FULL_NAME_EN");
					this.OnFULL_NAME_ENChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STUD_NAME_EN", DbType="NVarChar(50)")]
		public string STUD_NAME_EN
		{
			get
			{
				return this._STUD_NAME_EN;
			}
			set
			{
				if ((this._STUD_NAME_EN != value))
				{
					this.OnSTUD_NAME_ENChanging(value);
					this.SendPropertyChanging();
					this._STUD_NAME_EN = value;
					this.SendPropertyChanged("STUD_NAME_EN");
					this.OnSTUD_NAME_ENChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FATHER_NAME_EN", DbType="NVarChar(50)")]
		public string FATHER_NAME_EN
		{
			get
			{
				return this._FATHER_NAME_EN;
			}
			set
			{
				if ((this._FATHER_NAME_EN != value))
				{
					this.OnFATHER_NAME_ENChanging(value);
					this.SendPropertyChanging();
					this._FATHER_NAME_EN = value;
					this.SendPropertyChanged("FATHER_NAME_EN");
					this.OnFATHER_NAME_ENChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GRANDFATHER_NAME_EN", DbType="NVarChar(50)")]
		public string GRANDFATHER_NAME_EN
		{
			get
			{
				return this._GRANDFATHER_NAME_EN;
			}
			set
			{
				if ((this._GRANDFATHER_NAME_EN != value))
				{
					this.OnGRANDFATHER_NAME_ENChanging(value);
					this.SendPropertyChanging();
					this._GRANDFATHER_NAME_EN = value;
					this.SendPropertyChanged("GRANDFATHER_NAME_EN");
					this.OnGRANDFATHER_NAME_ENChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FAMILY_NAME_EN", DbType="NVarChar(50)")]
		public string FAMILY_NAME_EN
		{
			get
			{
				return this._FAMILY_NAME_EN;
			}
			set
			{
				if ((this._FAMILY_NAME_EN != value))
				{
					this.OnFAMILY_NAME_ENChanging(value);
					this.SendPropertyChanging();
					this._FAMILY_NAME_EN = value;
					this.SendPropertyChanged("FAMILY_NAME_EN");
					this.OnFAMILY_NAME_ENChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FATHER_PROFESSION", DbType="NVarChar(150)")]
		public string FATHER_PROFESSION
		{
			get
			{
				return this._FATHER_PROFESSION;
			}
			set
			{
				if ((this._FATHER_PROFESSION != value))
				{
					this.OnFATHER_PROFESSIONChanging(value);
					this.SendPropertyChanging();
					this._FATHER_PROFESSION = value;
					this.SendPropertyChanged("FATHER_PROFESSION");
					this.OnFATHER_PROFESSIONChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FATHER_NATIONAL_NUMBER", DbType="NVarChar(16)")]
		public string FATHER_NATIONAL_NUMBER
		{
			get
			{
				return this._FATHER_NATIONAL_NUMBER;
			}
			set
			{
				if ((this._FATHER_NATIONAL_NUMBER != value))
				{
					this.OnFATHER_NATIONAL_NUMBERChanging(value);
					this.SendPropertyChanging();
					this._FATHER_NATIONAL_NUMBER = value;
					this.SendPropertyChanged("FATHER_NATIONAL_NUMBER");
					this.OnFATHER_NATIONAL_NUMBERChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MOTHER_NATIONAL_NUMBER", DbType="NVarChar(16)")]
		public string MOTHER_NATIONAL_NUMBER
		{
			get
			{
				return this._MOTHER_NATIONAL_NUMBER;
			}
			set
			{
				if ((this._MOTHER_NATIONAL_NUMBER != value))
				{
					this.OnMOTHER_NATIONAL_NUMBERChanging(value);
					this.SendPropertyChanging();
					this._MOTHER_NATIONAL_NUMBER = value;
					this.SendPropertyChanged("MOTHER_NATIONAL_NUMBER");
					this.OnMOTHER_NATIONAL_NUMBERChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MOTHER_NAME_AR", DbType="NVarChar(100)")]
		public string MOTHER_NAME_AR
		{
			get
			{
				return this._MOTHER_NAME_AR;
			}
			set
			{
				if ((this._MOTHER_NAME_AR != value))
				{
					this.OnMOTHER_NAME_ARChanging(value);
					this.SendPropertyChanging();
					this._MOTHER_NAME_AR = value;
					this.SendPropertyChanged("MOTHER_NAME_AR");
					this.OnMOTHER_NAME_ARChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CL_MOTHER_NAME_AR", DbType="NVarChar(100)")]
		public string CL_MOTHER_NAME_AR
		{
			get
			{
				return this._CL_MOTHER_NAME_AR;
			}
			set
			{
				if ((this._CL_MOTHER_NAME_AR != value))
				{
					this.OnCL_MOTHER_NAME_ARChanging(value);
					this.SendPropertyChanging();
					this._CL_MOTHER_NAME_AR = value;
					this.SendPropertyChanged("CL_MOTHER_NAME_AR");
					this.OnCL_MOTHER_NAME_ARChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MOTHER_NAME_EN", DbType="NVarChar(100)")]
		public string MOTHER_NAME_EN
		{
			get
			{
				return this._MOTHER_NAME_EN;
			}
			set
			{
				if ((this._MOTHER_NAME_EN != value))
				{
					this.OnMOTHER_NAME_ENChanging(value);
					this.SendPropertyChanging();
					this._MOTHER_NAME_EN = value;
					this.SendPropertyChanged("MOTHER_NAME_EN");
					this.OnMOTHER_NAME_ENChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GS_CODE_GENDER_ID", DbType="Decimal(9,0) NOT NULL")]
		public decimal GS_CODE_GENDER_ID
		{
			get
			{
				return this._GS_CODE_GENDER_ID;
			}
			set
			{
				if ((this._GS_CODE_GENDER_ID != value))
				{
					this.OnGS_CODE_GENDER_IDChanging(value);
					this.SendPropertyChanging();
					this._GS_CODE_GENDER_ID = value;
					this.SendPropertyChanged("GS_CODE_GENDER_ID");
					this.OnGS_CODE_GENDER_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GS_CODE_RELIGION_ID", DbType="Decimal(9,0) NOT NULL")]
		public decimal GS_CODE_RELIGION_ID
		{
			get
			{
				return this._GS_CODE_RELIGION_ID;
			}
			set
			{
				if ((this._GS_CODE_RELIGION_ID != value))
				{
					this.OnGS_CODE_RELIGION_IDChanging(value);
					this.SendPropertyChanging();
					this._GS_CODE_RELIGION_ID = value;
					this.SendPropertyChanged("GS_CODE_RELIGION_ID");
					this.OnGS_CODE_RELIGION_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BIRTH_REG_NUMBER", DbType="NVarChar(50)")]
		public string BIRTH_REG_NUMBER
		{
			get
			{
				return this._BIRTH_REG_NUMBER;
			}
			set
			{
				if ((this._BIRTH_REG_NUMBER != value))
				{
					this.OnBIRTH_REG_NUMBERChanging(value);
					this.SendPropertyChanging();
					this._BIRTH_REG_NUMBER = value;
					this.SendPropertyChanged("BIRTH_REG_NUMBER");
					this.OnBIRTH_REG_NUMBERChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BIRTH_DATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> BIRTH_DATE
		{
			get
			{
				return this._BIRTH_DATE;
			}
			set
			{
				if ((this._BIRTH_DATE != value))
				{
					this.OnBIRTH_DATEChanging(value);
					this.SendPropertyChanging();
					this._BIRTH_DATE = value;
					this.SendPropertyChanged("BIRTH_DATE");
					this.OnBIRTH_DATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GS_BIRTH_COUNTRY_NODE_ID", DbType="Decimal(9,0)")]
		public System.Nullable<decimal> GS_BIRTH_COUNTRY_NODE_ID
		{
			get
			{
				return this._GS_BIRTH_COUNTRY_NODE_ID;
			}
			set
			{
				if ((this._GS_BIRTH_COUNTRY_NODE_ID != value))
				{
					this.OnGS_BIRTH_COUNTRY_NODE_IDChanging(value);
					this.SendPropertyChanging();
					this._GS_BIRTH_COUNTRY_NODE_ID = value;
					this.SendPropertyChanged("GS_BIRTH_COUNTRY_NODE_ID");
					this.OnGS_BIRTH_COUNTRY_NODE_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GS_COUNTRY_INFO_ID_1", DbType="Decimal(9,0) NOT NULL")]
		public decimal GS_COUNTRY_INFO_ID_1
		{
			get
			{
				return this._GS_COUNTRY_INFO_ID_1;
			}
			set
			{
				if ((this._GS_COUNTRY_INFO_ID_1 != value))
				{
					this.OnGS_COUNTRY_INFO_ID_1Changing(value);
					this.SendPropertyChanging();
					this._GS_COUNTRY_INFO_ID_1 = value;
					this.SendPropertyChanged("GS_COUNTRY_INFO_ID_1");
					this.OnGS_COUNTRY_INFO_ID_1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GS_COUNTRY_INFO_ID_2", DbType="Decimal(9,0)")]
		public System.Nullable<decimal> GS_COUNTRY_INFO_ID_2
		{
			get
			{
				return this._GS_COUNTRY_INFO_ID_2;
			}
			set
			{
				if ((this._GS_COUNTRY_INFO_ID_2 != value))
				{
					this.OnGS_COUNTRY_INFO_ID_2Changing(value);
					this.SendPropertyChanging();
					this._GS_COUNTRY_INFO_ID_2 = value;
					this.SendPropertyChanged("GS_COUNTRY_INFO_ID_2");
					this.OnGS_COUNTRY_INFO_ID_2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AS_FACULTY_INFO_ID", DbType="Decimal(9,0) NOT NULL")]
		public decimal AS_FACULTY_INFO_ID
		{
			get
			{
				return this._AS_FACULTY_INFO_ID;
			}
			set
			{
				if ((this._AS_FACULTY_INFO_ID != value))
				{
					this.OnAS_FACULTY_INFO_IDChanging(value);
					this.SendPropertyChanging();
					this._AS_FACULTY_INFO_ID = value;
					this.SendPropertyChanged("AS_FACULTY_INFO_ID");
					this.OnAS_FACULTY_INFO_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STUD_PHOTO", DbType="NVarChar(350)")]
		public string STUD_PHOTO
		{
			get
			{
				return this._STUD_PHOTO;
			}
			set
			{
				if ((this._STUD_PHOTO != value))
				{
					this.OnSTUD_PHOTOChanging(value);
					this.SendPropertyChanging();
					this._STUD_PHOTO = value;
					this.SendPropertyChanged("STUD_PHOTO");
					this.OnSTUD_PHOTOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_ITEC", DbType="NVarChar(100)")]
		public string USER_ITEC
		{
			get
			{
				return this._USER_ITEC;
			}
			set
			{
				if ((this._USER_ITEC != value))
				{
					this.OnUSER_ITECChanging(value);
					this.SendPropertyChanging();
					this._USER_ITEC = value;
					this.SendPropertyChanged("USER_ITEC");
					this.OnUSER_ITECChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PASSWORD_ITEC", DbType="NVarChar(100)")]
		public string PASSWORD_ITEC
		{
			get
			{
				return this._PASSWORD_ITEC;
			}
			set
			{
				if ((this._PASSWORD_ITEC != value))
				{
					this.OnPASSWORD_ITECChanging(value);
					this.SendPropertyChanging();
					this._PASSWORD_ITEC = value;
					this.SendPropertyChanged("PASSWORD_ITEC");
					this.OnPASSWORD_ITECChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ONLINE_PASSWORD", DbType="NVarChar(100)")]
		public string ONLINE_PASSWORD
		{
			get
			{
				return this._ONLINE_PASSWORD;
			}
			set
			{
				if ((this._ONLINE_PASSWORD != value))
				{
					this.OnONLINE_PASSWORDChanging(value);
					this.SendPropertyChanging();
					this._ONLINE_PASSWORD = value;
					this.SendPropertyChanged("ONLINE_PASSWORD");
					this.OnONLINE_PASSWORDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_S", DbType="VarChar(40)")]
		public string S
		{
			get
			{
				return this._S;
			}
			set
			{
				if ((this._S != value))
				{
					this.OnSChanging(value);
					this.SendPropertyChanging();
					this._S = value;
					this.SendPropertyChanged("S");
					this.OnSChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	public partial class natega2017Result
	{
		
		private string _SUBJECT_DESCR_AR;
		
		private string _RATING_DESCR_AR;
		
		public natega2017Result()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SUBJECT_DESCR_AR", DbType="NVarChar(150) NOT NULL", CanBeNull=false)]
		public string SUBJECT_DESCR_AR
		{
			get
			{
				return this._SUBJECT_DESCR_AR;
			}
			set
			{
				if ((this._SUBJECT_DESCR_AR != value))
				{
					this._SUBJECT_DESCR_AR = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RATING_DESCR_AR", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string RATING_DESCR_AR
		{
			get
			{
				return this._RATING_DESCR_AR;
			}
			set
			{
				if ((this._RATING_DESCR_AR != value))
				{
					this._RATING_DESCR_AR = value;
				}
			}
		}
	}
	
	public partial class StudentInfo2017Result
	{
		
		private string _FULL_NAME_AR;
		
		public StudentInfo2017Result()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FULL_NAME_AR", DbType="NVarChar(150)")]
		public string FULL_NAME_AR
		{
			get
			{
				return this._FULL_NAME_AR;
			}
			set
			{
				if ((this._FULL_NAME_AR != value))
				{
					this._FULL_NAME_AR = value;
				}
			}
		}
	}
}
#pragma warning restore 1591

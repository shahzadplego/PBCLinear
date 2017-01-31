//--------------------------------------------------------------------------------------------------
// <auto-generated>
//
//     This code was generated by code generator tool.
//
//     To customize the code use your own partial class. For more info about how to use and customize
//     the generated code see the documentation at http://docs.kentico.com.
//
// </auto-generated>
//--------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using CMS;
using CMS.Helpers;
using CMS.DataEngine;
using CMS.CustomTables.Types;
using CMS.CustomTables;

[assembly: RegisterCustomTable(ProductAssociationsItem.CLASS_NAME, typeof(ProductAssociationsItem))]

namespace CMS.CustomTables.Types
{
	/// <summary>
	/// Represents a content item of type ProductAssociationsItem.
	/// </summary>
	public partial class ProductAssociationsItem : CustomTableItem
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "PbcLinear.ProductAssociations";


		/// <summary>
		/// The instance of the class that provides extended API for working with ProductAssociationsItem fields.
		/// </summary>
		private readonly ProductAssociationsItemFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// Product Category 1.
		/// </summary>
		[DatabaseField]
		public string ProductCategory1
		{
			get
			{
				return ValidationHelper.GetString(GetValue("ProductCategory1"), "");
			}
			set
			{
				SetValue("ProductCategory1", value);
			}
		}


		/// <summary>
		/// Product Category 2.
		/// </summary>
		[DatabaseField]
		public string ProductCategory2
		{
			get
			{
				return ValidationHelper.GetString(GetValue("ProductCategory2"), "");
			}
			set
			{
				SetValue("ProductCategory2", value);
			}
		}


		/// <summary>
		/// Product Category 3.
		/// </summary>
		[DatabaseField]
		public string ProductCategory3
		{
			get
			{
				return ValidationHelper.GetString(GetValue("ProductCategory3"), "");
			}
			set
			{
				SetValue("ProductCategory3", value);
			}
		}


		/// <summary>
		/// Product SKU Number.
		/// </summary>
		[DatabaseField]
		public string ProductSKUNumber
		{
			get
			{
				return ValidationHelper.GetString(GetValue("ProductSKUNumber"), "");
			}
			set
			{
				SetValue("ProductSKUNumber", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with ProductAssociationsItem fields.
		/// </summary>
		public ProductAssociationsItemFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with ProductAssociationsItem fields.
		/// </summary>
		public partial class ProductAssociationsItemFields
		{
			/// <summary>
			/// The content item of type ProductAssociationsItem that is a target of the extended API.
			/// </summary>
			private readonly ProductAssociationsItem mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="ProductAssociationsItemFields" /> class with the specified content item of type ProductAssociationsItem.
			/// </summary>
			/// <param name="instance">The content item of type ProductAssociationsItem that is a target of the extended API.</param>
			public ProductAssociationsItemFields(ProductAssociationsItem instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// Product Category 1.
			/// </summary>
			public string ProductCategory1
			{
				get
				{
					return mInstance.ProductCategory1;
				}
				set
				{
					mInstance.ProductCategory1 = value;
				}
			}


			/// <summary>
			/// Product Category 2.
			/// </summary>
			public string ProductCategory2
			{
				get
				{
					return mInstance.ProductCategory2;
				}
				set
				{
					mInstance.ProductCategory2 = value;
				}
			}


			/// <summary>
			/// Product Category 3.
			/// </summary>
			public string ProductCategory3
			{
				get
				{
					return mInstance.ProductCategory3;
				}
				set
				{
					mInstance.ProductCategory3 = value;
				}
			}


			/// <summary>
			/// Product SKU Number.
			/// </summary>
			public string ProductSKUNumber
			{
				get
				{
					return mInstance.ProductSKUNumber;
				}
				set
				{
					mInstance.ProductSKUNumber = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="ProductAssociationsItem" /> class.
		/// </summary>
		public ProductAssociationsItem() : base(CLASS_NAME)
		{
			mFields = new ProductAssociationsItemFields(this);
		}

		#endregion
	}
}
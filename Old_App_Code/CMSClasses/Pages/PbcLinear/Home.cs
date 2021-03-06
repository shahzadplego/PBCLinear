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
using CMS.DocumentEngine.Types;
using CMS.DocumentEngine;

[assembly: RegisterDocumentType(Home.CLASS_NAME, typeof(Home))]

namespace CMS.DocumentEngine.Types
{
	/// <summary>
	/// Represents a content item of type Home.
	/// </summary>
	public partial class Home : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "PbcLinear.Home";


		/// <summary>
		/// The instance of the class that provides extended API for working with Home fields.
		/// </summary>
		private readonly HomeFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// HomeID.
		/// </summary>
		[DatabaseIDField]
		public int HomeID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("HomeID"), 0);
			}
			set
			{
				SetValue("HomeID", value);
			}
		}


		/// <summary>
		/// #### x #### Dimensions and only jpg, png and gif files.
		/// </summary>
		[DatabaseField]
		public string HeroImage
		{
			get
			{
				return ValidationHelper.GetString(GetValue("HeroImage"), "");
			}
			set
			{
				SetValue("HeroImage", value);
			}
		}


		/// <summary>
		/// H1 Large Text.
		/// </summary>
		[DatabaseField]
		public string H1LargeText
		{
			get
			{
				return ValidationHelper.GetString(GetValue("H1LargeText"), "");
			}
			set
			{
				SetValue("H1LargeText", value);
			}
		}


		/// <summary>
		/// H1 Small Text.
		/// </summary>
		[DatabaseField]
		public string H1SmallText
		{
			get
			{
				return ValidationHelper.GetString(GetValue("H1SmallText"), "");
			}
			set
			{
				SetValue("H1SmallText", value);
			}
		}


		/// <summary>
		/// Industry Section Title.
		/// </summary>
		[DatabaseField]
		public string IndustrySectionTitle
		{
			get
			{
				return ValidationHelper.GetString(GetValue("IndustrySectionTitle"), "");
			}
			set
			{
				SetValue("IndustrySectionTitle", value);
			}
		}


		/// <summary>
		/// Industry Section Description.
		/// </summary>
		[DatabaseField]
		public string IndustrySectionDescription
		{
			get
			{
				return ValidationHelper.GetString(GetValue("IndustrySectionDescription"), "");
			}
			set
			{
				SetValue("IndustrySectionDescription", value);
			}
		}


		/// <summary>
		/// Industry Section CTA Text.
		/// </summary>
		[DatabaseField]
		public string IndustrySectionCtaText
		{
			get
			{
				return ValidationHelper.GetString(GetValue("IndustrySectionCtaText"), "");
			}
			set
			{
				SetValue("IndustrySectionCtaText", value);
			}
		}


		/// <summary>
		/// Industry Section CTA Link.
		/// </summary>
		[DatabaseField]
		public string IndustrySectionCtaLink
		{
			get
			{
				return ValidationHelper.GetString(GetValue("IndustrySectionCtaLink"), "");
			}
			set
			{
				SetValue("IndustrySectionCtaLink", value);
			}
		}


		/// <summary>
		/// Featured Industry Title 1.
		/// </summary>
		[DatabaseField]
		public string FeaturedIndustryTitle1
		{
			get
			{
				return ValidationHelper.GetString(GetValue("FeaturedIndustryTitle1"), "");
			}
			set
			{
				SetValue("FeaturedIndustryTitle1", value);
			}
		}


		/// <summary>
		/// Featured Industry Description 1.
		/// </summary>
		[DatabaseField]
		public string FeaturedIndustryDescription1
		{
			get
			{
				return ValidationHelper.GetString(GetValue("FeaturedIndustryDescription1"), "");
			}
			set
			{
				SetValue("FeaturedIndustryDescription1", value);
			}
		}


		/// <summary>
		/// Featured Industry CTA Link 1.
		/// </summary>
		[DatabaseField]
		public string FeaturedIndustryCtaLink1
		{
			get
			{
				return ValidationHelper.GetString(GetValue("FeaturedIndustryCtaLink1"), "");
			}
			set
			{
				SetValue("FeaturedIndustryCtaLink1", value);
			}
		}


		/// <summary>
		/// Featured Industry Title 2.
		/// </summary>
		[DatabaseField]
		public string FeaturedIndustryTitle2
		{
			get
			{
				return ValidationHelper.GetString(GetValue("FeaturedIndustryTitle2"), "");
			}
			set
			{
				SetValue("FeaturedIndustryTitle2", value);
			}
		}


		/// <summary>
		/// Featured Industry Description 2.
		/// </summary>
		[DatabaseField]
		public string FeaturedIndustryDescription2
		{
			get
			{
				return ValidationHelper.GetString(GetValue("FeaturedIndustryDescription2"), "");
			}
			set
			{
				SetValue("FeaturedIndustryDescription2", value);
			}
		}


		/// <summary>
		/// Featured Industry CTA Link 2.
		/// </summary>
		[DatabaseField]
		public string FeaturedIndustryCtaLink2
		{
			get
			{
				return ValidationHelper.GetString(GetValue("FeaturedIndustryCtaLink2"), "");
			}
			set
			{
				SetValue("FeaturedIndustryCtaLink2", value);
			}
		}


		/// <summary>
		/// Featured Industry Title 3.
		/// </summary>
		[DatabaseField]
		public string FeaturedIndustryTitle3
		{
			get
			{
				return ValidationHelper.GetString(GetValue("FeaturedIndustryTitle3"), "");
			}
			set
			{
				SetValue("FeaturedIndustryTitle3", value);
			}
		}


		/// <summary>
		/// Featured Industry Description 3.
		/// </summary>
		[DatabaseField]
		public string FeaturedIndustryDescription3
		{
			get
			{
				return ValidationHelper.GetString(GetValue("FeaturedIndustryDescription3"), "");
			}
			set
			{
				SetValue("FeaturedIndustryDescription3", value);
			}
		}


		/// <summary>
		/// Featured Industry CTA Link 3.
		/// </summary>
		[DatabaseField]
		public string FeaturedIndustryCtaLink3
		{
			get
			{
				return ValidationHelper.GetString(GetValue("FeaturedIndustryCtaLink3"), "");
			}
			set
			{
				SetValue("FeaturedIndustryCtaLink3", value);
			}
		}


		/// <summary>
		/// Featured Industry Title 4.
		/// </summary>
		[DatabaseField]
		public string FeaturedIndustryTitle4
		{
			get
			{
				return ValidationHelper.GetString(GetValue("FeaturedIndustryTitle4"), "");
			}
			set
			{
				SetValue("FeaturedIndustryTitle4", value);
			}
		}


		/// <summary>
		/// Featured Industry Description 4.
		/// </summary>
		[DatabaseField]
		public string FeaturedIndustryDescription4
		{
			get
			{
				return ValidationHelper.GetString(GetValue("FeaturedIndustryDescription4"), "");
			}
			set
			{
				SetValue("FeaturedIndustryDescription4", value);
			}
		}


		/// <summary>
		/// Featured Industry CTA Link 4.
		/// </summary>
		[DatabaseField]
		public string FeaturedIndustryCtaLink4
		{
			get
			{
				return ValidationHelper.GetString(GetValue("FeaturedIndustryCtaLink4"), "");
			}
			set
			{
				SetValue("FeaturedIndustryCtaLink4", value);
			}
		}


		/// <summary>
		/// ## x ## Dimensions.
		/// </summary>
		[DatabaseField]
		public string Section2ContentWidthImage
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Section2ContentWidthImage"), "");
			}
			set
			{
				SetValue("Section2ContentWidthImage", value);
			}
		}


		/// <summary>
		/// Section 2 Title.
		/// </summary>
		[DatabaseField]
		public string Section2Title
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Section2Title"), "");
			}
			set
			{
				SetValue("Section2Title", value);
			}
		}


		/// <summary>
		/// Section 2 Sub Title.
		/// </summary>
		[DatabaseField]
		public string Section2SubTitle
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Section2SubTitle"), "");
			}
			set
			{
				SetValue("Section2SubTitle", value);
			}
		}


		/// <summary>
		/// Section 2 CTA Text.
		/// </summary>
		[DatabaseField]
		public string Section2CtaText
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Section2CtaText"), "");
			}
			set
			{
				SetValue("Section2CtaText", value);
			}
		}


		/// <summary>
		/// Section 2 CTA Link.
		/// </summary>
		[DatabaseField]
		public string Section2CtaLink
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Section2CtaLink"), "");
			}
			set
			{
				SetValue("Section2CtaLink", value);
			}
		}


		/// <summary>
		/// ## x ## Dimensions.
		/// </summary>
		[DatabaseField]
		public string Section3FullWidthImage
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Section3FullWidthImage"), "");
			}
			set
			{
				SetValue("Section3FullWidthImage", value);
			}
		}


		/// <summary>
		/// Section 3 Full Width Image Title.
		/// </summary>
		[DatabaseField]
		public string Section3FullWidthImageTitle
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Section3FullWidthImageTitle"), "");
			}
			set
			{
				SetValue("Section3FullWidthImageTitle", value);
			}
		}


		/// <summary>
		/// Section 3 Title.
		/// </summary>
		[DatabaseField]
		public string Section3Title
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Section3Title"), "");
			}
			set
			{
				SetValue("Section3Title", value);
			}
		}


		/// <summary>
		/// Section 3 Description.
		/// </summary>
		[DatabaseField]
		public string Section3Description
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Section3Description"), "");
			}
			set
			{
				SetValue("Section3Description", value);
			}
		}


		/// <summary>
		/// Section 3 CTA Text.
		/// </summary>
		[DatabaseField]
		public string Section3CtaText
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Section3CtaText"), "");
			}
			set
			{
				SetValue("Section3CtaText", value);
			}
		}


		/// <summary>
		/// Section 3 CTA Link.
		/// </summary>
		[DatabaseField]
		public string Section3CtaLink
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Section3CtaLink"), "");
			}
			set
			{
				SetValue("Section3CtaLink", value);
			}
		}


		/// <summary>
		/// ## x ## Dimensions.
		/// </summary>
		[DatabaseField]
		public string Section4FullWidthImage
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Section4FullWidthImage"), "");
			}
			set
			{
				SetValue("Section4FullWidthImage", value);
			}
		}


		/// <summary>
		/// Section 4 Full Width Image Title.
		/// </summary>
		[DatabaseField]
		public string Section4FullWidthImageTitle
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Section4FullWidthImageTitle"), "");
			}
			set
			{
				SetValue("Section4FullWidthImageTitle", value);
			}
		}


		/// <summary>
		/// Section 4 Title.
		/// </summary>
		[DatabaseField]
		public string Section4Title
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Section4Title"), "");
			}
			set
			{
				SetValue("Section4Title", value);
			}
		}


		/// <summary>
		/// Section 4 Description.
		/// </summary>
		[DatabaseField]
		public string Section4Description
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Section4Description"), "");
			}
			set
			{
				SetValue("Section4Description", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with Home fields.
		/// </summary>
		public HomeFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with Home fields.
		/// </summary>
		public partial class HomeFields
		{
			/// <summary>
			/// The content item of type Home that is a target of the extended API.
			/// </summary>
			private readonly Home mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="HomeFields" /> class with the specified content item of type Home.
			/// </summary>
			/// <param name="instance">The content item of type Home that is a target of the extended API.</param>
			public HomeFields(Home instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// HomeID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.HomeID;
				}
				set
				{
					mInstance.HomeID = value;
				}
			}


			/// <summary>
			/// #### x #### Dimensions and only jpg, png and gif files.
			/// </summary>
			public string HeroImage
			{
				get
				{
					return mInstance.HeroImage;
				}
				set
				{
					mInstance.HeroImage = value;
				}
			}


			/// <summary>
			/// H1 Large Text.
			/// </summary>
			public string H1LargeText
			{
				get
				{
					return mInstance.H1LargeText;
				}
				set
				{
					mInstance.H1LargeText = value;
				}
			}


			/// <summary>
			/// H1 Small Text.
			/// </summary>
			public string H1SmallText
			{
				get
				{
					return mInstance.H1SmallText;
				}
				set
				{
					mInstance.H1SmallText = value;
				}
			}


			/// <summary>
			/// Industry Section Title.
			/// </summary>
			public string IndustrySectionTitle
			{
				get
				{
					return mInstance.IndustrySectionTitle;
				}
				set
				{
					mInstance.IndustrySectionTitle = value;
				}
			}


			/// <summary>
			/// Industry Section Description.
			/// </summary>
			public string IndustrySectionDescription
			{
				get
				{
					return mInstance.IndustrySectionDescription;
				}
				set
				{
					mInstance.IndustrySectionDescription = value;
				}
			}


			/// <summary>
			/// Industry Section CTA Text.
			/// </summary>
			public string IndustrySectionCtaText
			{
				get
				{
					return mInstance.IndustrySectionCtaText;
				}
				set
				{
					mInstance.IndustrySectionCtaText = value;
				}
			}


			/// <summary>
			/// Industry Section CTA Link.
			/// </summary>
			public string IndustrySectionCtaLink
			{
				get
				{
					return mInstance.IndustrySectionCtaLink;
				}
				set
				{
					mInstance.IndustrySectionCtaLink = value;
				}
			}


			/// <summary>
			/// Featured Industry Title 1.
			/// </summary>
			public string FeaturedIndustryTitle1
			{
				get
				{
					return mInstance.FeaturedIndustryTitle1;
				}
				set
				{
					mInstance.FeaturedIndustryTitle1 = value;
				}
			}


			/// <summary>
			/// Featured Industry Description 1.
			/// </summary>
			public string FeaturedIndustryDescription1
			{
				get
				{
					return mInstance.FeaturedIndustryDescription1;
				}
				set
				{
					mInstance.FeaturedIndustryDescription1 = value;
				}
			}


			/// <summary>
			/// Featured Industry CTA Link 1.
			/// </summary>
			public string FeaturedIndustryCtaLink1
			{
				get
				{
					return mInstance.FeaturedIndustryCtaLink1;
				}
				set
				{
					mInstance.FeaturedIndustryCtaLink1 = value;
				}
			}


			/// <summary>
			/// Featured Industry Title 2.
			/// </summary>
			public string FeaturedIndustryTitle2
			{
				get
				{
					return mInstance.FeaturedIndustryTitle2;
				}
				set
				{
					mInstance.FeaturedIndustryTitle2 = value;
				}
			}


			/// <summary>
			/// Featured Industry Description 2.
			/// </summary>
			public string FeaturedIndustryDescription2
			{
				get
				{
					return mInstance.FeaturedIndustryDescription2;
				}
				set
				{
					mInstance.FeaturedIndustryDescription2 = value;
				}
			}


			/// <summary>
			/// Featured Industry CTA Link 2.
			/// </summary>
			public string FeaturedIndustryCtaLink2
			{
				get
				{
					return mInstance.FeaturedIndustryCtaLink2;
				}
				set
				{
					mInstance.FeaturedIndustryCtaLink2 = value;
				}
			}


			/// <summary>
			/// Featured Industry Title 3.
			/// </summary>
			public string FeaturedIndustryTitle3
			{
				get
				{
					return mInstance.FeaturedIndustryTitle3;
				}
				set
				{
					mInstance.FeaturedIndustryTitle3 = value;
				}
			}


			/// <summary>
			/// Featured Industry Description 3.
			/// </summary>
			public string FeaturedIndustryDescription3
			{
				get
				{
					return mInstance.FeaturedIndustryDescription3;
				}
				set
				{
					mInstance.FeaturedIndustryDescription3 = value;
				}
			}


			/// <summary>
			/// Featured Industry CTA Link 3.
			/// </summary>
			public string FeaturedIndustryCtaLink3
			{
				get
				{
					return mInstance.FeaturedIndustryCtaLink3;
				}
				set
				{
					mInstance.FeaturedIndustryCtaLink3 = value;
				}
			}


			/// <summary>
			/// Featured Industry Title 4.
			/// </summary>
			public string FeaturedIndustryTitle4
			{
				get
				{
					return mInstance.FeaturedIndustryTitle4;
				}
				set
				{
					mInstance.FeaturedIndustryTitle4 = value;
				}
			}


			/// <summary>
			/// Featured Industry Description 4.
			/// </summary>
			public string FeaturedIndustryDescription4
			{
				get
				{
					return mInstance.FeaturedIndustryDescription4;
				}
				set
				{
					mInstance.FeaturedIndustryDescription4 = value;
				}
			}


			/// <summary>
			/// Featured Industry CTA Link 4.
			/// </summary>
			public string FeaturedIndustryCtaLink4
			{
				get
				{
					return mInstance.FeaturedIndustryCtaLink4;
				}
				set
				{
					mInstance.FeaturedIndustryCtaLink4 = value;
				}
			}


			/// <summary>
			/// ## x ## Dimensions.
			/// </summary>
			public string Section2ContentWidthImage
			{
				get
				{
					return mInstance.Section2ContentWidthImage;
				}
				set
				{
					mInstance.Section2ContentWidthImage = value;
				}
			}


			/// <summary>
			/// Section 2 Title.
			/// </summary>
			public string Section2Title
			{
				get
				{
					return mInstance.Section2Title;
				}
				set
				{
					mInstance.Section2Title = value;
				}
			}


			/// <summary>
			/// Section 2 Sub Title.
			/// </summary>
			public string Section2SubTitle
			{
				get
				{
					return mInstance.Section2SubTitle;
				}
				set
				{
					mInstance.Section2SubTitle = value;
				}
			}


			/// <summary>
			/// Section 2 CTA Text.
			/// </summary>
			public string Section2CtaText
			{
				get
				{
					return mInstance.Section2CtaText;
				}
				set
				{
					mInstance.Section2CtaText = value;
				}
			}


			/// <summary>
			/// Section 2 CTA Link.
			/// </summary>
			public string Section2CtaLink
			{
				get
				{
					return mInstance.Section2CtaLink;
				}
				set
				{
					mInstance.Section2CtaLink = value;
				}
			}


			/// <summary>
			/// ## x ## Dimensions.
			/// </summary>
			public string Section3FullWidthImage
			{
				get
				{
					return mInstance.Section3FullWidthImage;
				}
				set
				{
					mInstance.Section3FullWidthImage = value;
				}
			}


			/// <summary>
			/// Section 3 Full Width Image Title.
			/// </summary>
			public string Section3FullWidthImageTitle
			{
				get
				{
					return mInstance.Section3FullWidthImageTitle;
				}
				set
				{
					mInstance.Section3FullWidthImageTitle = value;
				}
			}


			/// <summary>
			/// Section 3 Title.
			/// </summary>
			public string Section3Title
			{
				get
				{
					return mInstance.Section3Title;
				}
				set
				{
					mInstance.Section3Title = value;
				}
			}


			/// <summary>
			/// Section 3 Description.
			/// </summary>
			public string Section3Description
			{
				get
				{
					return mInstance.Section3Description;
				}
				set
				{
					mInstance.Section3Description = value;
				}
			}


			/// <summary>
			/// Section 3 CTA Text.
			/// </summary>
			public string Section3CtaText
			{
				get
				{
					return mInstance.Section3CtaText;
				}
				set
				{
					mInstance.Section3CtaText = value;
				}
			}


			/// <summary>
			/// Section 3 CTA Link.
			/// </summary>
			public string Section3CtaLink
			{
				get
				{
					return mInstance.Section3CtaLink;
				}
				set
				{
					mInstance.Section3CtaLink = value;
				}
			}


			/// <summary>
			/// ## x ## Dimensions.
			/// </summary>
			public string Section4FullWidthImage
			{
				get
				{
					return mInstance.Section4FullWidthImage;
				}
				set
				{
					mInstance.Section4FullWidthImage = value;
				}
			}


			/// <summary>
			/// Section 4 Full Width Image Title.
			/// </summary>
			public string Section4FullWidthImageTitle
			{
				get
				{
					return mInstance.Section4FullWidthImageTitle;
				}
				set
				{
					mInstance.Section4FullWidthImageTitle = value;
				}
			}


			/// <summary>
			/// Section 4 Title.
			/// </summary>
			public string Section4Title
			{
				get
				{
					return mInstance.Section4Title;
				}
				set
				{
					mInstance.Section4Title = value;
				}
			}


			/// <summary>
			/// Section 4 Description.
			/// </summary>
			public string Section4Description
			{
				get
				{
					return mInstance.Section4Description;
				}
				set
				{
					mInstance.Section4Description = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="Home" /> class.
		/// </summary>
		public Home() : base(CLASS_NAME)
		{
			mFields = new HomeFields(this);
		}

		#endregion
	}
}
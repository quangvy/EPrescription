﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.Design.WebControls;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace ePrescription.Web.UI
{
    /// <summary>
    /// A designer class for a strongly typed repeater <c>ClinicalStatsRepeater</c>
    /// </summary>
	public class ClinicalStatsRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:ClinicalStatsRepeaterDesigner"/> class.
        /// </summary>
		public ClinicalStatsRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is ClinicalStatsRepeater))
			{ 
				throw new ArgumentException("Component is not a ClinicalStatsRepeater."); 
			} 
			base.Initialize(component); 
			base.SetViewFlags(ViewFlags.TemplateEditing, true); 
		}


		/// <summary>
		/// Generate HTML for the designer
		/// </summary>
		/// <returns>a string of design time HTML</returns>
		public override string GetDesignTimeHtml()
		{

			// Get the instance this designer applies to
			//
			ClinicalStatsRepeater z = (ClinicalStatsRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();

			//return z.RenderAtDesignTime();

			//	ControlCollection c = z.Controls;
			//Totem z = (Totem) Component;
			//Totem z = (Totem) Component;
			//return ("<div style='border: 1px gray dotted; background-color: lightgray'><b>TagStat :</b> zae |  qsdds</div>");

		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <see cref="ClinicalStatsRepeater"/> Type.
    /// </summary>
	[Designer(typeof(ClinicalStatsRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:ClinicalStatsRepeater runat=\"server\"></{0}:ClinicalStatsRepeater>")]
	public class ClinicalStatsRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:ClinicalStatsRepeater"/> class.
        /// </summary>
		public ClinicalStatsRepeater()
		{
		}

		/// <summary>
        /// Gets a <see cref="T:System.Web.UI.ControlCollection"></see> object that represents the child controls for a specified server control in the UI hierarchy.
        /// </summary>
        /// <value></value>
        /// <returns>The collection of child controls for the specified server control.</returns>
		public override ControlCollection Controls
		{
			get
			{
				this.EnsureChildControls();
				return base.Controls;
			}
		}

		private ITemplate m_headerTemplate;
		/// <summary>
        /// Gets or sets the header template.
        /// </summary>
        /// <value>The header template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(ClinicalStatsItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate HeaderTemplate
		{
			get { return m_headerTemplate; }
			set { m_headerTemplate = value; }
		}

		private ITemplate m_itemTemplate;
		/// <summary>
        /// Gets or sets the item template.
        /// </summary>
        /// <value>The item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(ClinicalStatsItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate ItemTemplate
		{
			get { return m_itemTemplate; }
			set { m_itemTemplate = value; }
		}

		private ITemplate m_seperatorTemplate;
        /// <summary>
        /// Gets or sets the Seperator Template
        /// </summary>
        [Browsable(false)]
        [TemplateContainer(typeof(ClinicalStatsItem))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public ITemplate SeperatorTemplate
        {
            get { return m_seperatorTemplate; }
            set { m_seperatorTemplate = value; }
        }
			
		private ITemplate m_altenateItemTemplate;
        /// <summary>
        /// Gets or sets the alternating item template.
        /// </summary>
        /// <value>The alternating item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(ClinicalStatsItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate AlternatingItemTemplate
		{
			get { return m_altenateItemTemplate; }
			set { m_altenateItemTemplate = value; }
		}

		private ITemplate m_footerTemplate;
        /// <summary>
        /// Gets or sets the footer template.
        /// </summary>
        /// <value>The footer template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(ClinicalStatsItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate FooterTemplate
		{
			get { return m_footerTemplate; }
			set { m_footerTemplate = value; }
		}

//      /// <summary>
//      /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
//      /// </summary>
//		protected override void CreateChildControls()
//      {
//         if (ChildControlsCreated)
//         {
//            return;
//         }

//         Controls.Clear();

//         //Instantiate the Header template (if exists)
//         if (m_headerTemplate != null)
//         {
//            Control headerItem = new Control();
//            m_headerTemplate.InstantiateIn(headerItem);
//            Controls.Add(headerItem);
//         }

//         //Instantiate the Footer template (if exists)
//         if (m_footerTemplate != null)
//         {
//            Control footerItem = new Control();
//            m_footerTemplate.InstantiateIn(footerItem);
//            Controls.Add(footerItem);
//         }
//
//         ChildControlsCreated = true;
//      }
	
		/// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            
        }

        /// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
                
        }		
		
		/// <summary>
      	/// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
      	/// </summary>
		protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
      	{
         int pos = 0;

         if (dataBinding)
         {
            //Instantiate the Header template (if exists)
            if (m_headerTemplate != null)
            {
                Control headerItem = new Control();
                m_headerTemplate.InstantiateIn(headerItem);
                Controls.Add(headerItem);
            }
			if (dataSource != null)
			{
				foreach (object o in dataSource)
				{
						ePrescription.Entities.ClinicalStats entity = o as ePrescription.Entities.ClinicalStats;
						ClinicalStatsItem container = new ClinicalStatsItem(entity);
	
						if (m_itemTemplate != null && (pos % 2) == 0)
						{
							m_itemTemplate.InstantiateIn(container);
							
							if (m_seperatorTemplate != null)
							{
								m_seperatorTemplate.InstantiateIn(container);
							}
						}
						else
						{
							if (m_altenateItemTemplate != null)
							{
								m_altenateItemTemplate.InstantiateIn(container);
								
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}
								
							}
							else if (m_itemTemplate != null)
							{
								m_itemTemplate.InstantiateIn(container);
								
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}
							}
							else
							{
								// no template !!!
							}
						}
						Controls.Add(container);
						
						container.DataBind();
						
						pos++;
				}
			}
            //Instantiate the Footer template (if exists)
            if (m_footerTemplate != null)
            {
                Control footerItem = new Control();
                m_footerTemplate.InstantiateIn(footerItem);
                Controls.Add(footerItem);
            }

		}
			
			return pos;
		}

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
		protected override void OnPreRender(EventArgs e)
		{
			base.DataBind();
		}

		#region Design time
        /// <summary>
        /// Renders at design time.
        /// </summary>
        /// <returns>a  string of the Designed HTML</returns>
		internal string RenderAtDesignTime()
		{			
			return "Designer currently not implemented"; 
		}

		#endregion
	}

    /// <summary>
    /// A wrapper type for the entity
    /// </summary>
	[System.ComponentModel.ToolboxItem(false)]
	public class ClinicalStatsItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private ePrescription.Entities.ClinicalStats _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ClinicalStatsItem"/> class.
        /// </summary>
		public ClinicalStatsItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ClinicalStatsItem"/> class.
        /// </summary>
		public ClinicalStatsItem(ePrescription.Entities.ClinicalStats entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the StatId
        /// </summary>
        /// <value>The StatId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 StatId
		{
			get { return _entity.StatId; }
		}
        /// <summary>
        /// Gets the PatientCode
        /// </summary>
        /// <value>The PatientCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PatientCode
		{
			get { return _entity.PatientCode; }
		}
        /// <summary>
        /// Gets the Tid
        /// </summary>
        /// <value>The Tid.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Tid
		{
			get { return _entity.Tid; }
		}
        /// <summary>
        /// Gets the FirstName
        /// </summary>
        /// <value>The FirstName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FirstName
		{
			get { return _entity.FirstName; }
		}
        /// <summary>
        /// Gets the LastName
        /// </summary>
        /// <value>The LastName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LastName
		{
			get { return _entity.LastName; }
		}
        /// <summary>
        /// Gets the Dob
        /// </summary>
        /// <value>The Dob.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime Dob
		{
			get { return _entity.Dob; }
		}
        /// <summary>
        /// Gets the Sex
        /// </summary>
        /// <value>The Sex.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Sex
		{
			get { return _entity.Sex; }
		}
        /// <summary>
        /// Gets the Nationality
        /// </summary>
        /// <value>The Nationality.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Nationality
		{
			get { return _entity.Nationality; }
		}
        /// <summary>
        /// Gets the PatientStart
        /// </summary>
        /// <value>The PatientStart.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? PatientStart
		{
			get { return _entity.PatientStart; }
		}
        /// <summary>
        /// Gets the VitalSign
        /// </summary>
        /// <value>The VitalSign.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String VitalSign
		{
			get { return _entity.VitalSign; }
		}
        /// <summary>
        /// Gets the Lab
        /// </summary>
        /// <value>The Lab.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Lab
		{
			get { return _entity.Lab; }
		}
        /// <summary>
        /// Gets the Xray
        /// </summary>
        /// <value>The Xray.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Xray
		{
			get { return _entity.Xray; }
		}
        /// <summary>
        /// Gets the UltraSound
        /// </summary>
        /// <value>The UltraSound.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String UltraSound
		{
			get { return _entity.UltraSound; }
		}
        /// <summary>
        /// Gets the Cardiology
        /// </summary>
        /// <value>The Cardiology.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Cardiology
		{
			get { return _entity.Cardiology; }
		}
        /// <summary>
        /// Gets the MedReport
        /// </summary>
        /// <value>The MedReport.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MedReport
		{
			get { return _entity.MedReport; }
		}
        /// <summary>
        /// Gets the ChargedCodes
        /// </summary>
        /// <value>The ChargedCodes.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ChargedCodes
		{
			get { return _entity.ChargedCodes; }
		}
        /// <summary>
        /// Gets the IsCompleted
        /// </summary>
        /// <value>The IsCompleted.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? IsCompleted
		{
			get { return _entity.IsCompleted; }
		}
        /// <summary>
        /// Gets the CreateDate
        /// </summary>
        /// <value>The CreateDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? CreateDate
		{
			get { return _entity.CreateDate; }
		}

        /// <summary>
        /// Gets a <see cref="T:ePrescription.Entities.ClinicalStats"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public ePrescription.Entities.ClinicalStats Entity
        {
            get { return _entity; }
        }
	}
}

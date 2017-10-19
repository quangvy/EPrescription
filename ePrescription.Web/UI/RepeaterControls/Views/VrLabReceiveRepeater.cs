using System;
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
    /// A designer class for a strongly typed repeater <c>VrLabReceiveRepeater</c>
    /// </summary>
	public class VrLabReceiveRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:VrLabReceiveRepeaterDesigner"/> class.
        /// </summary>
		public VrLabReceiveRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is VrLabReceiveRepeater))
			{ 
				throw new ArgumentException("Component is not a VrLabReceiveRepeater."); 
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
			VrLabReceiveRepeater z = (VrLabReceiveRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();
		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <see cref="VrLabReceiveRepeater"/> Type.
    /// </summary>
	[Designer(typeof(VrLabReceiveRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:VrLabReceiveRepeater runat=\"server\"></{0}:VrLabReceiveRepeater>")]
	public class VrLabReceiveRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:VrLabReceiveRepeater"/> class.
        /// </summary>
		public VrLabReceiveRepeater()
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
		[TemplateContainer(typeof(VrLabReceiveItem))]
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
		[TemplateContainer(typeof(VrLabReceiveItem))]
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
        [TemplateContainer(typeof(VrLabReceiveItem))]
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
		[TemplateContainer(typeof(VrLabReceiveItem))]
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
		[TemplateContainer(typeof(VrLabReceiveItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate FooterTemplate
		{
			get { return m_footerTemplate; }
			set { m_footerTemplate = value; }
		}
		
		
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

//      /// <summary>
//      /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
//      /// </summary>
//		protected override void CreateChildControls()
//		{
//			if (ChildControlsCreated)
//			{
//				return;
//			}
//			Controls.Clear();
//
//			if (m_headerTemplate != null)
//			{
//				Control headerItem = new Control();
//				m_headerTemplate.InstantiateIn(headerItem);
//				Controls.Add(headerItem);
//			}
//
//			
//			if (m_footerTemplate != null)
//			{
//				Control footerItem = new Control();
//				m_footerTemplate.InstantiateIn(footerItem);
//				Controls.Add(footerItem);
//			}
//			ChildControlsCreated = true;
//		}
		
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
						ePrescription.Entities.VrLabReceive entity = o as ePrescription.Entities.VrLabReceive;
						VrLabReceiveItem container = new VrLabReceiveItem(entity);
	
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
	public class VrLabReceiveItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private ePrescription.Entities.VrLabReceive _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VrLabReceiveItem"/> class.
        /// </summary>
		public VrLabReceiveItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VrLabReceiveItem"/> class.
        /// </summary>
		public VrLabReceiveItem(ePrescription.Entities.VrLabReceive entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the Id
        /// </summary>
        /// <value>The Id.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 Id
		{
			get { return _entity.Id; }
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
        /// Gets the ReqId
        /// </summary>
        /// <value>The ReqId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ReqId
		{
			get { return _entity.ReqId; }
		}
        /// <summary>
        /// Gets the Code
        /// </summary>
        /// <value>The Code.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Code
		{
			get { return _entity.Code; }
		}
        /// <summary>
        /// Gets the Description
        /// </summary>
        /// <value>The Description.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Description
		{
			get { return _entity.Description; }
		}
        /// <summary>
        /// Gets the ReqDoctor
        /// </summary>
        /// <value>The ReqDoctor.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ReqDoctor
		{
			get { return _entity.ReqDoctor; }
		}
        /// <summary>
        /// Gets the Billable
        /// </summary>
        /// <value>The Billable.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? Billable
		{
			get { return _entity.Billable; }
		}
        /// <summary>
        /// Gets the Sample
        /// </summary>
        /// <value>The Sample.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Sample
		{
			get { return _entity.Sample; }
		}
        /// <summary>
        /// Gets the ColDate
        /// </summary>
        /// <value>The ColDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? ColDate
		{
			get { return _entity.ColDate; }
		}
        /// <summary>
        /// Gets the ColTime
        /// </summary>
        /// <value>The ColTime.</value>
		[System.ComponentModel.Bindable(true)]
		public System.TimeSpan? ColTime
		{
			get { return _entity.ColTime; }
		}
        /// <summary>
        /// Gets the ReqDate
        /// </summary>
        /// <value>The ReqDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? ReqDate
		{
			get { return _entity.ReqDate; }
		}
        /// <summary>
        /// Gets the SampleType
        /// </summary>
        /// <value>The SampleType.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SampleType
		{
			get { return _entity.SampleType; }
		}
        /// <summary>
        /// Gets the ProviderType
        /// </summary>
        /// <value>The ProviderType.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ProviderType
		{
			get { return _entity.ProviderType; }
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
        /// Gets the ReqStatus
        /// </summary>
        /// <value>The ReqStatus.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ReqStatus
		{
			get { return _entity.ReqStatus; }
		}

	}
}

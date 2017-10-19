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
    /// A designer class for a strongly typed repeater <c>FavoritDetailRepeater</c>
    /// </summary>
	public class FavoritDetailRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:FavoritDetailRepeaterDesigner"/> class.
        /// </summary>
		public FavoritDetailRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is FavoritDetailRepeater))
			{ 
				throw new ArgumentException("Component is not a FavoritDetailRepeater."); 
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
			FavoritDetailRepeater z = (FavoritDetailRepeater)Component;
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
    /// A strongly typed repeater control for the <see cref="FavoritDetailRepeater"/> Type.
    /// </summary>
	[Designer(typeof(FavoritDetailRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:FavoritDetailRepeater runat=\"server\"></{0}:FavoritDetailRepeater>")]
	public class FavoritDetailRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:FavoritDetailRepeater"/> class.
        /// </summary>
		public FavoritDetailRepeater()
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
		[TemplateContainer(typeof(FavoritDetailItem))]
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
		[TemplateContainer(typeof(FavoritDetailItem))]
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
        [TemplateContainer(typeof(FavoritDetailItem))]
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
		[TemplateContainer(typeof(FavoritDetailItem))]
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
		[TemplateContainer(typeof(FavoritDetailItem))]
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
						ePrescription.Entities.FavoritDetail entity = o as ePrescription.Entities.FavoritDetail;
						FavoritDetailItem container = new FavoritDetailItem(entity);
	
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
	public class FavoritDetailItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private ePrescription.Entities.FavoritDetail _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FavoritDetailItem"/> class.
        /// </summary>
		public FavoritDetailItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FavoritDetailItem"/> class.
        /// </summary>
		public FavoritDetailItem(ePrescription.Entities.FavoritDetail entity)
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
        /// Gets the FavouriteId
        /// </summary>
        /// <value>The FavouriteId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FavouriteId
		{
			get { return _entity.FavouriteId; }
		}
        /// <summary>
        /// Gets the DrugId
        /// </summary>
        /// <value>The DrugId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DrugId
		{
			get { return _entity.DrugId; }
		}
        /// <summary>
        /// Gets the DrugName
        /// </summary>
        /// <value>The DrugName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DrugName
		{
			get { return _entity.DrugName; }
		}
        /// <summary>
        /// Gets the RouteType
        /// </summary>
        /// <value>The RouteType.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String RouteType
		{
			get { return _entity.RouteType; }
		}
        /// <summary>
        /// Gets the RouteTypeVn
        /// </summary>
        /// <value>The RouteTypeVn.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String RouteTypeVn
		{
			get { return _entity.RouteTypeVn; }
		}
        /// <summary>
        /// Gets the Dosage
        /// </summary>
        /// <value>The Dosage.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Dosage
		{
			get { return _entity.Dosage; }
		}
        /// <summary>
        /// Gets the DosageUnit
        /// </summary>
        /// <value>The DosageUnit.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DosageUnit
		{
			get { return _entity.DosageUnit; }
		}
        /// <summary>
        /// Gets the DosageUnitVn
        /// </summary>
        /// <value>The DosageUnitVn.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DosageUnitVn
		{
			get { return _entity.DosageUnitVn; }
		}
        /// <summary>
        /// Gets the Frequency
        /// </summary>
        /// <value>The Frequency.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Frequency
		{
			get { return _entity.Frequency; }
		}
        /// <summary>
        /// Gets the FrequencyVn
        /// </summary>
        /// <value>The FrequencyVn.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FrequencyVn
		{
			get { return _entity.FrequencyVn; }
		}
        /// <summary>
        /// Gets the Duration
        /// </summary>
        /// <value>The Duration.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Duration
		{
			get { return _entity.Duration; }
		}
        /// <summary>
        /// Gets the DurationUnit
        /// </summary>
        /// <value>The DurationUnit.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DurationUnit
		{
			get { return _entity.DurationUnit; }
		}
        /// <summary>
        /// Gets the DurationUnitVn
        /// </summary>
        /// <value>The DurationUnitVn.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DurationUnitVn
		{
			get { return _entity.DurationUnitVn; }
		}
        /// <summary>
        /// Gets the TotalUnit
        /// </summary>
        /// <value>The TotalUnit.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String TotalUnit
		{
			get { return _entity.TotalUnit; }
		}
        /// <summary>
        /// Gets the Unit
        /// </summary>
        /// <value>The Unit.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Unit
		{
			get { return _entity.Unit; }
		}
        /// <summary>
        /// Gets the UnitVn
        /// </summary>
        /// <value>The UnitVn.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String UnitVn
		{
			get { return _entity.UnitVn; }
		}

        /// <summary>
        /// Gets a <see cref="T:ePrescription.Entities.FavoritDetail"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public ePrescription.Entities.FavoritDetail Entity
        {
            get { return _entity; }
        }
	}
}

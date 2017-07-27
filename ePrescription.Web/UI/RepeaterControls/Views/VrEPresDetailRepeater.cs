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
    /// A designer class for a strongly typed repeater <c>VrEPresDetailRepeater</c>
    /// </summary>
	public class VrEPresDetailRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:VrEPresDetailRepeaterDesigner"/> class.
        /// </summary>
		public VrEPresDetailRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is VrEPresDetailRepeater))
			{ 
				throw new ArgumentException("Component is not a VrEPresDetailRepeater."); 
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
			VrEPresDetailRepeater z = (VrEPresDetailRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();
		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <see cref="VrEPresDetailRepeater"/> Type.
    /// </summary>
	[Designer(typeof(VrEPresDetailRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:VrEPresDetailRepeater runat=\"server\"></{0}:VrEPresDetailRepeater>")]
	public class VrEPresDetailRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:VrEPresDetailRepeater"/> class.
        /// </summary>
		public VrEPresDetailRepeater()
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
		[TemplateContainer(typeof(VrEPresDetailItem))]
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
		[TemplateContainer(typeof(VrEPresDetailItem))]
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
        [TemplateContainer(typeof(VrEPresDetailItem))]
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
		[TemplateContainer(typeof(VrEPresDetailItem))]
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
		[TemplateContainer(typeof(VrEPresDetailItem))]
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
						ePrescription.Entities.VrEPresDetail entity = o as ePrescription.Entities.VrEPresDetail;
						VrEPresDetailItem container = new VrEPresDetailItem(entity);
	
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
	public class VrEPresDetailItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private ePrescription.Entities.VrEPresDetail _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VrEPresDetailItem"/> class.
        /// </summary>
		public VrEPresDetailItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VrEPresDetailItem"/> class.
        /// </summary>
		public VrEPresDetailItem(ePrescription.Entities.VrEPresDetail entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the PrescriptionDetailId
        /// </summary>
        /// <value>The PrescriptionDetailId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 PrescriptionDetailId
		{
			get { return _entity.PrescriptionDetailId; }
		}
        /// <summary>
        /// Gets the PrescriptionId
        /// </summary>
        /// <value>The PrescriptionId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PrescriptionId
		{
			get { return _entity.PrescriptionId; }
		}
        /// <summary>
        /// Gets the Sq
        /// </summary>
        /// <value>The Sq.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 Sq
		{
			get { return _entity.Sq; }
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
        /// Gets the Remark
        /// </summary>
        /// <value>The Remark.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Remark
		{
			get { return _entity.Remark; }
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
        /// Gets the Frequency
        /// </summary>
        /// <value>The Frequency.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Frequency
		{
			get { return _entity.Frequency; }
		}
        /// <summary>
        /// Gets the VnMeaning
        /// </summary>
        /// <value>The VnMeaning.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String VnMeaning
		{
			get { return _entity.VnMeaning; }
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
        /// Gets the TotalUnit
        /// </summary>
        /// <value>The TotalUnit.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String TotalUnit
		{
			get { return _entity.TotalUnit; }
		}
        /// <summary>
        /// Gets the Expr1
        /// </summary>
        /// <value>The Expr1.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Expr1
		{
			get { return _entity.Expr1; }
		}
        /// <summary>
        /// Gets the Meaning
        /// </summary>
        /// <value>The Meaning.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Meaning
		{
			get { return _entity.Meaning; }
		}
        /// <summary>
        /// Gets the Abbre
        /// </summary>
        /// <value>The Abbre.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Abbre
		{
			get { return _entity.Abbre; }
		}

	}
}

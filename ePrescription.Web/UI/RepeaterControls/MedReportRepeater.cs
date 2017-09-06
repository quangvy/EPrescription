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
    /// A designer class for a strongly typed repeater <c>MedReportRepeater</c>
    /// </summary>
	public class MedReportRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:MedReportRepeaterDesigner"/> class.
        /// </summary>
		public MedReportRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is MedReportRepeater))
			{ 
				throw new ArgumentException("Component is not a MedReportRepeater."); 
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
			MedReportRepeater z = (MedReportRepeater)Component;
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
    /// A strongly typed repeater control for the <see cref="MedReportRepeater"/> Type.
    /// </summary>
	[Designer(typeof(MedReportRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:MedReportRepeater runat=\"server\"></{0}:MedReportRepeater>")]
	public class MedReportRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:MedReportRepeater"/> class.
        /// </summary>
		public MedReportRepeater()
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
		[TemplateContainer(typeof(MedReportItem))]
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
		[TemplateContainer(typeof(MedReportItem))]
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
        [TemplateContainer(typeof(MedReportItem))]
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
		[TemplateContainer(typeof(MedReportItem))]
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
		[TemplateContainer(typeof(MedReportItem))]
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
						ePrescription.Entities.MedReport entity = o as ePrescription.Entities.MedReport;
						MedReportItem container = new MedReportItem(entity);
	
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
	public class MedReportItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private ePrescription.Entities.MedReport _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MedReportItem"/> class.
        /// </summary>
		public MedReportItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MedReportItem"/> class.
        /// </summary>
		public MedReportItem(ePrescription.Entities.MedReport entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the MedId
        /// </summary>
        /// <value>The MedId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int64 MedId
		{
			get { return _entity.MedId; }
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
        /// Gets the OnsetDate
        /// </summary>
        /// <value>The OnsetDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? OnsetDate
		{
			get { return _entity.OnsetDate; }
		}
        /// <summary>
        /// Gets the FirstConsultDate
        /// </summary>
        /// <value>The FirstConsultDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? FirstConsultDate
		{
			get { return _entity.FirstConsultDate; }
		}
        /// <summary>
        /// Gets the DeceaseHistory
        /// </summary>
        /// <value>The DeceaseHistory.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DeceaseHistory
		{
			get { return _entity.DeceaseHistory; }
		}
        /// <summary>
        /// Gets the DeceaseHistoryVn
        /// </summary>
        /// <value>The DeceaseHistoryVn.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DeceaseHistoryVn
		{
			get { return _entity.DeceaseHistoryVn; }
		}
        /// <summary>
        /// Gets the Symptoms
        /// </summary>
        /// <value>The Symptoms.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Symptoms
		{
			get { return _entity.Symptoms; }
		}
        /// <summary>
        /// Gets the SymptomsVn
        /// </summary>
        /// <value>The SymptomsVn.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SymptomsVn
		{
			get { return _entity.SymptomsVn; }
		}
        /// <summary>
        /// Gets the PastMedHistory
        /// </summary>
        /// <value>The PastMedHistory.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PastMedHistory
		{
			get { return _entity.PastMedHistory; }
		}
        /// <summary>
        /// Gets the PastMedHistoryVn
        /// </summary>
        /// <value>The PastMedHistoryVn.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PastMedHistoryVn
		{
			get { return _entity.PastMedHistoryVn; }
		}
        /// <summary>
        /// Gets the CurrentMedications
        /// </summary>
        /// <value>The CurrentMedications.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CurrentMedications
		{
			get { return _entity.CurrentMedications; }
		}
        /// <summary>
        /// Gets the PhysicalExam
        /// </summary>
        /// <value>The PhysicalExam.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PhysicalExam
		{
			get { return _entity.PhysicalExam; }
		}
        /// <summary>
        /// Gets the PhysicalExamVn
        /// </summary>
        /// <value>The PhysicalExamVn.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PhysicalExamVn
		{
			get { return _entity.PhysicalExamVn; }
		}
        /// <summary>
        /// Gets the Investigations
        /// </summary>
        /// <value>The Investigations.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Investigations
		{
			get { return _entity.Investigations; }
		}
        /// <summary>
        /// Gets the InvestigationsVn
        /// </summary>
        /// <value>The InvestigationsVn.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String InvestigationsVn
		{
			get { return _entity.InvestigationsVn; }
		}
        /// <summary>
        /// Gets the DiagnosisDetail
        /// </summary>
        /// <value>The DiagnosisDetail.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DiagnosisDetail
		{
			get { return _entity.DiagnosisDetail; }
		}
        /// <summary>
        /// Gets the DiagnosisDetailVn
        /// </summary>
        /// <value>The DiagnosisDetailVn.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DiagnosisDetailVn
		{
			get { return _entity.DiagnosisDetailVn; }
		}
        /// <summary>
        /// Gets the Treatment
        /// </summary>
        /// <value>The Treatment.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Treatment
		{
			get { return _entity.Treatment; }
		}
        /// <summary>
        /// Gets the TreatmentVn
        /// </summary>
        /// <value>The TreatmentVn.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String TreatmentVn
		{
			get { return _entity.TreatmentVn; }
		}
        /// <summary>
        /// Gets the ReviewPlan
        /// </summary>
        /// <value>The ReviewPlan.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ReviewPlan
		{
			get { return _entity.ReviewPlan; }
		}
        /// <summary>
        /// Gets the ReviewPlanVn
        /// </summary>
        /// <value>The ReviewPlanVn.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ReviewPlanVn
		{
			get { return _entity.ReviewPlanVn; }
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
        /// Gets the CreateUser
        /// </summary>
        /// <value>The CreateUser.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CreateUser
		{
			get { return _entity.CreateUser; }
		}
        /// <summary>
        /// Gets the UpdateDate
        /// </summary>
        /// <value>The UpdateDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? UpdateDate
		{
			get { return _entity.UpdateDate; }
		}
        /// <summary>
        /// Gets the UpdateUser
        /// </summary>
        /// <value>The UpdateUser.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String UpdateUser
		{
			get { return _entity.UpdateUser; }
		}

        /// <summary>
        /// Gets a <see cref="T:ePrescription.Entities.MedReport"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public ePrescription.Entities.MedReport Entity
        {
            get { return _entity; }
        }
	}
}


#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web.UI;
using System.Web.UI.Design.WebControls;
using System.Web.UI.WebControls;
using ePrescription;
using ePrescription.Web.Data;
using ePrescription.Entities;

#endregion

namespace ePrescription.Web.UI
{
    /// <summary>
    ///     Provides Search Functionality for GridView that uses TypedDataSource. This Composite Control automaticaly builds Fields dropdownlist box
    ///     based on the Business Entity class properties collection and GridView Column HeaderText
    ///     and SortExpression properties.
    /// </summary>
    [
        Designer(typeof(CompositeControlDesigner)),
        ToolboxData(
            "<{0}:GridViewMultiFilter runat=\"server\" GridViewControlId=\"GridView1\" PersistenceMethod=\"Session\" Filter=\"\" />"
            )
    ]
    public class GridViewMultiFilter : CompositeControl
    {
        #region Fields

        private List<MyNettierType> _allColumns;
        private string _businessEntityType = string.Empty;

        private FieldCollection _fields;
        private GridView _gridView1;
        private string _gridViewControlId = string.Empty;
        private Repeater _repeater;
        private DataSourceControl _typedDataSource;
        private Label _lblError;


        /// <summary>
        /// FilteringData source for repeater
        /// </summary>
        public List<FilterStructure> FilteringData
        {
            get { return (List<FilterStructure>)ViewState["FilteringData"]; }
            set { ViewState["FilteringData"] = value; }
        }

        #endregion

        #region Data Class

        /// <summary>
        ///     Add the filter struct to the list for being shown
        /// </summary>
        /// <param name="filterStructures"></param>
        /// <returns></returns>
        protected List<FilterStructure> AddStruct(List<FilterStructure> filterStructures)
        {
            var ss = filterStructures;
            FilterStructure s;
            if (ss == null)
            {
                ss = new List<FilterStructure>();
                s = new FilterStructure();
                s.ColumnNames = new List<MyNettierType>();
                foreach (var columns in _allColumns)
                {
                    s.ColumnNames.Add(columns);
                }
                s.RemoveImageUrl = Page.ClientScript.GetWebResourceUrl(GetType(),
                                                                       "InvoiceChecking.Web.Resources.remove.png");
                s = SetSpecificFieldType(s);
            }
            else
            {
                s = (FilterStructure)filterStructures[filterStructures.Count - 1].Clone();
            }
            ss.Add(s);
            return ss;
        }

        /// <summary>
        ///     This class is a structure of columns
        ///     to be bound to Multi Filter Control
        /// </summary>
        [Serializable]
        public class FilterStructure : ICloneable
        {
            public List<MyNettierType> ColumnNames { get; set; }
            public List<string> Operations { get; set; }

            public List<string> Relations
            {
                get { return new List<string> { "And", "Or" }; }
            }

            // This is bould field
            public string EqualValue { get; set; }
            public int ColumnIndex { get; set; }
            public int OperationIndex { get; set; }
            public int RelationIndex { get; set; }

            public string RemoveImageUrl { get; set; }

            public string SearchClass { get; set; }

            // This field illistrates the type of your field
            public Type DataType { get; set; }

            //Copy itself to create multiple filter
            public object Clone()
            {
                using (var ms = new MemoryStream())
                {
                    var f = new BinaryFormatter();
                    f.Serialize(ms, this);
                    ms.Position = 0;
                    return f.Deserialize(ms);
                }
            }
        }

        /// <summary>
        /// According to the specific type of structure,set proper operations.
        /// </summary>
        protected FilterStructure SetSpecificFieldType(FilterStructure stu)
        {
            FilterStructure s = stu;
            s.Operations = new List<string>();

            s.Operations.Add("=");
            s.Operations.Add("<>");
            s.DataType = _allColumns[s.ColumnIndex].DataType;

            if (_allColumns[s.ColumnIndex].DataType == typeof(string))
            {
                s.Operations.Insert(0,"Like");
            }
            else if (_allColumns[s.ColumnIndex].DataType != typeof(bool))
            {
                s.Operations.Add(">");
                s.Operations.Add(">=");
                s.Operations.Add("<");
                s.Operations.Add("<=");
            }
            if (_allColumns[s.ColumnIndex].DataType.ToString().ToLower().Contains("date"))
            {
                s.SearchClass = "text-input datepicker";
            }
            else
            {
                s.SearchClass = "text-input";
            }
            return s;
        }

        #endregion

        #region Repeater Template

        /// <summary>
        ///     Template to use in repeater
        /// </summary>
        public class MyTemplate : ITemplate
        {
            private readonly ListItemType _type;

            /// <summary>
            ///     Constructor
            /// </summary>
            /// <param name="type"></param>
            public MyTemplate(ListItemType type)
            {
                _type = type;
            }

            /// <summary>
            /// Constructor for passing event for ItemTemplate or AlternativeItemTemplate
            /// </summary>
            /// <param name="type"></param>
            /// <param name="fieldNameSelectedIndexChangedEvent"></param>
            public MyTemplate(ListItemType type, EventHandler fieldNameSelectedIndexChangedEvent)
            {
                _type = type;
                FieldNameSelectedIndexChanged = fieldNameSelectedIndexChangedEvent;
            }

            /// <summary>
            /// For Change type of dropdownlist
            /// </summary>
            public EventHandler FieldNameSelectedIndexChanged;

            public void InstantiateIn(Control container)
            {
                switch (_type)
                {
                    case ListItemType.Header:
                        container.Controls.Add(new LiteralControl("<table id='tblSearchPanel' style='width:700px'>"));
                        break;

                    case ListItemType.Footer:
                        container.Controls.Add(new LiteralControl("</table>"));
                        break;

                    case ListItemType.Item:
                    case ListItemType.AlternatingItem:
                        //Initialize Controls

                        #region Initialize Controls

                        var cboFieldName = new DropDownList();
                        cboFieldName.ID = "cboFieldName";
                        cboFieldName.SkinID = "cboFieldName";
                        cboFieldName.SelectedIndexChanged += FieldNameSelectedIndexChanged;
                        cboFieldName.AutoPostBack = true;
                        cboFieldName.CssClass = "disable-chosen";

                        var cboOperator = new DropDownList();
                        cboOperator.ID = "cboOperator";
                        cboOperator.SkinID = "cboOperator";
                        cboOperator.CssClass = "disable-chosen";

                        var txtKeyword = new TextBox();
                        txtKeyword.ID = "txtKeyword";
                        txtKeyword.SkinID = "txtKeyword";
                        txtKeyword.Width = 200;

                        var cboRelation = new DropDownList();
                        cboRelation.ID = "cboRelation";
                        cboRelation.SkinID = "cboRelation";
                        cboRelation.CssClass = "disable-chosen";

                        cboRelation.Items.Add(new ListItem("and"));
                        cboRelation.Items.Add(new ListItem("or"));

                        var btnRemove = new ImageButton();
                        btnRemove.ID = "btnRemove";
                        btnRemove.SkinID = "btnRemove";
                        btnRemove.ToolTip = "Remove Filter";
                        btnRemove.CommandName = "Remove";

                        var lblLookFor = new Label();
                        lblLookFor.ID = "lblLookFor";
                        lblLookFor.SkinID = "lblLookFor";
                        lblLookFor.Text = "Look For:";

                        var lblWhich = new Label();
                        lblWhich.ID = "lblWhich";
                        lblWhich.SkinID = "lblWhich";
                        lblWhich.Text = "Which:";

                        var lblRelation = new Label();
                        lblRelation.Text = "Relation:";

                        container.Controls.Add(new LiteralControl("<tr><td>"));
                        container.Controls.Add(lblLookFor);
                        container.Controls.Add(new LiteralControl("</td><td>"));
                        container.Controls.Add(cboFieldName);
                        container.Controls.Add(new LiteralControl("</td><td>"));
                        container.Controls.Add(lblWhich);
                        container.Controls.Add(new LiteralControl("</td><td>"));
                        container.Controls.Add(cboOperator);
                        container.Controls.Add(new LiteralControl("</td><td>"));
                        container.Controls.Add(txtKeyword);
                        container.Controls.Add(new LiteralControl("</td><td>"));
                        container.Controls.Add(lblRelation);
                        container.Controls.Add(new LiteralControl("</td><td>"));
                        container.Controls.Add(cboRelation);
                        container.Controls.Add(new LiteralControl("</td><td>"));
                        container.Controls.Add(btnRemove);
                        container.Controls.Add(new LiteralControl("</td><tr>"));
                        //For DataBinding Event to repeater
                        container.DataBinding += (sender, e) =>
                            {
                                var ri = (RepeaterItem)sender;
                                var riCboFieldName = (DropDownList)ri.FindControl("cboFieldName");
                                riCboFieldName.DataSource =
                                    DataBinder.Eval(ri.DataItem, "ColumnNames");
                                riCboFieldName.DataTextField = "Text";
                                riCboFieldName.DataValueField = "Name";
                                ((ImageButton)ri.FindControl("btnRemove")).ImageUrl =
                                    (string)DataBinder.Eval(ri.DataItem,
                                                             "RemoveImageUrl");
                                ((DropDownList)ri.FindControl("cboOperator")).DataSource = DataBinder.Eval(
                                    ri.DataItem, "Operations");
                                ((TextBox)ri.FindControl("txtKeyWord")).CssClass = (string)DataBinder.Eval(ri.DataItem,
                                                                                                              "SearchClass");
                                //    (string)DataBinder.Eval(ri.DataItem, "FieldName");
                            };

                        #endregion

                        break;
                }
            }
        }

        #endregion

        /// <summary>
        ///     SearchButtonClicked event raised whenever the Search Button Clicked
        /// </summary>
        public event EventHandler SearchButtonClicked;

        /// <summary>
        ///     ResetButtonClicked event raised whenever the Reset Button Clicked
        /// </summary>
        public event EventHandler ResetButtonClicked;

        /// <summary>
        ///     Raises the <see cref="E:System.Web.UI.Control.Init"></see> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="T:System.EventArgs"></see> object that contains the event data.
        /// </param>
        /// <remarks>
        ///     Page is responsible to maintain GridViewSearchPanel state, therefor subscribing to the
        ///     Page Init (to handle control's state) that occures after the GridViewSearchPanel Init
        /// </remarks>
        protected override void OnInit(EventArgs e)
        {
            Page.Init += delegate
            {
                switch (PersistenceMethod)
                {
                    case PersistenceMethod.Cookie:
                    case PersistenceMethod.PersistentCookie:
                        FormUtilBase.HandleGridViewMultiFilterState(this, PersistentCookieExpiryDateTime);
                        break;
                    case PersistenceMethod.Session:
                        FormUtilBase.HandleGridViewMultiFilterState(this, PersistenceMethod);
                        break;
                    case PersistenceMethod.None:
                        break;
                }
            };
            base.OnInit(e);
        }

        /// <summary>
        ///     Raises the <see cref="E:System.Web.UI.Control.Load"></see> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="T:System.EventArgs"></see> object that contains the event data.
        /// </param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            base.EnsureChildControls();
            // if we have a search value then build the search
            if ((!string.IsNullOrEmpty(FilterExpression) || !string.IsNullOrEmpty(Filter)))
            {
                SetWhereClause(FilterExpression);
            }
            ExcludeFields();
        }

        ///// <summary>
        /////     Binds a data source to the invoked server control and all its child controls.
        ///// </summary>
        //public override void DataBind()
        //{
        //    base.DataBind();
        //    BuildSearch();
        //}

        /// <summary>
        ///     Make sure that CreateChildControls has been called
        ///     before the control is rendered
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            base.EnsureChildControls();
            base.Render(writer);
        }

        /// <summary>
        /// When column name changes, it will detect the type and cascade to dropdown other dropdownlists
        /// </summary>
        protected void ddrColumnNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            //When a column's name changed, set proper operation
            AutoBind();
            var ddrColumnName = (DropDownList)sender;
            var item = (RepeaterItem)ddrColumnName.NamingContainer;
            //_allColumns = TableColumnsMapping;
            FilteringData[item.ItemIndex].ColumnIndex = ddrColumnName.SelectedIndex;
            FilteringData[item.ItemIndex].OperationIndex = (item.FindControl("cboOperator") as DropDownList).SelectedIndex;
            FilteringData[item.ItemIndex].RelationIndex = (item.FindControl("cboRelation") as DropDownList).SelectedIndex;
            FilteringData[item.ItemIndex] = SetSpecificFieldType(FilteringData[item.ItemIndex]);
            _repeater.DataSource = FilteringData;
            _repeater.DataBind();
            AutoShow();
        }

        /// <summary>
        ///     Called by the ASP.NET page framework to notify server controls that
        ///     use composition-based implementation to create any child controls they
        ///     contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls()
        {
            // Start with a clean form 
            base.Controls.Clear();

            #region UI implementation

            var tbl = new Table();
            var tr = new TableRow();
            var td = new TableCell();

            _repeater = new Repeater();
            _repeater.ID = "rep_FilterTemplate";
            _repeater.HeaderTemplate = new MyTemplate(ListItemType.Header);
            _repeater.ItemTemplate = new MyTemplate(ListItemType.Item, ddrColumnNames_SelectedIndexChanged);
            _repeater.AlternatingItemTemplate = new MyTemplate(ListItemType.AlternatingItem, ddrColumnNames_SelectedIndexChanged);
            _repeater.FooterTemplate = new MyTemplate(ListItemType.Footer);

            _repeater.ItemCommand += delegate(object source, RepeaterCommandEventArgs e)
                {
                    if (e.CommandName == "Remove")
                    {
                        if (FilteringData.Count > 1)
                        {
                            var c = e.CommandSource as Control;
                            int index = (c.NamingContainer as RepeaterItem).ItemIndex;
                            AutoBind();
                            FilteringData.RemoveAt(index);
                            _repeater.DataSource = FilteringData;
                            _repeater.DataBind();
                            AutoShow();
                        }
                    }
                };
            //base.Controls.Add(_repeater);

            td.ColumnSpan = 2;
            td.Controls.Add(_repeater);

            tr.Cells.Add(td);
            tbl.Rows.Add(tr);


            if (!DesignMode)
            {
                _gridView1 = (GridView)NamingContainer.FindControl(GridViewControlId);
                //_gridView1.PageIndexChanged += (sender, e) =>
                //{
                //    if (!string.IsNullOrEmpty(FilterExpression))
                //    {
                //        //AutoBind();
                //        SetWhereClause(FilterExpression);
                //        //AutoShow();
                //    }
                //};
                _typedDataSource = (DataSourceControl)NamingContainer.FindControl(_gridView1.DataSourceID);

                Type[] typeArguments = _typedDataSource.GetType().BaseType.GetGenericArguments();
                _businessEntityType = typeArguments[0].FullName;

                #region Set up the fields drop down list using the list of table columns

                Type enumType = EntityUtil.GetType(string.Format("{0}Column", _businessEntityType));

                _allColumns = new List<MyNettierType>();

                Array c = Enum.GetValues(enumType);
                for (int i = 0; i < c.Length; i++)
                {
                    var cea = EntityHelper.GetAttribute<ColumnEnumAttribute>((Enum)c.GetValue(i));
                    var etv = EntityHelper.GetAttribute<EnumTextValueAttribute>((Enum)c.GetValue(i));

                    // only show fields that we can realistically search against
                    switch (cea.DbType)
                    {
                        case DbType.AnsiString:
                        case DbType.AnsiStringFixedLength:
                        case DbType.Boolean:
                        case DbType.Byte:
                        case DbType.Currency:
                        case DbType.Date:
                        case DbType.DateTime:
                        case DbType.Decimal:
                        case DbType.Double:
                        case DbType.Int16:
                        case DbType.Int32:
                        case DbType.Int64:
                        case DbType.SByte:
                        case DbType.Single:
                        case DbType.String:
                        case DbType.StringFixedLength:
                        case DbType.Time:
                        case DbType.UInt16:
                        case DbType.UInt32:
                        case DbType.UInt64:
                        case DbType.VarNumeric:
                        case DbType.Xml:

                            #region Add fields to the dropdown collection

                            //var li = new ListItem();
                            //li.Text = etv != null && !string.IsNullOrEmpty(etv.Text)
                            //              ? EntityHelper.GetPascalSpacedName(etv.Text)
                            //              : EntityHelper.GetPascalSpacedName(cea.Name);
                            //li.Value = cea.Name;

                            var item = new MyNettierType();
                            item.Text = etv != null && !string.IsNullOrEmpty(etv.Text)
                                          ? EntityHelper.GetPascalSpacedName(etv.Text)
                                          : EntityHelper.GetPascalSpacedName(cea.Name);
                            item.Name = cea.Name;
                            item.DataType = cea.SystemType;
                            _allColumns.Add(item);

                            #endregion

                            break;
                    }
                }

                #endregion
            }
            else
            {
                _allColumns.Add(new MyNettierType { Text = "FieldName" });
            }
            if (FilteringData == null)
                FilteringData = AddStruct(FilteringData);

            _repeater.DataSource = FilteringData;
            _repeater.DataBind();

            tr = new TableRow();
            td = new TableCell();

            _lblError = new Label();
            _lblError.ForeColor = Color.Red;
            td.Controls.Add(_lblError);
            td.ColumnSpan = 2;
            tr.Cells.Add(td);
            tbl.Rows.Add(tr);

            tr = new TableRow();
            td = new TableCell();

            var cmdSearch = new Button();
            cmdSearch.ID = "cmdSearch";
            cmdSearch.SkinID = "cmdSearch";
            cmdSearch.Text = "Search";
            cmdSearch.CausesValidation = CausesValidation;
            cmdSearch.Click += cmdSearch_Click;

            var cmdAddFilter = new Button();
            cmdAddFilter.ID = "cmdAddFilter";
            cmdAddFilter.SkinID = "cmdAddFilter";
            cmdAddFilter.Text = "Add Filter";
            cmdAddFilter.CausesValidation = CausesValidation;
            cmdAddFilter.Click += cmdAddFilter_Click;

            var cmdReset = new Button();
            cmdReset.ID = "cmdReset";
            cmdReset.SkinID = "cmdReset";
            cmdReset.Text = "Reset";
            cmdReset.CausesValidation = CausesValidation;
            cmdReset.Click += cmdReset_Click;

            td.Controls.Add(cmdSearch);
            td.Controls.Add(cmdAddFilter);
            td.Controls.Add(cmdReset);
            tr.Cells.Add(td);

            td = new TableCell();
            tr.Cells.Add(td);

            tbl.Rows.Add(tr);

            #endregion

            tbl.Width = 700;
            base.Controls.Add(tbl);
            base.ClearChildViewState();
        }

        /// <summary>
        ///     This method is binding data contents, it's called when any data contents are changed.
        /// </summary>
        protected void AutoBind()
        {
            for (int i = 0; i < _repeater.Items.Count; ++i)
            {
                var ddrColumn = _repeater.Items[i].FindControl("cboFieldName") as DropDownList;
                var ddrOperation = _repeater.Items[i].FindControl("cboOperator") as DropDownList;
                var ddrRelation = _repeater.Items[i].FindControl("cboRelation") as DropDownList;

                FilteringData[i].EqualValue = (_repeater.Items[i].FindControl("txtKeyword") as TextBox).Text;
                FilteringData[i].ColumnIndex = ddrColumn.SelectedIndex;
                FilteringData[i].RelationIndex = ddrRelation.SelectedIndex;
                FilteringData[i].OperationIndex = ddrOperation.SelectedIndex;
            }
        }

        /// <summary>
        ///     This will retrieve all the data contents onto the UI.
        /// </summary>
        public void AutoShow()
        {
            for (int i = 0; i < _repeater.Items.Count; ++i)
            {
                var ddrColumn = _repeater.Items[i].FindControl("cboFieldName") as DropDownList;
                var ddrOperation = _repeater.Items[i].FindControl("cboOperator") as DropDownList;
                var ddrRelation = _repeater.Items[i].FindControl("cboRelation") as DropDownList;
                var txtKeyWord = _repeater.Items[i].FindControl("txtKeyword") as TextBox;
                ddrColumn.SelectedIndex = FilteringData[i].ColumnIndex;
                ddrOperation.SelectedIndex = FilteringData[i].OperationIndex;
                ddrRelation.SelectedIndex = FilteringData[i].RelationIndex;
                txtKeyWord.Text = FilteringData[i].EqualValue;
            }
        }

        #region Event Methods

        /// <summary>
        ///     Displays a Reset button control on the Web page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdReset_Click(object sender, EventArgs e)
        {
            //_cboFieldName.SelectedIndex = 0;
            //_cboOperator.SelectedIndex = 0;
            //_txtKeyword.Text = string.Empty;

            //Reset 
            //throw new NotImplementedException("Button Reset Click");

            FilteringData = null;
            FilteringData=AddStruct(FilteringData);
            _repeater.DataSource = FilteringData;
            _repeater.DataBind();
            SetWhereClause(string.Empty);
            _gridView1.DataBind();

            if (ResetButtonClicked != null) ResetButtonClicked(sender, e);
        }

        /// <summary>
        ///     Displays a Search button control on the Web page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            AutoBind();
            BuildSearch();
            //_gridView1.PageIndex = 0; // default to first page
            //_gridView1.DataBind();

            if (SearchButtonClicked != null) SearchButtonClicked(sender, e);
            AutoShow();
        }


        /// <summary>
        ///     Displays a Add Filter button control on the Web page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddFilter_Click(object sender, EventArgs e)
        {
            AutoBind();
            FilteringData = AddStruct(FilteringData);
            _repeater.DataSource = FilteringData;
            _repeater.DataBind();
            AutoShow();
        }

        /// <summary>
        ///     Builds the search.
        /// </summary>
        private void BuildSearch()
        {
            // Show All
            // Loop the FilterData to get the values
            var sbu = new StringBuilder();
            string s;

            foreach (FilterStructure filterStructuret in FilteringData)
            {
                if (!string.IsNullOrEmpty(filterStructuret.EqualValue))
                {
                    string tempop = filterStructuret.Operations[filterStructuret.OperationIndex];
                    string columnname = filterStructuret.ColumnNames[filterStructuret.ColumnIndex].Name;

                    s = "'" + filterStructuret.EqualValue + "')";

                    if (tempop.Equals("Like"))
                    {
                        s = "'%" + filterStructuret.EqualValue + "%')";
                    }
                    else if (filterStructuret.DataType == typeof(DateTime))
                    {
                        // DateTime has milliseconds, so "=" means between 00:00:00 and 23:59:59

                        if (tempop.Equals("="))
                        {
                            string ts = filterStructuret.EqualValue + " 00:00:00";
                            string ts2 = filterStructuret.EqualValue + " 23:59:59";
                            tempop = ">=";
                            s = "'" + ts + "' and "
                                + columnname + "<='"
                                + ts2 + "')";
                        }

                            // "<>" means not between 00:00:00 and 23:59:59
                        else if (tempop.Equals("<>"))
                        {
                            string ts = filterStructuret.EqualValue + " 00:00:00";
                            string ts2 = filterStructuret.EqualValue + " 23:59:59";
                            tempop = "<";
                            s = "'" + ts + "' or "
                                + columnname + ">'"
                                + ts2 + "')";
                        }
                        else if (tempop.Equals(">"))
                        {
                            s = "'" + filterStructuret.EqualValue + " 23:59:59')";
                        }

                            // ">=" means combining the two together
                        else if (tempop.Equals(">="))
                        {
                            string ts = filterStructuret.EqualValue + " 00:00:00";
                            string ts2 = filterStructuret.EqualValue + " 23:59:59";
                            tempop = ">=";
                            s = "'" + ts + "' and "
                                + columnname + "<='"
                                + ts2 + "' or " + columnname + " >'" + ts2 + "')";
                        }
                        else if (tempop.Equals("<"))
                        {
                            s = "'" + filterStructuret.EqualValue + " 00:00:00')";
                        }
                        else if (tempop.Equals("<="))
                        {
                            string ts = filterStructuret.EqualValue + " 00:00:00";
                            string ts2 = filterStructuret.EqualValue + " 23:59:59";
                            tempop = ">=";
                            s = "'" + ts + "' and "
                                + columnname + "<='"
                                + ts2 + "' or " + columnname + " <'" + ts2 + "')";
                        }
                    }

                    sbu.Append(
                        "("
                        + filterStructuret.ColumnNames[filterStructuret.ColumnIndex].Name
                        + " "
                        + tempop
                        + " "
                        + s
                        + filterStructuret.Relations[filterStructuret.RelationIndex]);
                }
            }

            // Remove the last relation symbol "And" or "Or"
            s = sbu.ToString().Substring(sbu.ToString().LastIndexOf(')') + 1);
            sbu = sbu.Remove(sbu.ToString().LastIndexOf(s), s.Length);

            try
            {
                // Set WhereClause for datasource
                if (!string.IsNullOrEmpty(sbu.ToString()))
                    SetWhereClause(sbu.ToString());
                FilterExpression = sbu.ToString().Trim();
                _lblError.Text = "";
            }
            catch
            {
                _lblError.Text = "Please check whether your value fits the type.";
            }
        }

        #endregion

        #region Help Methods

        /// <summary>
        ///     Sets DataSourceObject Parameter's WhereClause property
        /// </summary>
        /// <param name="whereClause"></param>
        private void SetWhereClause(string whereClause)
        {
            Type t = _typedDataSource.GetType();
            PropertyInfo prop = t.GetProperty("Parameters");
            var col = (ParameterCollection)prop.GetValue(_typedDataSource, null);
            var p = col["WhereClause"] as CustomParameter;

            // -- check if WhereClause exists in parameter's collection
            if (p != null)
            {
                p.Value = GetWhereClauseStatement(whereClause);
            }
            else
            {
                p = new CustomParameter();
                p.Name = "WhereClause";
                p.ConvertEmptyStringToNull = false;
                p.Value = GetWhereClauseStatement(whereClause);
                col.Add(p);
            }
        }

        /// <summary>
        ///     Constructs the statement based on several conditions
        /// </summary>
        /// <param name="whereClause"></param>
        /// <returns></returns>
        private string GetWhereClauseStatement(string whereClause)
        {
            if (whereClause == string.Empty)
                return Filter;
            if (Filter == string.Empty)
                return whereClause;
            return string.Format("{0} AND {1}", Filter, whereClause);
        }

        /// <summary>
        ///     Excluding fields from the list of the fields collection
        /// </summary>
        private void ExcludeFields()
        {
            //throw new NotImplementedException("Exclude Fields");

            //foreach (Field f in FieldsToExclude)
            //{
            //    ListItem li = _cboFieldName.Items.FindByValue(f.Value);
            //    if (li != null)
            //    {
            //        _cboFieldName.Items.Remove(li);
            //    }
            //}
        }

        #endregion

        #region Constructors

        #endregion

        #region Properties

        /// <summary>
        ///     Set / Gets the GridView ControlID
        /// </summary>
        [
            Browsable(true),
            Description("Set / Gets the GridView ControlID"),
            Category("Misc"),
            DefaultValue(""),
        ]
        public string GridViewControlId
        {
            get { return _gridViewControlId; }
            set { _gridViewControlId = value; }
        }

        /// <summary>
        ///     Gets or sets the persistence method
        /// </summary>
        public PersistenceMethod PersistenceMethod
        {
            get
            {
                var persistenceMethod = PersistenceMethod.Session;
                Object method = ViewState["_persistenceMethod"];
                if (method != null)
                {
                    persistenceMethod = (PersistenceMethod)method;
                }
                return persistenceMethod;
            }
            set { ViewState["_persistenceMethod"] = value; }
        }

        /// <summary>
        ///     Gets or sets the persistent cookie expiry datetime
        /// </summary>
        public DateTime PersistentCookieExpiryDateTime
        {
            get
            {
                Object expiryDateTime = ViewState["_persistentCookieExpiryDateTime"];
                if (expiryDateTime != null)
                {
                    return (DateTime)ViewState["_persistentCookieExpiryDateTime"];
                }
                else
                {
                    return DateTime.Today.AddDays(1);
                }
            }
            set { ViewState["_persistentCookieExpiryDateTime"] = value; }
        }

        /// <summary>
        /// Keep the FilterExpression for paging
        /// </summary>
        public string FilterExpression
        {
            get
            {
                return ViewState["filterexp"]
                    == null ? "" : ViewState["filterexp"].ToString();
            }
            set
            {
                ViewState["filterexp"] = value;
            }
        }

        /// <summary>
        ///     Set / Gets the Filter criteria for filter datasource
        /// </summary>
        [
            Browsable(true),
            Description("Set / Gets the Filter criteria"),
            Category("Misc"),
            DefaultValue(""),
        ]
        public string Filter
        {
            get
            {
                if (ViewState["_filter"] != null)
                {
                    return (string)ViewState["_filter"];
                }
                else
                {
                    return string.Empty;
                }
            }
            set { ViewState["_filter"] = value; }
        }
        /// <summary>
        ///     Gets or sets the search operator.
        /// </summary>
        /// <value>The search operator.</value>
        /// <summary>
        ///     Gets or sets the search keyword.
        /// </summary>
        /// <value>The search keyword.</value>
        /// <summary>
        ///     Gets / sets the Fields To Exclude Fields Collection
        /// </summary>
        [
            Browsable(true),
            Description("Set / Gets the Fields To Exclude Fields Collection"),
            Category("Misc"),
            DefaultValue(""),
        ]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public FieldCollection FieldsToExclude
        {
            get
            {
                if (_fields == null)
                {
                    _fields = new FieldCollection();
                }
                return _fields;
            }
        }

        /// <summary>
        ///     Set / Gets the CausesValidation
        /// </summary>
        [
            Browsable(true),
            Description("Whether the control causes validation to fire"),
            Category("Behavior"),
            DefaultValue("true"),
        ]
        public bool CausesValidation
        {
            get
            {
                if (ViewState["_causesValidation"] != null)
                {
                    return (bool)ViewState["_causesValidation"];
                }
                else
                {
                    return true;
                }
            }
            set { ViewState["_causesValidation"] = value; }
        }
        #endregion
    }
    /// <summary>
    /// Class For Passing Field To DropDownList
    /// </summary>
    [Serializable]
    public class MyNettierType
    {
        /// <summary>
        /// Text to show in Look For combo box
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Name in SQL Database
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Type in SQL Database
        /// </summary>
        public Type DataType { get; set; }
    }
}

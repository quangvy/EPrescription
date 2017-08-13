
#region Using Directives
using System.Collections.Generic;
using System.Web.UI.WebControls;
#endregion

namespace ePrescription.Web.UI
{
    /// <summary>
    ///     Used to store important GridView and GridViewSearchPanel properties
    ///     so that their state can be maintained
    /// </summary>
    public class GridViewMultiFilterState
    {
        #region Properties

        #region GridView

        /// <summary>
        ///     Gets or sets the index of the page.
        /// </summary>
        /// <value>The index of the page.</value>
        public int PageIndex { get; set; }

        /// <summary>
        ///     Gets or sets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        public int PageSize { get; set; }

        /// <summary>
        ///     Gets or sets the sort expression.
        /// </summary>
        /// <value>The sort expression.</value>
        public string SortExpression { get; set; }

        /// <summary>
        ///     Gets or sets the sort direction.
        /// </summary>
        /// <value>The sort direction.</value>
        public SortDirection SortDirection { get; set; }

        #endregion

        #region GridViewMultiFilter

        /// <summary>
        ///     Gets or sets the search filters data.
        /// </summary>
        /// <value>The search filters data</value>
        public List<GridViewMultiFilter.FilterStructure> FilteringData { get; set; }

        /// <summary>
        ///     Gets or sets the filter expression.
        /// </summary>
        /// <value>The filter expression.</value>
        /// 
        public string FilterExpression { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the GridViewMultiFilterState" class.
        /// </summary>
        public GridViewMultiFilterState()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the GridViewMultiFilterState" class.
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        /// <param name="searchPanel">The multi filter.</param>
        public GridViewMultiFilterState(GridView gridView, GridViewMultiFilter searchPanel)
        {
            SaveState(gridView, searchPanel);
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Saves the state of the grid view and grid view multi filter.
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        /// <param name="multiFilter">The multi filter.</param>
        public void SaveState(GridView gridView, GridViewMultiFilter multiFilter)
        {
            // Grid view values
            PageIndex = gridView.PageIndex;
            PageSize = gridView.PageSize;
            SortExpression = gridView.SortExpression;
            SortDirection = gridView.SortDirection;

            //SearchFieldName = searchPanel.SearchFieldName;
            //SearchOperator = searchPanel.SearchOperator;
            //SearchKeyword = searchPanel.SearchKeyword;
            FilterExpression = multiFilter.FilterExpression;
            //var repeater = (Repeater) multiFilter.FindControl("rep_FilterTemplate");
            FilteringData = multiFilter.FilteringData;
            //    new List<GridViewMultiFilter.FilterStructure>();
            //for (int i = 0; i < repeater.Items.Count; ++i)
            //{
            //    var ddrColumn = repeater.Items[i].FindControl("cboFieldName") as DropDownList;
            //    var ddrOperation = repeater.Items[i].FindControl("cboOperator") as DropDownList;
            //    var ddrRelation = repeater.Items[i].FindControl("cboRelation") as DropDownList;
            //    var filterStructure = new GridViewMultiFilter.FilterStructure();
            //    filterStructure.EqualValue = (repeater.Items[i].FindControl("txtKeyword") as TextBox).Text;
            //    filterStructure.ColumnIndex = ddrColumn.SelectedIndex;
            //    filterStructure.RelationIndex = ddrRelation.SelectedIndex;
            //    filterStructure.OperationIndex = ddrOperation.SelectedIndex;
            //    FilteringData.Add(filterStructure);
            //}
        }

        /// <summary>
        ///     Restores the state of the grid view and grid view multi filter.
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        /// <param name="multiFilter">The multi filter.</param>
        public void RestoreState(ref GridView gridView, ref GridViewMultiFilter multiFilter)
        {
            gridView.PageIndex = PageIndex;
            gridView.PageSize = PageSize;

            //searchPanel.SearchFieldName = SearchFieldName;
            //searchPanel.SearchKeyword = SearchKeyword;
            //searchPanel.SearchOperator = SearchOperator;
            multiFilter.FilterExpression = FilterExpression;
            var repeater = (Repeater)multiFilter.FindControl("rep_FilterTemplate");
            multiFilter.FilteringData = FilteringData;
            repeater.DataSource = FilteringData;
            repeater.DataBind();
            multiFilter.AutoShow();
            //for (int i = 0; i < repeater.Items.Count; ++i)
            //{
            //    var ddrColumn = repeater.Items[i].FindControl("cboFieldName") as DropDownList;
            //    var ddrOperation = repeater.Items[i].FindControl("cboOperator") as DropDownList;
            //    var ddrRelation = repeater.Items[i].FindControl("cboRelation") as DropDownList;
            //    var txtKeyWord = repeater.Items[i].FindControl("txtKeyword") as TextBox;
            //    ddrColumn.SelectedIndex = FilteringData[i].ColumnIndex;
            //    ddrOperation.SelectedIndex = FilteringData[i].OperationIndex;
            //    ddrRelation.SelectedIndex = FilteringData[i].RelationIndex;
            //    txtKeyWord.Text = FilteringData[i].EqualValue;
            //}

            if (!string.IsNullOrEmpty(SortExpression))
            {
                gridView.Sort(SortExpression, SortDirection);
            }
        }

        #endregion
    }
}

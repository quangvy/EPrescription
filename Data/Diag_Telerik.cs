using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using Telerik.Web.UI;

namespace ComboBox.Examples.PopulatingWithData.AutoCompleteSql
{
    [ScriptService]
    public class Products : WebService
    {
        [WebMethod]
        public RadComboBoxData GetCompanyNames(RadComboBoxContext context)
        {
            string sql = "SELECT diag_code+'-'+Diag_name as Diag_name from Diag_list WHERE diag_name LIKE '%'+ @text + '%' or diag_code LIKE '%'+ @text + '%'";

            SqlDataAdapter adapter = new SqlDataAdapter(sql,
                ConfigurationManager.ConnectionStrings["CMS"].ConnectionString);
            DataTable data = new DataTable();

            adapter.SelectCommand.Parameters.AddWithValue("@text", context.Text.Replace("%", "[%]"));
            adapter.Fill(data);

            List<RadComboBoxItemData> result = new List<RadComboBoxItemData>(context.NumberOfItems);
            RadComboBoxData comboData = new RadComboBoxData();
            try
            {
                int itemsPerRequest = 10;
                int itemOffset = context.NumberOfItems;
                int endOffset = itemOffset + itemsPerRequest;
                if (endOffset > data.Rows.Count)
                {
                    endOffset = data.Rows.Count;
                }
                if (endOffset == data.Rows.Count)
                {
                    comboData.EndOfItems = true;
                }
                else
                {
                    comboData.EndOfItems = false;
                }
                result = new List<RadComboBoxItemData>(endOffset - itemOffset);
                for (int i = itemOffset; i < endOffset; i++)
                {
                    RadComboBoxItemData itemData = new RadComboBoxItemData();
                    itemData.Text = data.Rows[i]["Diag_name"].ToString();
                    itemData.Value = data.Rows[i]["Diag_name"].ToString();

                    result.Add(itemData);
                }

                if (data.Rows.Count > 0)
                {
                    comboData.Message = String.Format("Items <b>1</b>-<b>{0}</b> out of <b>{1}</b>", endOffset.ToString(), data.Rows.Count.ToString());
                }
                else
                {
                    comboData.Message = "No matches";
                }
            }
            catch (Exception e)
            {
                comboData.Message = e.Message;
            }

            comboData.Items = result.ToArray();
            return comboData;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvRow in GridView1.Rows)
        {
            CheckBox checkbox = (CheckBox)gvRow.Cells[0].FindControl("CheckBox1");
            if (checkbox.Checked)
            {
                Server.Transfer("~/Default2.aspx");
            }
            else
            {
                Label1.Text = "Please select a product to pass to another page";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("ProductID", typeof(int));
        dt.Columns.Add("ProductName", typeof(string));
        dt.Columns.Add("CategoryID", typeof(int));
        dt.Columns.Add("UnitPrice", typeof(decimal));

        foreach (GridViewRow gvRow in GridView1.Rows)
        {
            CheckBox checkbox = (CheckBox)gvRow.Cells[0].FindControl("CheckBox1");
            if (checkbox.Checked)
            {
                DataRow row = dt.NewRow();
                row["ProductID"] = gvRow.Cells[1].Text;
                row["ProductName"] = gvRow.Cells[2].Text;
                row["CategoryID"] = gvRow.Cells[3].Text;
                row["UnitPrice"] = gvRow.Cells[4].Text;
                dt.Rows.Add(row);
            }
        }
        Session["ProductsTable"] = dt;
        Response.Redirect("~/Default2.aspx");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.PreviousPage != null)
        {
            GridView GridView1 = (GridView)Page.PreviousPage.FindControl("GridView1");

            foreach (GridViewRow gvRow in GridView1.Rows)
            {
                CheckBox checkbox = (CheckBox)gvRow.Cells[0].FindControl("CheckBox1");
                if (checkbox.Checked)
                {
                    Label1.Text += "ProductID: " + gvRow.Cells[0].Text + "<br />";
                    Label1.Text += "ProductName: " + gvRow.Cells[1].Text + "<br />";
                    Label1.Text += "CategoryID: " + gvRow.Cells[2].Text + "<br />";
                    Label1.Text += "UnitPrice: " + gvRow.Cells[3].Text + "<br />";
                }
            }
        }

        if (Session["ProductsTable"] != null)
        {
            DataTable dt = (DataTable)Session["ProductsTable"];

            GridView1.DataSource = dt;
            GridView1.DataBind();
            Session["ProductsTable"] = null;
        }
    }
}
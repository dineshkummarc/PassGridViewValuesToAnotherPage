Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        For Each gvRow As GridViewRow In GridView1.Rows
            Dim checkbox As CheckBox = DirectCast(gvRow.Cells(0).FindControl("CheckBox1"), CheckBox)
            If checkbox.Checked Then
                Server.Transfer("~/Default2.aspx")
            Else
                Label1.Text = "Please select a product to pass to another page"
                Label1.ForeColor = System.Drawing.Color.Red
            End If
        Next
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Dim dt As New DataTable()

        dt.Columns.Add("ProductID", GetType(Integer))
        dt.Columns.Add("ProductName", GetType(String))
        dt.Columns.Add("CategoryID", GetType(Integer))
        dt.Columns.Add("UnitPrice", GetType(Decimal))

        For Each gvRow As GridViewRow In GridView1.Rows
            Dim checkbox As CheckBox = DirectCast(gvRow.Cells(0).FindControl("CheckBox1"), CheckBox)
            If checkbox.Checked Then
                Dim row As DataRow = dt.NewRow()
                row("ProductID") = gvRow.Cells(1).Text
                row("ProductName") = gvRow.Cells(2).Text
                row("CategoryID") = gvRow.Cells(3).Text
                row("UnitPrice") = gvRow.Cells(4).Text
                dt.Rows.Add(row)
            End If
        Next
        Session("ProductsTable") = dt
        Response.Redirect("~/Default2.aspx")
    End Sub
End Class

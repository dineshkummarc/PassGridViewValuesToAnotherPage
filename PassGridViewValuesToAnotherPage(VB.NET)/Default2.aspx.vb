Imports System.Data

Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.PreviousPage IsNot Nothing Then
            Dim GridView1 As GridView = DirectCast(Page.PreviousPage.FindControl("GridView1"), GridView)

            For Each gvRow As GridViewRow In GridView1.Rows
                Dim checkbox As CheckBox = DirectCast(gvRow.Cells(0).FindControl("CheckBox1"), CheckBox)
                If checkbox.Checked Then
                    Label1.Text += "ProductID: " + gvRow.Cells(0).Text + "<br />"
                    Label1.Text += "ProductName: " + gvRow.Cells(1).Text + "<br />"
                    Label1.Text += "CategoryID: " + gvRow.Cells(2).Text + "<br />"
                    Label1.Text += "UnitPrice: " + gvRow.Cells(3).Text + "<br />"
                End If
            Next
        End If

        If Session("ProductsTable") IsNot Nothing Then
            Dim dt As DataTable = CType(Session("ProductsTable"), DataTable)
            GridView1.DataSource = dt
            GridView1.DataBind()
            Session("ProductsTable") = Nothing
        End If
    End Sub
End Class

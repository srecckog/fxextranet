using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Drawing;

public partial class Contact : Page
{

    public SqlConnection con;
    public string constr, connstr2;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["rfind1"].ToString();
        con = new SqlConnection(constr);
        con.Open();
        
        //string query = "select * from event e left join [user] u on e.[user]=u.oid where u.[lastname] like '%"+TextBox1.Text.TrimEnd()+"%' order by dt desc";
        string query = "select  * from telefonskimenik where prezime like '"+TextBox1.Text.TrimEnd()+"%' order by prezime";

        SqlDataAdapter da = new SqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowIndex == GridView1.SelectedIndex)
            {
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                row.ToolTip = string.Empty;
                string f1=row.Cells[0].Text.ToString();
                //int CellValue = Convert.ToInt32(row.Cells[2].Text);
            }
            else
            {
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                row.ToolTip = "Click to select this row.";
            }
        }

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Attaching one onclick event for the entire row, so that it will
            // fire SelectedIndexChanged, while we click anywhere on the row.
            e.Row.Attributes["onclick"] =
              ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
        }
    }
}
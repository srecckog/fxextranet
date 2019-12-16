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

public partial class DSR1 : System.Web.UI.Page
{
    public SqlConnection con;
    public string constr, connstr2;
    protected void Page_Load(object sender, EventArgs e)
    {
        int g = 1;
        if (Session["vrstaizv"] == null)
        {
            Session["vrstaizv"] = "Jucer";
        }
        if (Session["smjena"] == null)
        {
            Session["smjena"] = "Sve";
        }

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string name = GridView1.SelectedRow.Cells[0].Text;

    }
    protected void BindData()
    {
        string vrstaizv = Session["vrstaizv"].ToString();
        string smjena   = Session["smjena"].ToString();
        string constr = ConfigurationManager.ConnectionStrings["Feroapp1"].ToString();
        con = new SqlConnection(constr);
        con.Open();
        //string query = "select * from event e left join [user] u on e.[user]=u.oid where u.[lastname] like '%"+TextBox1.Text.TrimEnd()+"%' order by dt desc";
        string query = "";

        if (smjena.Contains("Sve"))
        {
            if (vrstaizv.Contains("Danas"))
            {
                DateTime danas = DateTime.Now;
                string dat1 = danas.Year.ToString() + "-" + danas.Month.ToString() + "-" + danas.Day.ToString();
                query = "rfind.dbo.realizacija '" + dat1 + "','" + dat1 + "',14";
            }
            else
            {
                DateTime danas = DateTime.Now.AddDays(-1);
                string dat1 = danas.Year.ToString() + "-" + danas.Month.ToString() + "-" + danas.Day.ToString();
                query = "rfind.dbo.realizacija '" + dat1 + "','" + dat1 + "',14";
            }
        }
        else    // po smjenama
        {
            string smjena1 = smjena;
            if (vrstaizv.Contains("Danas"))
            {
                DateTime danas = DateTime.Now;
                string dat1 = danas.Year.ToString() + "-" + danas.Month.ToString() + "-" + danas.Day.ToString();
                query = "rfind.dbo.realizacija2 '" + dat1 + "','" + dat1 + "',14,"+smjena1;
            }
            else
            {
                DateTime danas = DateTime.Now.AddDays(-1);
                string dat1 = danas.Year.ToString() + "-" + danas.Month.ToString() + "-" + danas.Day.ToString();
                query = "rfind.dbo.realizacija2 '" + dat1 + "','" + dat1 + "',14,"+smjena1;
            }


        }

        
        SqlDataAdapter da = new SqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        Button2.Visible = true;
    }
    // buttn, danas
    protected void Button1_Click(object sender, EventArgs e)
    {
        Button1.BackColor = System.Drawing.Color.GreenYellow;
        Button3.BackColor = System.Drawing.Color.White;
        Session["vrstaizv"] = "Danas";
        BindData();

    }

    // buttn, jučer
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=PregledProizvodnje" + System.DateTime.Now.ToString() + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter stringWriter = new StringWriter())
            {
                HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
                GridView1.RenderControl(htmlTextWriter);
                Response.Output.Write(stringWriter.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception ex)
        {
            String error = ex.Message.ToString();
        }
    }



    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that all the controls is rendered */
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindData();
    }

    // buttn, pregled po evidenciji normi
    protected void Button3_Click(object sender, EventArgs e)
    {

        Session["vrstaizv"] = "Jučer";
        Button3.BackColor = System.Drawing.Color.GreenYellow;
        Button1.BackColor = System.Drawing.Color.White;
        BindData();

        
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





    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue=="1")
        {
            Session["smjena"] = "1";

        }
        if (RadioButtonList1.SelectedValue == "2")
        {
            Session["smjena"] = "2";

        }
        if (RadioButtonList1.SelectedValue == "3")
        {
            Session["smjena"] = "3";

        }
        if (RadioButtonList1.SelectedValue == "4")
        {
            Session["smjena"] = "Sve";
        }
    }
}
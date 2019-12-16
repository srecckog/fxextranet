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

public partial class Reports : System.Web.UI.Page
{
    public SqlConnection con;
    public string constr;
    protected void Page_Load(object sender, EventArgs e)
    {
        

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["rfind1"].ToString();
        con = new SqlConnection(constr);
        con.Open();

        //string query = "select * from event e left join [user] u on e.[user]=u.oid where u.[lastname] like '%"+TextBox1.Text.TrimEnd()+"%' order by dt desc";
        string query = "select top 100 (rtrim(u.[lastname]) + ' ' + rtrim(u.[firstname])) Ime,e.dt Vrijeme, r.Name Čitač, u.extid ID,t.codename status from event e left join[user] u on e.[user]= u.oid left join Reader r on r.Id= e.Device_ID left join eventtype t on t.Code=e.EventType where (rtrim(u.[lastname])+' '+rtrim(u.[firstname])) like '" + TextBox1.Text.TrimEnd() + "%' order by dt desc";

       SqlDataAdapter da = new SqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        Button2.Visible = true;


    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=PregledRegistracije"   + System.DateTime.Now.ToString() + ".xls");
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


}
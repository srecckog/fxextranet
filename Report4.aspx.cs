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


public partial class Report4 : System.Web.UI.Page
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
        DateTime danas = DateTime.Now;
        DateTime prije = danas.AddDays(-100);
        string sdanas = danas.Year.ToString() + '-' + danas.Month.ToString() + '-' + danas.Day.ToString();
        string sprije = prije.Year.ToString() + '-' + prije.Month.ToString() + '-' + prije.Day.ToString();

        //string query = "select * from event e left join [user] u on e.[user]=u.oid where u.[lastname] like '%"+TextBox1.Text.TrimEnd()+"%' order by dt desc";
        string query = "select top 100 Radnik,Vrsta,Firma,Datum,Hala,Smjena,LInija,NazivPar,BrojRn,Proizvod,Norma,KOlicinaok,OtpadObrada,OtpadMat,kolicinaPorozno,MinutaRadaradnika,Napomena1,Napomena2,Napomena3,MT,PomocniRadnik from fx_rfind.dbo.evidnormiradad('"+sprije+"','"+sdanas+"') where radnik like '"+TextBox1.Text.TrimEnd()+"%'  order by datum desc";

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
            Response.AddHeader("content-disposition", "attachment;filename=PregledIzvršenjarada" + System.DateTime.Now.ToString() + ".xls");
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

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string name = GridView1.SelectedRow.Cells[0].Text;
    }
}
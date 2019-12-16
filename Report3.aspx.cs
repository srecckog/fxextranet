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
using System.Globalization;

public partial class Report3 : System.Web.UI.Page
{
    public SqlConnection con;
    public string constr, connstr2;
    protected void Page_Load(object sender, EventArgs e)
    {
        int g = 1;
        if (Session["baza"] == null)
        {
            Session["baza"] = "rfind1";            
        }
               
    }


    // click on datagridview, evidencija normi
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.SelectedRow.BackColor = Pnl_kolicina.BackColor;
        string dat1 = GridView1.SelectedRow.Cells[0].Text;
        string l1 = GridView1.SelectedRow.Cells[4].Text;
        string s1 = GridView1.SelectedRow.Cells[2].Text;               
        string h1 = GridView1.SelectedRow.Cells[1].Text;
        string k1 = GridView1.SelectedRow.Cells[7].Text;
        string idpro1 = GridView1.SelectedRow.Cells[9].Text;

        TextBox3.Text = k1;
        DateTime dt2 = DateTime.ParseExact(dat1,"dd.MM.yyyy", CultureInfo.InvariantCulture);
        //string h1 = TextBox2.Text;
        dat1 = dt2.Year.ToString() + "-" + dt2.Month.ToString() + '-' + dt2.Day.ToString();
        //string l1 = TextBox1.Text;

        if (l1.Length < 2)
            l1 = "0" + l1.TrimEnd();

        l1 = " linija='" + l1 + "' or linija='" + l1 + "*' ";

        Pnl_kolicina.Visible = true;
        string gsql1 = "select z.hala,s.linija,n.kolicinanar,n.id_mat,z.[username],s.kolicinaok,s.norma,s.brojrn,s.vrijemeod,s.vrijemedo,s.radnik,z.smjena,n.id_pro,p.NazivPro,z.datum,n.aktivno FROM[FeroApp].[dbo].[EvidencijaNormiZag] z " +
                      "left join[FeroApp].[dbo].[EvidencijaNormista] s on z.id_enz=s.id_enz left join narudzbesta n on n.Brojrn=s.brojrn left join Proizvodi p on p.id_pro=n.id_pro where hala='"+h1+"' and ("+l1+")  and smjena='"+s1+"' and datum = '"+dat1+"' ";
        connstr2 = Session["baza"].ToString();
        string constr = ConfigurationManager.ConnectionStrings[connstr2].ToString();
        con = new SqlConnection(constr);
        con.Open();
        
        SqlCommand cmd = new SqlCommand(gsql1, con);

        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        tr1_hala1.Text= dr[0].ToString()+" Smjena:"+ dr[11].ToString();
        tr1_linija1.Text = dr[1].ToString();
        tr2_radnik1.Text = dr[10].ToString();
        tr2_rn1.Text = dr[7].ToString();
        tr3_proizvod1.Text = dr[13].ToString()+" ("+ dr[12].ToString()+")";
        tr3_mat1.Text = dr[3].ToString();
        tr4_naruceno1.Text = dr[2].ToString();
        tr4_norma1.Text = dr[6].ToString();
        dat1 = dr[14].ToString();
        string[] s11 = dat1.Split(' ');       
        
        dat1 = s11[0].Substring(0, s11[0].Length - 1);
        
        tr5_datum1.Text = dat1;
        tr5_zobrada1.Text = ""; // dr[6].ToString();



    }

    protected void BindData()
    {
        connstr2 = Session["baza"].ToString();
        string constr = ConfigurationManager.ConnectionStrings[connstr2].ToString();
        con = new SqlConnection(constr);
        con.Open();
        //string query = "select * from event e left join [user] u on e.[user]=u.oid where u.[lastname] like '%"+TextBox1.Text.TrimEnd()+"%' order by dt desc";
        string query = "";
        if (connstr2.Contains("rfind"))
        {
            query = "select top 100 Convert(VarChar, p.datum, 104) Datum,r.id,r.prezime,r.ime,p.hala H ,p.smjena S ,p.radnomjesto,p.dosao,p.otisao,p.Kasni,p.Ukupno_minuta,p.Ukupno_sati from pregledvremena p left join radnici_ r on r.id = p.idradnika where p.radnomjesto like  '%" + TextBox1.Text.TrimEnd() + "%' and p.hala = '" + TextBox2.Text.TrimEnd() + "'  order by p.datum desc";
        }
        else
        {
            DateTime oddatuma = DateTime.Now.AddDays(-30);
            DateTime dodatuma = DateTime.Now;
            string soddatuma = oddatuma.Year.ToString() + '-' + oddatuma.Month + '-' + oddatuma.Day;
            string sdodatuma = dodatuma.Year.ToString() + '-' + dodatuma.Month + '-' + dodatuma.Day;
            string linija1 = TextBox2.Text.TrimEnd();
            if (linija1.Length < 2)
                   linija1 = "0" + linija1;
            linija1 = " e.linija='" + linija1 + "' or e.linija='" + linija1 + "*' ";

            query = "select Convert(VarChar, e.datum, 104) Datum, Hala H, e.Smjena S ,e.Radnik,e.Linija L, Brojrn, Nazivpro,  Kolicinaok, Norma, Zavrsnaobrada, Gotovo, Obradaa, Obradab, Obradac, Obradad, Obradae, Vrstanarudzbe, kupac from evidnormi('" + soddatuma + "', '" + sdodatuma + "', 0) e where e.linija like  '%" + TextBox1.Text.TrimEnd() + "%' and e.hala = '" + TextBox2.Text.TrimEnd() + "'  order by e.datum desc";
            query = "select Convert(VarChar, e.datum, 104) Datum, Hala H, e.Smjena S ,e.Radnik,e.Linija L, Brojrn, Nazivpro,  Kolicinaok, Norma, Zavrsnaobrada, Gotovo, Obradaa, Obradab, Obradac, Obradad, Obradae, Vrstanarudzbe, kupac from evidnormi('" + soddatuma + "', '" + sdodatuma + "', 0) e where " + linija1+ " and e.hala = '" + TextBox2.Text.TrimEnd() + "'  order by e.datum desc";

        }
        SqlDataAdapter da = new SqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        Button2.Visible = true;
    }
    // buttn, pregled po planu
    protected void Button1_Click(object sender, EventArgs e)
    {
        Button1.BackColor= System.Drawing.Color.GreenYellow;
        Button3.BackColor = System.Drawing.Color.White;
        Session["baza"] = "rfind1";
        connstr2 = Session["baza"].ToString();
        string constr = ConfigurationManager.ConnectionStrings[connstr2].ToString();
        con = new SqlConnection(constr);
        con.Open();

        //string query = "select * from event e left join [user] u on e.[user]=u.oid where u.[lastname] like '%"+TextBox1.Text.TrimEnd()+"%' order by dt desc";

        string query = "select top 100 Convert(VarChar, p.datum, 104) Datum,r.id,r.prezime,r.ime,p.hala H ,p.smjena S ,p.radnomjesto,p.dosao,p.otisao,p.Kasni,p.Ukupno_minuta,p.Ukupno_sati from pregledvremena p left join radnici_ r on r.id = p.idradnika where p.radnomjesto like  '%" + TextBox1.Text.TrimEnd() + "%' and p.hala = '" + TextBox2.Text.TrimEnd() + "'  order by p.datum desc";
        SqlDataAdapter da = new SqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        Button2.Visible = true;


    }

    // buttn, export to excel
    protected void Button2_Click(object sender, EventArgs e)
    {
       
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=PregledRegistracije" + System.DateTime.Now.ToString() + ".xls");
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
        Button1.BackColor = System.Drawing.Color.White;
        Button3.BackColor = System.Drawing.Color.GreenYellow;
        Session["baza"] = "feroapp1";
        string constr = ConfigurationManager.ConnectionStrings["feroapp1"].ToString();
        con = new SqlConnection(constr);
        con.Open();

        //string query = "select * from event e left join [user] u on e.[user]=u.oid where u.[lastname] like '%"+TextBox1.Text.TrimEnd()+"%' order by dt desc";

        DateTime oddatuma = DateTime.Now.AddDays(-30);
        DateTime dodatuma = DateTime.Now;
        string soddatuma = oddatuma.Year.ToString() + '-' + oddatuma.Month + '-' + oddatuma.Day;
        string sdodatuma = dodatuma.Year.ToString() + '-' + dodatuma.Month + '-' + dodatuma.Day;
        string linija1 = TextBox1.Text.TrimEnd();
        if (linija1.Length < 2)
            linija1 = "0" + linija1;
        linija1 = " e.linija='" + linija1 + "' or e.linija='" + linija1 + "*' ";

        string query = "select Convert(VarChar, e.datum, 104) Datum, Hala H, e.Smjena S,e.Radnik,e.Linija L, Brojrn, Nazivpro,  Kolicinaok, Norma, id_pro,id_mat,Zavrsnaobrada, Gotovo, Obradaa, Obradab, Obradac, Obradad, Obradae, Vrstanarudzbe, kupac from evidnormi('"+soddatuma+"', '"+sdodatuma+"', 0) e where (" + linija1 + ") and e.hala = '" + TextBox2.Text.TrimEnd() + "'  order by e.datum desc,smjena desc,linija desc";

        SqlDataAdapter da = new SqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        Button2.Visible = true;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Attaching one onclick event for the entire row, so that it will
            // fire SelectedIndexChanged, while we click anywhere on the row.
            //e.Row.Attributes["onclick"] =
            //  ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
        }

        try
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.Header:
                    //...
                    break;
                case DataControlRowType.DataRow:
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#93A3B0'; this.style.color='White'; this.style.cursor='pointer'");
                    if (e.Row.RowState == DataControlRowState.Alternate)
                    {
                        e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", GridView1.AlternatingRowStyle.BackColor.ToKnownColor()));
                    }
                    else
                    {
                        e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", GridView1.RowStyle.BackColor.ToKnownColor()));
                    }
                    e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(GridView1, "Select$" + e.Row.RowIndex.ToString()));
                    break;
            }
        }
        catch
        {
            //...throw
        }



    }
    protected void grvSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //Do wherever you want with grvSearch.SelectedIndex    
            int z = 1;
        }
        catch
        {
            //...throw
        }
    }


    protected void btn_kolicina_Click(object sender, EventArgs e)
    {
        Pnl_kolicina.Visible = false;


        string h1 = TextBox2.Text;
        string l1 = TextBox1.Text;

//        string gsql1 = "select z.hala,s.linija,z.[username],s.kolicinaok,s.norma,s.brojrn,s.vrijemeod,s.vrijemedo,s.radnik,n.id_pro,p.NazivPro,n.id_mat,n.aktivno,n.kolicinanar FROM[FeroApp].[dbo].[EvidencijaNormiZag] z" +
//                      "left join[FeroApp].[dbo].[EvidencijaNormista] s on z.id_enz=s.id_enz left join narudzbesta n on n.Brojrn=s.brojrn left join Proizvodi p on p.id_pro=n.id_pro where hala="+h1+" and linija = '"+l1+"'   and datum = '"+dat1+"'";

//        string sql1 = "insert into "
    }
}



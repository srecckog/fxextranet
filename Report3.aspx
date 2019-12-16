<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" EnableEventValidation="False" AutoEventWireup="true" CodeFile="Report3.aspx.cs" Inherits="Report3" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>Pregled planiranja linija</h2>
    <link href="~/Content//GridView.css" rel="stylesheet" />
    <p>
        Linija
        :
        <asp:TextBox ID="TextBox1" runat="server" Width="80px"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="Hala"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Width="62px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Pretraži plan" />
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Evidencija normi" />
    </p>
    <p>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Izvoz u Excel" Visible="False" Width="123px" />
</p>
    <asp:Panel ID="Pnl_kolicina" runat="server" Height="238px" BackColor="#33CCFF" BorderStyle="Double" Visible="False">
        <br />
        <br />
        <asp:Table ID="Table1" runat="server" BorderStyle="Solid" Height="103px" Width="661px">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Hala</asp:TableCell>
                <asp:TableCell  ID="tr1_hala1" runat="server"></asp:TableCell>
                <asp:TableCell runat="server">Linija</asp:TableCell>
                <asp:TableCell ID="tr1_linija1" runat="server"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Radnik</asp:TableCell>
                <asp:TableCell ID="tr2_radnik1" runat="server"></asp:TableCell>
                <asp:TableCell runat="server">Radni Nalog</asp:TableCell>
                <asp:TableCell ID="tr2_rn1" runat="server"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Proizvod</asp:TableCell>
                <asp:TableCell ID="tr3_proizvod1" runat="server"></asp:TableCell>
                <asp:TableCell runat="server">Materijal</asp:TableCell>
                <asp:TableCell ID="tr3_mat1" runat="server"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Naručeno</asp:TableCell>
                <asp:TableCell ID="tr4_naruceno1" runat="server"></asp:TableCell>
                <asp:TableCell runat="server">Norma</asp:TableCell>
                <asp:TableCell ID="tr4_norma1" runat="server"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Datum</asp:TableCell>
                <asp:TableCell ID="tr5_datum1" runat="server"></asp:TableCell>
                <asp:TableCell runat="server">Završna obrada</asp:TableCell>
                <asp:TableCell ID="tr5_zobrada1" runat="server"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Label ID="Label2" runat="server" Text="Količina"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" Height="16px" Width="55px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btn_kolicina0" runat="server" OnClick="btn_kolicina_Click" Text="Spremi" Width="339px" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </asp:Panel>
<p>
    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        AllowPaging="True" PageSize="25" ShowFooter="True" CssClass="GridViewStyle" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound"> 
             <HeaderStyle CssClass="HeaderStyle" BackColor="lightgrey" Font-Bold="True" ForeColor="White" />
             <FooterStyle CssClass="FooterStyle" BackColor="#990000" Font-Bold="True" ForeColor="White" />
             <RowStyle CssClass="RowStyle" BackColor="#FFFBD6" ForeColor="#333333" />
             <AlternatingRowStyle CssClass="AlternatingRowStyle" BackColor="White" />
             <PagerStyle CssClass="PagerStyle" BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />         
             <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
             <SortedAscendingCellStyle BackColor="#FDF5AC" />
             <SortedAscendingHeaderStyle BackColor="#4D0000" />
             <SortedDescendingCellStyle BackColor="#FCF6C0" />
             <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>

    <asp:GridView ID="GridView11" runat="server" AutoGenerateColumns="False"  Width="600px" 

             AllowPaging="True" PageSize="15" ShowFooter="True" CssClass="GridViewStyle" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">            

             <HeaderStyle CssClass="HeaderStyle" BackColor="Tan" Font-Bold="True" />

             <FooterStyle CssClass="FooterStyle" BackColor="Tan" />

             <RowStyle CssClass="RowStyle" />

             <AlternatingRowStyle CssClass="AlternatingRowStyle" BackColor="PaleGoldenrod" />

             <PagerStyle CssClass="PagerStyle" BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />           

             <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
             <SortedAscendingCellStyle BackColor="#FAFAE7" />
             <SortedAscendingHeaderStyle BackColor="#DAC09E" />
             <SortedDescendingCellStyle BackColor="#E1DB9C" />
             <SortedDescendingHeaderStyle BackColor="#C2A47B" />

        </asp:GridView> 


</p>
<p>&nbsp;</p>
</asp:Content>

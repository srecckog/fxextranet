<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DSR1.aspx.cs" Inherits="DSR1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2><%: Title %>Pregled proizvedene količine</h2>
    <link href="~/Content//GridView.css" rel="stylesheet" />
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Danas" />
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Jučer" />
    </p>
    <hr />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        






    </asp:UpdatePanel>
    <p>
        Smjena:<asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem Value="4">Sve</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Izvoz u Excel" Visible="False" Width="123px" />
    </p>
    <hr />
    <p>
        &nbsp;</p>
<p>
    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        AllowPaging="True" PageSize="25" ShowFooter="True" CssClass="GridViewStyle" CellPadding="4" ForeColor="#333333" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False"> 
             <HeaderStyle CssClass="HeaderStyle" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <Columns>
                 <asp:BoundField DataField="kupac" HeaderText="Kupac" />
                 <asp:BoundField DataField="norma" HeaderText="Planirano" />
                 <asp:BoundField DataField="kolicina" HeaderText="Količina" />
                 <asp:BoundField DataField="vrijednost" HeaderText="Vrijednost EUR" DataFormatString="{0:0.00}" />
                 <asp:BoundField DataField="vrstapro" HeaderText="Vrsta proizvoda" />
                 <asp:BoundField DataField="vo" HeaderText="Vrsta obrade" />
             </Columns>
             <EditRowStyle BackColor="#2461BF" />
             <FooterStyle CssClass="FooterStyle" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <RowStyle CssClass="RowStyle" BackColor="#EFF3FB" />
             <AlternatingRowStyle CssClass="AlternatingRowStyle" BackColor="White" />
             <PagerStyle CssClass="PagerStyle" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />         
             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
             <SortedAscendingCellStyle BackColor="#F5F7FB" />
             <SortedAscendingHeaderStyle BackColor="#6D95E1" />
             <SortedDescendingCellStyle BackColor="#E9EBEF" />
             <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>


</p>
<p>&nbsp;</p>


</asp:Content>


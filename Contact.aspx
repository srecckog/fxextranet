<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" EnableEventValidation="False" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <h3>&nbsp;</h3>
    <address>
        &nbsp;</address>
    <address>
    <h1>    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Larger" style="text-align: center" Text="Interni telefonski imenik"></asp:Label></h1>
    </address>
    <hr />
<address>
        <asp:Label ID="Label1" runat="server" Text="Unesi prezime: "></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Height="16px" Width="120px"></asp:TextBox>
       
    </address>
<address>
        <asp:Button ID="Button1" runat="server" Text="Pretraži" OnClick="Button1_Click" />
       
    </address>
<address>
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" >
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#594B9C" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#33276A" />
        </asp:GridView>
       
    </address>
<address>
        <br />
       
    </address>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SVUPage.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
     .style3
        {
            width: 222px;
        }
       .auto-style6 {
           width: 955px;
       }
       .auto-style7 {
           text-align: left;
       }
       .auto-style8 {
            width: 238px;
            text-align: left;
        }
    .auto-style9 {
        width: 958px;
    }
    .auto-style10 {
        font-size: medium;
    }
        .auto-style11 {
            width: 238px;
            text-align: center;
        }
        .auto-style12 {
            font-size: medium;
            color: #C0C0C0;
        }
        .auto-style13 {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
           <table class="auto-style9" border="1">
     <tr >
        <td class="auto-style8" 
                style="border-width: thin; border-color: #999999; font-family: 'Segoe UI'; font-size: medium; color: #000066; ">
               <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="All Programs at SVU" Width="100%" Height="51px" />
         </td>
          <td rowspan="21" valign="baseline" class="auto-style13">
              <strong>
              <asp:Label ID="Label1" runat="server" Text="Label" Visible="false" CssClass="auto-style10"></asp:Label></strong><br />
              <div class="auto-style13">
              <asp:GridView ID="GridView1" runat="server" Font-Names="Segoe UI" Font-Size="Medium" 
                    CellPadding="4" Font-Bold="True" ForeColor="#333333" GridLines="None" Width="100%">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" /></asp:GridView>
              </div>
              <br /><br />
              <strong>
              <asp:Label ID="Label2" runat="server" Text="Label" Visible="false" CssClass="auto-style10"></asp:Label></strong><br />
              <div class="auto-style13">
              <asp:GridView ID="GridView2" runat="server" Font-Names="Segoe UI" Font-Size="Medium" 
                    CellPadding="4" Font-Bold="True" ForeColor="#333333" GridLines="None" Width="100%">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" /></asp:GridView>
              </div>
              <br /><br />
              <strong>
              <asp:Label ID="Label3" runat="server" Text="Label" Visible="false" CssClass="auto-style10"></asp:Label></strong><br />
              <div class="auto-style13">
              <asp:GridView ID="GridView3" runat="server" Font-Names="Segoe UI" Font-Size="Medium" 
                    CellPadding="4" Font-Bold="True" ForeColor="#333333" GridLines="None" Width="100%">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" /></asp:GridView>
              </div>
              <br /><br />
              <strong>
              <asp:Label ID="Label4" runat="server" Text="Label" Visible="false" CssClass="auto-style10"></asp:Label></strong><br />
              <asp:GridView ID="GridView4" runat="server" Font-Names="Segoe UI" Font-Size="Medium" 
                    CellPadding="4" Font-Bold="True" ForeColor="#333333" GridLines="None" 
                    style="text-align: justify" Width="100%">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" /></asp:GridView><br /><br /><br />
          </td>
 </tr>
 <tr>
          <td class="auto-style11"> 
              <strong>
              <asp:Label ID="Label5" runat="server" Text="Bachelor Programs at SVU" Width="100%" CssClass="auto-style12"></asp:Label>
              </strong>
          </td>

      </tr>
                <tr>
          <td class="auto-style8"><%--1--%>
              <asp:Button ID="Button2" runat="server" Text="Bachelor of Science in Economics"  Width="100%" OnClick="Button2_Click1" style="height: 26px"/>
                         
          </td>

      </tr>
 <tr>
          <td class="auto-style8"><%--2--%>
              <asp:Button ID="Button3" runat="server" Text="Bachelor of Information Technology"  Width="100%" OnClick="Button3_Click"  style="height: 26px" />
                         
          </td>

      </tr>

      <tr>
          <td class="auto-style8"><%--3--%>
                            <asp:Button ID="Button10" runat="server" Text="Bachelor of Mass Communication"  Width="100%" OnClick="Button10_Click"  style="height: 26px" />
          </td>

      </tr>
                 <tr>
          <td class="auto-style8"><%--4--%>
                         <asp:Button ID="Button11" runat="server" Text="Bachelor of Communications Technology"  Width="100%" OnClick="Button11_Click" style="height: 26px" />
          </td>

      </tr>
  <tr>
          <td class="auto-style8"><%--5--%>
                        <asp:Button ID="Button4" runat="server" Text="Bachelor of Law" Width="100%" OnClick="Button4_Click" style="height: 26px" />
            
          </td>

      </tr>
                <tr>
          <td class="auto-style11">
              <strong>
              <asp:Label ID="Label6" runat="server" Text="Master Programs at SVU" Width="100%" CssClass="auto-style12"></asp:Label>
              </strong>
          </td>

      </tr>
 <tr>
          <td class="auto-style8">
                         <asp:Button ID="Button5" runat="server" Text="Master in Web Sciences"  Width="100%" OnClick="Button5_Click" style="height: 26px" />
          </td>

      </tr>

 <tr>
          <td class="auto-style8">
                         <asp:Button ID="Button6" runat="server" Text="Master in Web Technology"  Width="100%" OnClick="Button6_Click" style="height: 26px" />
          </td>

      </tr>
 <tr>
          <td class="auto-style8">
                         <asp:Button ID="Button7" runat="server" Text="Master in Technology Management" Width="100%" OnClick="Button7_Click" style="height: 26px" />
          </td>

      </tr>
                <tr>
          <td class="auto-style8">
                         <asp:Button ID="Button8" runat="server" Text="Master In Quality Management"  Width="100%" OnClick="Button8_Click" style="height: 26px"/>
          </td>

      </tr>
 <tr>
          <td class="auto-style8">
                         <asp:Button ID="Button9" runat="server" Text="Master in Business Administration"  Width="100%" OnClick="Button9_Click" style="height: 26px" />
          </td>

      </tr>
                <tr>
          <td class="auto-style8">
                       
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
            
                       
          </td>

      </tr>
    </table>
    </div>


</asp:Content>


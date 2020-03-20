<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DBpediaSyrianUniversities.aspx.cs" Inherits="_Default" %>

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
              width: 289px;
              text-align: left;
          }
    .auto-style9 {
        width: 958px;
    }
    .auto-style10 {
        font-size: medium;
    }
          .auto-style12 {
              width: 289px;
              text-align: center;
          }
          .auto-style13 {
              font-size: medium;
              color: #CCCCCC;
          }
          .auto-style14 {
              text-align: left;
          }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
           <table class="auto-style9" border="1">
     <tr >
        <td class="auto-style8" 
                style="border-width: thin; border-color: #999999; font-family: 'Segoe UI'; font-size: medium; color: #000066; ">
               <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="All Syrian Universities at DBpedia " Width="100%" Height="46px" />
         </td>
          <td rowspan="21" valign="baseline">
              <strong>
              <asp:Label ID="Label1" runat="server" Text="Label" Visible="false" CssClass="auto-style10"></asp:Label></strong><br /><br />
              <div class="auto-style14">
                <asp:GridView ID="GridView1" runat="server" Font-Names="Segoe UI" Font-Size="Medium" BorderColor="Black" 
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
              </div><br /> <br /><br />
                <strong>
                <asp:Label ID="Label2" runat="server" Text="Label" Visible="false" CssClass="auto-style10"></asp:Label></strong></strong><br /><br />
              <div class="auto-style14">
               <asp:GridView ID="GridView2" runat="server" Font-Names="Segoe UI" Font-Size="Medium" BorderColor="Black"
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
          
          </td>
 </tr>

 <tr>
          <td class="auto-style12">
              <strong>
              <asp:Label ID="Label4" runat="server" Text="Some Public Syrian Universities"   CssClass="auto-style13"  Width="100%"  style="height: 20px"  ></asp:Label>
              </strong>
          </td>

      </tr>
      <tr>
          <td class="auto-style8">
                         <asp:Button ID="Button3" runat="server" Text="Higher Institute for Applied Sciences and Technology"  Width="100%"  style="height: 26px" OnClick="Button3_Click"  />
          </td>

      </tr>
                 <tr>
          <td class="auto-style8">
                         <asp:Button ID="Button4" runat="server" Text="Syrian Virtual University"  Width="100%"  style="height: 26px" OnClick="Button4_Click"  />
          </td>

      </tr>
  <tr>
          <td class="auto-style8">
                         <asp:Button ID="Button5" runat="server" Text="Al-Baath University"  Width="100%"  style="height: 26px" OnClick="Button5_Click"  />
          </td>

      </tr>
 <tr>
          <td class="auto-style8">
                         <asp:Button ID="Button6" runat="server" Text="Tishreen University"   Width="100%"  style="height: 26px" OnClick="Button6_Click"  />
          </td>

      </tr>

 <tr>
          <td class="auto-style8">
                         <asp:Button ID="Button7" runat="server" Text="University of Aleppo"  Width="100%"  style="height: 26px" OnClick="Button7_Click"  />
          </td>

      </tr>
 <tr>
          <td class="auto-style8">
                         <asp:Button ID="Button8" runat="server" Text="Al-Furat University"  Width="100%"  style="height: 26px" OnClick="Button8_Click"  />
          </td>

      </tr>
               
          <tr>

              <td class="auto-style12">
              <strong>
              <asp:Label ID="Label3" runat="server" Text="Some Private Syrian Universities"   Width="100%" CssClass="auto-style13" Height="20px"  ></asp:Label>
              </strong>
          </td>


          </tr>


                <tr>
          <td class="auto-style8">
                         <asp:Button ID="Button9" runat="server" Text="International University for Science and Technology"  Width="100%"  style="height: 26px" OnClick="Button9_Click"  />
          </td>

      </tr>
 <tr>
          <td class="auto-style8">
                         <asp:Button ID="Button10" runat="server" Text="Arab International University"  Width="100%"  style="height: 26px" OnClick="Button10_Click"   />
          </td>

      </tr>
               
                <tr>
          <td class="auto-style8">
                         <asp:Button ID="Button1" runat="server" Text="Syrian Private University"   Width="100%"  style="height: 26px" OnClick="Button1_Click1"  />
          </td>

      </tr>
               
                <tr>
          <td class="auto-style8">
                         <asp:Button ID="Button11" runat="server" Text="Yarmouk Private University"   Width="100%"  style="height: 26px" OnClick="Button11_Click"  />
          </td>

      </tr>
               
                <tr>
          <td class="auto-style8">
                         <asp:Button ID="Button12" runat="server" Text="University of Kalamoon"  Width="100%"  style="height: 26px" OnClick="Button12_Click"  />
          </td>

      </tr>
               
                <tr>
          <td class="auto-style8">
                         <asp:Button ID="Button13" runat="server" Text="Al-Andalus University for Medical Sciences"   Width="100%"  style="height: 26px" OnClick="Button13_Click"  />
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


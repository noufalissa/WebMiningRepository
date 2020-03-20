<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GraphOfDataModel.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .contentbo{
            height: 1000%;
            width: 100%;
            max-width: 1200px;
            margin:0 auto;
            background-color:white;
        }
          .contentboo{
            
            width: 100%;
            max-width: 1200px;
            margin:0 auto;
            background-color:white;
        }
        .imgbo{
            margin:0 auto;
            display:block;
            max-width:100%;
            height:1000px;
        }
        .imgboo{
            margin:0 auto;
            display:block;
            max-width:100%;
           
        }
        .auto-style10 {
            font-size: x-large;
             position: absolute;
            font-size: x-large;

        }
        .auto-style11 {
            text-align: left;
            position: relative;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="auto-style11">
        <asp:Panel ID="Panel3"  runat="server" CssClass="contentboo">
         <strong>
        <asp:Label ID="Label2" runat="server" CssClass="auto-style10" ForeColor="Black" Text="Your RDF document validated Successfully....."></asp:Label>
         ...</strong><br /><br />
    </asp:Panel>
    </div>
    <asp:Panel CssClass="contentbo" ID="Panel4" runat="server">
       
        <asp:Image ID="Image2" CssClass="imgboo" runat="server" ImageUrl="~/images/successfully validat.PNG" />

    </asp:Panel>
    <asp:Panel ID="Panel2"  runat="server" CssClass="contentbo">
         <strong>
        <asp:Label ID="Label1" runat="server" CssClass="auto-style10" ForeColor="Black" Text="Graph of the data model by W3C RDF Powered Validation Service....."></asp:Label>
         ...</strong><br /><br />
         <div>
        <label> To See the Clearer Graph With Width 700%, Please Click</label>
       <asp:HyperLink runat="server" NavigateUrl="~/ClearerGraph.aspx" Target="_blank"> here </asp:HyperLink>
    </div>
    </asp:Panel>
    </div>
    <asp:Panel CssClass="contentbo" ID="Panel1" runat="server">
       
        <asp:Image ID="Image1" CssClass="imgbo" runat="server" ImageUrl="~/images/GraphOfDataModel.gif" />

    </asp:Panel>
   
</asp:Content>


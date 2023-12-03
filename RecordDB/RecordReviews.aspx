<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecordReviews.aspx.cs" Inherits="RecordDB.RecordReviews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div id="main" role="main" class="mainArea"> 
        <div class="table-responsive">
         <asp:GridView ID="recordGridView" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" AllowPaging="True" PageSize="30"  DataSourceID="recordDataSource" runat="server">
            <Columns>
               <asp:BoundField DataField="ArtistName" HtmlEncode="False" HeaderText="Artist">
                   <HeaderStyle Width="15%"></HeaderStyle>
               </asp:BoundField>
               <asp:BoundField DataField="Name" HtmlEncode="False" HeaderText="Title">
                   <HeaderStyle Width="20%"></HeaderStyle>
               </asp:BoundField>
               <asp:BoundField DataField="Review" HeaderText="Field">
                   <HeaderStyle Width="65%"></HeaderStyle>
               </asp:BoundField>
            </Columns>             
         </asp:GridView>
    </div>
    
        <asp:ObjectDataSource
            id="recordDataSource"
            TypeName="RecordDAL.RecordData"
            SelectMethod="SelectRecordReviews"
            Runat="server">
        </asp:ObjectDataSource>        
    </div>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="EndOfPageContent" runat="server">

</asp:Content>

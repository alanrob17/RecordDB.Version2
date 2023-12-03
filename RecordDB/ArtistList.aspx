<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArtistList.aspx.cs" Inherits="RecordDB.ArtistList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="table-responsive">
         <asp:GridView ID="artistGridView" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" AllowPaging="True" PageSize="30"  DataSourceID="artistObjectDataSource" runat="server">
            <Columns>
                <asp:BoundField DataField="ArtistId" HtmlEncode="False" HeaderText="ArtistId">
               </asp:BoundField>
               <asp:BoundField DataField="FirstName" HeaderText="First Name">
               </asp:BoundField>
               <asp:BoundField DataField="LastName" HeaderText="Last Name">
               </asp:BoundField>
               <asp:BoundField DataField="Name" HtmlEncode="False" HeaderText="Artist">
               </asp:BoundField>
               <asp:BoundField DataField="Biography" HeaderText="Biography">
                   <HeaderStyle Width="70%"></HeaderStyle>
               </asp:BoundField>
            </Columns>             
         </asp:GridView>
    </div>
    <asp:ObjectDataSource ID="artistObjectDataSource" TypeName="RecordDAL.ArtistData" SelectMethod="GetArtists" runat="server"></asp:ObjectDataSource>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="EndOfPageContent" runat="server">
</asp:Content>

﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecordReviews.aspx.cs" Inherits="RecordDB.RecordReviews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="main" role="main" class="mainArea">
        <div class="row">
            <div class="col-xs-6 col-md-4 center-block">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="headerLabel">Record Reviews</h3>
                    </div>
                </div>
            </div>
            <div>
                <div class="table-responsive">
                    <asp:GridView ID="recordGridView" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" AllowPaging="True" PageSize="30" DataSourceID="recordDataSource" runat="server">
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
                    ID="recordDataSource"
                    TypeName="RecordDAL.RecordData"
                    SelectMethod="SelectRecordReviews"
                    runat="server"></asp:ObjectDataSource>
            </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="EndOfPageContent" runat="server">
</asp:Content>

﻿<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditRecord.aspx.cs" Inherits="RecordDB.EditRecord" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="col-md-6 center-block">
<div class="container mt-5 col-md-5">
    <h3 class="headerLabel mb-4">Update Record</h3>
        <div class="row">
            <div class="mb-3">
                <label for="artistDropDownList" class="form-label"><strong>Select Artist</strong></label>
                <asp:DropDownList ID="artistDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="artistDropDownList_SelectedIndexChanged"
                  CssClass="form-control form-select rounded-3"
                  title="Select Artist"></asp:DropDownList>
            </div>
            <asp:Panel ID="recordDropDownPanel" runat="server">
            <div class="mb-3">
                <label for="recordDropDownList" class="form-label"><strong>Select Record</strong></label>
                <asp:DropDownList ID="recordDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="recordDropDownList_SelectedIndexChanged"
                  CssClass="form-control form-select rounded-3"
                  title="Select record"></asp:DropDownList>
            </div>
            </asp:Panel>
        </div>
        <asp:Panel ID="tablePanel" runat="server">
        <div class="row">
            <div class="mb-3">
                <div>
                    <label for="nameTextBox" class="form-label"><strong>Title</strong></label>
                    <asp:TextBox ID="nameTextBox" runat="server"
                        CssClass="form-control rounded-3"
                        title="Title"
                        autofocus="autofocus"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <!-- First Column -->
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="fieldDropDownList" class="form-label"><strong>Field</strong></label>
                    <asp:DropDownList ID="fieldDropDownList" runat="server"				  
                  CssClass="form-control form-select rounded-3"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="labelTextBox" class="form-label"><strong>Label</strong></label>
                    <asp:TextBox ID="labelTextBox" runat="server"
                  CssClass="form-control rounded-3"
                  title="Label" placeholder="Record label"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="ratingDropDownList" class="form-label"><strong>Rating</strong></label>
                    <asp:DropDownList ID="ratingDropDownList" runat="server"				  
                  CssClass="form-control form-select rounded-3"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="mediaDropDownList" class="form-label"><strong>Media</strong></label>
                    <asp:DropDownList ID="mediaDropDownList" runat="server"				  
                  CssClass="form-control form-select rounded-3"></asp:DropDownList>
                </div>
            </div>
            <!-- Second Column -->
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="recordedTextBox" class="form-label"><strong>Recorded</strong></label>
                    <asp:TextBox ID="recordedTextBox" runat="server"
                  CssClass="form-control rounded-3"
                  title="Recorded" placeholder="Year recorded"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="pressingDropDownList" class="form-label"><strong>Pressing</strong></label>
                    <asp:DropDownList ID="pressingDropDownList" runat="server"				  
                  CssClass="form-control form-select rounded-3"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="discsDropDownList" class="form-label"><strong>Discs</strong></label>
                    <asp:DropDownList ID="discsDropDownList" runat="server"				  
                  CssClass="form-control form-select rounded-3"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="boughtTextBox" class="form-label"><strong>Bought</strong></label>
                    <asp:TextBox ID="boughtTextBox" runat="server"
                  CssClass="form-control rounded-3"
                  title="Bought" placeholder="Bought"></asp:TextBox>
                </div>
            </div>
            </div>
            <div class="row">
                <div class="mb-3">
                    <div>
                        <label for="costTextBox" class="form-label"><strong>Cost</strong></label>
                        <asp:TextBox ID="costTextBox" runat="server"
                  CssClass="form-control rounded-3"
                  title="Cost" placeholder="Cost"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3">
                    <div>
                        <label for="coverNameTextBox" class="form-label"><strong>Cover Name</strong></label>
                        <asp:TextBox ID="coverNameTextBox" runat="server"
                  CssClass="form-control rounded-3"
                  title="Cover Name" placeholder="Cover name"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3">
                    <div>
                        <label for="reviewTextBox" class="form-label"><strong>Review</strong></label>
                        <asp:TextBox ID="reviewTextBox" runat="server"
                    TextMode="MultiLine"
                  CssClass="form-control rounded-3"
                  title="Review" Height="260px" placeholder="Review"></asp:TextBox>
                    </div>
                </div>
                <div class="mt-3 mb-3">
                <div id="messageAreaDiv"
                  runat="server"
                  visible="false">
                  <div class="well">
                    <asp:Label ID="messageLabel" runat="server"
                      CssClass="text-warning"
                      Text="ERROR:<br/>" />
                  </div>
                </div>
                </div>
            </div>    
        </asp:Panel>
        <asp:button id="submitButton" CssClass="btn btn-primary rounded-3" runat="server" Text="Save" OnClick="submitButton_Click"></asp:button>&nbsp;                    
        <asp:button id="returnButton" CssClass="btn btn-primary rounded-3" runat="server" Text="Home" OnClick="returnButton_Click"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:button id="browseButton" CssClass="btn btn-primary rounded-3" runat="server" Text="Records" OnClick="browseButton_Click"></asp:button>
    <asp:Label ID="artistLabel" Visible="False" runat="server"></asp:Label>
</div>
</div>
  <div class="row">
      <footer>
          <hr />
        <p>Return to the <a href="/default">Main Menu</a></p>
      </footer>
  </div>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="EndOfPageContent" runat="server">
</asp:Content>

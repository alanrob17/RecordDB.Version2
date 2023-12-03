<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditArtist.aspx.cs" Inherits="RecordDB.EditArtist"  ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div class="row">
    <div class="col-xs-12 col-md-6 center-block">
      <div class="panel panel-default">
        <div class="panel-heading">
          <div class="panel-title">&nbsp;<strong>Update Artist</strong></div>
        </div>
        <div class="panel-body">
          <div class="form-horizontal">
            <div class="form-group">
              <label for="artistDropDownList" class="control-label col-md-2">
                Select Artist:</label>
              <div class="col-md-8">
                <asp:DropDownList ID="artistDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="artistDropDownList_SelectedIndexChanged"
                  CssClass="form-control"
                  title="Select Artist"></asp:DropDownList>
              </div>
            </div>
            <asp:Panel ID="editPanel" runat="server">
            <div class="form-group">
              <label class="control-label col-md-4">
                <strong>Edit Artist</strong></label>
            </div>
            <div class="form-group">
              <label for="firstNameTextBox" class="control-label col-md-2">
                <strong>First Name:</strong></label>
              <div class="col-md-10">
                <asp:TextBox ID="firstNameTextBox" runat="server"
                  CssClass="form-control"
                  title="First Name"
                  autofocus="autofocus"></asp:TextBox>
              </div>
            </div>
            <div class="form-group">
              <label for="lastNameTextBox" class="control-label col-md-2">
                <strong>Last Name:</strong></label>
              <div class="col-md-10">
                <asp:TextBox ID="lastNameTextBox" runat="server"
                  CssClass="form-control" 
                  title="Last Name"></asp:TextBox>
              </div>
            </div>
            <div class="form-group">
              <label for="nameTextBox" class="control-label col-md-2">
                <strong>Full Name:</strong></label>
              <div class="col-md-10">
                <asp:TextBox ID="nameTextBox" runat="server"
                  CssClass="form-control"
                  title="Full Name"></asp:TextBox>
              </div>
            </div>
            <div class="form-group">
              <label for="biographyTextBox" class="control-label col-md-2">
                <strong>Biography:</strong></label>
              <div class="col-md-12">
                <asp:TextBox ID="biographyTextBox" runat="server"
                    TextMode="MultiLine"
                  CssClass="form-control"
                    Height="360px"
                  title="Biography"></asp:TextBox>
              </div>
            </div>
            <div class="row">
              <div class="col-xs-12">
                <div id="divMessageArea"
                  runat="server"
                  visible="false">
                  <div class="well">
                    <asp:Label ID="messageLabel" runat="server"
                      CssClass="text-warning"
                      Text="Area to display messages." />
                  </div>
                </div>
              </div>
            </div>
            </asp:Panel>
          </div>
        </div>
        <div class="panel-footer">
          <div class="row">
            <div class="col-xs-12">
               <asp:button id="submitButton" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="submitButton_Click"></asp:button>&nbsp;                    
               <asp:button id="returnButton" CssClass="btn btn-primary" runat="server" Text="Home" OnClick="returnButton_Click"></asp:button>
             </div>
          </div>
        </div>
      </div>
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

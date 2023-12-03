<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteRecord.aspx.cs" Inherits="RecordDB.DeleteRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row">
    <div class="col-xs-12 col-md-6 center-block">
      <div class="panel panel-default">
        <div class="panel-heading">
          <h3 class="panel-title glyphicon-star">&nbsp;<strong>Delete Record</strong></h3>
        </div>
        <div class="panel-body">
          <div class="form-horizontal">
            <div class="form-group">
              <label for="artistDropDownList" class="control-label col-md-2">
                Select Artist:</label>
              <div class="col-md-8">
                <asp:DropDownList ID="artistDropDownList" runat="server" OnSelectedIndexChanged="artistDropDownList_SelectedIndexChanged"
                  CssClass="form-control"
                    AutoPostBack="True"
                  title="Select Artist"></asp:DropDownList>
              </div>
            </div>
            <asp:Panel ID="recordDropDownPanel" runat="server">
            <div class="form-group">
              <label for="recordDropDownList" class="control-label col-md-2">
                Select Record:</label>
              <div class="col-md-8">
                <asp:DropDownList ID="recordDropDownList" runat="server" AutoPostBack="True" 
				  OnSelectedIndexChanged="recordDropDownList_SelectedIndexChanged"
                  CssClass="form-control"
                  title="Select Record"></asp:DropDownList>
              </div>                
            </div>
            </asp:Panel>
            <asp:Panel ID="tablePanel" runat="server">
            <div class="form-group">
              <label class="control-label col-md-12">
                <strong>Edit Record</strong></label>
            </div>
            <div class="form-group">
              <label for="nameLabel" class="control-label col-md-2">
                <strong>Title</strong></label>
              <div class="col-md-10">
                <asp:Label ID="nameLabel" runat="server"
                  CssClass="form-control"
                  title="Title"
                  ></asp:Label>
              </div>
            </div>
            <div class="form-group">
              <label for="fieldDropDownList" class="control-label col-md-2">Field</label>
              <div class="col-md-4">
                <asp:Label ID="fieldLabel" runat="server"				  
                  CssClass="form-control"></asp:Label>
              </div>
              <label for="recordedLabel" class="control-label col-md-2">Recorded</label>
              <div class="col-md-4">
                <asp:Label ID="recordedLabel" runat="server"
                  CssClass="form-control"
                  title="Recorded"></asp:Label>
              </div>
            </div>
           <div class="form-group">
              <label for="label" class="control-label col-md-2">Label</label>
              <div class="col-md-4">
                <asp:TextBox ID="label" runat="server"
                  CssClass="form-control"
                  title="Label"></asp:TextBox>
              </div>
              <label for="pressingLabel" class="control-label col-md-2">Pressing</label>
              <div class="col-md-4">
               <asp:Label ID="pressingLabel" runat="server"				  
                  CssClass="form-control"></asp:Label>
              </div>
            </div>
            <div class="form-group">
              <label for="ratingLabel" class="control-label col-md-2">Rating</label>
              <div class="col-md-4">
               <asp:Label ID="ratingLabel" runat="server"				  
                  CssClass="form-control"></asp:Label>
              </div>
              <label for="discsLabel" class="control-label col-md-2">Discs</label>
              <div class="col-md-4">
               <asp:Label ID="discsLabel" runat="server"				  
                  CssClass="form-control"></asp:Label>
              </div>
            </div>
           <div class="form-group">
              <label for="mediaLabel" class="control-label col-md-2">Media</label>
              <div class="col-md-4">
               <asp:Label ID="mediaLabel" runat="server"				  
                  CssClass="form-control"></asp:Label>
              </div>
              <label for="boughtLabel" class="control-label col-md-2">Bought</label>
              <div class="col-md-4">
                <asp:Label ID="boughtLabel" runat="server"
                  CssClass="form-control"
                  title="Bought"></asp:Label>
              </div>
            </div>
            <div class="form-group">
              <label for="costLabel" class="control-label col-md-2">
                <strong>Cost</strong></label>
              <div class="col-md-10">
                <asp:Label ID="costLabel" runat="server"
                  CssClass="form-control"
                  title="Cost"></asp:Label>
              </div>
            </div>
            <div class="form-group">
              <label for="coverNameLabel" class="control-label col-md-2">
                <strong>Cover Name</strong></label>
              <div class="col-md-10">
                <asp:Label ID="coverNameLabel" runat="server"
                  CssClass="form-control"
                  title="Cover Name"></asp:Label>
              </div>
            </div>
            <div class="form-group">
              <label for="reviewLabel" class="control-label col-md-2">
                <strong>Review</strong></label>
              <div class="col-md-10">
                <asp:Label ID="reviewLabel" runat="server"
                  CssClass="form-control"
                  title="Review"></asp:Label>
              </div>
            </div>
            <div class="row">
              <div class="col-xs-12">
                <div id="messageAreaDiv"
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
               <asp:button id="deleteButton" runat="server" 
                   CssClass="btn btn-danger"
                   Text="Delete Record"
                   CommandName="Delete"
                   OnClientClick="return confirm('This will permanently delete this Record Are you sure you want to do this?');"
                   OnCommand="deleteButton_ItemDeleted"></asp:button>&nbsp;                    
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

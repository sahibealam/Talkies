<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateMasterAdmin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main-content">
        <div class="main-content-inner">
            <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true" EnablePageMethods="true" AsyncPostBackTimeout="6000">
            </cc1:ToolkitScriptManager>
            <div class="page-content">
                <div class="row">
                    <div class="col-xs-12">
                        <div class="table-header">
                            User Review
                        </div>
                    </div>
                </div>


                <div class="row">
                    <div class="col-xs-12">
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="User Name*" CssClass="control-label no-padding-right"></asp:Label>
                                <asp:DropDownList ID="ddlUserName" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Label ID="Label2" runat="server" Text="Rating*" CssClass="control-label no-padding-right"></asp:Label>
                                <cc1:Rating ID="Rating1" runat="server" Direction="LeftToRight" MaxRating="5" RatingDirection="LeftToRightTopToBottom" RatingAlign="Horizontal" CurrentRating='0' StarCssClass="ratingStar"
                                    WaitingStarCssClass="savedRatingStar"
                                    FilledStarCssClass="filledRatingStar"
                                    EmptyStarCssClass="emptyRatingStar" Width="80px">
                                </cc1:Rating>
                            </div>
                        </div>



                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Label ID="Label3" runat="server" Text="Comment*" CssClass="control-label no-padding-right"></asp:Label>
                                <asp:TextBox ID="txtComment" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Label ID="Label4" runat="server" CssClass="control-label no-padding-right"></asp:Label>
                                <asp:CheckBox ID="CheckBox2" runat="server" Text="Favourite*" CssClass="control-label no-padding-right" />
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage=" This must be Required" ClientValidationFunction="ValidateCheckBox"></asp:CustomValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>




            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-12">
                        <div class="form-group">
                            <asp:Button ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" runat="server" CssClass="btn btn-info"></asp:Button>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function ValidateCheckBox(sender, args) {
            if (document.getElementById("<%=CheckBox2.ClientID %>").checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }
    </script>
</asp:Content>


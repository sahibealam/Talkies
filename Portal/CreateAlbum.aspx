<%@ Page Language="C#" MasterPageFile="~/TemplateMasterAdmin.master" AutoEventWireup="true"
    CodeFile="CreateAlbum.aspx.cs" Inherits="CreateAlbum" MaintainScrollPositionOnPostback="true" EnableEventValidation="false" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="main-content">
        <div class="main-content-inner">
            <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true" EnablePageMethods="true" AsyncPostBackTimeout="6000">
            </cc1:ToolkitScriptManager>
            <asp:UpdatePanel ID="up" runat="server">
                <ContentTemplate>

                    <cc1:ModalPopupExtender ID="mpCreateStar" runat="server" PopupControlID="Panel1" TargetControlID="btnShowPopup1"
                        CancelControlID="btnclose1" BackgroundCssClass="modalBackground1">
                    </cc1:ModalPopupExtender>
                    <asp:Button ID="btnShowPopup1" Text="Show" runat="server" Style="display: none;"></asp:Button>

                    <cc1:ModalPopupExtender ID="mpGenere" runat="server" PopupControlID="Panel2" TargetControlID="btnShowPopup2"
                        CancelControlID="btnclose2" BackgroundCssClass="modalBackground1">
                    </cc1:ModalPopupExtender>
                    <asp:Button ID="btnShowPopup2" Text="Show" runat="server" Style="display: none;"></asp:Button>

                    <cc1:ModalPopupExtender ID="mpStudio" runat="server" PopupControlID="Panel3" TargetControlID="btnShowPopup3"
                        CancelControlID="btnclose3" BackgroundCssClass="modalBackground1">
                    </cc1:ModalPopupExtender>
                    <asp:Button ID="btnShowPopup3" Text="Show" runat="server" Style="display: none;"></asp:Button>



                    <div class="page-content">

                        <div class="row">
                            <div class="col-xs-12">
                                <div class="table-header">
                                    Create Album
                               </div>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label ID="lblBank" runat="server" Text="Album Name*" CssClass="control-label no-padding-right"></asp:Label>
                                        <asp:TextBox ID="txtAlbumName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" Text="Album Description*" CssClass="control-label no-padding-right"></asp:Label>
                                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label ID="Label2" runat="server" Text="Rating*" CssClass="control-label no-padding-right"></asp:Label>
                                        <cc1:Rating ID="Rating1" runat="server" Direction="LeftToRight" MaxRating="5" RatingDirection="LeftToRightTopToBottom" RatingAlign="Horizontal" CurrentRating='0' StarCssClass="ratingStar"
                                            WaitingStarCssClass="savedRatingStar"
                                            FilledStarCssClass="filledRatingStar"
                                            EmptyStarCssClass="emptyRatingStar" Width="80px">
                                        </cc1:Rating>
                                    </div>
                                </div>
                                </div>
                              </div>
                            <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label ID="Label3" runat="server" Text="Starring*" CssClass="control-label no-padding-right"></asp:Label>
                                        <div class="form-group form-check" style="float: right; padding-right: 10px">
                                            <asp:ImageButton ID="btnAddStarring" ImageUrl="~/assets/images/add-icon.png" Width="15px" Height="15px" OnClick="btnAddStarring_Click" runat="server" />
                                        </div>
                                        <asp:ListBox ID="lbStarring" runat="server" SelectionMode="Multiple" class="chosen-select form-control" data-placeholder="Choose a Starring..."></asp:ListBox>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label ID="Label4" runat="server" Text="Genere*" CssClass="control-label no-padding-right"></asp:Label>
                                        <div class="form-group form-check" style="float: right; padding-right: 10px">
                                            <asp:ImageButton ID="btnAddGenere" ImageUrl="~/assets/images/add-icon.png" Width="15px" Height="15px" OnClick="btnAddGenere_Click" runat="server" />
                                        </div>
                                        <asp:ListBox ID="lbGenere" runat="server" SelectionMode="Multiple" class="chosen-select form-control" data-placeholder="Choose a Genere..."></asp:ListBox>

                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label ID="Label9" runat="server" Text="Studio*" CssClass="control-label no-padding-right"></asp:Label>
                                        <div class="form-group form-check" style="float: right; padding-right: 10px">
                                            <asp:ImageButton ID="btnAddStudio" ImageUrl="~/assets/images/add-icon.png" Width="15px" Height="15px" OnClick="btnAddStudio_Click" runat="server" />
                                        </div>
                                        <asp:DropDownList ID="ddlStudio" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label ID="Label10" runat="server" Text="Director*" CssClass="control-label no-padding-right"></asp:Label>
                                        <asp:ListBox ID="lbDirector" runat="server" SelectionMode="Multiple" class="chosen-select form-control" data-placeholder="Choose a Director..."></asp:ListBox>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label ID="Label11" runat="server" Text="SupportingActor*" CssClass="control-label no-padding-right"></asp:Label>
                                        <asp:ListBox ID="lbSupportingActor" runat="server" SelectionMode="Multiple" class="chosen-select form-control" data-placeholder="Choose a SupportingActor..."></asp:ListBox>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label ID="Label12" runat="server" Text="Mounting Rating*" CssClass="control-label no-padding-right"></asp:Label>
                                        <asp:DropDownList ID="ddlMountingRating" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="U" Text="U"></asp:ListItem>
                                            <asp:ListItem Value="A" Text="A"></asp:ListItem>
                                            <asp:ListItem Value="UA" Text="S"></asp:ListItem>
                                            <asp:ListItem Value="12+" Text="12+"></asp:ListItem>
                                            <asp:ListItem Value="15+" Text="15+"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                               

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="col-xs-6">
                                    <div class="table-header">
                                        Upload Banner Images
                                    </div>

                                </div>
                                <div class="col-xs-6">
                                    <div class="table-header">
                                        Upload Trailer Videos
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="col-md-6">
                                    <iframe id="frmMultipleBanner" src="CommanFileUpload_Multiple.aspx" runat="server" width="100%"></iframe>
                                </div>
                                <div class="col-md-6">
                                    <iframe id="frmMultipleVideo" src="CommanFileUpload_Multiple1.aspx" runat="server" width="100%"></iframe>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <asp:Label ID="Label113" runat="server" Text="Category*" CssClass="control-label no-padding-right"></asp:Label>
                                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" CssClass="btn btn-info"></asp:Button>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup1" Style="display: none; width: 430px; height: 300px; margin-left: -32px" ScrollBars="Auto">
                            <h3 class="header smaller red">Create Stars: 
                            </h3>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="Label6" runat="server" Text="Star Name*" CssClass="control-label no-padding-right"></asp:Label>
                                            <asp:TextBox ID="txtStarName" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label ID="Label7" runat="server" Text="Type*" CssClass="control-label no-padding-right"></asp:Label>
                                            <br />
                                            <asp:DropDownList ID="ddlStarType" runat="server">
                                                <asp:ListItem Text="Star" Value="S" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Supporting Actor" Value="A"></asp:ListItem>
                                                <asp:ListItem Text="Director" Value="D"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Button ID="btnSaveStar" Text="Save Star" OnClick="btnSaveStar_Click" runat="server" CssClass="btn btn-warning"></asp:Button>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Button ID="btnclose1" Text="Close" runat="server" CssClass="btn btn-pink"></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup1" Style="display: none; width: 430px; height: 300px; margin-left: -32px" ScrollBars="Auto">
                            <h3 class="header smaller red">Create Genere: 
                            </h3>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <asp:Label ID="Label8" runat="server" Text="Genere Name*" CssClass="control-label no-padding-right"></asp:Label>
                                            <asp:TextBox ID="txtGenere" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Button ID="btnCreateGenere" Text="Save Genere" OnClick="btnCreateGenere_Click" runat="server" CssClass="btn btn-warning"></asp:Button>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Button ID="btnclose2" Text="Close" runat="server" CssClass="btn btn-pink"></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="Panel3" runat="server" CssClass="modalPopup1" Style="display: none; width: 430px; height: 300px; margin-left: -32px" ScrollBars="Auto">
                            <h3 class="header smaller red">Create Studio: 
                            </h3>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <asp:Label ID="Label5" runat="server" Text="Studio*" CssClass="control-label no-padding-right"></asp:Label>
                                            <asp:TextBox ID="txtStudio" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Button ID="btnCreateStudio" Text="Save Studio" runat="server" OnClick="btnCreateStudio_Click" CssClass="btn btn-warning"></asp:Button>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Button ID="btnclose3" Text="Close" runat="server" CssClass="btn btn-pink"></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:HiddenField Value="0" ID="hf_AlbumId" runat="server" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdateProgress ID="UpdateProgress1" DynamicLayout="true" runat="server" AssociatedUpdatePanelID="up">
                <ProgressTemplate>
                    <div style="position: fixed; z-index: 999; height: 100%; width: 100%; top: 0; background-color: Black; filter: alpha(opacity=60); opacity: 0.6; -moz-opacity: 0.8; cursor: not-allowed;">
                        <div style="z-index: 1000; margin: 300px auto; padding: 10px; width: 130px; background-color: White; border-radius: 10px; filter: alpha(opacity=100); opacity: 1; -moz-opacity: 1;">
                            <img src="assets/images/mb/mbloader.gif" style="height: 100px; width: 100px;" />
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </div>

    <!-- DataTable specific plugin scripts -->

    <script>
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (evt, args) {
            jQuery(function ($) {
                $('.modalBackground1').click(function () {
                    var id = $(this).attr('id').replace('_backgroundElement', '');
                    $find(id).hide();
                });
            })
        });
    </script>
</asp:Content>




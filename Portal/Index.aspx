<%@ Page Language="C#" MasterPageFile="~/Login.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="center">
        <h1>
            <i>
                <img src="assets/images/mb/icon.png" width="30px" height="30px" />
            </i>
            <span class="red">Talkis</span><br />
        </h1>
    </div>

    <div class="space-6"></div>

    <div class="position-relative">
        <div id="login-box" class="login-box visible widget-box no-border">
            <div class="widget-body">
                <div class="widget-main">
                    <h4 class="header blue lighter bigger">
                        <i class="ace-icon fa fa-coffee green"></i>
                        Please Enter Credentials
                    </h4>

                    <div class="space-6"></div>

                    <fieldset>
                        <label class="block clearfix">
                            <span class="block input-icon input-icon-right">
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="User Name" autocomplete="off">                                       
                                </asp:TextBox>
                            </span>
                        </label>

                        <label class="block clearfix">
                            <span class="block input-icon input-icon-right">
                                <asp:TextBox ID="txtPassowrd" runat="server" CssClass="form-control" placeholder="Password" autocomplete="off" TextMode="Password">
                                </asp:TextBox>
                            </span>
                        </label>

                        <div class="clearfix">
                            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="width-35 pull-right btn btn-sm btn-primary" OnClick="btnLogin_Click" />
                        </div>

                        <div class="space-4"></div>
                    </fieldset>
                    <div class="social-or-login center">
                        <span class="bigger-110">Or Login Using</span>
                    </div>
                </div>
                <div class="space-6"></div>

                <div class="social-login center">
                    <a class="btn btn-primary">
                        <i class="ace-icon fa fa-facebook"></i>
                    </a>

                    <a class="btn btn-info">
                        <i class="ace-icon fa fa-twitter"></i>
                    </a>

                    <a class="btn btn-danger">
                        <i class="ace-icon fa fa-google-plus"></i>
                    </a>
                </div>
            </div>
            <!-- /.widget-main -->

            <div class="toolbar clearfix">
                <div>
                    <a href="#" data-target="#forgot-box" class="forgot-password-link">
                        <%--<i class="ace-icon fa fa-arrow-left"></i>
                            I forgot my password--%>
                    </a>
                </div>
            </div>
        </div>
        <!-- /.widget-body -->
    </div>
    <!-- /.login-box -->

    <div id="forgot-box" class="forgot-box widget-box no-border">
        <div class="widget-body">
            <div class="widget-main">
                <h4 class="header red lighter bigger">
                    <i class="ace-icon fa fa-key"></i>
                    Retrieve Password
                </h4>

                <div class="space-6"></div>
                <p>
                    Enter your email and to receive instructions
                </p>


                <fieldset>
                    <label class="block clearfix">
                        <span class="block input-icon input-icon-right">
                            <input type="email" class="form-control" placeholder="Email" />
                            <i class="ace-icon fa fa-envelope"></i>
                        </span>
                    </label>

                    <div class="clearfix">
                        <button type="button" class="width-35 pull-right btn btn-sm btn-danger">
                            <i class="ace-icon fa fa-lightbulb-o"></i>
                            <span class="bigger-110">Send Me!</span>
                        </button>
                    </div>
                </fieldset>

            </div>
            <!-- /.widget-main -->

            <div class="toolbar center">
                <a href="#" data-target="#login-box" class="back-to-login-link">Back to Employee Login
												<i class="ace-icon fa fa-arrow-right"></i>
                </a>
            </div>
        </div>
        <!-- /.widget-body -->
    </div>

    <!-- /.position-relative -->
</asp:Content>

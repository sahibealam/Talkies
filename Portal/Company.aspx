<%@ Page Title="" Language="C#" MasterPageFile="~/TemplateMasterAdmin.master" AutoEventWireup="true"
    CodeFile="Company.aspx.cs" Inherits="Company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main-content">
        <div class="main-content-inner">
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Label ID="lblCompany" runat="server" Text="Company*" CssClass="control-label nopaddingright"
                                    Style="text-align: center"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:DropDownList ID="ddlCompany" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <table class="auto-style1" style="border: 1px solid black">
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style3" style="border: 1px solid black">Buy Quantity</td>
                        <td style="border: 1px solid black">Sell Quantity</td>
                    </tr>
                    <tr>
                        <td class="auto-style2" style="border: 1px solid black">ATO</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="lblAto_sell" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="lblAto_By" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" style="border: 1px solid black">Total</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="lblTotl_sell" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="lblTotl_Qty" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Label ID="lblFinalQuantity" runat="server" Text="FinalQuantity*" CssClass="control-label nopaddingright"
                                    Style="text-align: center"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:TextBox ID="txtFinalQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Label ID="lblSelfResult" runat="server" Text="SelfResult*" CssClass="control-label nopaddingright"
                                    Style="text-align: center"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:TextBox ID="txtSelfResult" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Label ID="lblNSE" runat="server" Text="NSE*" CssClass="control-label nopaddingright"
                                    Style="text-align: center"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:TextBox ID="txtNSE" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Label ID="lblDate" runat="server" Text="Date*" CssClass="control-label nopaddingright"
                                    Style="text-align: center"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Button ID="btnSave" Text="Save" OnClick="btnSave_Click" runat="server" CssClass="btn btn-success">
                                </asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>



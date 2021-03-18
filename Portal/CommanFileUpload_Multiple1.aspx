<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CommanFileUpload_Multiple1.aspx.cs" Inherits="CommanFileUpload_Multiple1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true" EnablePageMethods="true" AsyncPostBackTimeout="6000">
        </cc1:ToolkitScriptManager>
        
        <asp:AjaxFileUpload ID="AjaxFileUploadMultiple" runat="server" MaximumNumberOfFiles="10" OnUploadCompleteAll="AjaxFileUploadMultiple_UploadCompleteAll"
        OnUploadComplete="AjaxFileUploadMultiple_UploadComplete" Width="600px" Mode="Auto" />
    </form>
</body>
</html>

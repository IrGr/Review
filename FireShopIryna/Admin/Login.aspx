<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<%@ Register Src="~/WUC/WUC_LoginForm.ascx" TagPrefix="uc1" TagName="WUC_LoginForm" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <!--Bootstrap-->
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />

    <!-- Særlige styles der overskriver Bootstrap -->
    <link href="../Styles/MyAdminStyleSheet.css" rel="stylesheet" />

    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:WUC_LoginForm runat="server" ID="WUC_LoginForm" />
    </div>
    </form>
     <script src="../Scripts/jquery-1.9.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
</body>
</html>

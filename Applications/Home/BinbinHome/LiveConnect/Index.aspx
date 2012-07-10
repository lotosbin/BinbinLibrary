<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="LiveConnect.Index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://js.live.net/v5.0/wl.js" type="text/javascript">
    </script>
    <script type="text/javascript">
        WL.Event.subscribe("auth.login", onLogin);
        WL.Event.subscribe("auth.sessionChange", onSessionChange);
        WL.init({
            client_id: "0000000040071641",
            redirect_uri: "http://www.binbinsoft.com",
            response_type: "token"
        });
        var scopesArr = ["wl.signin"];
        WL.ui({
            name: "signin",
            element: "signInButton",
            scope: scopesArr
        });
        function signUserIn() {
            var scopesArr = ["wl.signin"];
            WL.login({ scope: scopesArr });
        }
        document.write("<a href='/' onclick='signUserIn()'>Don't like signin controls? Click here instead!</a>"); function onLogin() {
            var session = WL.getSession();
            if (session) {
                alert("You are signed in!");
            }
        }
        function onSessionChange() {
            var session = WL.getSession();
            if (session) {
                alert("Your session has changed.");
            }
        }
        function addScope() {
            var newScope = ["wl.birthday"];
            WL.login({ scope: newScope });
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="signInButton">
        </div>
    </div>
    </form>
</body>
</html>

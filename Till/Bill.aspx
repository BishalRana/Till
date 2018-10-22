<%@ Page Language="C#" EnableViewStateMac="true" Inherits="Till.Bill" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Web Till </title>
        <link href="~/Content/bootstrap.min.css" rel="stylesheet"/>
        <link href="~/Content/bootstrap-theme.min.css" rel="stylesheet"/>
        <link href="~/Content/mystyle.css" rel="stylesheet"/>
        <script src="~/scripts/jquery-3.3.1.min.js"></script>
      
</head>
<body>
        <section >
             <div class="row">
                <div class="page-header">
                    <h2 class="bg-info text-center"> Till</h2>
                </div>
            </div>
        </section>
	<form id="form1" runat="server">
            <div class="container">
                <div class="row ">
                    <div class="col-md-4"></div>
                    <asp:Label id="msgId" CssClass="text-center bg-info  col-md-4 " Style="font-family: 'Times New Roman', Times, serif; font-size:2em;" runat="server" Text="Thank You!!! Have a good day."/>
                    <div class="col-md-4"></div>
                </div>
            </div>
            <br/>
            <div class="container">
                <div class="row">
                    <asp:Label id="totalCstLbl" CssClass="text-center bg-info col-md-1 "  runat="server" Text="Service"/>

                    <asp:Label id="service" CssClass="col-offset-md-5 col-md-6" runat="server" Text=""/>

                </div>
            </div>
            <br/>
            <div class="container">
                <div class="row">
                    <asp:Table CssClass="table table-responsive table-bordered" id="tableBill" runat="server"></asp:Table>
                </div>
            </div>

            <div class="container">
                <div class="row">
                    <asp:Button CssClass="text-center btn btn-primary col-md-2 col-sm-3 col-xs-4" ID="bckHome" runat="server" Text="Home" OnClick="Send" />
                </div>
            </div>
              
	</form>
</body>
</html>

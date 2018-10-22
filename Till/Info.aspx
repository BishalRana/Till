<%@ Page Language="C#" EnableViewStateMac="true" Inherits="Till.Info" %>
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



    <div class="row">
        <div class="page-header">
            <h2 class="bg-info text-center"> Till</h2>
        </div>
    </div>  

    <section class="container">

   <form id="form1" runat="server" method="post">

           <div class="container ">
                <div class="row">
                    <asp:Label CssClass="text-center bg-info col-md-2 col-sm-3 col-xs-4" ID="itemLbl" runat="server" Text="Item " />                       
                    <asp:Label CssClass="text-center  col-offset-md-2 col-md-8 col-sm-9 col-xs-8 "  ID="itemName" runat="server" Text=""  />
                </div>                          
           </div>
           <br/>
           <br/>
        <div class="container">
            <div class="row">
             <asp:Label CssClass="text-center bg-info col-md-2 col-sm-3 col-xs-4" ID="ingdLbl" runat="server" Text="Ingredients " />                              
             <p>
              <asp:Label CssClass="text-center col-offset-md-2 col-md-8 col-sm-9 col-xs-8"  ID="ingredients" runat="server" Text=""  />               
            </p>
            </div>
        </div>
        <br/>
        <br/>
     <div class="container">           
        <div class="row">
             <p id="descInfo" class="col-md-8" runat="server" Text=""/>
             <img runat="server" id="itmImage" style="height:400px;" class = " img-thumbnail col-md-4 "/>
        </div>            
      </div>
        <br/>
        <div class="container">
              <asp:Button CssClass="text-center btn btn-primary col-md-2 col-sm-3 col-xs-4" ID="bckHome" runat="server" Text="Back" OnClick="Send" />
        </div>
    </form>
  </section>
           
</body>
</html>


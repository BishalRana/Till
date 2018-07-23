﻿<%@ Page Language="C#" EnableViewStateMac="true" Inherits="Till.Default" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Web Till </title>
        <link href="~/Content/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>
 <section class="container">

    <div class="row">
        <div class="page-header">
            <h2 class="bg-info text-center"> Till</h2>
        </div>
    </div>
            
   <form id="form1" runat="server" method="post">

               <!-- <div class="row" style="padding-top:20px;">
                        <asp:Label ID="greeting" CssClass="text-center bg-info col-md-2" runat="server" Text=""></asp:Label>                                                                                                                       
                </div>-->
               <div class="row">
                            <asp:Label ID="ServiceType" CssClass="text-center bg-info col-md-2 col-sm-2 col-xs-2" runat="server" Text=""></asp:Label> 
                            <asp:Label ID="ttlLbl" CssClass="text-center bg-info col-md-offset-8 col-md-1 col-sm-offset-7 col-sm-1 col-xs-offset-6 col-xs-2" runat="server" Text="Total"></asp:Label> 
                            <asp:Label ID="ttlCost" CssClass="text-center bg-info col-md-1 col-sm-2 col-xs-2" runat="server" Text=""></asp:Label>                         
                </div>
               
           
              <div class="row" style="padding-top:20px;">
                    
                     <asp:Button CssClass="btn btn-default col-md-2 col-sm-3 col-xs-4" ID="EatIn" runat="server" Text="EatIn" OnClick="EatIn_Click" />                       
                      <asp:Button CssClass="text-center btn btn-default col-md-2 col-sm-3 col-xs-4" ID="Takeaway" runat="server" Text="Takeway" OnClick="Takeaway_Click" />
                      <asp:Button CssClass="btn btn-default col-md-offset-6 col-md-2  col-sm-offset-3 col-sm-3 col-xs-4" ID="Checkout" runat="server" Text="Checkout" OnClick="Checkout_Click" />

              </div>

               <div class="row" style="padding-top:20px;"> 
                    <div class="" style="">
                           <asp:GridView ViewStateMode="Enabled" Style="height:100%; width:100%" ID="purchasedFoodView" runat="server"
                                        HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                                         ShowHeader="True"
                                         OnSelectedIndexChanged="invoice_SelectedIndexChanged" 
                                         AutoGenerateColumns="false" 
                                         ShowHeaderWhenEmpty="True"
                                         AllowPaging="True"
                                         PageSize="5"
                                         OnPageIndexChanging="invoice_PageIndexChanging"
                                         CssClass="table">  

                                        <rowstyle backcolor="#dce2ed"  
                                           forecolor="black"
                                           />

                                        <alternatingrowstyle backcolor="#82b6cc"  
                                          forecolor="black"
                                          />
                            
                                         <EmptyDataTemplate >
                                              <h4 class="bg-info text-center">Select the food</h4> 
                                        </EmptyDataTemplate>

                                        <Columns>                                                                                           
                                           <asp:BoundField  DataField="itemName" 
                                             HeaderText="Item"
                                             InsertVisible="False" ReadOnly="True" 
                                             SortExpression="itemName" />

                                             <asp:BoundField DataField="qty" 
                                             HeaderText="Qty" 
                                             InsertVisible="False" ReadOnly="True" 
                                             SortExpression="qty" />

                                          

                                 <asp:TemplateField HeaderText="Price">
                                     <ItemTemplate>
                                         <asp:Label ID="lblPrice" runat="server" 
                                                    Text='<%# "£ "+Eval("price").ToString()%>'>
                                         </asp:Label>                                       
                                     </ItemTemplate>                                   
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount">
                                     <ItemTemplate>
                                         <asp:Label ID="lblAmount" runat="server" 
                                                    Text='<%# "£ "+Eval("totalCost").ToString()%>'>
                                         </asp:Label>
                                     </ItemTemplate>
                                   
                                 </asp:TemplateField>

                                 
                               </Columns>                                                                                                   
                                        <headerstyle BackColor="#5D7B9D"  Font-Bold="True" ForeColor="#dee3e5"></headerstyle> 
                                        <footerstyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></footerstyle> 
                                        <pagerstyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></pagerstyle>                                         
                           </asp:GridView> 


                    </div>
                     
              </div>

              <br>
              <div class="row" id="Bento Form" >

                <div class="col-md-4" >   
                    <div class="row form-group">
                        <div class="col-md-6">
                              <asp:DropDownList CssClass="form-control" id="BentoList" runat="server"/>
                        </div>
                         <div class="col-md-6">
                                <div>
                                    <asp:Button ID="Bento" CssClass="btn btn-default" runat="server" Text="Add Bento" OnClick="Bento_Click" />  
                                </div>
                         </div>
                    </div>                                                                  
               </div>
               
               <div class="col-md-4">
                    <div class="row form-group">
                        <div class="col-md-6">
                            <asp:DropDownList CssClass="form-control" id="SushiList" runat="server"/>
                        </div>
                        <div class="col-md-6">
                                <div>
                                    <asp:Button id="Sushi"  CssClass="btn btn-default" runat="server" Text="Add Sushi" OnClick="Sushi_Click" />                                        
                                </div>
                            
                         </div>
                    </div>                                                           
                </div>
                     
                <div class="col-md-4">
                   <div class="row form-group">
                      <div class="col-md-6">   
                            <asp:DropDownList id="DrinkList" CssClass="form-control" runat="server"/>
                       </div>
                         <div class="col-md-6">  
                                <div>
                                    <asp:Button id="Drink"  CssClass="btn btn-default" runat="server" Text="Add Drink"  OnClick="Drink_Click" />                                   
                                </div>
                           
                       </div>
                    </div>


                </div>
                             
              </div>    
        
            </form>
        </section>
           
</body>
</html>


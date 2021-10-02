<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Usersignup.aspx.cs" Inherits="WebApplication1.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                       <div class="row">
                           <div class="col">
                               <center>
                                   <img width="150" src="imgs/generaluser.png" />
                                   
                               </center>
                           </div>
                       </div>

                       
                        <div class="row">
                            <div class="col">
                                <center>
                                <h5>Member Signup</h5>
                                    </center>
                            </div>
                        </div>
                        <hr />
                         <div class="row">
                           <div class="col-md-6">
                               <label>Name</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control"  ID="TextBox3" runat="server" placeholder="enter user id" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>              
                                </div>
                           </div>
                            <div class="col-md-6">
                               <label>DateofBirth</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox4" runat="server" placeholder="enter user id" TextMode="Date"></asp:TextBox>              
                                </div>
                           </div>
                       </div>

                        <div class="row">
                           <div class="col-md-6">
                               <label>Contact Number</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox5" runat="server" placeholder="enter contact number" TextMode="Number"></asp:TextBox>              
                                </div>
                           </div>
                            <div class="col-md-6">
                               <label>EmailId</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="enter email id" TextMode="Email"></asp:TextBox>              
                                </div>
                           </div>
                       </div>

                        <div class="row">
                           <div class="col-md-4">
                               <label>State</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                        <asp:ListItem Text="select" value="Select" />
                                        <asp:ListItem Text="AndraPradesh" value="AndraPradesh" />
                                        <asp:ListItem Text="Telangana" value="Telangana" />
                                        <asp:ListItem Text="Jammukashmir" value="Jammukashmir" />
                                        <asp:ListItem Text="Punjab" value="Punjab" />
                                        <asp:ListItem Text="Odisha" value="Odisha" />
                                        <asp:ListItem Text="Kerala" value="Kerala" />
                                        <asp:ListItem Text="TamilNadu" value="TamilNadu" />
                                        <asp:ListItem Text="karnataka" value="Karnataka" />
                                        <asp:ListItem Text="Maharashtra" value="Maharashtra" />
                                        <asp:ListItem Text="Gujarat" value="Gujarat" />
                                        <asp:ListItem Text="MadyaPradesh" value="MadyaPradesh" />


                                    </asp:DropDownList>        
                                </div>
                           </div>
                            <div class="col-md-4">
                               <label>city</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder="City"></asp:TextBox>              
                                </div>
                           </div>
                            <div class="col-md-4">
                               <label>Pincode</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="enter Pincode"></asp:TextBox>              
                                </div>
                           </div>
                       </div>


                        <div class="row">
                           <div class="col">
                               <label>Full addressr</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="enter Full address" TextMode="MultiLine"></asp:TextBox>              
                                </div>
                           
                       </div>
                         </div>

                        <div class="row">
                           <div class="col">
                               <center>
                               <span class="badge badge-pill badge-info">Login credentials</span>
                           </center>
                       </div>
                         </div>
                        
                           <div class="row">
                            <div class="col-md-6">
                                <label>UserId</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control"  ID="TextBox1" runat="server" placeholder="enter user id"></asp:TextBox>              
                                </div>
                                </div>
                            <div class="col-md-6">

                            <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>
                         </div>
                      </div>

                            <div class="row">
                                <div class="col">
                        
                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Signup" onClick="Button1_Click" />
                        </div>
                            </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

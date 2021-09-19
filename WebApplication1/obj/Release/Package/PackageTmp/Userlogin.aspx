<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Userlogin.aspx.cs" Inherits="WebApplication1.Userlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
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
                                <h6>Member login</h6>
                                    </center>
                            </div>
                        </div>
                        <hr />

                        <div class="row">
                            <div class="col">
                                <label>UserId</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control"  ID="TextBox1" runat="server" placeholder="enter user id"></asp:TextBox>              
                                </div>

                                <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                        </div>
                                <div class="form-group">
                           <a href="Userlogin.aspx"><input class="btn btn-info btn-block btn-lg" id="Button2" type="button" value="Sign Up" /></a>
                        </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

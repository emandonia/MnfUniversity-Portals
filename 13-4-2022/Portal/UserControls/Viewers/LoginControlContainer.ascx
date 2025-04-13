<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControlContainer.ascx.cs" Inherits="MnfUniversity_Portals.UserControls.Viewers.LoginControlContainer" %>

<div  class="login" style="float: <%=StaticUtilities.FloatRight%>;">
    
        <div id="loginContainer">
             <a href="#" id="loginButton" class="">
               <span >
                    <asp:LoginView ID="MasterLoginView" runat="server" ClientIDMode="Static">
                        <AnonymousTemplate>
                            <asp:Localize ID="Label9" runat="server" meta:resourcekey="LinkButton1Resource1" Text="Label"></asp:Localize>
                        </AnonymousTemplate>
                        <LoggedInTemplate>
                            <asp:LoginName ID="LoginName1" runat="server" />
                        </LoggedInTemplate>
                    </asp:LoginView>
              </span>
            </a> 
            <div style="clear: both"></div>
            <div id="loginBox" clientidmode="Static" runat="server"  >
                <asp:LoginView ID="MasterLoginView2" runat="server" ClientIDMode="Static">
                    <AnonymousTemplate>
                        <div style="direction: <%=StaticUtilities.Dir%>">
                            <uc:LoginControl runat="server" ID="LoginControl" />
                        </div>
                    </AnonymousTemplate>
                    <LoggedInTemplate>
                       <%-- <div id="loginForm">--%>
                            <fieldset id="body"  >
                                <%--<fieldset>--%>
                                   <div >
                                        <div style="float: <%=StaticUtilities.FloatRight%>">
                                            <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutText="Logout ..." meta:resourcekey="LoginStatus1Resource1"
                                                OnLoggingOut="LoginStatus1_LoggingOut" OnLoggedOut="LoginStatus1_Loggedout" />
                                        </div>
                                   <div style="float: <%=StaticUtilities.FloatLeft%>">
                                            <asp:LoginStatus ID="LoginStatusimg" runat="server" LogoutText="Logout ..." LogoutImageUrl="~/styles/Main/images/login.png"
                                                meta:resourcekey="LoginStatus1Resource1" />
                                        </div>
                                 </div>
                              </fieldset>
                            </fieldset>
                      </div>
                    </LoggedInTemplate>
                </asp:LoginView>
            </div>
            
            
            
                
        </div>
    
</div>
</ContentTemplate>
    </asp:UpdatePanel>

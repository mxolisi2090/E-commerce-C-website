 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_218010450_FrontEndMini.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>

    <link href="assets/css/Login.css" rel="stylesheet" />
    
        


</head>
<body>

<form id="form1" runat="server"> 

   <div class="container">
		<div class="screen">
		  <div class="screen__content">
			<header>
				<div class="title">
					<h1> Welcome To Stormzy</h1>
					<h2>Sound Devices</h2>
				</div>
			</header>

			<div class="login__field">
				<i class="login__icon fas fa-user"></i>
				<input type="text" class="login__input" id="email" runat="server" placeholder="User name / Email">
			</div>

			<div class="login__field">
				<i class="login__icon fas fa-lock"></i>
				<input type="password" id="pass" runat="server" class="login__input" placeholder="Password">
			</div>

			<div class="btn_error_message">
				<button runat="server" onserverclick="LoginClicked" class="login__submit">
					<span class="button__text">Log In</span>
					<i class="button__icon fas fa-chevron-right"></i>
				</button>
				<asp:Label class="text-center" runat="server" id="errorcode">
				</asp:Label>
			</div>

			<h3 style="text-align: center; margin-top: 5px; "><a href="Home.aspx?" style=" text-decoration: none; color: #a3a3a3;">Sign Up</a></h3>
		  </div>
		  <div class="screen__background">
			<span class="screen__background__shape screen__background__shape4"></span>
			<span class="screen__background__shape screen__background__shape3"></span>
			<span class="screen__background__shape screen__background__shape2"></span>
			<span class="screen__background__shape screen__background__shape1"></span>
		  </div>
		</div>
    </div>  
	
	</form>

</body>
</html>

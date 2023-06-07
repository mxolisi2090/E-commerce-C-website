<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TesterPage.aspx.cs" Inherits="_218010450_FrontEndMini.TesterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <style media="screen">
body{
background: #222225;
color: white;
margin: 100px auto;
}

.rating {
display: flex;
flex-direction: row-reverse;
justify-content: center;
}


.rating > input{ display:none;}

.rating > label {
position: relative;
width: 1.1em;
font-size: 15vw;
color: #FFD700;
cursor: pointer;
}

.rating > label::before{
content: "\2605";
position: absolute;
opacity: 0;
}

.rating > label:hover:before,
.rating > label:hover ~ label:before {
opacity: 1 !important;
}

.rating > input:checked ~ label:before{
opacity:1;
}

.rating:hover > input:checked ~ label:before{ opacity: 0.4; }




  </style>





    <div class="rating">
    <input type="radio" name="rating" runat="server" value="5" id="first"><label for="5">☆</label>
    <input type="radio" name="rating" runat="server" value="4" id="second"><label for="4">☆</label>
    <input type="radio" name="rating" runat="server" value="3" id="third"><label for="3">☆</label>
    <input type="radio" name="rating" runat="server" value="2" id="fourth"><label for="2">☆</label>
    <input type="radio" name="rating" runat="server" value="1" id="fifth"><label for="1">☆</label>
  </div>



</asp:Content>

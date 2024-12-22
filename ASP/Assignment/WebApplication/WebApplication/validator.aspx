<%@ Page Language="C#" AutoEventWireup="true" CodeFile="validator.aspx.cs" Inherits="validator" %>
   <!DOCTYPE html>
   <html>
   <head>
       <title>Validation Example</title>
   </head>
   <body>
       <form id="form1" runat="server">
           <div>
               <h2>Insert your details:</h2>
               <table>
                   <tr>
                       <td>Name:</td>
                       <td>
                           <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="*" />
                       </td>
                   </tr>
                   <tr>
                       <td>Family Name:</td>
                       <td>
                           <asp:TextBox ID="txtFamilyName" runat="server"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="rfvFamilyName" runat="server" ControlToValidate="txtFamilyName" ErrorMessage="*" />
                       </td>
                   </tr>
                   <tr>
                       <td>Address:</td>
                       <td><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                       <td>City:</td>
                       <td><asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                       <td>Zip Code:</td>
                       <td><asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                       <td>Phone:</td>
                       <td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                       <td>Email:</td>
                       <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                       <td colspan="2">
                           <asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="btnCheck_Click" />
                       </td>
                   </tr>
               </table>
               <asp:Label ID="lblError" runat="server" ForeColor="Red" />
           </div>
       </form>
   </body>
   </html>
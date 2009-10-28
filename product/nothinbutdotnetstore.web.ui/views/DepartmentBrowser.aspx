<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="System.Web.UI.Page" MasterPageFile="Store.master" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>
    <%= "test" + HttpContext.Current.Items["data"] %>

            <table>            
            
		<!-- for each of the main departments in the store -->
        	<tr class="ListItem">
               		 <td>                     

                	</td>
           	 </tr>        
	    </table>            
</asp:Content>

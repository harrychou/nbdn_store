<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="nothinbutdotnetstore.web.ui.views.DepartmentBrowser" MasterPageFile="Store.master" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>

            <table>            
                <% foreach (var item in model) {%>
                	<tr class="ListItem">
                   		 <td>                     
                   		 <%= item.name %>
                    	</td>
                 	 </tr>        
<%} %>
	    </table>            
</asp:Content>

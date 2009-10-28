<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="nothinbutdotnetstore.web.ui.views.DepartmentBrowser" MasterPageFile="Store.master" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>

            <table>            
                <% foreach (var item in model) {%>
                	<tr class="ListItem">
                   		 <td>                     
                   		 <a href="view_sub_dept.store?<%= item.id %>"><%= item.name %></a>
                    	</td>
                 	 </tr>        
<%} %>
	    </table>            
</asp:Content>

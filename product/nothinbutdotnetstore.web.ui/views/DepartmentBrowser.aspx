<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="System.Web.UI.Page" MasterPageFile="Store.master" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="nothinbutdotnetstore.dto" %>
<%@ Import Namespace="nothinbutdotnetstore.web.application" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>

            <table>            
            
                <% foreach (var department_item in ((IEnumerable<DepartmentItem>)HttpContext.Current.Items[DataKeys.departments])) {%>
        	<tr class="ListItem">
               		 <td>                     
               		 <%= department_item.name %>
                	</td>
           	 </tr>        
<%} %>
	    </table>            
</asp:Content>

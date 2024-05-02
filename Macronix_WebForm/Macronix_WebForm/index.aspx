<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Macronix_WebForm.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form" runat="server">
     

        <div>
            <h2>輸入資料</h2>
            <p>
                姓名：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </p>
            <p>
                年齡：<asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
            </p>
            <p>
                生日：<asp:TextBox ID="txtDate" runat="server" placeholder="YYYY/MM/DD"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnCalculate" runat="server" Text="建立帳號" OnClick="btnCreate_Click"  />
            </p>
        </div>

        <div>
      <asp:HiddenField ID="hfSelectedIndex" runat="server" />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
    
                    <asp:BoundField DataField="Name" HeaderText="姓名" />
                    <asp:BoundField DataField="Age" HeaderText="年齡" />
                    <asp:BoundField DataField="Date" HeaderText="生日" />
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Text="修改" OnClick="btnEdit_Click"/>
                            <asp:Button ID="btnDelete" runat="server" Text="刪除"  OnClick="btnDelet_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>

</body>
</html>

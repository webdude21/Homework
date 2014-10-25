<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RegisterValidation.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
</head>
<body>
    <form id="formRegistration" runat="server">
        <div>
            <asp:ValidationSummary runat="server" ID="ValidationSummary" />
            <br />
            <asp:Label runat="server" ID="LabelUsername">Username: </asp:Label>
            <asp:TextBox runat="server" ID="TextBoxUsername"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxUsername" ErrorMessage="Username field is required"></asp:RequiredFieldValidator>
            <br />
            <asp:Label runat="server" ID="LabelPassword">Password: </asp:Label>
            <asp:TextBox runat="server" ID="TextBoxPassword"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxPassword" ErrorMessage="Password field is required"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                ErrorMessage="Both Passwords should be the same!"
                ControlToValidate="TextBoxPassword"
                ControlToCompare="TextBoxRepeatPassword"></asp:CompareValidator>
            <br />
            <asp:Label runat="server" ID="LabelRepeatPassword">Repeat Password: </asp:Label>
            <asp:TextBox runat="server" ID="TextBoxRepeatPassword"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxRepeatPassword" ErrorMessage="Repeat Password field is required"></asp:RequiredFieldValidator>
            <br />
            <asp:Label runat="server" ID="LabelFirstName">First Name: </asp:Label>
            <asp:TextBox runat="server" ID="TextBoxFirstName"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxFirstName" ErrorMessage="First Name field is required"></asp:RequiredFieldValidator>
            <br />
            <asp:Label runat="server" ID="LabelLastName">Last Name: </asp:Label>
            <asp:TextBox runat="server" ID="TextBoxLastName"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxLastName" ErrorMessage="Last Name field is required"></asp:RequiredFieldValidator>
            <br />
            <asp:Label runat="server" ID="LabelAge">Age: </asp:Label>
            <asp:TextBox runat="server" ID="TextBoxAge" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxAge" ErrorMessage="Age field is required"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidatorAge" runat="server"
                ErrorMessage="Valid age is between 18 and 81"
                ControlToValidate="TextBoxAge" MaximumValue="81" MinimumValue="18">
            </asp:RangeValidator>
            <br />
            <asp:Label runat="server" ID="LabelEmail">Email: </asp:Label>
            <asp:TextBox runat="server" ID="TextBoxEmail"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Email field is required"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionEmailValidatior"
                runat="server" ErrorMessage="Incorrect email address!"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ControlToValidate="TextBoxEmail"></asp:RegularExpressionValidator>
            <br />
            <asp:Label runat="server" ID="LabelAddress">Address: </asp:Label>
            <asp:TextBox runat="server" ID="TextBoxAddress"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxAddress" ErrorMessage="Address field is required"></asp:RequiredFieldValidator>
            <br />
            <asp:Label runat="server" ID="LabelPhone">Phone: </asp:Label>
            <asp:TextBox runat="server" ID="TextBoxPhone"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxPhone" ErrorMessage="Phone field is required"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhone"
                runat="server" ErrorMessage="Incorrect phone number!"
                ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"
                ControlToValidate="TextBoxPhone"></asp:RegularExpressionValidator>
            <br />
            <asp:Label runat="server" ID="LabelAccepted">I Accept:</asp:Label>
            <asp:CheckBox runat="server" ID="CheckBoxAccepted" />
            <asp:CustomValidator runat="server" ID="CheckBoxRequired" EnableClientScript="true"
                OnServerValidate="CheckBoxRequired_ServerValidate"
                ClientValidationFunction="CheckBoxRequired_ClientValidate">You must select this box to proceed.</asp:CustomValidator>
            <br />
            <asp:Button runat="server" ID="ButtonSubmit" Text="Sumbit" OnClick="ButtonSubmit_Click" />
        </div>
    </form>
</body>
</html>

<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LoginApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Welcome to Login App</h1>
            <p class="lead">Task 3: Design the Login Page Using Visual Studio 2022 IDE (Design Window)</p>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle">Create a New Webform</h2>
                <p>
1. Open Visual Studio 2022 IDE and create a new project:
- Go to File > New > Project > Windows Forms App (.NET Framework)
- Name the project (e.g., LoginApp) and click Finish.
                    </p>
                <p>
2. Create the Login Form:
- Right-click the Source	Packages folder.
- Select Add > Webform.
- Name it LoginForm and click Add.
                </p>
                
            </section>
            <section class="col-md-4" aria-labelledby="librariesTitle">
                <h2 id="librariesTitle">Design the Interface</h2>
                <p>
1. Title Label:
- Drag a ASP Label 
- Set its text to "Login Page" in the Properties window.
- Customize the font (e.g., Arial, Bold, 24px) and alignment (center).</p>
                <p>
2. Username Label & Field:
- Add a ASP Label with text "Username:".
- Add ASP TextBox Name it usernameField in Properties > 
Variable Name.
- Set Place holder to "Enter Username"
                </p>
                <p>
                   3. Password Label & Field:
- Add a Add Label with text "Password:".
- Add a ASp PasswordField  Name it passwordField.
- Set Place holder to "Enter Password"
                </p>
                <p>
                    4. Login Button:
- Add a ASP Button to the bottom of the form.
- Set its text to "Login" and name it loginButton
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <h2 id="hostingTitle">Customize Layout & Alignment</h2>
                <p>
                    1. layout is managed using HTML + CSS.
                </p>
                <p>
                    2. Adjust Sizing & Spacing
                </p>
                <p>
                    3. Center the Window
                </p>
            </section>
        </div>
    </main>

</asp:Content>

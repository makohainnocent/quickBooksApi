Imports System.Configuration
Imports System.Security.Claims
Imports Intuit.Ipp.OAuth2PlatformClient
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.Security
Imports Intuit.Ipp.DataService

Imports System.Security


Public Class FormMain

    Private _serviceContext As ServiceContext
    Private _oauthValidator As OAuth2RequestValidator
    Dim cAppConfig As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
    Dim asSettings As AppSettingsSection = cAppConfig.AppSettings

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAddQuickBooks_Click(sender As Object, e As EventArgs) Handles btnAddQuickBooks.Click
        Dim authForm As New FrmAuth()
        authForm.Show()
    End Sub

    Private Sub btnCompanyInfo_Click(sender As Object, e As EventArgs) Handles btnCompanyInfo.Click
        Try

            InitializeServiceContext()

            Dim companyInfo As CompanyInfo = QueryCompanyInfo()

            ' Display the company information (Replace the following with your actual logic)
            MessageBox.Show($"Company Name: {companyInfo.CompanyName}" & vbCrLf &
                        $"Company Address: {companyInfo.CompanyAddr.Line1}, {companyInfo.CompanyAddr.City}, {companyInfo.CompanyAddr.PostalCode}")
        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}")
        End Try

    End Sub


    Private Sub InitializeServiceContext()
        Dim accessToken As String = asSettings.Settings("AccessToken").Value
        Dim realmId As String = asSettings.Settings("realmId").Value

        InitialiseAuthValidator(accessToken)

        InitializeServiceContext(realmId, _oauthValidator)

        _serviceContext.IppConfiguration.MinorVersion.Qbo = "23"
        _serviceContext.IppConfiguration.BaseUrl.Qbo = "https://sandbox-quickbooks.api.intuit.com/"
    End Sub

    Private Sub InitializeServiceContext(realmId As String, OAuth2RequestValidator As OAuth2RequestValidator)
        _serviceContext = New ServiceContext(realmId, IntuitServicesType.QBO, OAuth2RequestValidator)

    End Sub

    Private Sub InitialiseAuthValidator(accessToken As String)
        _oauthValidator = New OAuth2RequestValidator(accessToken)

    End Sub
    Private Function QueryCompanyInfo() As CompanyInfo

        Try
            Dim queryService As New QueryService(Of CompanyInfo)(_serviceContext)
            Dim companyInfoList As List(Of CompanyInfo) = queryService.ExecuteIdsQuery("SELECT * FROM CompanyInfo").ToList()

            If companyInfoList IsNot Nothing AndAlso companyInfoList.Count > 0 Then
                Return companyInfoList.First()
            End If

            Return Nothing
        Catch ex As Exception
            Throw New Exception($"Error querying CompanyInfo: {ex.Message}")
        End Try
    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub btnCreateAccount_Click(sender As Object, e As EventArgs) Handles btnCreateAccount.Click

        Try

            InitializeServiceContext()

            Dim dataService As New DataService(_serviceContext)

            Dim account As Account = CreateAccount()

            Dim accountAdded = dataService.Add(Of Account)(account)

            Console.WriteLine(accountAdded)

            MsgBox("account created successfully")

        Catch ex As Exception
            Throw New Exception($"Error creating account: {ex.Message}")
        End Try



    End Sub


    Private Sub btnCreateCustomer_Click(sender As Object, e As EventArgs) Handles btnCreateCustomer.Click

        Try

            InitializeServiceContext()

            Dim dataService As New DataService(_serviceContext)

            Dim customer As Customer = CreateCustomer()

            Dim customerAdded = dataService.Add(Of Customer)(customer)

            Console.WriteLine(customerAdded)

            MsgBox("customer created successfully")

        Catch ex As Exception
            Throw New Exception($"Error creating account: {ex.Message}")
        End Try



    End Sub


    Private Function CreateAccount() As Account
        Dim randomNum As New Random()
        Dim account As New Account()

        account.Name = "Name_testmakohaiizero" & randomNum.Next()
        account.FullyQualifiedName = account.Name

        account.Classification = AccountClassificationEnum.Revenue
        account.ClassificationSpecified = True
        account.AccountType = AccountTypeEnum.Bank
        account.AccountTypeSpecified = True

        account.CurrencyRef = New ReferenceType() With {
        .name = "United States Dollar",
        .Value = "USD"
    }

        Return account
    End Function


    Private Function CreateCustomer() As Customer
        Dim random As New Random()
        Dim customer As New Customer()

        customer.GivenName = "makohatest cutomer" & random.Next()
        customer.FamilyName = "Serling"
        customer.DisplayName = customer.CompanyName

        Return customer
    End Function

    Private Function CreateItem(incomeAccount As Account) As Item
        Dim item As New Item()
        Dim randomNum As New Random()

        item.Name = "Replacement mak inno of Item-" & randomNum.Next()
        item.Description = "Description"
        item.Type = ItemTypeEnum.NonInventory
        item.TypeSpecified = True

        item.Active = True
        item.ActiveSpecified = True

        item.Taxable = False
        item.TaxableSpecified = True

        item.UnitPrice = New Decimal(100.0)
        item.UnitPriceSpecified = True

        item.TrackQtyOnHand = False
        item.TrackQtyOnHandSpecified = True

        item.IncomeAccountRef = New ReferenceType() With {
        .name = incomeAccount.Name,
        .Value = incomeAccount.Id
    }

        item.ExpenseAccountRef = New ReferenceType() With {
        .name = incomeAccount.Name,
        .Value = incomeAccount.Id
    }

        ' For inventory item, asset account reference is required

        Return item
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim test As New test()
        test.Show()
    End Sub

    Private Sub createQuickbooksItem_Click(sender As Object, e As EventArgs) Handles createQuickbooksItem.Click
        InitializeServiceContext()
        'QueryCustomer()
        'QueryAccount()

        Try

            InitializeServiceContext()

            Dim account = QueryAccount()

            Dim dataService As New DataService(_serviceContext)

            Dim Item As Item = CreateItem(account)

            Dim ItemAdded = dataService.Add(Of Item)(Item)

            Console.WriteLine(ItemAdded)

            MsgBox("item created successfully")

        Catch ex As Exception
            Throw New Exception($"Error creating item: {ex.Message}")
        End Try
    End Sub

    Private Function QueryCustomer() As Customer

        Try
            Dim queryService As New QueryService(Of Customer)(_serviceContext)
            Dim customer As Customer = queryService.ExecuteIdsQuery("SELECT * FROM Customer").FirstOrDefault

            If customer IsNot Nothing Then
                'MsgBox(customer.GivenName)
                Return customer
            End If
            MsgBox("nothing")
            Return Nothing
        Catch ex As Exception
            Throw New Exception($"Error querying CompanyInfo: {ex.Message}")
        End Try
    End Function

    Private Function QueryAccount() As Account

        Try
            Dim queryService As New QueryService(Of Account)(_serviceContext)
            Dim account As Account = queryService.ExecuteIdsQuery($"SELECT * FROM Account where Classification='{AccountClassificationEnum.Revenue}'").FirstOrDefault

            If account IsNot Nothing Then
                MsgBox(account.Name)
                Return account
            End If
            MsgBox("nothing")
            Return Nothing
        Catch ex As Exception
            Throw New Exception($"Error querying CompanyInfo: {ex.Message}")
        End Try
    End Function
End Class

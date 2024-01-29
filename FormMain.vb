Imports System.Configuration
Imports System.Security.Claims
Imports Intuit.Ipp.OAuth2PlatformClient
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.Security
Imports Intuit.Ipp.DataService

Imports System.Security
Imports Newtonsoft.Json.Linq
Imports Intuit.Ipp.ReportService


Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Web
Imports System.Web.Mvc
Imports System.Net
Imports System.Net.Http.Headers
Imports System.Text.Json
Imports Intuit.Ipp.Utility


Public Class FormMain

    Private _serviceContext As ServiceContext
    Private _oauthValidator As OAuth2RequestValidator
    Dim cAppConfig As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
    Dim asSettings As AppSettingsSection = cAppConfig.AppSettings
    Dim addedInvoice As Invoice

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

    Private Sub createInvoice_Click(sender As Object, e As EventArgs) Handles createInvoice.Click
        Try
            Dim realmId As String = asSettings.Settings("realmId").Value
            InitializeServiceContext()

            Dim dataService As New DataService(_serviceContext)

            Dim account = QueryAccount()

            Dim customer = QueryCustomer()

            Dim Item As Item = CreateItem(account)

            Dim ItemAdded = dataService.Add(Of Item)(Item)

            Dim objInvoice = createQuickBooksInvoice(realmId, customer, ItemAdded)
            addedInvoice = dataService.Add(Of Invoice)(objInvoice)

            MsgBox("invoice created successfully")

        Catch ex As Exception
            ' Handle the exception here
            MsgBox($"An error occurred while creating invoice: {ex.Message}")
        End Try


    End Sub

    Private Function createQuickBooksInvoice(realmId As String, customer As Customer, item As Item) As Invoice

        InitializeServiceContext()

        Dim Invoice As New Invoice()
        'Invoice.Deposit = New Decimal(0.00)
        'Invoice.DepositSpecified = True
        Dim lineList As New List(Of Line)()

        Dim line As New Line()
        line.Description = "Description"
        line.Amount = New Decimal(100.0)
        line.AmountSpecified = True

        Invoice.CustomerRef = New ReferenceType With {
            .Value = customer.Id
        }


        Dim SalesItemLineDetail As New SalesItemLineDetail()
        SalesItemLineDetail.Qty = New Decimal(1.0)
        SalesItemLineDetail.ItemRef = New ReferenceType() With {
            .Value = item.Id
        }

        line.AnyIntuitObject = SalesItemLineDetail

        line.DetailType = LineDetailTypeEnum.SalesItemLineDetail
        line.DetailTypeSpecified = True

        lineList.Add(line)
        Invoice.Line = lineList.ToArray()

        'Step 5 Set other properties such as Total Amount, Due Date, Email status And Transaction Date
        Invoice.DueDate = DateTime.UtcNow.Date
        Invoice.DueDateSpecified = True


        Invoice.TotalAmt = New Decimal(10.0)
        Invoice.TotalAmtSpecified = True

        Invoice.EmailStatus = EmailStatusEnum.NotSet
        Invoice.EmailStatusSpecified = True

        Invoice.Balance = New Decimal(10.0)
        Invoice.BalanceSpecified = True

        Invoice.TxnDate = DateTime.UtcNow.Date
        Invoice.TxnDateSpecified = True
        Invoice.TxnTaxDetail = New TxnTaxDetail With {
            .TotalTax = Convert.ToDecimal(10),
            .TotalTaxSpecified = True
        }

        Return Invoice


    End Function

    Private Sub btnSendInvoice_Click(sender As Object, e As EventArgs) Handles btnSendInvoice.Click
        Try
            InitializeServiceContext()
            Dim dataService As New DataService(_serviceContext)
            dataService.SendEmail(Of Invoice)(addedInvoice, "vantagepoint2019@gmail.com")
            MsgBox("invoice email sent successfully")

        Catch ex As Exception
            ' Handle the exception here
            MsgBox($"An error occurred while sending invoice: {ex.Message}")
        End Try


    End Sub

    Private Sub btnProfitAndLossReport_Click(sender As Object, e As EventArgs) Handles btnProfitAndLossReport.Click
        Try
            InitializeServiceContext()
            _serviceContext.IppConfiguration.Message.Request.SerializationFormat = SerializationFormat.Xml
            _serviceContext.IppConfiguration.Message.Response.SerializationFormat = SerializationFormat.Xml
            Dim dataService As New DataService(_serviceContext)
            Dim dateRangeReportService1 As ReportService = New ReportService(_serviceContext)
            'dateRangeReportService1.start_date = "2024-01-01"
            'dateRangeReportService1.end_date = "2024-01-29"
            Dim dateRangePnL As Report = dateRangeReportService1.ExecuteReport("ProfitAndLoss")

            MsgBox("success generating profit and loss report")

        Catch ex As Exception
            ' Handle the exception here
            MsgBox($"An error occurred while sending invoice: {ex.Message}")

        Finally
            ' Include any cleanup code that should run regardless of whether an exception occurred
            ' For example, closing connections or releasing resources

        End Try

    End Sub


End Class

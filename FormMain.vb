Imports System.Configuration
Imports System.Security.Claims
Imports Intuit.Ipp.OAuth2PlatformClient
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.Security
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
            Dim accessToken As String = asSettings.Settings("AccessToken").Value
            Dim realmId As String = asSettings.Settings("realmId").Value

            InitialiseAuthValidator(accessToken)

            InitializeServiceContext(realmId, _oauthValidator)

            _serviceContext.IppConfiguration.MinorVersion.Qbo = "23"
            _serviceContext.IppConfiguration.BaseUrl.Qbo = "https://sandbox-quickbooks.api.intuit.com/"


            Dim companyInfo As CompanyInfo = QueryCompanyInfo()

            ' Display the company information (Replace the following with your actual logic)
            MessageBox.Show($"Company Name: {companyInfo.CompanyName}" & vbCrLf &
                        $"Company Address: {companyInfo.CompanyAddr.Line1}, {companyInfo.CompanyAddr.City}, {companyInfo.CompanyAddr.PostalCode}")
        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}")
        End Try

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



End Class

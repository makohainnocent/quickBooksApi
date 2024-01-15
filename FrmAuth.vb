Imports System.Configuration
Imports System.Web
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.OAuth2PlatformClient

Public Class FrmAuth

    Dim cAppConfig As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
    Dim asSettings As AppSettingsSection = cAppConfig.AppSettings

    Dim clientid As String = asSettings.Settings("clientid").Value
    Dim clientsecret As String = asSettings.Settings("clientsecret").Value
    Dim redirectUrl As String = asSettings.Settings("redirectUrl").Value
    Dim appEnvironment As String = asSettings.Settings("appEnvironment").Value
    Dim OAuth2Client As New OAuth2Client(clientid, clientsecret, redirectUrl, appEnvironment)

    Private Sub FrmAuth_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' When the form is loaded, generate the authorization URL and visit it
        Dim authUrl = GenerateAuthUrl(OAuth2Client)
        VisitAuthUrlAsync(authUrl)
    End Sub

    Private Function GenerateAuthUrl(Auth2Client As OAuth2Client) As String
        Dim scopes As New List(Of OidcScopes)()
        scopes.Add(OidcScopes.Accounting)
        Dim authorizeUrl As String = Auth2Client.GetAuthorizationURL(scopes)
        Return authorizeUrl
    End Function

    Private Async Sub VisitAuthUrlAsync(authUrl As String)
        Await wbAuth.EnsureCoreWebView2Async(Nothing)
        wbAuth.CoreWebView2.Navigate(authUrl)
    End Sub

    Private Sub FrmAuth_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim queryString As String = wbAuth.Source.Query
        Dim parameters As System.Collections.Specialized.NameValueCollection = HttpUtility.ParseQueryString(queryString)
        Dim code As String = parameters("code")
        Dim realmId As String = parameters("realmId")
        If Not (String.IsNullOrEmpty(code)) And Not (String.IsNullOrEmpty(realmId)) Then
            getAuthTokenAsync(code, realmId)
        Else
            MsgBox("error! the code or realmid was not returned")
        End If

    End Sub


    Private Async Sub getAuthTokenAsync(code As String, realmId As String)

        Try
            Dim tokenResponse = Await OAuth2Client.GetBearerTokenAsync(code)

            Dim access_token As String = tokenResponse.AccessToken
            Dim access_token_expires_at As DateTime = DateTime.Now.AddSeconds(tokenResponse.AccessTokenExpiresIn)

            Dim refresh_token As String = tokenResponse.RefreshToken
            Dim refresh_token_expires_at As DateTime = DateTime.Now.AddSeconds(tokenResponse.RefreshTokenExpiresIn)

            SaveToken("code", code)
            SaveToken("realmId", realmId)
            SaveToken("AccessToken", tokenResponse.AccessToken)
            SaveToken("AccessTokenExpiresAt", DateTime.Now.AddSeconds(tokenResponse.AccessTokenExpiresIn).ToString())
            SaveToken("RefreshToken", tokenResponse.RefreshToken)
            SaveToken("RefreshTokenExpiresAt", DateTime.Now.AddSeconds(tokenResponse.RefreshTokenExpiresIn).ToString())

            MsgBox("success!")
        Catch ex As Exception
            MsgBox($"An error occurred: {ex.Message}")
        End Try

    End Sub

    Private Sub SaveToken(key As String, value As String)
        ' Get or create the appSettings section
        Dim appSettings As AppSettingsSection = cAppConfig.AppSettings

        ' Check if the key already exists
        If appSettings.Settings(key) IsNot Nothing Then
            ' Key exists, update its value
            appSettings.Settings.Item(key).Value = value
        Else
            ' Key doesn't exist, add it
            appSettings.Settings.Add(key, value)
            appSettings.Settings.Item(key).Value = value
        End If

        ' Save the changes to app.config
        cAppConfig.Save(ConfigurationSaveMode.Modified)
    End Sub


End Class

Imports System.Configuration
Imports Intuit.Ipp.OAuth2PlatformClient

Public Class FormMain


    Dim cAppConfig As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
    Dim asSettings As AppSettingsSection = cAppConfig.AppSettings
    Private Sub btnAddQuickBooks_Click(sender As Object, e As EventArgs) Handles btnAddQuickBooks.Click
        Dim authForm As New FrmAuth()
        authForm.Show()
    End Sub




End Class

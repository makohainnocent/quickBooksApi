<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAuth
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        wbAuth = New Microsoft.Web.WebView2.WinForms.WebView2()
        CType(wbAuth, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' wbAuth
        ' 
        wbAuth.AllowExternalDrop = True
        wbAuth.CreationProperties = Nothing
        wbAuth.DefaultBackgroundColor = Color.White
        wbAuth.Dock = DockStyle.Fill
        wbAuth.Location = New Point(0, 0)
        wbAuth.Name = "wbAuth"
        wbAuth.Size = New Size(800, 450)
        wbAuth.TabIndex = 0
        wbAuth.ZoomFactor = 1R
        ' 
        ' Auth
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(wbAuth)
        Name = "Auth"
        Text = "quickbooks "
        CType(wbAuth, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents wbAuth As Microsoft.Web.WebView2.WinForms.WebView2
End Class

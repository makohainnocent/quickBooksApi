<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btnAddQuickBooks = New Button()
        btnCompanyInfo = New Button()
        SuspendLayout()
        ' 
        ' btnAddQuickBooks
        ' 
        btnAddQuickBooks.Location = New Point(951, 3)
        btnAddQuickBooks.Margin = New Padding(4, 5, 4, 5)
        btnAddQuickBooks.Name = "btnAddQuickBooks"
        btnAddQuickBooks.Size = New Size(189, 52)
        btnAddQuickBooks.TabIndex = 0
        btnAddQuickBooks.Text = "add Quickbooks"
        btnAddQuickBooks.UseVisualStyleBackColor = True
        ' 
        ' btnCompanyInfo
        ' 
        btnCompanyInfo.Location = New Point(951, 65)
        btnCompanyInfo.Margin = New Padding(4, 5, 4, 5)
        btnCompanyInfo.Name = "btnCompanyInfo"
        btnCompanyInfo.Size = New Size(189, 52)
        btnCompanyInfo.TabIndex = 1
        btnCompanyInfo.Text = "company info"
        btnCompanyInfo.UseVisualStyleBackColor = True
        ' 
        ' FormMain
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1143, 750)
        Controls.Add(btnCompanyInfo)
        Controls.Add(btnAddQuickBooks)
        Margin = New Padding(4, 5, 4, 5)
        Name = "FormMain"
        Text = "Delta finance"
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnAddQuickBooks As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents btnCompanyInfo As Button
End Class

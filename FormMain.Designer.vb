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
        btnCreateAccount = New Button()
        btnCreateCustomer = New Button()
        Button2 = New Button()
        createQuickbooksItem = New Button()
        createInvoice = New Button()
        btnSendInvoice = New Button()
        btnProfitAndLossReport = New Button()
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
        ' btnCreateAccount
        ' 
        btnCreateAccount.Location = New Point(951, 127)
        btnCreateAccount.Margin = New Padding(4, 5, 4, 5)
        btnCreateAccount.Name = "btnCreateAccount"
        btnCreateAccount.Size = New Size(189, 52)
        btnCreateAccount.TabIndex = 2
        btnCreateAccount.Text = "create account"
        btnCreateAccount.UseVisualStyleBackColor = True
        ' 
        ' btnCreateCustomer
        ' 
        btnCreateCustomer.Location = New Point(951, 189)
        btnCreateCustomer.Margin = New Padding(4, 5, 4, 5)
        btnCreateCustomer.Name = "btnCreateCustomer"
        btnCreateCustomer.Size = New Size(189, 52)
        btnCreateCustomer.TabIndex = 3
        btnCreateCustomer.Text = "create customer"
        btnCreateCustomer.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(951, 251)
        Button2.Margin = New Padding(4, 5, 4, 5)
        Button2.Name = "Button2"
        Button2.Size = New Size(189, 52)
        Button2.TabIndex = 4
        Button2.Text = "open test"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' createQuickbooksItem
        ' 
        createQuickbooksItem.Location = New Point(951, 313)
        createQuickbooksItem.Margin = New Padding(4, 5, 4, 5)
        createQuickbooksItem.Name = "createQuickbooksItem"
        createQuickbooksItem.Size = New Size(189, 52)
        createQuickbooksItem.TabIndex = 5
        createQuickbooksItem.Text = "create item"
        createQuickbooksItem.UseVisualStyleBackColor = True
        ' 
        ' createInvoice
        ' 
        createInvoice.Location = New Point(951, 375)
        createInvoice.Margin = New Padding(4, 5, 4, 5)
        createInvoice.Name = "createInvoice"
        createInvoice.Size = New Size(189, 52)
        createInvoice.TabIndex = 6
        createInvoice.Text = "create invoice"
        createInvoice.UseVisualStyleBackColor = True
        ' 
        ' btnSendInvoice
        ' 
        btnSendInvoice.Location = New Point(951, 449)
        btnSendInvoice.Margin = New Padding(4, 5, 4, 5)
        btnSendInvoice.Name = "btnSendInvoice"
        btnSendInvoice.Size = New Size(189, 52)
        btnSendInvoice.TabIndex = 7
        btnSendInvoice.Text = "send invoice"
        btnSendInvoice.UseVisualStyleBackColor = True
        ' 
        ' btnProfitAndLossReport
        ' 
        btnProfitAndLossReport.Location = New Point(754, 3)
        btnProfitAndLossReport.Margin = New Padding(4, 5, 4, 5)
        btnProfitAndLossReport.Name = "btnProfitAndLossReport"
        btnProfitAndLossReport.Size = New Size(189, 52)
        btnProfitAndLossReport.TabIndex = 8
        btnProfitAndLossReport.Text = "profit & loss report"
        btnProfitAndLossReport.UseVisualStyleBackColor = True
        ' 
        ' FormMain
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1143, 750)
        Controls.Add(btnProfitAndLossReport)
        Controls.Add(btnSendInvoice)
        Controls.Add(createInvoice)
        Controls.Add(createQuickbooksItem)
        Controls.Add(Button2)
        Controls.Add(btnCreateCustomer)
        Controls.Add(btnCreateAccount)
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
    Friend WithEvents btnCreateAccount As Button
    Friend WithEvents btnCreateCustomer As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents createQuickbooksItem As Button
    Friend WithEvents createInvoice As Button
    Friend WithEvents btnSendInvoice As Button
    Friend WithEvents btnProfitAndLossReport As Button
End Class

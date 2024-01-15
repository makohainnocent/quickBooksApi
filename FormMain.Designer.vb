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
        SuspendLayout()
        ' 
        ' btnAddQuickBooks
        ' 
        btnAddQuickBooks.Location = New Point(666, 2)
        btnAddQuickBooks.Name = "btnAddQuickBooks"
        btnAddQuickBooks.Size = New Size(132, 31)
        btnAddQuickBooks.TabIndex = 0
        btnAddQuickBooks.Text = "add Quickbooks"
        btnAddQuickBooks.UseVisualStyleBackColor = True
        ' 
        ' FormMain
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnAddQuickBooks)
        Name = "FormMain"
        Text = "Delta finance"
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnAddQuickBooks As Button
End Class

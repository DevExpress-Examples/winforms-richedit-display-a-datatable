Namespace RichEditDisplayDataTable

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

'#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.richEditControl1 = New DevExpress.XtraRichEdit.RichEditControl()
            Me.btnDisplayProducts = New DevExpress.XtraEditors.SimpleButton()
            Me.SuspendLayout()
            ' 
            ' richEditControl1
            ' 
            Me.richEditControl1.Anchor = CType(((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right)), System.Windows.Forms.AnchorStyles)
            Me.richEditControl1.Location = New System.Drawing.Point(12, 12)
            Me.richEditControl1.Name = "richEditControl1"
            Me.richEditControl1.Size = New System.Drawing.Size(1138, 440)
            Me.richEditControl1.TabIndex = 0
            ' 
            ' btnDisplayProducts
            ' 
            Me.btnDisplayProducts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.btnDisplayProducts.Location = New System.Drawing.Point(523, 467)
            Me.btnDisplayProducts.Name = "btnDisplayProducts"
            Me.btnDisplayProducts.Size = New System.Drawing.Size(117, 45)
            Me.btnDisplayProducts.TabIndex = 1
            Me.btnDisplayProducts.Text = "Display Products"
            AddHandler Me.btnDisplayProducts.Click, New System.EventHandler(AddressOf Me.btnDisplayProducts_Click)
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1162, 524)
            Me.Controls.Add(Me.btnDisplayProducts)
            Me.Controls.Add(Me.richEditControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            Me.ResumeLayout(False)
        End Sub

'#End Region
        Private richEditControl1 As DevExpress.XtraRichEdit.RichEditControl

        Private btnDisplayProducts As DevExpress.XtraEditors.SimpleButton
    End Class
End Namespace

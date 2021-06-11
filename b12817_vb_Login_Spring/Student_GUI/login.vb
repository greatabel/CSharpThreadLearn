Public Class Login

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtUser.Text = ""
        txtPass.Text = ""
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        End
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If txtUser.Text = "user" And txtPass.Text = "pass" Then
            Me.Visible = False
            MsgBox("Successfuly login" & vbNewLine & "Your...Welcome...")
            about.Show()
        Else
            MsgBox("UnSuccessfuly login" & vbNewLine & "Please enter right username or password...")
            txtPass.Text = ""
            txtUser.Text = ""
            txtUser.TabIndex = 0
        End If
    End Sub
End Class

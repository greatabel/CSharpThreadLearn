Public Class Login

    

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim fee As Decimal = CDec(Val("0" & txtNum.Text))
        Dim array(2) As Integer
        array(0) = 800
        array(1) = 600

        ' Initialize the random-number generator.
        Randomize()
        ' Generate random value between 1 and 6.
        Dim remain As Integer = CInt(Int((6 * Rnd()) + 1))


        If fee < 5 Then
            fee = fee * array(0) + remain
        ElseIf fee >= 5 Then
            fee = fee * array(1) + remain
        End If

        If RadioButtonN.Checked Then
            fee = 0
        End If
        If txtUser.Text = "user" And txtPass.Text = "pass" Then
            MsgBox("恭喜你，登陆成功" & vbNewLine & "欢迎使用我们的系统" & vbNewLine & "旅游费用：" & fee
                   )
        Else
            MsgBox("很抱歉，登陆不成功" & vbNewLine & "请输入正确的用户名和密码...")
            txtPass.Text = ""
            txtUser.Text = ""
            txtUser.TabIndex = 0
        End If
        fee = 0
    End Sub

    Private Sub btnReset_Click() Handles btnReset.Click
        txtUser.Text = ""
        txtPass.Text = ""
        txtNum.Text = ""
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        End
    End Sub

    Private Sub txtPass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPass.TextChanged

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
End Class

Public Class Login

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MinimizeBox = False
        MaximizeBox = False
        Opencone()
        Create_DB()
        Create_tb_athletes()
        Create_tb_Awardees()
        Create_table_users()
        TextBox2.UseSystemPasswordChar = True
        Default_account()
    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            Label5.Text = "userxxx"
            Label6.Text = "passxxx"
        ElseIf TextBox1.Text = "reset123xxx" Then
            Dim ask As MsgBoxResult = MessageBox.Show("Are you sure to reset the athletes and awardee list?", "Resetting", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If ask = MsgBoxResult.Yes Then
                Reset_system()
                TextBox1.Clear()
                TextBox2.Clear()
                Create_tb_athletes()
                Create_tb_Awardees()
                Create_table_users()
            Else
                TextBox1.Clear()
                TextBox2.Clear()
            End If
        Else
            Searchby_username()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("Please input username or password.", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox2.Clear()
        ElseIf TextBox1.Text = Label5.Text And TextBox2.Text = Label6.Text Then
            MessageBox.Show("You are now logged on.", "Logged On", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Form1.Show()
            Me.Hide()
            TextBox1.Clear()
            TextBox2.Clear()
        Else
            MessageBox.Show("Incorrect Username/Password.", "Invalid Identity", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Clear()
        End If
    End Sub
End Class
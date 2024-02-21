Public Class UserProfile

    Private Sub UserProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Opencone()
        Reload_Users()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox6.UseSystemPasswordChar = True
        TextBox7.UseSystemPasswordChar = True
        TextBox8.UseSystemPasswordChar = True
        TextBox9.UseSystemPasswordChar = True
        TextBox10.UseSystemPasswordChar = True

        With ComboBox1
            .DropDownStyle = ComboBoxStyle.DropDownList
            .FlatStyle = FlatStyle.Popup
            .Items.Clear()
            .Items.Add("MALE")
            .Items.Add("FEMALE")
            .Text = "MALE"
        End With

    End Sub

    Sub Txtclear()
        Reload_Users()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Txtclear()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox10.UseSystemPasswordChar = False
            TextBox8.UseSystemPasswordChar = False
            TextBox9.UseSystemPasswordChar = False
        Else
            TextBox10.UseSystemPasswordChar = True
            TextBox8.UseSystemPasswordChar = True
            TextBox9.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then
            MessageBox.Show("Please input all required information. Thank you!", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox6.Clear()
            TextBox7.Clear()
        ElseIf Not TextBox7.Text = Label10.Text Then
            MessageBox.Show("Please confirm old password. Thank you!", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox6.Clear()
            TextBox7.Clear()
        ElseIf Not TextBox6.Text = Label10.Text Then
            MessageBox.Show("Please input old password. Thank you!", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox6.Clear()
            TextBox7.Clear()
        Else
            MessageBox.Show("An user profile is now updated.", "Saved Changes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Update_profile()
            Txtclear()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Txtclear()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox10.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Then
            MessageBox.Show("Please input all required information. Thank you!", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox8.Clear()
            TextBox9.Clear()
        ElseIf Not Label10.Text = TextBox10.Text Then
            MessageBox.Show("Please input correct old password. Thank you!", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox8.Clear()
            TextBox9.Clear()
        ElseIf Not TextBox8.Text = TextBox9.Text Then
            MessageBox.Show("Please in matched password confirmation.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show("Your password is now updated.", "Saved Changes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Update_password()
            Txtclear()
        End If
    End Sub
End Class
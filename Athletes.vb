Public Class Athletes

    Private Sub Athletes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Opencone()
        ListSetUp()
        Reload_athletes()
        PictureBox2.Image = Athletes_Records_System.My.Resources.Resources._7
        PictureBox1.Image = Athletes_Records_System.My.Resources.Resources._7
        TextBox3.Enabled = False
        TextBox14.Enabled = False
    End Sub


    Sub ListSetUp()
        With ComboBox1
            .DropDownStyle = ComboBoxStyle.DropDownList
            .FlatStyle = FlatStyle.Flat
            .Items.Clear()
            .Items.Add("MALE")
            .Items.Add("FEMALE")
            .Text = "MALE"
        End With

        With ComboBox2
            .DropDownStyle = ComboBoxStyle.DropDownList
            .FlatStyle = FlatStyle.Flat
            .Items.Clear()
            .Items.Add("SELECT")
            .Items.Add("MALE")
            .Items.Add("FEMALE")
            .Text = "SELECT"
        End With

        With ComboBox3
            .DropDownStyle = ComboBoxStyle.DropDownList
            .FlatStyle = FlatStyle.Flat
            .Items.Clear()
            .Items.Add("ACTIVE")
            .Items.Add("INACTIVE")
            .Text = "ACTIVE"
        End With

        With ListView1
            .View = View.Details
            .GridLines = False
            .FullRowSelect = True
            .HeaderStyle = ColumnHeaderStyle.Nonclickable
            .BorderStyle = BorderStyle.None
            .Columns.Clear()
            .Columns.Add("#", 0)
            .Columns.Add("Date", 100)
            .Columns.Add("ID Number", 100)
            .Columns.Add("Lastname, Firstname,M.I.", 200)
            .Columns.Add("Sex", 60)
            .Columns.Add("Birthdate", 100)
            .Columns.Add("Age", 60)
            .Columns.Add("Height", 100)
            .Columns.Add("Weight", 100)
            .Columns.Add("Course", 100)
            .Columns.Add("Year Level", 100)

        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fileP As New OpenFileDialog
        OpenFileDialog1.ShowDialog()
        TextBox11.Text = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
        PictureBox1.ImageLocation = TextBox11.Text
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Txtclear()
        Reload_athletes()
        PictureBox1.Image = Athletes_Records_System.My.Resources.Resources._7

    End Sub

    Sub Txtclear()
        Label24.Text = "0"
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        ComboBox1.Text = "MALE"
        ComboBox2.Text = "SELECT"
        ComboBox3.Text = "ACTIVE"
        PictureBox1.Image = Athletes_Records_System.My.Resources.Resources._7
        PictureBox2.Image = Athletes_Records_System.My.Resources.Resources._7
        PictureBox3.Image = Athletes_Records_System.My.Resources.Resources._8
        TextBox1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox6.Text = "" Or TextBox11.Text = "" Or TextBox7.Text = "" Or TextBox12.Text = "" Or TextBox8.Text = "" Or TextBox5.Text = "" Or TextBox13.Text = "" Then
            MessageBox.Show("Please input all required information. Thank you!", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox11.Clear()
            PictureBox1.Image = Athletes_Records_System.My.Resources.Resources._7
            PictureBox3.Image = Athletes_Records_System.My.Resources.Resources._8
        ElseIf TextBox1.Text = Label34.Text Then
            MessageBox.Show("Sorry! ID number is already taken.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox11.Clear()
            PictureBox1.Image = Athletes_Records_System.My.Resources.Resources._7
            PictureBox3.Image = Athletes_Records_System.My.Resources.Resources._8
        Else
            If Label24.Text = "0" Then
                Savenewdetails()
                MessageBox.Show("A new athlete is now added.", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)
                PictureBox1.Image = Athletes_Records_System.My.Resources.Resources._7
                PictureBox3.Image = Athletes_Records_System.My.Resources.Resources._8
                Txtclear()
            Else
                Dim ask As MsgBoxResult = MessageBox.Show("Are you sure to update that student details?", "Updating", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If ask = MsgBoxResult.Yes Then
                    Updatedetails()
                    MessageBox.Show("An athlete details is now updated.", "Successfully Changed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PictureBox1.Image = Athletes_Records_System.My.Resources.Resources._7
                    Txtclear()
                Else
                End If

            End If
        End If

    End Sub

    Private Sub DateTimePicker1_TextChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.TextChanged
        Dim age As Double
        age = DateTime.Today.Year - DateTimePicker1.Value.Year
        TextBox3.Text = age

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.MaxLength = 15
        If Not IsNumeric(TextBox1.Text) Then
            TextBox1.Clear()
        End If
        If TextBox1.Text = "" Then
            Label34.Text = "0"
        Else
            Find_existed_IDnumber()
        End If
    End Sub


    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged
        TextBox13.MaxLength = 11
        If Not IsNumeric(TextBox13.Text) Then
            TextBox13.Clear()
        End If

    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        AllowedKeys(e)
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Sub AllowedKeys(e)
        If e.keychar = "'" Or e.keychar = "\" Then
            e.handled = True
        Else
            e.handled = False
        End If

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        AllowedKeys(e)
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If IsNumeric(TextBox2.Text) Then
            MessageBox.Show("Number is invalid as name.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Clear()
        Else

        End If
    End Sub

    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        AllowedKeys(e)
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub TextBox12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox12.KeyPress
        AllowedKeys(e)
    End Sub

    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged

    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        AllowedKeys(e)
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click

    End Sub

    Private Sub Label23_TextChanged(sender As Object, e As EventArgs) Handles Label23.TextChanged
        If Label23.Text = "" Or Label23.Text = "0" Or Label23.Text = "File" Then
            PictureBox2.Image = Athletes_Records_System.My.Resources.Resources._7
        Else
            PictureBox2.ImageLocation = Label23.Text
        End If
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged
        If TextBox11.Text = "" Then
            PictureBox1.Image = Athletes_Records_System.My.Resources.Resources._7
        Else
            PictureBox1.ImageLocation = TextBox11.Text
        End If
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        TextBox1.Enabled = False
        PictureBox1.Image = Athletes_Records_System.My.Resources.Resources._7
        PictureBox2.Image = Athletes_Records_System.My.Resources.Resources._7
        PictureBox3.Image = Athletes_Records_System.My.Resources.Resources._8
        Select_athlete()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged
        Searchbyathletes()
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        Searchbysports()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_TextChanged(sender As Object, e As EventArgs) Handles ComboBox2.TextChanged
        If ComboBox2.Text = "SELECT" Then
            Reload_athletes()
        Else
            Searchbysex()
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        Searchbydate()
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim fileP As New OpenFileDialog
        OpenFileDialog1.ShowDialog()
        TextBox14.Text = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
        PictureBox3.ImageLocation = TextBox14.Text
    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged
        If TextBox14.Text = "" Then
            PictureBox3.Image = Athletes_Records_System.My.Resources.Resources._8
        Else
            PictureBox3.ImageLocation = TextBox14.Text
        End If
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click

    End Sub
End Class
Public Class Awardees

    Private Sub Awardees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Opencone()
        ListSetUp()
        Reload_Awardees()
        PictureBox1.Image = Athletes_Records_System.My.Resources.Resources._7
        PictureBox3.Image = Athletes_Records_System.My.Resources.Resources._7
        PictureBox2.Image = Athletes_Records_System.My.Resources.Resources._9
        PictureBox4.Image = Athletes_Records_System.My.Resources.Resources._9
    End Sub

    Sub ListSetUp()
        With ListView1
            .ForeColor = Color.DimGray
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
            .Columns.Add("Course", 100)
            .Columns.Add("Year Level", 100)
            .Columns.Add("Sports", 100)
            .Columns.Add("Position", 100)
            .Columns.Add("Contact Number", 120)
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fileP As New OpenFileDialog
        OpenFileDialog1.ShowDialog()
        Label10.Text = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
        PictureBox1.ImageLocation = Label10.Text
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim fileP As New OpenFileDialog
        OpenFileDialog1.ShowDialog()
        Label14.Text = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
        PictureBox2.ImageLocation = Label14.Text
    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Label10_TextChanged(sender As Object, e As EventArgs) Handles Label10.TextChanged
        If Label10.Text = "0" Then
        Else
            PictureBox1.ImageLocation = Label10.Text
            PictureBox3.ImageLocation = Label10.Text
        End If
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub

    Private Sub Label14_TextChanged(sender As Object, e As EventArgs) Handles Label14.TextChanged
        If Label14.Text = "0" Then
        Else
            PictureBox2.ImageLocation = Label14.Text
            PictureBox4.ImageLocation = Label14.Text
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
           Textclear()
        Else
            FindbyIdnumber()
        End If

    End Sub


    Sub Textclear()
        Label10.Text = "0"
        Label14.Text = "0"
        Label24.Text = "0"
        TextBox1.Clear()
        TextBox10.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox2.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        Reload_Awardees()
        PictureBox1.Image = Athletes_Records_System.My.Resources.Resources._7
        PictureBox3.Image = Athletes_Records_System.My.Resources.Resources._7
        PictureBox2.Image = Athletes_Records_System.My.Resources.Resources._9
        PictureBox4.Image = Athletes_Records_System.My.Resources.Resources._9
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox12.Text = "" Or TextBox13.Text = "" Then
            MessageBox.Show("Please input all required information. Thank you!", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If Label24.Text = "0" Then
                NewAwardee()
                MessageBox.Show("A new awadee is now added.", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Textclear()
            Else
                UpdateAwardee()
                MessageBox.Show("An awadee details are now updated.", "Successfully Changed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Textclear()
            End If
            
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Textclear()
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        Label10.Text = "0"
        Label14.Text = "0"
        Select_Awardee()
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged
        search_Awardees()
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        search_Awardees_sports()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        search_Awardees_bydate()
    End Sub
End Class
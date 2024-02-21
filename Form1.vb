Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Opencone()
        Create_DB()
        Create_tb_athletes()
        Create_tb_Awardees()
        Reload_athletes()
        Reload_Awardees()
        Dim newsize As New Size(32, 32)
        Button1.Image = New Bitmap(Athletes_Records_System.My.Resources.Resources._1, newsize)
        Button2.Image = New Bitmap(Athletes_Records_System.My.Resources.Resources._2, newsize)
        Button3.Image = New Bitmap(Athletes_Records_System.My.Resources.Resources._3, newsize)
        Button4.Image = New Bitmap(Athletes_Records_System.My.Resources.Resources._4, newsize)
        Button5.Image = New Bitmap(Athletes_Records_System.My.Resources.Resources._5, newsize)
        IsMdiContainer = True
        Countuser()
    End Sub

    Sub CloseAllExcept()
        GroupBox1.Visible = False
        For Each subf As Form In Me.MdiChildren
            subf.Close()
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GroupBox1.Visible = True
        For Each subf As Form In Me.MdiChildren
            subf.Close()
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CloseAllExcept()
        Athletes.MdiParent = Me
        Athletes.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MessageBox.Show("You are now logged out.", "Logged Out", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label10.Text = Today
        Label11.Text = TimeOfDay
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CloseAllExcept()
        Awardees.MdiParent = Me
        Awardees.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CloseAllExcept()
        UserProfile.MdiParent = Me
        UserProfile.Show()
    End Sub
End Class

Imports MySql.Data.MySqlClient
Module systemMOD

    Dim con As New MySqlConnection("server=localhost; username=root; database=mysql;")
    Dim com As New MySqlCommand
    Dim dr As MySqlDataReader

    Sub Opencone()
        con.Close()
        con.Open()
        com.Connection = con
    End Sub

    Sub Closereader()
        dr = com.ExecuteReader
        dr.Close()
    End Sub

    Sub Create_DB()
        com = New MySqlCommand("create database if not exists db_ars;", con)
        Closereader()
    End Sub

    Sub Create_tb_athletes()
        com = New MySqlCommand("create table if not exists db_ars.athletes(id int(100) auto_increment primary key, date text, idnumber text, fullname text, sex text, birthdate text, age int(2), height text, weight text, course text, yearlevel text, sport text, position text, contactnumber text, stats text, filepath text , filepath2 text);", con)
        Closereader()
    End Sub

    Sub Athletes_params()
        com.Parameters.AddWithValue("@date", Form1.Label10.Text)
        com.Parameters.AddWithValue("@idnumber", Athletes.TextBox1.Text)
        com.Parameters.AddWithValue("@fullname", Athletes.TextBox2.Text)
        com.Parameters.AddWithValue("@sex", Athletes.ComboBox1.Text)
        com.Parameters.AddWithValue("@birthdate", Athletes.DateTimePicker1.Text)
        com.Parameters.AddWithValue("@age", Athletes.TextBox3.Text)
        com.Parameters.AddWithValue("@height", Athletes.TextBox4.Text)
        com.Parameters.AddWithValue("@weight", Athletes.TextBox5.Text)
        com.Parameters.AddWithValue("@course", Athletes.TextBox6.Text)
        com.Parameters.AddWithValue("@yearlevel", Athletes.TextBox7.Text)
        com.Parameters.AddWithValue("@sport", Athletes.TextBox8.Text)
        com.Parameters.AddWithValue("@position", Athletes.TextBox12.Text)
        com.Parameters.AddWithValue("@stats", Athletes.ComboBox3.Text)
        com.Parameters.AddWithValue("@filepath", Athletes.TextBox11.Text)
        com.Parameters.AddWithValue("@filepath2", Athletes.TextBox14.Text)
        com.Parameters.AddWithValue("@contactnumber", Athletes.TextBox13.Text)
    End Sub

    Sub Savenewdetails()
        com = New MySqlCommand("insert into db_ars.athletes(date, idnumber, fullname, sex, birthdate, age, height, weight, course, yearlevel, sport, position, contactnumber, stats, filepath, filepath2)values(@date, @idnumber, @fullname, @sex, @birthdate, @age, @height, @weight, @course, @yearlevel, @sport, @position, @contactnumber, @stats, @filepath, @filepath2)", con)
        Athletes_params()
        Closereader()
        Reload_athletes()
    End Sub

    Sub Updatedetails()
        com = New MySqlCommand("update db_ars.athletes set id=@id, idnumber=@idnumber, fullname=@fullname, sex=@sex, birthdate=@birthdate, age=@age, height=@height, weight=@weight, course=@course, yearlevel=@yearlevel, sport=@sport, position=@position, contactnumber=@contactnumber, stats=@stats, filepath=@filepath, filepath2=@filepath2 where id=@id", con)
        com.Parameters.AddWithValue("@id", Athletes.Label24.Text)
        Athletes_params()
        Closereader()
        Reload_athletes()
    End Sub

    Sub ItemsLists()
        Dim il As Integer
        Dim ils As New ListViewItem(dr.Item(0).ToString)
        For il = 1 To 10 Step 1
            If dr.Item(14).ToString = "ACTIVE" Then
                ils.SubItems.Add(dr.Item(il).ToString).BackColor = Color.Green
            Else
                ils.SubItems.Add(dr.Item(il).ToString).BackColor = Color.DarkRed
            End If
        Next
        ils.UseItemStyleForSubItems = False
        Athletes.ListView1.Items.AddRange(New ListViewItem() {ils})
    End Sub

    Sub Reload_athletes()
        Athletes.ListView1.ForeColor = Color.White
        Athletes.ListView1.Items.Clear()
        com = New MySqlCommand("select * from db_ars.athletes;", con)
        dr = com.ExecuteReader
        While dr.Read
            ItemsLists()
        End While
        dr.Close()
        Athletes.Label13.Text = Athletes.ListView1.Items.Count
        Form1.Label5.Text = Athletes.ListView1.Items.Count

        com = New MySqlCommand("select count(stats) from db_ars.athletes where stats=@stats;", con)
        com.Parameters.AddWithValue("@stats", "ACTIVE")
        dr = com.ExecuteReader
        While dr.Read
            Athletes.Label30.Text = dr.Item(0).ToString
        End While
        dr.Close()

        com = New MySqlCommand("select count(stats) from db_ars.athletes where stats=@stats;", con)
        com.Parameters.AddWithValue("@stats", "INACTIVE")
        dr = com.ExecuteReader
        While dr.Read
            Athletes.Label32.Text = dr.Item(0).ToString
        End While
        dr.Close()

    End Sub

    Sub Searchbyathletes()
        Athletes.ListView1.ForeColor = Color.White
        Athletes.ListView1.Items.Clear()
        com = New MySqlCommand("select * from db_ars.athletes where idnumber like @search or fullname like @search;", con)
        com.Parameters.AddWithValue("@search", "%" + Athletes.TextBox10.Text + "%")
        dr = com.ExecuteReader
        While dr.Read
            ItemsLists()
        End While
        dr.Close()
        Athletes.Label13.Text = Athletes.ListView1.Items.Count
        Form1.Label5.Text = Athletes.ListView1.Items.Count
    End Sub

    Sub Searchbysports()
        Athletes.ListView1.ForeColor = Color.White
        Athletes.ListView1.Items.Clear()
        com = New MySqlCommand("select * from db_ars.athletes where sport like @search;", con)
        com.Parameters.AddWithValue("@search", "%" + Athletes.TextBox9.Text + "%")
        dr = com.ExecuteReader
        While dr.Read
            ItemsLists()
        End While
        dr.Close()
        Athletes.Label13.Text = Athletes.ListView1.Items.Count
        Form1.Label5.Text = Athletes.ListView1.Items.Count
    End Sub

    Sub Searchbysex()
        Athletes.ListView1.ForeColor = Color.White
        Athletes.ListView1.Items.Clear()
        com = New MySqlCommand("select * from db_ars.athletes where sex=@sex;", con)
        com.Parameters.AddWithValue("@sex", Athletes.ComboBox2.Text)
        dr = com.ExecuteReader
        While dr.Read
            ItemsLists()
        End While
        dr.Close()
        Athletes.Label13.Text = Athletes.ListView1.Items.Count
        Form1.Label5.Text = Athletes.ListView1.Items.Count
    End Sub

    Sub Searchbydate()
        Athletes.ListView1.ForeColor = Color.White
        Athletes.ListView1.Items.Clear()
        com = New MySqlCommand("select * from db_ars.athletes where date=@date;", con)
        com.Parameters.AddWithValue("@date", Athletes.DateTimePicker2.Text)
        dr = com.ExecuteReader
        While dr.Read
            ItemsLists()
        End While
        dr.Close()
        Athletes.Label13.Text = Athletes.ListView1.Items.Count
        Form1.Label5.Text = Athletes.ListView1.Items.Count
    End Sub

    Sub Select_athlete()
        com = New MySqlCommand("select * from db_ars.athletes where id=@id;", con)
        com.Parameters.AddWithValue("@id", Athletes.ListView1.FocusedItem.Text)
        dr = com.ExecuteReader
        While dr.Read
            Athletes.Label24.Text = dr.Item(0).ToString
            Athletes.TextBox1.Text = dr.Item(2).ToString
            Athletes.TextBox2.Text = dr.Item(3).ToString
            Athletes.ComboBox1.Text = dr.Item(4).ToString
            Athletes.DateTimePicker1.Text = dr.Item(5).ToString
            Athletes.TextBox3.Text = dr.Item(6).ToString
            Athletes.TextBox4.Text = dr.Item(7).ToString
            Athletes.TextBox5.Text = dr.Item(8).ToString
            Athletes.TextBox6.Text = dr.Item(9).ToString
            Athletes.TextBox7.Text = dr.Item(10).ToString
            Athletes.TextBox8.Text = dr.Item(11).ToString
            Athletes.TextBox12.Text = dr.Item(12).ToString
            Athletes.TextBox13.Text = dr.Item(13).ToString
            Athletes.ComboBox3.Text = dr.Item(14).ToString
            Athletes.Label23.Text = dr.Item(15).ToString
            Athletes.TextBox11.Text = dr.Item(15).ToString
            Athletes.TextBox14.Text = dr.Item(16).ToString
        End While
        dr.Close()
    End Sub

    Sub Find_existed_IDnumber()
        If Athletes.Label24.Text = 0 Then
            com = New MySqlCommand("select * from db_ars.athletes where idnumber=@idnumber;", con)
            com.Parameters.AddWithValue("@idnumber", Athletes.TextBox1.Text)
            dr = com.ExecuteReader
            While dr.Read
                Athletes.Label34.Text = dr.Item(2).ToString
            End While
            dr.Close()
        Else
        End If
    End Sub

    Sub Create_tb_Awardees()
        com = New MySqlCommand("create table if not exists db_ars.awardees(id int(100) auto_increment primary key, date text, idnumber text, fullname text, course text, yearlevel text, sport text, position text, contactnumber text, athletepic text, athleteawards text);", con)
        Closereader()
    End Sub

    Sub Awardees_params()
        com.Parameters.AddWithValue("@date", Form1.Label10.Text)
        com.Parameters.AddWithValue("@idnumber", Awardees.TextBox1.Text)
        com.Parameters.AddWithValue("@fullname", Awardees.TextBox2.Text)
        com.Parameters.AddWithValue("@course", Awardees.TextBox6.Text)
        com.Parameters.AddWithValue("@yearlevel", Awardees.TextBox7.Text)
        com.Parameters.AddWithValue("@sport", Awardees.TextBox8.Text)
        com.Parameters.AddWithValue("@position", Awardees.TextBox12.Text)
        com.Parameters.AddWithValue("@contactnumber", Awardees.TextBox13.Text)
        com.Parameters.AddWithValue("@athletepic", Awardees.Label10.Text)
        com.Parameters.AddWithValue("@athleteawards", Awardees.Label14.Text)
    End Sub

    Sub NewAwardee()
        com = New MySqlCommand("insert into db_ars.awardees(date, idnumber, fullname, course, yearlevel, sport, position, contactnumber, athletepic, athleteawards)values(@date, @idnumber, @fullname, @course, @yearlevel, @sport, @position, @contactnumber, @athletepic, @athleteawards)", con)
        Awardees_params()
        Closereader()
        Reload_Awardees()
    End Sub

    Sub UpdateAwardee()
        com = New MySqlCommand("update db_ars.awardees set id=@id, idnumber=@idnumber, fullname=@fullname, course=@course, yearlevel=@yearlevel, sport=@sport, position=@position, contactnumber=@contactnumber, athletepic=@athletepic, athleteawards=@athleteawards where id=@id", con)
        com.Parameters.AddWithValue("@id", Awardees.Label24.Text)
        Awardees_params()
        Closereader()
        Reload_Awardees()
    End Sub


    Sub Reload_Awardees()
        Awardees.ListView1.Items.Clear()
        com = New MySqlCommand("select * from db_ars.awardees;", con)
        dr = com.ExecuteReader
        While dr.Read
            Dim ilc As Integer
            Dim il As New ListViewItem(dr.Item(0).ToString)
            For ilc = 1 To 8 Step 1
                il.SubItems.Add(dr.Item(ilc).ToString)
            Next
            il.UseItemStyleForSubItems = False
            Awardees.ListView1.Items.AddRange(New ListViewItem() {il})
        End While
        Awardees.Label13.Text = Awardees.ListView1.Items.Count
        Form1.Label6.Text = Awardees.ListView1.Items.Count
        dr.Close()
    End Sub

    Sub FindbyIdnumber()
        If Awardees.Label24.Text = "0" Then
            com = New MySqlCommand("select * from db_ars.athletes where idnumber like @idnumber;", con)
            com.Parameters.AddWithValue("@idnumber", "%" + Awardees.TextBox1.Text + "%")
            dr = com.ExecuteReader
            While dr.Read
                Awardees.TextBox2.Text = dr.Item(3).ToString
                Awardees.TextBox6.Text = dr.Item(9).ToString
                Awardees.TextBox7.Text = dr.Item(10).ToString
                Awardees.TextBox8.Text = dr.Item(11).ToString
                Awardees.TextBox12.Text = dr.Item(12).ToString
                Awardees.TextBox13.Text = dr.Item(13).ToString
                Awardees.Label10.Text = dr.Item(15).ToString
            End While
            dr.Close()
        Else
        End If
    End Sub

    Sub Select_Awardee()
        com = New MySqlCommand("select * from db_ars.awardees where id=@id;", con)
        com.Parameters.AddWithValue("@id", Awardees.ListView1.FocusedItem.Text)
        dr = com.ExecuteReader
        While dr.Read
            Awardees.Label24.Text = dr.Item(0).ToString
            Awardees.TextBox1.Text = dr.Item(2).ToString
            Awardees.TextBox2.Text = dr.Item(3).ToString
            Awardees.TextBox6.Text = dr.Item(4).ToString
            Awardees.TextBox7.Text = dr.Item(5).ToString
            Awardees.TextBox8.Text = dr.Item(6).ToString
            Awardees.TextBox12.Text = dr.Item(7).ToString
            Awardees.TextBox13.Text = dr.Item(8).ToString
            Awardees.Label10.Text = dr.Item(9).ToString
            Awardees.Label14.Text = dr.Item(10).ToString
        End While
        dr.Close()
    End Sub

    Sub search_Awardees()
        Awardees.ListView1.Items.Clear()
        com = New MySqlCommand("select * from db_ars.awardees where idnumber like @search or fullname like @search;", con)
        com.Parameters.AddWithValue("@search", "%" + Awardees.TextBox10.Text + "%")
        dr = com.ExecuteReader
        While dr.Read
            Dim ilc As Integer
            Dim il As New ListViewItem(dr.Item(0).ToString)
            For ilc = 1 To 8 Step 1
                il.SubItems.Add(dr.Item(ilc).ToString)
            Next
            il.UseItemStyleForSubItems = False
            Awardees.ListView1.Items.AddRange(New ListViewItem() {il})
        End While
        Awardees.Label13.Text = Awardees.ListView1.Items.Count
        Form1.Label6.Text = Awardees.ListView1.Items.Count
        dr.Close()
    End Sub

    Sub search_Awardees_sports()
        Awardees.ListView1.Items.Clear()
        com = New MySqlCommand("select * from db_ars.awardees where sport like @search;", con)
        com.Parameters.AddWithValue("@search", "%" + Awardees.TextBox9.Text + "%")
        dr = com.ExecuteReader
        While dr.Read
            Dim ilc As Integer
            Dim il As New ListViewItem(dr.Item(0).ToString)
            For ilc = 1 To 8 Step 1
                il.SubItems.Add(dr.Item(ilc).ToString)
            Next
            il.UseItemStyleForSubItems = False
            Awardees.ListView1.Items.AddRange(New ListViewItem() {il})
        End While
        Awardees.Label13.Text = Awardees.ListView1.Items.Count
        Form1.Label6.Text = Awardees.ListView1.Items.Count
        dr.Close()
    End Sub

    Sub search_Awardees_bydate()
        Awardees.ListView1.Items.Clear()
        com = New MySqlCommand("select * from db_ars.awardees where date=@search;", con)
        com.Parameters.AddWithValue("@search", Awardees.DateTimePicker2.Text)
        dr = com.ExecuteReader
        While dr.Read
            Dim ilc As Integer
            Dim il As New ListViewItem(dr.Item(0).ToString)
            For ilc = 1 To 8 Step 1
                il.SubItems.Add(dr.Item(ilc).ToString)
            Next
            il.UseItemStyleForSubItems = False
            Awardees.ListView1.Items.AddRange(New ListViewItem() {il})
        End While
        Awardees.Label13.Text = Awardees.ListView1.Items.Count
        Form1.Label6.Text = Awardees.ListView1.Items.Count
        dr.Close()
    End Sub


    Sub Create_table_users()
        com = New MySqlCommand("create table if not exists db_ars.useraccount (id int(100) auto_increment primary key, fullname text, address text, contactnumber text, sex text, email text, role text, status text, username text, password text);", con)
        Closereader()
    End Sub

    Sub Default_account()
        Try
            com = New MySqlCommand("insert into db_ars.useraccount(id, fullname, address, contactnumber, sex, email, role, status, username, password)values(""1"", ""System Administrator"", ""Araneta City"", ""09912345678"", ""MALE"",""sample@admin.com"",  ""ADMIN"", ""APPROVED"", ""admin123"", ""admin"")", con)
            Closereader()
        Catch ex As Exception

        End Try
    End Sub


    Sub Profiel_params()
        com.Parameters.AddWithValue("@id", UserProfile.Label14.Text)
        com.Parameters.AddWithValue("@fullname", UserProfile.TextBox1.Text)
        com.Parameters.AddWithValue("@address", UserProfile.TextBox2.Text)
        com.Parameters.AddWithValue("@contactnumber", UserProfile.TextBox3.Text)
        com.Parameters.AddWithValue("@sex", UserProfile.ComboBox1.Text)
        com.Parameters.AddWithValue("@email", UserProfile.TextBox4.Text)
        com.Parameters.AddWithValue("@username", UserProfile.TextBox5.Text)
    End Sub

    Sub Update_profile()
        com = New MySqlCommand("update db_ars.useraccount set id=@id, fullname=@fullname, address=@address, contactnumber=@contactnumber, sex=@sex, email=@email, username=@username where id=@id;", con)
        Profiel_params()
        Closereader()
        Reload_Users()
    End Sub

    Sub Update_password()
        com = New MySqlCommand("update db_ars.useraccount set id=@id, password=@password where id=@id;", con)
        com.Parameters.AddWithValue("@id", UserProfile.Label14.Text)
        com.Parameters.AddWithValue("@password", UserProfile.TextBox9.Text)
        Closereader()
        Reload_Users()
    End Sub

    Sub Searchby_username()
        com = New MySqlCommand("select * from db_ars.useraccount where username like @username;", con)
        com.Parameters.AddWithValue("@username", "%" + Login.TextBox1.Text + "%")
        dr = com.ExecuteReader
        While dr.Read
            Form1.Label12.Text = dr.Item(8).ToString
            Form1.Label13.Text = "Hi! " & dr.Item(1).ToString
            Login.Label5.Text = dr.Item(8).ToString
            Login.Label6.Text = dr.Item(9).ToString
        End While
        dr.Close()
    End Sub

    Sub Countuser()
        com = New MySqlCommand("select count(id) from db_ars.useraccount;", con)
        dr = com.ExecuteReader
        While dr.Read
            Form1.Label8.Text = dr.Item(0).ToString
        End While
        dr.Close()
    End Sub

    Sub Reload_Users()
        com = New MySqlCommand("select * from db_ars.useraccount where username=@username;", con)
        com.Parameters.AddWithValue("@username", Form1.Label12.Text)
        dr = com.ExecuteReader
        While dr.Read
            UserProfile.Label14.Text = dr.Item(0).ToString
            UserProfile.TextBox1.Text = dr.Item(1).ToString
            UserProfile.TextBox2.Text = dr.Item(2).ToString
            UserProfile.TextBox3.Text = dr.Item(3).ToString
            UserProfile.ComboBox1.Text = dr.Item(4).ToString
            UserProfile.TextBox4.Text = dr.Item(5).ToString
            UserProfile.TextBox5.Text = dr.Item(8).ToString
            UserProfile.Label10.Text = dr.Item(9).ToString
        End While
        dr.Close()
    End Sub

    Sub Reset_system()
        com = New MySqlCommand("drop table db_ars.athletes;", con)
        Closereader()
        com = New MySqlCommand("drop table db_ars.awardees;", con)
        Closereader()
        MessageBox.Show("Reset Done.", "Reset Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Module

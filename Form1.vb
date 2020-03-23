Public Class Form1
    'Declare the variables
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim user As New DataTable("steam")
    Dim user2 As New DataTable("steam2")
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub


    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        user.ReadXmlSchema(Application.StartupPath + "\steam_sh.xml")
        user.ReadXml(Application.StartupPath + "\steam_dt.xml")

        ListBox1.DisplayMember = "username"
        ListBox1.DataSource = user

        If user.Columns.Count = 1 Then



        End If

    End Sub
    Public Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If TextBox1.Text = "" Then Else user.Rows.Add(TextBox1.Text)
        ListBox1.DisplayMember = "username"
        ListBox1.DataSource = user

        user.TableName = ("steam")
        user.WriteXmlSchema(Application.StartupPath + "\steam_sh.xml", True)
        user.WriteXml(Application.StartupPath + "\steam_dt.xml", True)

    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        user.Rows.Clear()

        user.TableName = ("steam")
        user.WriteXmlSchema(Application.StartupPath + "\steam_sh.xml", True)
        user.WriteXml(Application.StartupPath + "\steam_dt.xml", True)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim file As System.IO.StreamWriter
        Dim steam() As Process = Process.GetProcessesByName("steam")

        For Each Process As Process In steam
            Process.Kill()
        Next

        For i As Integer = 1 To 100
            System.Threading.Thread.Sleep(10)
            System.Windows.Forms.Application.DoEvents()
        Next

        file = My.Computer.FileSystem.OpenTextFileWriter("UserReg.bat", True)
        file.WriteLine("set username=" + ListBox1.GetItemText(ListBox1.SelectedItem) + Label4.Text)
        file.Close()

        Process.Start(Application.StartupPath + "\\UserReg.bat")

        For i As Integer = 1 To 100
            System.Threading.Thread.Sleep(10)
            System.Windows.Forms.Application.DoEvents()
        Next

        System.IO.File.WriteAllText(Application.StartupPath + "\\UserReg.bat", "")

    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        Dim file As System.IO.StreamWriter
        Dim steam() As Process = Process.GetProcessesByName("steam")

        For Each Process As Process In steam
            Process.Kill()
        Next

        For i As Integer = 1 To 100
            System.Threading.Thread.Sleep(10)
            System.Windows.Forms.Application.DoEvents()
        Next

        file = My.Computer.FileSystem.OpenTextFileWriter("UserReg.bat", True)
        file.WriteLine("set username=" + ListBox1.GetItemText(ListBox1.SelectedItem) + Label4.Text)
        file.Close()

        Process.Start(Application.StartupPath + "\\UserReg.bat")

        For i As Integer = 1 To 100
            System.Threading.Thread.Sleep(10)
            System.Windows.Forms.Application.DoEvents()
        Next

        System.IO.File.WriteAllText(Application.StartupPath + "\\UserReg.bat", "")
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If TextBox1.Text = "" Then Label2.Show() Else Label2.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        MsgBox("Insert your username
Click Add
Select the desired account in the menu
Click Open

Creator(Discord): Afonso1234#2209",
               MsgBoxStyle.MsgBoxHelp,
               "Help")
    End Sub
End Class
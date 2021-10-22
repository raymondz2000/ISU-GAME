'raymond
'2019.01.01
'Game snake 

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myGame = New Game(500, 500, 10, 10)
        PICSHOW.Width = myGame.myMap.width + 1
        PICSHOW.Height = myGame.myMap.height + 1
        PICSHOW.Left = myGame.lk
        PICSHOW.Top = 3 * myGame.lk
        Me.Width = PICSHOW.Width + 4 * myGame.lk
        Me.Height = PICSHOW.Height + 8 * myGame.lk
        Timer1.Enabled = False
    End Sub
    Private Sub PicShow_Paint(sender As Object, e As PaintEventArgs) Handles PICSHOW.Paint

        'Paint the grid
        Dim x, y, i As Integer
        Dim sw, sh, w, h As Integer
        sw = myGame.myMap.cellwidth
        sh = myGame.myMap.cellheight
        w = myGame.myMap.width
        h = myGame.myMap.height
        x = w \ sw
        y = h \ sh
        Dim mygraphics As Graphics
        mygraphics = e.Graphics
        For i = 0 To x Step x
            mygraphics.DrawLine(Pens.Black, i * sw, 0, i * sw, h)
        Next
        For i = 0 To y Step y
            mygraphics.DrawLine(Pens.Black, 0, i * sh, w, i * sh)
        Next

        'paint the snake head
        Dim mybrush As New SolidBrush(myGame.mySnake.head.c)
        Dim r As Integer
        x = myGame.mySnake.head.x
        y = myGame.mySnake.head.y
        r = myGame.mySnake.head.r
        Dim rect As Rectangle = New Rectangle(x - r, y - r, 2 * r, 2 * r)
        mygraphics.DrawEllipse(Pens.Black, rect)
        mygraphics.FillEllipse(mybrush, rect)
        mybrush = Nothing
        'paint the snake body
        If (myGame.mySnake.bodyNum > 0) Then
            For i = 0 To myGame.mySnake.bodyNum - 1
                x = myGame.mySnake.body(i).x
                y = myGame.mySnake.body(i).y
                r = myGame.mySnake.body(i).r
                Dim mybrush1 As New SolidBrush(myGame.mySnake.body(i).c)
                Dim mypen As New Pen(myGame.mySnake.body(i).c)
                mygraphics.DrawEllipse(mypen, x - r, y - r, 2 * r, 2 * r)
                mygraphics.FillEllipse(mybrush1, x - r, y - r, 2 * r, 2 * r)
            Next
        End If
        'paint the egg
        x = myGame.myEgg.x
        y = myGame.myEgg.y
        r = myGame.myEgg.r
        Dim mybrush2 As New SolidBrush(myGame.myEgg.c)
        Dim mypen2 As New Pen(myGame.myEgg.c)
        mygraphics.DrawEllipse(mypen2, x - r, y - r, 2 * r, 2 * r)
        mygraphics.FillEllipse(mybrush2, x - r, y - r, 2 * r, 2 * r)

    End Sub

    Private Sub MnuQuit_Click(sender As Object, e As EventArgs) Handles MnuQuit.Click
        Application.Exit()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim sw, sh As Integer
        sw = myGame.myMap.cellwidth
        sh = myGame.myMap.cellheight
        myGame.mySnake.Move(myGame.Direction, sw, sh)
        PICSHOW.Refresh()
        'HIT DIED DETECT
        If myGame.JudgeDie Then
            Timer1.Enabled = False
            MessageBox.Show("YOU HIT DIED, YOUR SCORE IS： " & myGame.Score, "HINT", MessageBoxButtons.OK, MessageBoxIcon.Information)
            myGame.WriteToFile()
            MNUSCORE.Text = "SCORE： 0"
            Exit Sub
        End If
        'DETECT TO EAT EGG
        If myGame.JudgeScore Then
            MNUSCORE.Text = "SCORE： " & myGame.Score
            Exit Sub
        End If

    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.W
                If (myGame.Direction = "w"c) Then Exit Sub
                myGame.Direction = "w"c
            Case Keys.A
                If (myGame.Direction = "a"c) Then Exit Sub
                myGame.Direction = "a"c
            Case Keys.D
                If (myGame.Direction = "d"c) Then Exit Sub
                myGame.Direction = "d"c
            Case Keys.S
                If (myGame.Direction = "s"c) Then Exit Sub
                myGame.Direction = "s"c
        End Select
    End Sub

    Private Sub MnuRecord_Click(sender As Object, e As EventArgs) Handles MnuRecord.Click
        myGame.ReadFile()
    End Sub

    Private Sub HELPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HELPToolStripMenuItem.Click
        Dim msg As String
        msg = "GAME INSTRUCTION：" & vbCrLf
        msg &= "USE UP,DOWN,LEFT,RIGHT TO CONTROL THE HEAD" & vbCrLf
        msg &= "ENTER TO PAUSE/START"
        MessageBox.Show(msg, "HELP")
    End Sub

    Private Sub STARTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles STARTToolStripMenuItem.Click
        myGame = New Game(500, 500, 10, 10)
        Dim gr As Graphics
        gr = PICSHOW.CreateGraphics()
        Dim mybrush As New SolidBrush(myGame.mySnake.head.c)
        Dim x, y, r As Integer
        x = myGame.mySnake.head.x
        y = myGame.mySnake.head.y
        r = myGame.mySnake.head.r
        Dim rect As Rectangle = New Rectangle(x - r, y - r, 2 * r, 2 * r)
        gr.DrawEllipse(Pens.Black, rect)
        gr.FillEllipse(mybrush, rect)
        Timer1.Enabled = True
    End Sub

    Private Sub PAUSEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PAUSEToolStripMenuItem.Click
        Timer1.Enabled = False
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Timer1.Enabled = True
    End Sub
End Class

Public Class map
    Public width, height, cellwidth, cellheight As Integer
    Public Sub New(ByVal width As Integer, height As Integer, cellWidth As Integer, cellHeight As Integer)
        Me.width = width
        Me.height = height
        Me.cellwidth = cellWidth
        Me.cellheight = cellHeight
    End Sub
End Class

Public Class snake
    Class snakebody
        Public x, y, r As Integer
        Public c As Color
        Public Sub New(ByVal x%, ByVal y%, ByVal r%, ByVal c As Color)
            Me.x = x
            Me.y = y
            Me.r = r
            Me.c = c
        End Sub
    End Class

    Public head As snakebody
    Public body() As snakebody
    Public bodyNum As Integer

    Public Sub New(ByVal x%, ByVal y%, ByVal r%, ByVal c As Color)
        head = New snakebody(x, y, r, c)
    End Sub

    Public Sub Move(ByVal Direction As Char, ByVal cellWidth As Integer, ByVal cellHeight As Integer)

        'body move
        Dim i As Integer
        If bodyNum >= 2 Then
            For i = bodyNum - 1 To 1 Step -1
                body(i).x = body(i - 1).x
                body(i).y = body(i - 1).y
            Next
        End If
        If bodyNum >= 1 Then
            body(0).x = head.x
            body(0).y = head.y
        End If

        'head move
        Select Case Direction
            Case "w"c
                head.y -= cellHeight
            Case "s"c
                head.y += cellHeight
            Case "a"c
                head.x -= cellWidth
            Case "d"c
                head.x += cellWidth
        End Select
    End Sub
End Class

Public Class Egg
    Public x, y, r As Integer 'r is radius
    Public c As Color 'color
    Public rand As Random

    Public Sub New()
        rand = New Random()
    End Sub

    Public Sub RandInfo(ByVal width As Integer, ByVal height As Integer)
        'set the coordinate in the map and random a radius and color
        r = rand.Next(5, 20)
        x = rand.Next(r, width - r)
        y = rand.Next(r, height - r)
        'random 10 color
        Dim cr As Integer
        cr = rand.Next(10)
        Select Case cr
            Case 0
                c = Color.Red
            Case 1
                c = Color.Orange
            Case 2
                c = Color.Yellow
            Case 3
                c = Color.Green
            Case 4
                c = Color.Beige
            Case 5
                c = Color.Blue
            Case 6
                c = Color.Peru
            Case 7
                c = Color.Pink
            Case 8
                c = Color.SkyBlue
            Case 9
                c = Color.Salmon
        End Select
    End Sub

End Class

Public Class Game
    Public mySnake As snake
    Public myMap As map
    Public myEgg As Egg
    Public Score As Integer
    Public Direction As Char = "w"c 'going up initially
    Public lk As Integer = 10  'leave more space in the window

    Public Sub New(ByVal width As Integer, ByVal height As Integer, ByVal cellWidth As Integer, ByVal cellHeight As Integer)
        myMap = New map(width, height, cellWidth, cellHeight)
        mySnake = New snake(myMap.width \ 2, myMap.height \ 2, myMap.cellwidth, Color.Black)
        myEgg = New Egg()
        myEgg.RandInfo(myMap.width, myMap.height)
    End Sub

    Public Function JudgeDie() As Boolean
        'over map then true, if not, detect is hit or not
        If mySnake.head.x - mySnake.head.r < 0 Or mySnake.head.x + mySnake.head.r > myMap.width Or
               mySnake.head.y - mySnake.head.r < 0 Or mySnake.head.y + mySnake.head.r > myMap.height Then
            Return True
        ElseIf mySnake.bodyNum > 2 Then 'detect is hit the head from body(2)
            Dim i As Integer
            For i = 2 To mySnake.bodyNum - 1
                Dim d As Single
                d = (mySnake.head.x - mySnake.body(i).x) ^ 2 + (mySnake.head.y - mySnake.body(i).y) ^ 2
                d = Math.Sqrt(d)
                Dim r1, r2 As Integer
                r1 = mySnake.head.r
                r2 = mySnake.body(i).r
                If (d < r1 + r2) Then 'head hit the body
                    Return True
                End If
            Next
            Return False
        Else
            Return False
        End If
    End Function

    Public Function JudgeScore() As Boolean 'need to +1 point?
        'check the distance from head and egg
        Dim d As Single
        d = (mySnake.head.x - myEgg.x) ^ 2 + (mySnake.head.y - myEgg.y) ^ 2
        d = Math.Sqrt(d)
        Dim r1, r2 As Integer
        r1 = mySnake.head.r
        r2 = myEgg.r
        If (d < r1 + r2) Then ' eat egg
            'inc score
            Score += myEgg.r
            'inc snakebody

            Dim x, y As Integer
            Select Case Direction
                Case "w"
                    x = mySnake.head.x
                    y = mySnake.head.y - myEgg.r
                Case "s"
                    x = mySnake.head.x
                    y = mySnake.head.y + myEgg.r
                Case "a"
                    x = mySnake.head.x + myEgg.r
                    y = mySnake.head.y
                Case "d"
                    x = mySnake.head.x - myEgg.r
                    y = mySnake.head.y
            End Select
            ReDim Preserve mySnake.body(mySnake.bodyNum + 1)
            mySnake.body(mySnake.bodyNum) = New snake.snakebody(x, y, mySnake.head.r, myEgg.c)
            mySnake.bodyNum += 1
            'randinfo egg
            myGame.myEgg.RandInfo(myMap.width, myMap.height)

            Return True
        End If
        Return False
    End Function

    Public Sub WriteToFile()
        Dim path As String = Application.StartupPath & "\record.txt"
        If (Not IO.File.Exists(path)) Then
            Dim sw As IO.StreamWriter = IO.File.CreateText(path)
            Using (sw)
                sw.WriteLine(Now() & " " & "Score= " & Score)
            End Using
            MessageBox.Show("Create the record file")
            Exit Sub
        End If
        Dim sw1 = IO.File.AppendText(path)
        Using (sw1)
            sw1.WriteLine(Now() & " " & "Score= " & Score)
        End Using
    End Sub

    Public Sub ReadFile()
        Dim path As String = Application.StartupPath & "\record.txt"
        If (Not IO.File.Exists(path)) Then
            MessageBox.Show("File is not exit")
            Exit Sub
        End If
        Dim txt As String = IO.File.ReadAllText(path)
        MessageBox.Show(txt)
    End Sub
End Class

Module Module1
    Public myGame As Game
End Module



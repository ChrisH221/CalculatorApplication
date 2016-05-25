Public Class Form1

    'Strings for representing the two input numbers
    Dim Number1 As String = ""
    Dim Number2 As String = ""

    Dim squareSymbol As String = ""

    Dim symbol As String ' The operator being applied to the two inputs
    Dim nextNum As Boolean ' Set equal to True when first input is completed and operator has been selected
    Dim sum As Boolean

    Dim square1 As Boolean
    Dim square2 As Boolean

    'Setup for assigning a function to each button that represents a number
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim button As Button() = {Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9}
        For i As Integer = 0 To button.Length - 1
            AddHandler button(i).Click, AddressOf numberPress
        Next


        MyBase.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        MyBase.MinimizeBox = False
        MyBase.MaximizeBox = False


    End Sub

    'Logic for the button OnClick event
    Function numberPress(ByVal sender As Object, ByVal e As EventArgs)
        Dim button As Button
        button = sender
        If RichTextBox1.Text = "Error" Then RichTextBox1.Text = ""
        If sum Then RichTextBox1.Text = ClearAll()
        If nextNum Then
            Number2 = Number2 + button.Text
            If square1 And square2 Then

                RichTextBox1.Text = Number2 + squareSymbol + symbol + "(" + Number1 + squareSymbol

            ElseIf square1 Then

                RichTextBox1.Text = Number2 + symbol + "(" + Number1 + squareSymbol


            ElseIf square2 Then

                RichTextBox1.Text = Number2 + squareSymbol + symbol + Number1

            Else

                RichTextBox1.Text = Number2 + symbol + Number1
            End If

        Else
            Number1 = Number1 + button.Text
            RichTextBox1.Text = Number1 + squareSymbol
        End If
    End Function

    'Slightly different logic required for the button zero OnClick event
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If RichTextBox1.Text = "Error" Then RichTextBox1.Text = ""
        If sum Then RichTextBox1.Text = ClearAll()
        If nextNum Then
            If Number2.Length > 0 Then
                Number2 = Number2 + "0"
                RichTextBox1.Text = Number2 + symbol + Number1
            End If
        Else
            If Number1.Length > 0 Then
                Number1 = Number1 + "0"
                RichTextBox1.Text = RichTextBox1.Text + "0"
            End If

        End If
    End Sub

    'A Function for resetting the state of global variables
    Function ClearAll()
        RichTextBox1.Text = ""
        Number1 = ""
        Number2 = ""
        nextNum = False
        symbol = ""
        squareSymbol = ""
        sum = False
        square1 = False
        square2 = False

    End Function


    'Returns all variables to original state
    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        ClearAll()
    End Sub

    'Button_Click for addition the divide symbol to the current number and setting nextNum equal to True
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If sum Then RichTextBox1.Text = ClearAll()
        If Number1.Length < 1 Then
            RichTextBox1.Text = "Error"
        Else
            nextNum = True
            symbol = " + "
            If square1 Then
                RichTextBox1.Text = symbol + "(" + Number1 + squareSymbol
            Else
                RichTextBox1.Text = symbol + Number1
            End If

        End If

    End Sub


    'Button_Click for appending the minus symbol to the current number and setting nextNum equal to True
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        If sum Then RichTextBox1.Text = ClearAll()
        If Number1.Length < 1 Then
            RichTextBox1.Text = "Error"
        Else
            nextNum = True
            symbol = " - "
            If square1 Then
                RichTextBox1.Text = symbol + "(" + Number1 + squareSymbol
            Else
                RichTextBox1.Text = symbol + Number1
            End If

        End If

    End Sub
    'Button_Click for appending the multiplcation symbol to the current number and setting nextNum equal to True
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If sum Then RichTextBox1.Text = ClearAll()
        If Number1.Length < 1 Then
            RichTextBox1.Text = "Error"
        Else
            nextNum = True
            symbol = " × "
            If square1 Then
                RichTextBox1.Text = symbol + "(" + Number1 + squareSymbol
            Else
                RichTextBox1.Text = symbol + Number1
            End If

        End If

    End Sub

    'Button_Click for appending the divide symbol to the current number and setting nextNum equal to True
    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        If sum Then RichTextBox1.Text = ClearAll()
        If Number1.Length < 1 Then
            RichTextBox1.Text = "Error"
        Else
            nextNum = True
            symbol = " ÷ "
            If square1 Then
                RichTextBox1.Text = symbol + "(" + Number1 + squareSymbol
            Else
                RichTextBox1.Text = symbol + Number1
            End If

        End If

    End Sub


    'Equals button features a Select Case for selecting which operation to apply to the inputs
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim Num1 As Double
        Dim Num2 As Double
        Int32.TryParse(Number1, Num1)
        Int32.TryParse(Number2, Num2)
        If square1 Then
            Num1 = Math.Sqrt(Num1)
        End If
        If square2 Then
            Num2 = Math.Sqrt(Num2)
        End If
        If Number2.Length >= 1 Then
            Select Case symbol
                Case " + "
                    RichTextBox1.Text = Num1 + Num2
                Case " - "
                    RichTextBox1.Text = Num1 - Num2
                Case " ÷ "
                    RichTextBox1.Text = Num1 / Num2
                Case " × "
                    RichTextBox1.Text = Num1 * Num2
            End Select
        Else
            RichTextBox1.Text = "Error"
        End If

        'Manually reset some variables to original state
        Number1 = ""
        Number2 = ""
        nextNum = False
        symbol = ""
        squareSymbol = ""
        sum = False
        square1 = False
        square2 = False

    End Sub


    'Appends the square root operator to the appropriate input and flags if the operator is applied to either the first or second input
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

        squareSymbol = ")√"

        If RichTextBox1.Text = "Error" Then
            If Number1.Length < 1 Then
                square1 = True
                RichTextBox1.Text = Number1 + squareSymbol

            End If

        Else

            If RichTextBox1.Text = "" Then
                If Number1.Length < 1 Then
                    square1 = True
                    RichTextBox1.Text = Number1 + squareSymbol

                End If
            Else
                If nextNum Then
                    If square1 Then
                        If Number2.Length < 1 Then
                            square2 = True
                            RichTextBox1.Text = Number2 + squareSymbol + symbol + "(" + Number1 + squareSymbol

                        End If
                    Else
                        square2 = True
                        RichTextBox1.Text = Number2 + squareSymbol + symbol + Number1
                    End If

                Else
                    RichTextBox1.Text = "Error"
                    Number1 = ""
                    Number2 = ""
                    squareSymbol = ""
                End If

            End If
        End If
    End Sub
    'Append the closing brace to specify the number that the square root operation is applied to
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        If nextNum Then
            Dim button As Button
            button = Button10
            button.PerformClick() 'If the square root is calulated for the second input, then call the equals method
        Else
            If square1 Then
                RichTextBox1.Text = "(" + Number1 + squareSymbol
            End If
        End If

    End Sub

End Class

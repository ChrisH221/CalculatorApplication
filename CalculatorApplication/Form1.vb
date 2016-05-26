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

        Dim buttonOperator As Button() = {Button13, Button14, Button16, Button17}

        For i As Integer = 0 To buttonOperator.Length - 1
            AddHandler buttonOperator(i).Click, AddressOf doOperation
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
            RichTextBox1.Text = Number2 + symbol + Number1


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

    Function doOperation(ByVal sender As Object, ByVal e As EventArgs)

        If sum Then RichTextBox1.Text = ClearAll()
        If Number1.Length < 1 Then
            RichTextBox1.Text = "Error"
        Else
            Dim button As Button
            button = sender
            Dim bTest As String
            bTest = button.Text

            Select Case bTest
                Case "+"
                    symbol = " + "
                Case "-"
                    symbol = " - "
                Case "÷"
                    symbol = " ÷ "
                Case "x"
                    symbol = " × "
            End Select
           
            RichTextBox1.Text = symbol + Number1
            nextNum = True

        End If


    End Function


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

   
    'Equals button features a Select Case for selecting which operation to apply to the inputs
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim Num1 As Double
        Dim Num2 As Double
        Int32.TryParse(Number1, Num1)
        Int32.TryParse(Number2, Num2)
      
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
        sum = False
       

    End Sub


    

End Class

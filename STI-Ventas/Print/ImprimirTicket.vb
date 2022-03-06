Imports System.Drawing.Printing

''' <summary>
''' Impresión del ticket.
''' </summary>
''' <remarks>05.03.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class ImprimirTicket
    Private headerLines As ArrayList = New ArrayList()
    Private subHeaderLines As ArrayList = New ArrayList()
    Private items As ArrayList = New ArrayList()
    Private totales As ArrayList = New ArrayList()
    Private footerLines As ArrayList = New ArrayList()
    Private headerImage_ As Image = Nothing
    Private count As Integer = 0
    Private maxChar_ As Integer = 40
    Private maxCharDescription_ As Integer = 30
    Private imageHeight As Integer = 0
    Private leftMargin As Single = 1
    Private topMargin As Single = 3
    Private fontName_ As String = "Lucida Console"
    Public LastError As String
    Private fontSize_ As Single = 8
    Private printFont As Font = Nothing
    Private myBrush As SolidBrush = New SolidBrush(Color.Black)
    Private gfx As Graphics = Nothing
    Private line As String = Nothing

    Public Property HeaderImage As Image
        Get
            Return headerImage_
        End Get
        Set(value As Image)
            headerImage_ = value
        End Set
    End Property

    Public Property MaxChar As Integer
        Get
            Return maxChar_
        End Get
        Set(value As Integer)
            If value <> maxChar_ Then maxChar_ = value
        End Set
    End Property

    Public Property MaxCharDescription As Integer
        Get
            Return maxCharDescription_
        End Get
        Set(value As Integer)
            If value <> maxCharDescription_ Then maxCharDescription_ = value
        End Set
    End Property

    Public Property FontSize As Single
        Get
            Return fontSize_
        End Get
        Set(value As Single)
            If value <> fontSize_ Then fontSize_ = value
        End Set
    End Property

    Public Property FontName As String
        Get
            Return fontName_
        End Get
        Set(value As String)
            If value <> fontName_ Then fontName_ = value
        End Set
    End Property

    Public Sub AddHeaderLine(line As String)
        headerLines.Add(line)
    End Sub

    Public Sub AddSubHeaderLine(line As String)
        subHeaderLines.Add(line)
    End Sub

    Public Sub AddItem(cantidad As String, item As String, price As String)
        Dim newItem As New OrderItem("?"c)
        items.Add(newItem.GenerateItem("     " & cantidad, "               " & item, "        " & price))
    End Sub

    Public Sub AddItem(cantidad As String, item As String, price As String, total As String)
        Dim newItem As New OrderItem("?"c)
        'items.Add(newItem.GenerateItem("     " & cantidad, "               " & item, "        " & price))
        items.Add(newItem.GenerateItem(item, cantidad, price, total))
    End Sub

    Public Sub AddTotal(name As String, price As String)
        Dim newTotal As OrderTotal = New OrderTotal("?"c)
        totales.Add(newTotal.GenerateTotal(name, price))
    End Sub

    Public Sub AddFooterLine(line As String)
        footerLines.Add(line)
    End Sub

    Private Function AlignRightText(lenght As Integer) As String
        Dim espacios As String = ""
        Dim spaces As Integer = MaxChar - lenght

        For x As Integer = 0 To spaces - 1
            espacios += " "
        Next

        Return espacios
    End Function

    Private Function DottedLine() As String
        Dim dotted As String = ""

        For x As Integer = 0 To MaxChar - 1
            dotted += "="
        Next

        Return dotted
    End Function

    Public Function PrinterExists(impresora As String) As Boolean
        For Each strPrinter As String In PrinterSettings.InstalledPrinters
            If impresora = strPrinter Then Return True
        Next

        Return False
    End Function

    Public Sub PrintTicket(impresora As String)
        Dim printDoc As PrintDocument
        Try
            printFont = New Font(FontName, FontSize, FontStyle.Regular)
            printDoc = New PrintDocument()

            If Not String.IsNullOrEmpty(impresora) Then
                printDoc.PrinterSettings.PrinterName = impresora
            End If

            AddHandler printDoc.PrintPage, AddressOf pr_PrintPage

            printDoc.Print()
        Catch exc As InvalidPrinterException
            LastError = exc.ToString()
        End Try
    End Sub

    Private Sub pr_PrintPage(sender As Object, e As PrintPageEventArgs)
        e.Graphics.PageUnit = GraphicsUnit.Millimeter
        gfx = e.Graphics
        DrawImage()
        DrawHeader()
        DrawSubHeader()
        DrawItems()
        DrawTotales()
        DrawFooter()

        If HeaderImage IsNot Nothing Then
            HeaderImage.Dispose()
            HeaderImage.Dispose()
        End If

        items.Clear()
        headerLines.Clear()
        subHeaderLines.Clear()
        totales.Clear()
        footerLines.Clear()
        count = 0
    End Sub

    Private Function YPosition() As Single
        Return topMargin + (count * printFont.GetHeight(gfx) + imageHeight)
    End Function

    Private Sub DrawImage()
        If HeaderImage IsNot Nothing Then

            Try
                gfx.DrawImage(HeaderImage, New Point(CInt(leftMargin), CInt(YPosition())))
                Dim height As Double = (CDbl(HeaderImage.Height) / 58) * 15
                imageHeight = CInt(Math.Round(height)) + 3
            Catch __unusedException1__ As Exception
                __unusedException1__.ToString()
            End Try
        End If
    End Sub

    Private Sub DrawHeader()
        For Each header As String In headerLines

            If header.Length > MaxChar Then
                Dim currentChar As Integer = 0
                Dim headerLenght As Integer = header.Length

                While headerLenght > MaxChar
                    line = header.Substring(currentChar, MaxChar)
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), New StringFormat())
                    count += 1
                    currentChar += MaxChar
                    headerLenght -= MaxChar
                End While

                line = header
                gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), New StringFormat())
                count += 1
            Else
                line = header
                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), New StringFormat())
                count += 1
            End If
        Next

        DrawEspacio()
    End Sub

    Private Sub DrawSubHeader()

        For Each subHeader As String In subHeaderLines

            If subHeader.Length > MaxChar Then
                Dim currentChar As Integer = 0
                Dim subHeaderLenght As Integer = subHeader.Length

                While subHeaderLenght > MaxChar
                    line = subHeader
                    gfx.DrawString(line.Substring(currentChar, MaxChar), printFont, myBrush, leftMargin, YPosition(), New StringFormat())
                    count += 1
                    currentChar += MaxChar
                    subHeaderLenght -= MaxChar
                End While

                line = subHeader
                gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), New StringFormat())
                count += 1
            Else
                line = subHeader
                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), New StringFormat())
                count += 1
                'line = DottedLine()
                'gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), New StringFormat())
                'count += 1
            End If
        Next

        If subHeaderLines.Count > 0 Then
            line = DottedLine()
            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), New StringFormat())
            count += 1
        End If

        DrawEspacio()
    End Sub

    Private Sub DrawItems()
        Dim ordIt As OrderItem = New OrderItem("?"c)
        gfx.DrawString("DESCRIPCIÓN                 CANT.   PRECIO   TOTAL", printFont, myBrush, leftMargin, YPosition(), New StringFormat())
        count += 1
        DrawEspacio()

        For Each item As String In items
            line = ordIt.GetItemCantidad(item)
            line = AlignRightText(line.Length) & line
            gfx.DrawString("          " & line, printFont, myBrush, leftMargin, YPosition(), New StringFormat())

            line = ordIt.GetItemPrice(item)
            line = AlignRightText(line.Length) & line
            gfx.DrawString("                           " & line, printFont, myBrush, leftMargin, YPosition(), New StringFormat())

            line = ordIt.GetItemTotal(item)
            line = AlignRightText(line.Length) & line
            gfx.DrawString("                                         " & line, printFont, myBrush, leftMargin, YPosition(), New StringFormat())

            Dim name As String = ordIt.GetItemName(item)
            leftMargin = 1

            If name.Length > MaxCharDescription Then
                Dim currentChar As Integer = 0
                Dim itemLenght As Integer = name.Length

                While itemLenght > MaxCharDescription
                    line = ordIt.GetItemName(item)
                    gfx.DrawString("" & line.Substring(currentChar, MaxCharDescription), printFont, myBrush, leftMargin, YPosition(), New StringFormat())
                    count += 1
                    currentChar += MaxCharDescription
                    itemLenght -= MaxCharDescription
                End While

                line = ordIt.GetItemName(item)
                gfx.DrawString("               " & line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), New StringFormat())
                count += 1
            Else
                gfx.DrawString("" & ordIt.GetItemName(item), printFont, myBrush, leftMargin, YPosition(), New StringFormat())
                count += 1
            End If
        Next

        leftMargin = 1
        DrawEspacio()
        line = DottedLine()
        gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), New StringFormat())
        count += 1
        DrawEspacio()
    End Sub

    Private Sub DrawTotales()
        Dim ordTot As OrderTotal = New OrderTotal("?"c)

        For Each total As String In totales
            line = ordTot.GetTotalCantidad(total)
            line = AlignRightText(line.Length) & line
            gfx.DrawString("                               " & line, printFont, myBrush, leftMargin, YPosition(), New StringFormat())
            leftMargin = 1
            line = "          " & ordTot.GetTotalName(total)
            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), New StringFormat())
            count += 1
        Next

        leftMargin = 1
        DrawEspacio()
        DrawEspacio()
    End Sub

    Private Sub DrawFooter()
        For Each footer As String In footerLines

            If footer.Length > MaxChar Then
                Dim currentChar As Integer = 0
                Dim footerLenght As Integer = footer.Length

                While footerLenght > MaxChar
                    line = footer
                    gfx.DrawString(line.Substring(currentChar, MaxChar), printFont, myBrush, leftMargin, YPosition(), New StringFormat())
                    count += 1
                    currentChar += MaxChar
                    footerLenght -= MaxChar
                End While

                line = footer
                gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush, leftMargin, YPosition(), New StringFormat())
                count += 1
            Else
                line = footer
                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), New StringFormat())
                count += 1
                line = DottedLine()
                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), New StringFormat())
                count += 1
            End If
        Next

        leftMargin = 1
        DrawEspacio()
    End Sub

    Private Sub DrawEspacio()
        line = ""
        gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), New StringFormat())
        count += 1
    End Sub
End Class

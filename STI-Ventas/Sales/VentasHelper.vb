Imports STIVentas.Model

''' <summary>
''' Helper para impresion de tickets de venta.
''' </summary>
''' <remarks>05.03.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public NotInheritable Class VentasHelper
    Public Shared Function PrintTicket(ordenVentaCobro As OrdenVentaCobroViewModel, ordenVenta As OrdenVentaModel, lineasVenta As List(Of OrdenVentaDetalleModel)) As Boolean
        Dim ret As Boolean = False
        Dim imprimeTicket As ImprimirTicket

        Try
            imprimeTicket = New ImprimirTicket()
            imprimeTicket.FontName = "Humnst777 Blk BT"
            imprimeTicket.FontSize = 8
            imprimeTicket.MaxChar = 40

            imprimeTicket.AddHeaderLine("    STI - Ventas")
            imprimeTicket.AddHeaderLine("    Expedido en: Test dirección")
            imprimeTicket.AddHeaderLine("    Tefono: 7122084099")

            imprimeTicket.AddSubHeaderLine("Caja: Uno.  Ticket: " & ordenVenta.GetReference())

            imprimeTicket.AddSubHeaderLine("Atendio: " & ordenVentaCobro.IdUsuario.ToString())
            imprimeTicket.AddSubHeaderLine("Cliente: " & ordenVenta.GetCliente())
            imprimeTicket.AddSubHeaderLine("Fecha: " + Date.Now.ToString("dd/MM/yy HH:mm:ss"))

            For Each ventaDetalle As OrdenVentaDetalleModel In lineasVenta
                imprimeTicket.AddItem(ventaDetalle.Nombre.Replace("?", ""), ventaDetalle.Cantidad.ToString("n0"), ventaDetalle.PrecioUnitario.ToString("n2"), ventaDetalle.Monto.ToString("n2"))
            Next

            imprimeTicket.AddTotal("Total      ....$", ordenVentaCobro.Total.ToString("n2"))
            imprimeTicket.AddTotal("Efectivo ....$", ordenVentaCobro.GetEfectivo().ToString("n2"))
            imprimeTicket.AddTotal("Cambio  ....$", ordenVentaCobro.Vuelto.ToString("n2"))

            imprimeTicket.PrintTicket("")
            ret = String.IsNullOrEmpty(imprimeTicket.LastError)

            If Not ret Then
                HandleError(imprimeTicket.LastError)
            End If

        Catch ex As Exception
            HandleException(ex)
        End Try

        Return ret
    End Function
End Class

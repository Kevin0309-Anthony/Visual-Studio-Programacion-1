﻿Public Class Form1
    Dim objEstadistica As New Estadistica
    Private Sub bntmMediaAritmetica_Click(sender As Object, e As EventArgs) Handles bntmMediaAritmetica.Click
        lblrespuestaMedia.Text = objEstadistica.calcularMedia(txtserie.Text.Split(","))
        lblrespuestaVarianza.Text = objEstadistica.calcularVarianza(txtserie.Text.Split(","))
        lblrespuestaDesvTipica.Text = objEstadistica.calcularDesvTipica(txtserie.Text.Split(","))
    End Sub

    Private Sub grdEstadistica_KeyUp(sender As Object, e As KeyEventArgs) Handles grdEstadistica.KeyUp
        Dim nfilas = grdEstadistica.Rows.Count - 1,
            totalf1 = 0,
            totalx1xf1 = 0.0,
            totalx21xf1 = 0.0
        Dim fila As New DataGridViewRow
        For i = 0 To nfilas - 1
            fila = grdEstadistica.Rows(i)
            Dim x1 = 0, f1 = 0
            If fila.Cells("x1").Value <> "" Then
                x1 = Integer.Parse(fila.Cells("x1").Value.ToString())
            End If
            If fila.Cells("f1").Value <> "" Then
                f1 = Integer.Parse(fila.Cells("f1").Value.ToString())
            End If
            totalf1 += f1
            totalx1xf1 += x1 * f1
            totalx21xf1 += x1 ^ 2 * f1

            fila.Cells("n1").Value = totalf1.ToString()
            fila.Cells("x1xf1").Value = (x1 * f1).ToString()
            fila.Cells("x21xf1").Value = (x1 ^ 2 * f1).ToString()
        Next
        lbltotalf1.Text = totalf1.ToString()
        lbltotalx1xf1.Text = totalx1xf1.ToString()
        lbltotalx21xf1.Text = totalx21xf1.ToString()

        Dim media = Math.Round(totalx1xf1 / totalf1, 2)
        Dim varianza = Math.Round(totalx21xf1 / totalf1 - media ^ 2, 2)
        lblrespuestaMedia.Text = media.ToString()
        lblrespuestaVarianza.Text = varianza.ToString()
        lblrespuestaDesvTipica.Text = Math.Round(Math.Sqrt(varianza), 2).ToString()

    End Sub
End Class
Public Class Ticket
    ' Propiedades de la clase Ticket
    Public Property TicketId As String
    Public Property Fecha As Date
    Public Property Hora As Date
    Public Property UsuarioGeneroTicket As String
    Public Property UsuarioConsulta As String

    ' Constructor modificado para aceptar solo los argumentos necesarios
    Public Sub New(ByVal ticketId As String, ByVal fecha As Date, ByVal hora As Date, ByVal usuarioGeneroTicket As String, ByVal usuarioConsulta As String)
        Me.TicketId = ticketId
        Me.Fecha = fecha
        Me.Hora = hora
        Me.UsuarioGeneroTicket = usuarioGeneroTicket
        Me.UsuarioConsulta = usuarioConsulta
    End Sub
End Class

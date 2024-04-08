' SesionUsuario.vb

Public Class SesionUsuario
    Private Shared nombreUsuario As String = String.Empty

    Public Shared Sub IniciarSesion(nombre As String)
        nombreUsuario = nombre
    End Sub

    Public Shared Sub CerrarSesion()
        nombreUsuario = String.Empty
    End Sub

    Public Shared Function ObtenerNombreUsuario() As String
        Return nombreUsuario
    End Function
End Class

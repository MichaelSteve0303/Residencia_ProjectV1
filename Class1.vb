Imports System.Data.SqlClient
Public Class Class1
    'No te olvides visitar Vaidrollteam.blogspot.com para encontrar más proyectos.
    Dim cnx As New SqlConnection("server=localhost\SQLEXPRESS;integrated security=true;Database=VaiInventario123")

    Public Function Login(usu As String, pass As String) As DataTable
        Dim cmd As SqlCommand = New SqlCommand("vai_logueo", cnx)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@usuario", usu)
        cmd.Parameters.AddWithValue("@clave", pass)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dtable1 As DataTable = New DataTable()
        da.Fill(dtable1)
        Return dtable1
    End Function

    Public Function BuscarProductos(nombreproducto As String, idcategoria As String) As DataTable
        Dim cmd As SqlCommand = New SqlCommand("vai_buscar_productos", cnx)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@nombre", nombreproducto)
        cmd.Parameters.AddWithValue("@idcategoria", idcategoria)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dtable1 As DataTable = New DataTable()
        da.Fill(dtable1)
        Return dtable1
    End Function
    'No te olvides de suscribirte al canal VaidrollTeam
    Public Function ListarCategoria() As DataTable
        Dim da As New SqlDataAdapter("vai_listar_categoria", cnx)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function

    Public Function RegistrarProducto(nombreproducto As String, idcategoria As String, precio As Decimal, stock As Integer)
        Dim da As New SqlCommand("vai_nuevo_producto", cnx)
        da.CommandType = CommandType.StoredProcedure
        da.Parameters.AddWithValue("@nombre", nombreproducto)
        da.Parameters.AddWithValue("@idcategoria", idcategoria)
        da.Parameters.AddWithValue("@precio", precio)
        da.Parameters.AddWithValue("@stock", stock)
        cnx.Open()
        Dim resp As Integer
        Try
            resp = da.ExecuteNonQuery
            MsgBox("Registrador con exito " + nombreproducto)
            cnx.Close()
        Catch ex As Exception
            MsgBox("Error al registrar producto")
        End Try
        Return resp
    End Function

    Public Function EliminarProducto(codigo As String)
        Dim eliminar As New SqlCommand("vai_eliminar_producto", cnx)
        eliminar.CommandType = CommandType.StoredProcedure
        eliminar.Parameters.AddWithValue("@codigo", codigo)
        cnx.Open()
        Dim resp As Integer
        Try
            resp = eliminar.ExecuteNonQuery
            MsgBox("Eliminado con exito " + codigo)
            cnx.Close()
        Catch ex As Exception
            MsgBox("Error al eliminar producto")
        End Try
        Return resp
    End Function

    Public Function ModificarProducto(codigo As String, nombreproducto As String, idcategoria As String, precio As Decimal, stock As Integer)
        Dim modificar As New SqlCommand("vai_modificar_producto", cnx)
        modificar.CommandType = CommandType.StoredProcedure
        modificar.Parameters.AddWithValue("@codigo", codigo)
        modificar.Parameters.AddWithValue("@nombre", nombreproducto)
        modificar.Parameters.AddWithValue("@idcategoria", idcategoria)
        modificar.Parameters.AddWithValue("@precio", precio)
        modificar.Parameters.AddWithValue("@stock", stock)
        cnx.Open()
        Dim resp As Integer
        Try
            resp = modificar.ExecuteNonQuery
            MsgBox("Modificado con exito " + codigo)
            cnx.Close()
        Catch ex As Exception
            MsgBox("Error al modificar producto")
        End Try
        Return resp
    End Function

    Public Function BuscarCategoria(idcategoria As String, nombrecategoria As String) As DataTable
        Dim cmd As SqlCommand = New SqlCommand("vai_buscar_categoria", cnx)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@idcategoria", idcategoria)
        cmd.Parameters.AddWithValue("@nombre", nombrecategoria)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dtable1 As DataTable = New DataTable()
        da.Fill(dtable1)
        Return dtable1
    End Function

    Public Function RegistrarCategoria(nombrecategoria As String)
        Dim da As New SqlCommand("vai_nueva_categoria", cnx)
        da.CommandType = CommandType.StoredProcedure
        da.Parameters.AddWithValue("@nombre", nombrecategoria)
        cnx.Open()
        Dim resp As Integer
        Try
            resp = da.ExecuteNonQuery
            MsgBox("Registrador con exito " + nombrecategoria)
            cnx.Close()
        Catch ex As Exception
            MsgBox("Error al registrar categoria")
        End Try
        Return resp
    End Function

    Public Function ModificarCategoria(codigo As String, nombreproducto As String)
        Dim modificar As New SqlCommand("vai_modificar_categoria", cnx)
        modificar.CommandType = CommandType.StoredProcedure
        modificar.Parameters.AddWithValue("@codigo", codigo)
        modificar.Parameters.AddWithValue("@nombre", nombreproducto)
        cnx.Open()
        Dim resp As Integer
        Try
            resp = modificar.ExecuteNonQuery
            MsgBox("Modificado con exito " + codigo)
            cnx.Close()
        Catch ex As Exception
            MsgBox("Error al modificar categoria")
        End Try
        Return resp
    End Function

    Public Function BuscarUsuarios(nombreusuario As String) As DataTable
        Dim cmd As SqlCommand = New SqlCommand("vai_buscar_usuarios", cnx)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@nombre", nombreusuario)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dtable1 As DataTable = New DataTable()
        da.Fill(dtable1)
        Return dtable1
    End Function
    Public Function RegistrarUsuario(nombreusuario As String, correo As String, usuario As String, permiso As String)
        Dim da As New SqlCommand("vai_nuevo_usuario", cnx)
        da.CommandType = CommandType.StoredProcedure
        da.Parameters.AddWithValue("@nombre", nombreusuario)
        da.Parameters.AddWithValue("@correo", correo)
        da.Parameters.AddWithValue("@usuario", usuario)
        da.Parameters.AddWithValue("@permiso", permiso)
        cnx.Open()
        Dim resp As Integer
        resp = da.ExecuteNonQuery
            MsgBox("Registrador con exito " + nombreusuario)
            cnx.Close()

            Return resp
    End Function
    Public Function ModificarUsuario(codigo As String, nombreusuario As String, correo As String, permiso As String)
        Dim modificar As New SqlCommand("vai_modificar_usuario", cnx)
        modificar.CommandType = CommandType.StoredProcedure
        modificar.Parameters.AddWithValue("@codigo", codigo)
        modificar.Parameters.AddWithValue("@nombre", nombreusuario)
        modificar.Parameters.AddWithValue("@correo", correo)
        modificar.Parameters.AddWithValue("@permiso", permiso)
        cnx.Open()
        Dim resp As Integer
        resp = modificar.ExecuteNonQuery
            MsgBox("Modificado con exito " + codigo)
        cnx.Close()
        Return resp
    End Function
    Public Function EliminarUsuario(codigo As String)
        Dim eliminar As New SqlCommand("vai_eliminar_usuario", cnx)
        eliminar.CommandType = CommandType.StoredProcedure
        eliminar.Parameters.AddWithValue("@codigo", codigo)
        cnx.Open()
        Dim resp As Integer
        resp = eliminar.ExecuteNonQuery
        MsgBox("Eliminado con exito " + codigo)
        cnx.Close()
        Return resp
    End Function

    Public Function ResetearUsuario(codigo As String)
        Dim modificar As New SqlCommand("vai_reset_pass", cnx)
        modificar.CommandType = CommandType.StoredProcedure
        modificar.Parameters.AddWithValue("@codigo", codigo)
        cnx.Open()
        Dim resp As Integer
        resp = modificar.ExecuteNonQuery
        MsgBox("Reseteado con exito " + codigo)
        cnx.Close()
        Return resp
    End Function

    Public Function ListarUsuarios() As DataTable
        Dim da As New SqlDataAdapter("vai_listar_permisos", cnx)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function

    Public Function CambiarPass(codigo As String, passnueva As String)
        Dim modificar As New SqlCommand("vai_pass", cnx)
        modificar.CommandType = CommandType.StoredProcedure
        modificar.Parameters.AddWithValue("@codigo", codigo)
        modificar.Parameters.AddWithValue("@clavenueva", passnueva)
        cnx.Open()
        Dim resp As Integer
        Try
            resp = modificar.ExecuteNonQuery
            MsgBox("Contraseña modificada " + codigo)
            cnx.Close()
        Catch ex As Exception
            MsgBox("La contraseña antigua no coincide")
        End Try

        Return resp
    End Function


    Public Function ObtenerUsuarios() As DataTable
        Dim dtUsuarios As New DataTable()

        Try
            Dim cmd As New SqlCommand("SELECT Codigo, Nombre FROM Usuarios", cnx)
            Using da As New SqlDataAdapter(cmd)
                da.Fill(dtUsuarios)
            End Using
        Catch ex As Exception
            ' Devolver la excepción en lugar de mostrar un mensaje
            Throw ex
        End Try

        Return dtUsuarios
    End Function

    Public Function ObtenerNivelAcceso(codigoUsuario As String) As Integer
        ' Aquí colocarías el código para consultar el nivel de acceso del usuario en la base de datos
        ' Por ejemplo, podrías usar una consulta SQL para obtener este valor
        ' Aquí supondré que tienes una tabla llamada Usuarios con un campo NivelAcceso

        Dim nivelAcceso As Integer = 0 ' Valor predeterminado
        Dim queryString As String = "SELECT NivelAcceso FROM Usuarios WHERE Codigo = @Codigo"

        Using connection As New SqlConnection("Tu cadena de conexión")
            Using command As New SqlCommand(queryString, connection)
                command.Parameters.AddWithValue("@Codigo", codigoUsuario)
                connection.Open()
                Dim result As Object = command.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    nivelAcceso = Convert.ToInt32(result)
                End If
            End Using
        End Using

        Return nivelAcceso
    End Function

    Public Function ObtenerCodigoUsuarioActual() As String
        ' Aquí debes implementar la lógica para obtener el código del usuario actual
        ' Por ejemplo, si estás utilizando un sistema de autenticación, podrías retornar el código del usuario autenticado actualmente.
        ' Por ahora, retornaré un valor ficticio como ejemplo:
        Return "codigo_usuario_actual"
    End Function

    Public Function EsAdministrador(codigoUsuario As String) As Boolean
        ' Lógica para determinar si el usuario es administrador
        ' Puedes implementar la lógica de acuerdo a cómo determinas si un usuario es administrador en tu aplicación
        ' Por ejemplo, si tienes un campo en la base de datos que indica el rol del usuario, puedes consultar ese campo aquí
        ' y devolver true si el rol es de administrador, y false en caso contrario.
        ' Esta es solo una implementación de ejemplo:
        Dim esAdmin As Boolean = ObtenerRolUsuario(codigoUsuario) = "admin"
        Return esAdmin
    End Function

    Public Function ObtenerRolUsuario(codigoUsuario As String) As String
        Dim rol As String = ""

        Try
            ' Aquí realizarías una consulta a la base de datos para obtener el rol del usuario
            ' por ejemplo:
            Dim query As String = "SELECT NivelAcceso FROM Usuarios WHERE Codigo = @Codigo"


            Using connection As New SqlConnection("server=localhost\SQLEXPRESS;integrated security=true;Database=VaiInventario123")
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Codigo", codigoUsuario)
                    connection.Open()
                    Dim result As Object = command.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        rol = result.ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Manejar cualquier error que pueda ocurrir durante la consulta
            MsgBox("Error al obtener el rol del usuario: " & ex.Message)
        End Try

        Return rol
    End Function


End Class


SQL
USE [master]

GO

CREATE DATABASE [VaiInventario123]

GO

USE [VaiInventario123]

GO

CREATE TABLE [Usuarios](
    [Codigo] [varchar](5) PRIMARY KEY,
    [Nombre] [varchar](50) NOT NULL,
    [Correo] [varchar](50) NOT NULL,
    [Usuario] [varchar](50) NOT NULL,
    [Password] [varchar](50) NOT NULL,
    [IdPermisos] [varchar](5) NOT NULL
)

GO

CREATE TABLE [Permisos](
    [IdPermisos] [varchar](5) PRIMARY KEY,
    [TipoPermiso] [varchar](50) NOT NULL
)

GO

CREATE TABLE [Categoria](
    [IdCategoria] [varchar](5) PRIMARY KEY,
    [Nombre] [varchar](50) NOT NULL
)

GO

CREATE TABLE [Productos](
    [Codigo] [varchar](5) PRIMARY KEY,
    [Nombre] [varchar](50) NOT NULL,
    [IdCategoria] [varchar](5) NOT NULL,
    [Precio] [decimal](16, 2) NOT NULL,
    [Stock] [int] NOT NULL,
    CONSTRAINT [FK_Productos_Categoria] FOREIGN KEY ([IdCategoria]) REFERENCES [Categoria] ([IdCategoria])
)

GO

Use VaiInventario123
go

--Login--
create proc vai_logueo
@usuario varchar(50),
@clave varchar(50)
as
select Nombre,Usuario,Password,IdPermisos,Codigo from Usuarios 
where usuario=@usuario and Password=@clave
go

--Listar categoria--
create proc vai_listar_categoria
as
select '' as IdCategoria,'--Seleccione--' as Nombre
union all
select * from Categoria
go
------------PRODUCTOS------------
--Listar productos--
create proc vai_buscar_productos 
@nombre varchar(50),
@idcategoria varchar(5)
as
select Codigo,pro.Nombre,pro.IdCategoria as idcategoria,cat.Nombre as Categoria, Precio,Stock 
from Productos pro,Categoria cat where pro.IdCategoria=cat.IdCategoria 
and pro.nombre like @nombre + '%' and pro.IdCategoria like @idcategoria + '%'
go

--Registrar productos---
create proc vai_nuevo_producto
@nombre varchar(50),
@idcategoria varchar(5),
@precio money,
@stock int
as
declare @codigonuevo varchar(5)
set @codigonuevo= (select MAX(Codigo) from Productos)
set @codigonuevo= 'P' + RIGHT ('0000' + LTRIM (right(isnull(@codigonuevo,'0000'),4)+1),4)
insert into Productos values (@codigonuevo,@nombre,@idcategoria,@precio,@stock)
go

--Elimina productos---
create proc vai_eliminar_producto
@codigo varchar(5)
as
delete from Productos where Codigo=@codigo
go

--Modificar productos---
create proc vai_modificar_producto
@codigo varchar(5),
@nombre varchar(50),
@idcategoria varchar(5),
@precio money,
@stock int
as
update Productos set Nombre=@nombre,IdCategoria=@idcategoria,Precio=@precio,Stock=@stock
where Codigo=@codigo
go
------------CATEGORIA------------
--Buscar categoria--
create proc vai_buscar_categoria
@idcategoria varchar(5),
@nombre varchar(50)
as
select IdCategoria,Nombre from Categoria where IdCategoria like @idcategoria + '%' and Nombre like @nombre + '%'
go
--Registrar categoria---
create proc vai_nueva_categoria
@nombre varchar(50)
as
declare @codnuevocat varchar(5)
set @codnuevocat= (select MAX(IdCategoria) from Categoria)
set @codnuevocat= 'C' + RIGHT ('0000' + LTRIM (right(isnull(@codnuevocat,'0000'),4)+1),4)
insert into Categoria values (@codnuevocat,@nombre)
go
--Modificar categoria---
create proc vai_modificar_categoria
@codigo varchar(5),
@nombre varchar(50)
as
update Categoria set Nombre=@nombre where IdCategoria=@codigo
go
------------USUARIOS------------
--Buscar usuarios--
create proc vai_buscar_usuarios
@nombre varchar(50)
as
select codigo,Nombre,Correo,Usuario,per.IdPermisos,per.TipoPermiso
from Usuarios usu,Permisos per where usu.IdPermisos=per.IdPermisos
and Nombre like @nombre + '%'
go

--Nuevo usuarios--
create proc vai_nuevo_usuario
@nombre varchar(50),
@correo varchar(5),
@usuario varchar(50),
@permiso varchar(5)
as
declare @codigonuevo varchar(5)
set @codigonuevo= (select MAX(Codigo) from Usuarios)
set @codigonuevo= 'A' + RIGHT ('0000' + LTRIM (right(isnull(@codigonuevo,'0000'),4)+1),4)
insert into Usuarios values (@codigonuevo,@nombre,@correo,@usuario,@usuario,@permiso)
go
--Modificar usuarios--
create proc vai_modificar_usuario
@codigo varchar(5),
@nombre varchar(50),
@correo varchar(50),
@permiso varchar(5)
as
update Usuarios set Nombre=@nombre,IdPermisos=@permiso,Correo=@correo where Codigo=@codigo
go

create proc vai_eliminar_usuario
@codigo varchar(5)
as
delete from Usuarios where Codigo=@codigo
go

------------PERMISOS------------
create proc vai_listar_permisos
as
select '' as idpermisos,'--Seleccione--' as Permiso
union all
select * from Permisos
go
------------RESETEAR PASSWORD------------
create proc vai_reset_pass
@codigo varchar(5)
as
update Usuarios set Password=Usuario where Codigo=@codigo
go

------------CAMBIAR PASSWORD------------
create proc vai_pass
@codigo varchar(5),
@clavenueva varchar(50)
as
update Usuarios set Usuarios.Password=@clavenueva where Codigo=@codigo
go
Use VaiInventario123
go

--Insertar datos de usuarios--
--B0001 = ADMIN
--B0002 = USUARIO
insert into Usuarios values('A0001','VaidrollTeam','correo@gmail.com','admin','admin','B0001')
insert into Usuarios values('A0002','Usuario2','correo2@gmail.com','admin2','admin2','B0001')
insert into Usuarios values('A0003','Usuario3','correo3@gmail.com','usu1','usu1','B0002')
insert into Usuarios values('A0004','Usuario4','correo4@gmail.com','usu2','usu2','B0002')
insert into Usuarios values('A0005','Usuario5','correo5@gmail.com','usu3','usu3','B0002')
insert into Usuarios values('A0006','Usuario6','correo6@gmail.com','usu4','usu4','B0002')

select * from Usuarios
go

--Insertar datos de permisos--
insert into Permisos values('B0001','Administrador')
insert into Permisos values('B0002','Usuario')

--Insertar datos de categorias--

insert into Categoria values('C0001','Categoria1')
insert into Categoria values('C0002','Categoria2')
insert into Categoria values('C0003','Categoria3')
insert into Categoria values('C0004','Categoria4')
insert into Categoria values('C0005','Categoria5')
insert into Categoria values('C0006','Categoria6')
insert into Categoria values('C0007','Categoria7')
insert into Categoria values('C0008','Categoria8')
insert into Categoria values('C0009','Categoria9')
insert into Categoria values('C0010','Categoria10')

select * from Categoria
go
--Insertar datos de productos--

insert into Productos values('P0001','Producto1','C0001','12.00',10)
insert into Productos values('P0002','Producto2','C0002','6.00',6)
insert into Productos values('P0003','Producto3','C0003','4.00',20)
insert into Productos values('P0004','Producto4','C0004','20.00',42)
insert into Productos values('P0005','Producto5','C0005','90.00',2)
insert into Productos values('P0006','Producto6','C0006','30.00',65)
insert into Productos values('P0007','Producto7','C0001','47.00',2)
insert into Productos values('P0008','Producto8','C0005','41.00',4)
insert into Productos values('P0009','Producto9','C0003','26.00',1)
insert into Productos values('P0010','Producto10','C0001','31.00',8)
insert into Productos values('P0011','Producto11','C0010','64.00',16)
insert into Productos values('P0012','Producto12','C0009','85.00',74)
insert into Productos values('P0013','Producto13','C0008','95.00',30)
insert into Productos values('P0014','Producto14','C0007','16.00',5)
insert into Productos values('P0015','Producto15','C0004','3.00',8)
insert into Productos values('P0016','Producto16','C0002','8.00',54)
insert into Productos values('P0017','Producto17','C0001','7.00',10)
insert into Productos values('P0018','Producto18','C0003','14.00',16)
insert into Productos values('P0019','Producto19','C0010','64.00',2)
insert into Productos values('P0020','Producto20','C0006','38.00',8)

select * from Productos
go
--------------------------------
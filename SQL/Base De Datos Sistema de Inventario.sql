Create Database SistemaFerreteria
go

use SistemaFerreteria
go


---Tabla de Categorias--
Create Table  Categorias (
id_Categoria int identity(1,1) primary key,
Nombre_Categoria varchar (60) not null
)
go
insert into Categorias values('Herramientas'),('Pinturas'),('Ceramicas'),('Ilumniacion y Electricidad'),('Construccion'),('Fontaneria'),('Repuestos')

select * from Categorias

--Tabla de Marcas--
Create table Marcas(
id_Marca int identity (1,1) primary key,
Nombre_Marca varchar(60) not null,
id_Categoria int not null,
)
go
---Inserciones de Marcas--
insert into Marcas values('Truper',(Select top 1 id_Categoria from Categorias where id_Categoria=1)),
('CaterPillar',(Select top 1 id_Categoria from Categorias where id_Categoria=1)),
('Black & Decker',(Select top 1 id_Categoria from Categorias where id_Categoria=1)),
('Honda',(Select top 1 id_Categoria from Categorias where id_Categoria=1)),
('Makita',(Select top 1 id_Categoria from Categorias where id_Categoria=1)),
('Lumi Max',(Select top 1 id_Categoria from Categorias where id_Categoria=4)),
('Silvania',(Select top 1 id_Categoria from Categorias where id_Categoria=4)),
('Fluxo',(Select top 1 id_Categoria from Categorias where id_Categoria=4)),
('Zuper',(Select top 1 id_Categoria from Categorias where id_Categoria=4)),
('Suli',(Select top 1 id_Categoria from Categorias where id_Categoria=4)),
('Syska',(Select top 1 id_Categoria from Categorias where id_Categoria=4)),
('Lanco',(Select top 1 id_Categoria from Categorias where id_Categoria=2)),
('Protecto',(Select top 1 id_Categoria from Categorias where id_Categoria=2)),
('Sur',(Select top 1 id_Categoria from Categorias where id_Categoria=2)),
('Modelo',(Select top 1 id_Categoria from Categorias where id_Categoria=2)),
('Comex',(Select top 1 id_Categoria from Categorias where id_Categoria=2)),
('Loctite',(Select top 1 id_Categoria from Categorias where id_Categoria=6)),
('Arco',(Select top 1 id_Categoria from Categorias where id_Categoria=6)),
('Grohe',(Select top 1 id_Categoria from Categorias where id_Categoria=6)),
('Ideal',(Select top 1 id_Categoria from Categorias where id_Categoria=6)),
('Maissen',(Select top 1 id_Categoria from Categorias where id_Categoria=3)),
('Wedgwood',(Select top 1 id_Categoria from Categorias where id_Categoria=3)),
('Limoges',(Select top 1 id_Categoria from Categorias where id_Categoria=3)),
('Stanley',(Select top 1 id_Categoria from Categorias where id_Categoria=5)),
('Silverline',(Select top 1 id_Categoria from Categorias where id_Categoria=5)),
('Holcin',(Select top 1 id_Categoria from Categorias where id_Categoria=5)),
('Canal',(Select top 1 id_Categoria from Categorias where id_Categoria=5)),
('Royal',(Select top 1 id_Categoria from Categorias where id_Categoria=7)),
('Blend',(Select top 1 id_Categoria from Categorias where id_Categoria=7)),
('Steel',(Select top 1 id_Categoria from Categorias where id_Categoria=7)),
('UniQflex',(Select top 1 id_Categoria from Categorias where id_Categoria=7))




---Tabla de Productos---
Create Table Productos(
id_Producto int identity (1,1) primary key,
Codigo varchar(20),
Nombre_Producto varchar(45),
id_marca int not null,
id_categ int not null,
Descripcion varchar(100),
PrecioDeCompra decimal(10,2) default 0,
PrecioDeVenta decimal(10,2) default 0,
Inventario int not null default 0,
Total decimal(10,2) default 0,
Porcentaje decimal (18,2)default 0,
)
go
---Procedimiento para agregar productos--
create procedure InsertarProductos
@codigo varchar (20),
@NombreProd varchar (45),
@idMarca int ,
@idCategoria int,
@descripcion varchar (100)
as
insert into Productos(Codigo,Nombre_Producto,id_marca,id_categ,Descripcion) values(@codigo,@NombreProd,@idMarca,@idCategoria,@descripcion)
go

---Procedimineto para mostrar en el griv--
create procedure Mostrar_Productos
as
select id_Producto as ID,Codigo,Nombre_Producto as Nombre,Nombre_Marca AS Marca,Nombre_Categoria as Categoria,Descripcion,Inventario,PrecioDeCompra,PrecioDeVenta,Total,Porcentaje
from Productos
inner join Categorias on Productos.id_categ=Categorias.id_Categoria
inner join Marcas ON Productos.id_marca=Marcas.id_Marca
go

---procedimiento para mostar productos en el griv modal--
create procedure Mostrar_modalProd
as
select id_Producto as ID,Codigo,Nombre_Producto as Producto,Nombre_Categoria as Categoria
from Productos
inner join Categorias on Productos.id_categ=Categorias.id_Categoria
inner join Marcas ON Productos.id_marca=Marcas.id_Marca
go

--Procedimiento para buscar productos en el griv modal--
Create or alter Procedure BuscarProd
@TextoBusqueda NVARCHAR(100) = NULL,
@TipoSearch INT = NULL
as
IF (@TextoBusqueda IS NULL OR LEN(TRIM(@TextoBusqueda)) <= 0) OR @TipoSearch IS NULL
	BEGIN
	select id_Producto as ID,Codigo,Nombre_Producto as Producto,Nombre_Categoria as Categoria
from Productos
inner join Categorias on Productos.id_categ=Categorias.id_Categoria
inner join Marcas ON Productos.id_marca=Marcas.id_Marca
END
ELSE
	IF @TipoSearch = 1 
		BEGIN
		select id_Producto as ID,Codigo,Nombre_Producto as Producto,Nombre_Categoria as Categoria
from Productos
inner join Categorias on Productos.id_categ=Categorias.id_Categoria
inner join Marcas ON Productos.id_marca=Marcas.id_Marca
WHERE Nombre_Producto LIKE '%' + @TextoBusqueda + '%'
		END
		ELSE IF @TipoSearch = 2 
		BEGIN
		select id_Producto as ID,Codigo,Nombre_Producto as Producto,Nombre_Categoria as Categoria
from Productos
inner join Categorias on Productos.id_categ=Categorias.id_Categoria
inner join Marcas ON Productos.id_marca=Marcas.id_Marca
WHERE Nombre_Categoria LIKE '%' + @TextoBusqueda + '%'
END
	ELSE IF @TipoSearch = 3 
		BEGIN
		select id_Producto as ID,Codigo,Nombre_Producto as Producto,Nombre_Categoria as Categoria
from Productos
inner join Categorias on Productos.id_categ=Categorias.id_Categoria
inner join Marcas ON Productos.id_marca=Marcas.id_Marca
WHERE Codigo LIKE '%' + @TextoBusqueda + '%'
end
go






----Procemineto almaceenado para buscar en la ventana de inventario----
CREATE OR ALTER PROCEDURE Search_Productos
@TextoBusqueda NVARCHAR(100) = NULL,
@TipoSearch INT = NULL
as
IF (@TextoBusqueda IS NULL OR LEN(TRIM(@TextoBusqueda)) <= 0) OR @TipoSearch IS NULL
	BEGIN
		select id_Producto as ID,Codigo,Nombre_Producto as Nombre,Nombre_Marca AS Marca,Nombre_Categoria as Categoria,Descripcion,Inventario,PrecioDeCompra,PrecioDeVenta,Total,Porcentaje
from Productos
inner join Categorias on Productos.id_categ=Categorias.id_Categoria
inner join Marcas ON Productos.id_marca=Marcas.id_Marca
	END
ELSE
	IF @TipoSearch = 1 
		BEGIN
			select id_Producto as ID,Codigo,Nombre_Producto as Nombre,Nombre_Marca AS Marca,Nombre_Categoria as Categoria,Descripcion,Inventario,PrecioDeCompra,PrecioDeVenta,Total,Porcentaje
from Productos
inner join Categorias on Productos.id_categ=Categorias.id_Categoria
inner join Marcas ON Productos.id_marca=Marcas.id_Marca
			WHERE Nombre_Producto LIKE '%' + @TextoBusqueda + '%'
		END
	ELSE IF @TipoSearch = 2 
		BEGIN
			select id_Producto as ID,Codigo,Nombre_Producto as Nombre,Nombre_Marca AS Marca,Nombre_Categoria as Categoria,Descripcion,Inventario,PrecioDeCompra,PrecioDeVenta,Total,Porcentaje
from Productos
inner join Categorias on Productos.id_categ=Categorias.id_Categoria
inner join Marcas ON Productos.id_marca=Marcas.id_Marca
			WHERE Nombre_Marca LIKE '%' + @TextoBusqueda + '%'
		END
	ELSE IF @TipoSearch = 3 
		BEGIN
			select id_Producto as ID,Codigo,Nombre_Producto as Nombre,Nombre_Marca AS Marca,Nombre_Categoria as Categoria,Descripcion,Inventario,PrecioDeCompra,PrecioDeVenta,Total,Porcentaje
from Productos
inner join Categorias on Productos.id_categ=Categorias.id_Categoria
inner join Marcas ON Productos.id_marca=Marcas.id_Marca
			WHERE Nombre_Categoria LIKE '%' + @TextoBusqueda + '%'
			END

			ELSE IF @TipoSearch = 4
		BEGIN
			select id_Producto as ID,Codigo,Nombre_Producto as Nombre,Nombre_Marca AS Marca,Nombre_Categoria as Categoria,Descripcion,Inventario,PrecioDeCompra,PrecioDeVenta,Total,Porcentaje
from Productos
inner join Categorias on Productos.id_categ=Categorias.id_Categoria
inner join Marcas ON Productos.id_marca=Marcas.id_Marca
			WHERE Codigo LIKE '%' + @TextoBusqueda + '%'
			END

			go


---Tabla de Usuarios para la seguridad--
create Table Rol(
id_Rol int identity(1,1)primary key,
Descripcion varchar(50),
fechacreacion datetime default getdate()
)
go

Create Table Permisos(
id_Permiso int identity(1,1)primary key,
idRol int references Rol(id_Rol),
Nombre_Menu varchar(100),
fechacreacion datetime default getdate()
)
go

Create Table Usuario(
id_Usuario int identity(1,1) primary key,
Nombre_User varchar(50),
account varchar(50),
pass nvarchar(max),
Estado bit,
id_Rol int references Rol(id_Rol)
)
go

Create table Proveedor(
id_Prov int identity(1,1)primary key,
Documento varchar(50),
RazonSocial varchar (50),
Correo varchar(50),
Telefono varchar(50),
Estado bit,
FechaCreacion datetime default getdate()
)
go



---Procediminentos para Proveedores---
--Ingresar Provedoor--
Create Procedure Ingresar_Proveedor(
@Documento Varchar(30),
@RazonSocial Varchar(30),
@Correo varchar(30),
@Telefono varchar(8),
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)as 
begin
	set @Resultado=0
	Declare @IDPERSONA INT
	if not exists(Select * from Proveedor where Documento=@Documento)
	begin
	insert into Proveedor(Documento,RazonSocial,Correo,Telefono,Estado)values(@Documento,@RazonSocial,@Correo,@Telefono,@Estado)
	set @Resultado=SCOPE_IDENTITY()
	end
	else
	set @Mensaje='El Numero de Documento ya existe'
end
go

---Editar Proveedor--
Create Procedure Editar_Proveedor(
@Id_Proveedor int,
@Documento Varchar(30),
@RazonSocial Varchar(30),
@Correo varchar(30),
@Telefono varchar(8),
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)
as
begin 
	set @Resultado=1
	declare @IDPERSONA INT
	if not exists(Select * from Proveedor where Documento=@Documento and id_Prov != @Id_Proveedor)
	begin 
	update Proveedor set
	Documento=@Documento,
	RazonSocial=@RazonSocial,
	Correo=@Correo,
	Telefono=@Telefono,
	Estado=@Estado
	where id_Prov=@Id_Proveedor
	end
	else
	begin
	set @Resultado=0
	set @Mensaje='El numero de Documento ya existe'
	end
end
go


--Eliminar Proveedor--
Create Procedure Eliminar_Proveedor(
@Id_Proveedor int,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
set @Resultado=1
if not exists(select * from Proveedor
inner join Compra on Proveedor.id_Prov=Compra.id_Proveedor
where Proveedor.id_Prov=@Id_Proveedor)
begin
delete top(1) from Proveedor where id_Prov=@Id_Proveedor
end
else
begin
set @Resultado=0
set @Mensaje='El Proveedor esta relacionado asociado a una compra'
end
end
go

select * from Proveedor

--Tabla Compras--
Create table Compra(
id_Compra int identity (1,1) primary key,
id_usuario int references Usuario(id_Usuario),
id_Proveedor int References Proveedor(id_Prov),
TipoDeDocumento varchar(50),
NumeroDocumento varchar(50),
MontoTotal decimal(10,2),
FechaCreacion datetime default getdate()
)

create table DetalleCompra(
id_DetalleCompra int identity(1,1) primary key,
idCompra int references Compra(id_Compra),
idProducto int references Productos(id_Producto),
PrecioDeCompra decimal(10,2),
PrecioDeVenta decimal(10,2),
Cantidad int,
Montototal decimal(10,2),
FechaCreacion datetime default getdate()
)


--Tabla de Negocio--
Create Table Negocio(
id_Negocio int primary key,
Nombre varchar(50) not null,
RUC varchar(50)not null,
Direccion varchar(50)not null,
Logo varbinary(max) null
)
insert into Negocio(id_Negocio,Nombre,RUC,Direccion)values(1,'Ferreteria ToolTrack','1010-10','Managua')

select * from Negocio
delete from Negocio

---Tabla de Porcentajes--
Create Table Porcentajes(
id_Pro int not null,
porc decimal(18,2),
PrecioTotal decimal(10,2),
procentajeAcum decimal default 0
)
go

---Mostrar Porcentaje de Productos ABC---
create procedure Mostrar_Porcenta
as
select id_Producto as ID,Codigo ,Nombre_Producto as Nombre,PrecioTotal as PrecioTotal,porc as Porcentaje,procentajeAcum as PorcentajeAcumulado
from Porcentajes
inner Join Productos on Porcentajes.id_Pro=Productos.id_Producto
order by(porc)desc
go

select * from Porcentajes

---Tabla del ABC--
Create Table ABC(
id_PPro int not null,
Precio decimal(10,2),
PorcentajeFinal decimal (18,2)
)
go

---Metodo para poner Productos en el chart
Create procedure Ingresar_char
as
select Codigo,Nombre_Producto as Nombre,Precio as PrecioTotal,PorcentajeFinal as ValorPorcentualFinal
from ABC
inner Join Productos on ABC.id_PPro=Productos.id_Producto
go

---Produccto A--
create procedure MostrarProductoA
as
select Codigo,Nombre_Producto as Nombre,Precio as PrecioTotal,PorcentajeFinal as ValorPorcentualFinal
from ABC
inner Join Productos on ABC.id_PPro=Productos.id_Producto
where(PorcentajeFinal)>0 and (PorcentajeFinal)<=80
go

--Prodcuto B---
Create procedure MostrarProductoB
as
select Codigo,Nombre_Producto as Nombre,Precio as PrecioTotal,PorcentajeFinal as ValorPorcentualFinal
from ABC
inner Join Productos on ABC.id_PPro=Productos.id_Producto
where(PorcentajeFinal)>80 and (PorcentajeFinal)<=95
go

--Producto C---
Create Procedure MostrarProductoC
as
select Codigo,Nombre_Producto as Nombre,Precio as PrecioTotal,PorcentajeFinal as ValorPorcentualFinal
from ABC
inner Join Productos on ABC.id_PPro=Productos.id_Producto
where(PorcentajeFinal)>95 and (PorcentajeFinal)<=100
go

select * from ABC
select * from Porcentajes
delete ABC
Delete Porcentajes

exec Mostrar_Porcenta
select * from Porcentajes
select * from ABC

exec Mostrar_Productos
select * from Porcentajes
exec Mostrar_Porcenta
delete ABC
select * from Usuario


-----Todo esto tomado en cuenta para el chart---
--Tabla Rangos del ABC---
Create Table Rangos(
Producto varchar(50),
Rango decimal(18,2),
)
go
insert into Rangos values('Producto A',80),('Producto B',95),('Producto C',100)
--Mostrar rangos del ABC--
Create Procedure  Mostrar_Rangos
as
select * from Rangos
go






--Modulo de prueba de usuarios---
select p.idRol,p.Nombre_Menu from Permisos p
inner join Rol r on r.id_Rol=p.idRol
inner join Usuario u on u.id_Rol=r.id_Rol
where u.id_Usuario=1

--Los roles del sistema--
insert into Rol(Descripcion)values('Administrador')
insert into Rol(Descripcion)values('Empleado')
--Primer usuario--
insert into Usuario(Nombre_User,account,pass,id_Rol,Estado)values('Cesar','admin','123',1,1)
insert into Usuario(Nombre_User,account,pass,id_Rol,Estado)values('Marlon','emp','145',2,1)
--Permisos del sistema--
insert into Permisos(idRol,Nombre_Menu)values(1,'ingresoDeProductosToolStripMenuItem'),(1,'comprasToolStripMenuItem'),(1,'clasificacionABCToolStripMenuItem'),(1,'proveedoresToolStripMenuItem'),
(1,'registrarUsuarioToolStripMenuItem'),(1,'cerrarSesionToolStripMenuItem')
insert into Permisos(idRol,Nombre_Menu)
values(2,'comprasToolStripMenuItem'),(2,'proveedoresToolStripMenuItem'),
(2,'cerrarSesionToolStripMenuItem')

insert into Permisos(idRol,Nombre_Menu)
values(2,'ReportesToolStripMenuItem')

insert into Permisos(idRol,Nombre_Menu)
values(1,'ReportesToolStripMenuItem')

insert into Permisos(idRol,Nombre_Menu)
values(2,'cerrarSesionToolStripMenuItem1')

insert into Permisos(idRol,Nombre_Menu)
values(1,'cerrarSesionToolStripMenuItem1')



select * from Usuario
-------Relaciones---
alter table Productos add constraint fk_Categoria
foreign key (id_Categ) references Categorias(id_Categoria)

alter table Marcas add constraint fk_cate
foreign key (id_Categoria)references Categorias(id_Categoria)

alter table ABC add constraint fk_P
foreign key(id_PPro)references Productos(id_Producto)



--Modulo de Usuarios--
Select u.id_Usuario,u.Nombre_User,u.account,u.pass,u.Estado,r.id_Rol,r.Descripcion from Usuario u
inner join Rol r on r.id_Rol=u.id_Rol

update Usuario set Estado=0 where id_Usuario=2

go

--para insertar usuarios--
create procedure Insertar_Usuarios(
@Nombre varchar(50),
@Usuario varchar(50),
@pass varchar(50),
@Estado bit,
@id_Rol int,
@idUsuarioResultado int output,
@Mensaje varchar(500) output
)
as
begin
  set @idUsuarioResultado=0
  set @Mensaje=''
  if not exists(select * from Usuario where Nombre_User=@Nombre)
  begin
   insert into Usuario(Nombre_User,account,pass,Estado,id_Rol)
   values(@Nombre,@Usuario,@pass,@Estado,@id_Rol)

   set @idUsuarioResultado=SCOPE_IDENTITY()
    end
  else 
     set @Mensaje='No se puede repetir el nombre para mas de un usuario'

end

--para editar usuarios--
create procedure Editar_Usuarios(
@idUsuario int,
@Nombre varchar(50),
@Usuario varchar(50),
@pass varchar(50),
@Estado bit,
@id_Rol int,
@Respuesta bit output,
@Mensaje varchar(500) output
)
as
begin
  set @Respuesta=0
  set @Mensaje=''
  if not exists(select * from Usuario where Nombre_User=@Nombre and id_Usuario!=@idUsuario)
  begin
      update Usuario set
	  Nombre_User=@Nombre,
	  account=@Usuario,
	  pass=@pass,
	  Estado=@Estado,
	  id_Rol=@id_Rol
	  where id_Usuario=@idUsuario
  
   set @Respuesta=1
    end
  else 
     set @Mensaje='No se puede repetir el nombre para mas de un usuario'

end


--Para eliminar Uusario---
create procedure Eliminar_Usuarios(
@idUsuario int,
@Respuesta bit output,
@Mensaje varchar(500) output
)
as
begin
  set @Respuesta=0
  set @Mensaje=''
  declare @pasoreglas bit=1
   if exists(select * from Compra c 
     inner join Usuario u on u.id_Usuario=c.id_usuario
	 where u.id_Usuario=@idUsuario)
	 begin 
	 set @pasoreglas=0
	 set @Respuesta=0
	 set @Mensaje=@Mensaje+'No se puede eliminar el usuario porque esta asociado a una compra\n'
	  end
if(@pasoreglas=1)
  begin
      delete from Usuario where id_Usuario=@idUsuario
	  set @Respuesta=1
  
    end
end


   
    
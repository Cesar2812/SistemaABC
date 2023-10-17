use SistemaFerreteria
go

select 
convert(char(10),c.FechaCreacion,103)[FechaCreacion],c.TipoDeDocumento,c.NumeroDocumento,c.MontoTotal,
u.Nombre_User[UsuarioRegistro],
pr.Documento[DcocumentoProveedor],pr.RazonSocial,
p.Codigo[CodigoProducto],p.Nombre_Producto[NombreProducto],mc.Nombre_Marca[Marca],ca.Nombre_Categoria[Categoria],dc.PrecioDeCompra,dc.PrecioDeVenta,dc.Cantidad,dc.Montototal[SubTotal]
from Compra c
inner join Usuario u on u.id_Usuario=c.id_usuario
inner join Proveedor pr on pr.id_Prov=c.id_Proveedor
inner join DetalleCompra dc on dc.idCompra=c.id_Compra
inner Join Productos p on p.id_Producto=dc.idProducto
inner join Categorias ca on ca.id_Categoria=p.id_categ
inner join Marcas mc on p.id_marca=mc.id_Marca
where convert(date,c.FechaCreacion) between '2023/10/12' and '2023/10/15'
and pr.id_Prov= iif(0=0, pr.id_prov,3)

--Procedimiento almacenado--
create or alter procedure ReporteCompras(
@fechaCreacion varchar(10),
@fechaFin varchar(10),
@idproveedor int
)
as
	begin
	set dateformat dmy;
	select 
convert(char(10),c.FechaCreacion,103)[FechaCreacion],c.TipoDeDocumento,c.NumeroDocumento,c.MontoTotal,
u.Nombre_User[UsuarioRegistro],
pr.Documento[DcocumentoProveedor],pr.RazonSocial,
p.Codigo[CodigoProducto],p.Nombre_Producto[NombreProducto],mc.Nombre_Marca[Marca],ca.Nombre_Categoria[Categoria],dc.PrecioDeCompra,dc.PrecioDeVenta,dc.Cantidad,dc.Montototal[SubTotal]
from Compra c
inner join Usuario u on u.id_Usuario=c.id_usuario
inner join Proveedor pr on pr.id_Prov=c.id_Proveedor
inner join DetalleCompra dc on dc.idCompra=c.id_Compra
inner Join Productos p on p.id_Producto=dc.idProducto
inner join Categorias ca on ca.id_Categoria=p.id_categ
inner join Marcas mc on p.id_marca=mc.id_Marca
where convert(date,c.FechaCreacion) between @fechaCreacion and @fechaFin
and pr.id_Prov= iif(@idproveedor=0,pr.id_Prov,@idproveedor)
end




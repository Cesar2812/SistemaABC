use SistemaFerreteria 
go

---Proceso para las compras---
 create type [dbo].[eDetalleCompra]as table(
 [idProducto]int  null,
 [PrecioDeCompra]decimal(10,2) null,
 [PrecioDeVenta]decimal(10,2)null,
 [Cantidad]int null,
 [Montototal]decimal(10,2)null
 )
 go


 create or alter procedure RegistrarCompraa(
 @idusuario int,
 @idproveed int,
 @TipoDeDocumento varchar(500),
 @NumeroDocumento varchar(500),
 @MontoTotal decimal(10,2),
 @DetalleCompra [eDetalleCompra] readonly,
 @Resultado bit output,
 @Mensaje varchar(500) output
 )
 as
 begin
   begin try
		declare @id_Compra int=0
		set @Resultado=1
		set @Mensaje=''

		begin transaction registro
				insert into Compra(id_usuario,id_Proveedor,TipoDeDocumento,NumeroDocumento,MontoTotal)
				values(@idusuario,@idproveed,@TipoDeDocumento,@NumeroDocumento,@MontoTotal)

				set @id_Compra= SCOPE_IDENTITY()

				insert into DetalleCompra(idCompra,idProducto,PrecioDeCompra,PrecioDeVenta,Cantidad,Montototal)
				select @id_Compra,idProducto,PrecioDeCompra,PrecioDeVenta,Cantidad,Montototal  from @DetalleCompra

				update p set p.Inventario=p.Inventario+dc.Cantidad,
				p.PrecioDeCompra=dc.PrecioDeCompra,
				p.PrecioDeVenta=dc.PrecioDeVenta
				from Productos p
				inner join @DetalleCompra dc on dc.idProducto=p.id_Producto
		commit transaction registro
   end try
   begin catch
   set @Resultado=0
   set @Mensaje=ERROR_MESSAGE() 
   rollback transaction registro
   end catch
 end


 select count(*)+1 from Compra
 select * from Productos
 

 select * from Proveedor

 select * from Compra 
 select * from DetalleCompra 

 
 select id_Compra,Nombre_User,Documento,RazonSocial,TipoDeDocumento,NumeroDocumento,MontoTotal,convert(char(10),Compra.FechaCreacion,103)[FechaRegistro]
 from Compra
 inner join Usuario on Compra.id_usuario=Usuario.id_Usuario
 inner join Proveedor on Compra.id_Proveedor=Proveedor.id_Prov
 where NumeroDocumento='0001'


 select Nombre_Producto,DetalleCompra.PrecioDeCompra,Cantidad,Montototal
 from DetalleCompra
 inner join Productos on DetalleCompra.idProducto=Productos.id_Producto
 where idCompra=1


 Select c.id_Compra,
 u.Nombre_User,
 pr.Documento,pr.RazonSocial,
 c.TipoDeDocumento,c.NumeroDocumento,c.MontoTotal,convert(char(10),c.FechaCreacion,103)[FechaCreacion]
 from Compra c
 inner join Usuario u on u.id_Usuario=c.id_usuario
 inner join Proveedor pr on pr.id_Prov=c.id_Proveedor
 where c.NumeroDocumento='0001'

 select * from Porcentajes

use bdproyecto
go

/*************PROCEDIMIENTOS PARA INSERTAR SOLO EN SCRIPT******************/
create or alter procedure usp_savePais
@descripcion varchar(64)
as
begin
	insert into tb_pais values (@descripcion)
end
go

exec usp_savePais 'Argentina'
exec usp_savePais 'China'
exec usp_savePais 'Japon'
exec usp_savePais 'Alemania'
exec usp_savePais 'Francia'
exec usp_savePais 'Inglaterra'
exec usp_savePais 'EE.UU.'
exec usp_savePais 'Italia'
exec usp_savePais 'Corea del Sur'
go

create or alter procedure usp_saveRol
@descripcion varchar(64)
as
begin
	insert into tb_rol values (@descripcion)
end
go

exec usp_saveRol 'Administrador'
exec usp_saveRol 'Vendedor'
exec usp_saveRol 'Cliente'
go

create or alter procedure usp_saveDistrito
@descripcion varchar(64)
as
begin
	insert into tb_distrito values (@descripcion)
end
go

exec usp_saveDistrito 'Lima Metropolitana'
exec usp_saveDistrito 'Rimac'
exec usp_saveDistrito 'San Juan de Lurigancho'
exec usp_saveDistrito 'San Martin de Porres'
exec usp_saveDistrito 'Independencia'
exec usp_saveDistrito 'Los Olivos'
exec usp_saveDistrito 'Breña'
exec usp_saveDistrito 'Comas'
exec usp_saveDistrito 'Miraflores'
exec usp_saveDistrito 'San Isidro'
exec usp_saveDistrito 'Surco'
exec usp_saveDistrito 'Chorrillos'
exec usp_saveDistrito 'Magdalena'
go

/***********************************END***********************************/

/*************PROCEDIMIENTOS PARA LOS CONTROLLERS******************/

/*************PAÍS******************/

create or alter procedure usp_findAllPais
as
begin
	Select * from tb_pais
end
go

/*************END******************/

/*************ROL******************/

create or alter procedure usp_findAllRol
as
begin
	Select * from tb_rol
end
go

/*************END******************/

/*************DISTRITO******************/

create or alter procedure usp_findAllDistrito
as
begin
	Select * from tb_distrito
end
go

/*************END******************/

/*************MARCA******************/

create or alter procedure usp_saveMarca
@descripcion varchar(64),
@cod_pais int,
@ruc varchar(32),
@telefono varchar(15),
@correo varchar(128)
as
begin
	insert into tb_marca values (@descripcion, @cod_pais, @ruc, @telefono, @correo)
end
go

create or alter procedure usp_updateMarca
@cod_marca int,
@descripcion varchar(64),
@cod_pais int,
@ruc varchar(32),
@telefono varchar(15),
@correo varchar(128)
as
begin
	update tb_marca set
	descripcion = @descripcion, cod_pais = @cod_pais, ruc = @ruc, telefono = @telefono, correo = @correo
	where cod_marca = @cod_marca
end
go

create or alter procedure usp_findAllMarca
as
begin
	select * from tb_marca
end
go

create or alter procedure usp_deleteMarca
@cod_marca int
as
begin
	delete tb_marca where cod_marca = @cod_marca
end
go

/*************END******************/

exec usp_saveMarca 'TOYOTA', 3, '20100132592', '800-331-4331', 'toyota@toyota.com'
exec usp_saveMarca 'KIA', 9, '20472468147', '01-617-3939', 'kia@kia.com'
exec usp_saveMarca 'HONDA', 3, '20103733015', '0-800-28000', 'honda@honda.com'
exec usp_saveMarca 'HYUNDAI', 9, '20506006024', '062-637-195', 'hyundai@hyundai.com'
exec usp_saveMarca 'MITSUBISHI', 3, '20100136156', '01-630-7225', 'mitsubishi@mitsubishi.com'
exec usp_saveMarca 'NISSAN', 3, '20602458491', '0800-00-230', 'nissan@nissan.com'
go

/*************PRODUCTO******************/

create or alter procedure usp_saveProducto
@nombre varchar(128),
@cod_marca int,
@descripcion varchar(256),
@precio decimal(10,2)
as
begin
	insert into tb_producto values (@nombre, @descripcion, @cod_marca, @precio)
end
go

create or alter procedure usp_updateProducto
@cod_producto int,
@nombre varchar(128),
@cod_marca int,
@descripcion varchar(256),
@precio decimal(10,2)
as
begin
	update tb_producto set
	nombre = @descripcion, descripcion = @descripcion, cod_marca = @cod_marca, precio = @precio
	where cod_producto = @cod_producto
end
go

create or alter procedure usp_findAllProducto
as
begin
	select * from tb_Producto
end
go

create or alter procedure usp_deleteProducto
@cod_producto int
as
begin
	delete tb_producto where cod_producto = @cod_producto
end
go

/*************END******************/


/*************USUARIO******************/

create or alter procedure usp_saveUsuario
@cod_rol int,
@correo varchar(128),
@contrasena char(10),
@nombre varchar(128),
@dni char(8),
@telefono varchar(16)
as
begin
	insert into tb_usuario values (@cod_rol, @correo, @contrasena,@nombre, @dni, @telefono)
end
go

create or alter procedure usp_updateUsuario
@cod_usuario int,
@cod_rol int,
@correo varchar(128),
@contrasena char(10),
@nombre varchar(128),
@dni char(8),
@telefono varchar(16)
as
begin
	update tb_usuario set
	cod_rol = @cod_rol, correo = @correo, contrasena = @contrasena, nombre = @nombre, dni = @dni, telefono = @telefono
	where cod_usuario = @cod_usuario
end
go

create or alter procedure usp_findAllUsuario
as
begin
	select * from tb_usuario
end
go

create or alter procedure usp_deleteUsuario
@cod_usuario int
as
begin
	delete tb_usuario where cod_usuario = @cod_usuario
end
go

create or alter procedure usp_findAllUsuarioDetalle
as
begin
	Select	u.cod_usuario,
			r.descripcion,
			u.correo,
			u.nombre,
			u.dni,
			u.telefono
			from tb_usuario u
			inner join tb_rol r on u.cod_rol = r.cod_rol
end
go

/*************END******************/

/*************CLIENTE******************/

create or alter procedure usp_saveCliente
@cod_usuario int,
@cod_distrito int,
@direccion varchar(128)
as
begin
	insert into tb_cliente values (@cod_usuario, @cod_distrito, @direccion)
end
go

create or alter procedure usp_updateCliente
@cod_cliente int,
@cod_usuario int,
@cod_distrito int,
@direccion varchar(128)
as
begin
	update tb_cliente set
	cod_usuario = @cod_usuario, cod_distrito = @cod_distrito, direccion = @direccion
	where cod_cliente = @cod_cliente
end
go

create or alter procedure usp_findAllCliente
as
begin
	select * from tb_cliente
end
go

create or alter procedure usp_deleteCliente
@cod_cliente int
as
begin
	delete tb_cliente where cod_cliente = @cod_cliente
end
go

create or alter procedure usp_findAllClienteDetalle
as
begin
	Select  c.cod_cliente,
			u.nombre,
			d.descripcion,
			c.direccion
			from tb_cliente c 
			inner join tb_usuario u on c.cod_usuario = u.cod_usuario
			inner join tb_distrito d on c.cod_distrito = d.cod_distrito
end
go

/*************END******************/

/*************BOLETA******************/

create or alter procedure usp_saveBoleta
@cod_usuario int,
@cod_cliente int,
@fecha_emision date,
@cod_producto int,
@total_pagar decimal(10,2)
as
begin
	insert into tb_boleta values (@cod_usuario, @cod_cliente, @fecha_emision, @cod_producto, @total_pagar)
end
go

create or alter procedure usp_updateBoleta
@cod_boleta int,
@cod_usuario int,
@cod_cliente int,
@fecha_emision date,
@cod_producto int,
@total_pagar decimal(10,2)
as
begin
	update tb_boleta set
	cod_usuario = @cod_usuario, cod_cliente = @cod_cliente, fecha_emision = @fecha_emision, cod_producto = @cod_producto, total_pagar = @total_pagar
	where cod_boleta = @cod_boleta
end
go

create or alter procedure usp_findAllBoleta
as
begin
	select * from tb_boleta
end
go

create or alter procedure usp_deleteBoleta
@cod_boleta int
as
begin
	delete tb_boleta where cod_boleta = @cod_boleta
end
go

/*************END******************/


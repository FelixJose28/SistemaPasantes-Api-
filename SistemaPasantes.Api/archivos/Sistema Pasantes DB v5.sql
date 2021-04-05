create database sistemapasante;
use sistemapasante;

create table rol(
id int not null Primary Key Identity(1,1),
nombre nvarchar(100) not null -- admin, pasante, aspirante, usuario
); 

create table grupo(
id int not null Primary key Identity(1,1),
nombre nvarchar(100) not null
);


create table usuario(
id int not null Primary Key Identity(1,1),
correo varchar(100) not null unique,
nombre nvarchar(100) not null,
apellido nvarchar(100) null,
clave  varchar(300) not null,
--clave  varbinary(max) not null,
telefono varchar(30) not null,
idRol int not null,
idGrupo int null,
constraint fk_rol_usuario foreign key(idRol) references Rol(id),
constraint fk_grupo_usuario foreign key(idGrupo) references grupo(id),
); 

create table estadoTarea(
id int identity(1,1) primary key,
nombre_estado nvarchar(100) not null -- abierta, cerrada
);




create table tarea(
id int not null Primary Key Identity(1,1),
titulo nvarchar(100) not null,
descripcion nvarchar(max) not null,
fecha_cierre Datetime not null,
idAdminUsuario int not null,
idEstado int not null,
constraint fk_tarea_usuario_admin foreign key(idAdminUsuario) references usuario(id),
constraint fk_tarea_estadoTarea foreign key(idEstado) references estadoTarea(id)
); 


create table tareaEntrega(
id int not null Primary Key Identity(1,1),
fecha_entrega datetime default GETDATE(),
archivo varbinary(max) null,
comentarios nvarchar(max) null,
calificacion int null,
idUsuario int not null,
idTarea int not null,
constraint fk_entrega_usuario foreign key(idUsuario) references usuario(id),
constraint fk_entrega_tarea foreign key(idTarea) references tarea(id)
); 


create table tareaEntregaGrupo(
id int not null primary key identity(1,1),
idTareaEntregada int not null,
calificacion int null,
constraint fk_idTareaEntregadaPorUsuario foreign key (idTareaEntregada) references tareaEntrega(id)
);
/*
Los formularios serán guardados como JSON, por ejemplo:
{
	{label: 'Nombre', type: 'text' },
	{label: 'Edad', type: 'dropdown', options: ['menor de 18', 'mayor de 18'] }
}

En el frontend se tomará este JSON y creará un formulario apartir del mismo
*/
create table formulario(
id int identity(1,1) primary key,
nombre nvarchar(255) not null,
json_data nvarchar(max) not null,
);
 
create table evaluacion(
id int not null Primary Key Identity(1,1),
titulo nvarchar(255) not null, 
descripcion nvarchar(max) null, 
fecha_cierre date not null, 
idAdminUsuario int not null,
idFormulario int not null, 
constraint fk_evaluacion_usuario foreign key(idAdminUsuario) references usuario(id),
constraint fk_evaluacion_formulario foreign key(idFormulario) references formulario(id)
);

create table tipoRespuestaEvaluacion (
id int not null primary key identity(1,1),
nombre varchar(100) not null
);

/*
Las respuestas a los formularios guardarán el formulario pero con los datos de las respuestas en estos en el key "value":
{
	{label: 'Nombre', type: 'text', value: 'Manuel' },
	{label: 'Edad', type: 'dropdown', options: ['menor de 18', 'mayor de 18'], value: 1 }
}
*/
create table respuestaFormulario(
id int not null Primary Key Identity(1,1),
fecha_entrega datetime not null,
json_data nvarchar(max) not null, 
calificacion int, 
idTipoRespuesta int not null,
idUsuario int not null,
idFormulario int not null,
constraint fk_respuesta_usuario foreign key(idUsuario) references usuario(id),
constraint fk_tipo_respuesta foreign key(idTipoRespuesta) references tipoRespuestaEvaluacion(id),
constraint fk_respuesta_formulario foreign key(idFormulario) references formulario(id)
); 

create table convocatoria(
id int not null Primary Key Identity(1,1),
fecha_inicio date default GETDATE(),
fecha_cierre date not null,
cupo int not null,
titulo nvarchar(max) not null, 
descripcion nvarchar(max) null,
idAdminUsuario int not null,
idFormulario int not null, 
constraint fk_convocatoria_usuario foreign key(idAdminUsuario) references usuario(id),
constraint fk_convocatoria_formulario foreign key(idFormulario) references formulario(id),
);

create table pasante (
id int not null primary key identity(1,1),
idUsuario int not null unique,
idConvocatoria int not null,
constraint fk_pasante_usuario foreign key(idUsuario) references usuario(id),
constraint fk_pasante_convocatoria foreign key(idConvocatoria) references convocatoria(id),
);




alter table grupo add  idConvocatoria int constraint fk_idConvocatoriaG foreign key (idConvocatoria) references convocatoria(id)


create database viagenjlk;
go
use viagenjlk;
go
create table tipoUse (
  id_tipoUse int identity(1,1),
  nomeUse nvarchar(200) not null,  
  loginUse varchar(100) not null,
  data_nasc varchar(50) not null,
  senhaUse varchar(50) not null,
  contaUse varchar(50) not null,  
  constraint pk_tipoUse primary key (id_tipoUse)
);
go
create table pacotes (
  id_pacotes int identity(1,1),
  nome varchar(200) not null,
  origem varchar(200) not null,
  destino varchar(200) not null,
  saida varchar(50) not null,
  retorno varchar(50) not null,
  preco decimal(9,2) not null  
  constraint pk_pacotes primary key (id_pacotes)  
);
go
create table compras (
  id_compra int identity(1,1),
  nome varchar(200) not null,
  origem varchar(200) not null,
  destino varchar(200) not null,
  saida varchar(50) not null,
  retorno varchar(50) not null,
  preco decimal(9,2) not null,
  id_pacotes int not null,
  id_tipoUse int not null,
  constraint pk_compras primary key (id_compra),
  constraint fk_compras_pacotes foreign key (id_pacotes) references pacotes (id_pacotes),
  constraint fk_compras_tipoUse foreign key (id_tipoUse) references tipoUse (id_tipoUse)
);
go
create table atendimento (
  id_atendimento int identity(1,1),
  nome varchar(200) not null,
  email varchar(200) not null,
  duvida varchar(500) not null
  constraint pk_atendimento primary key (id_atendimento)
);
go

insert into tipoUse (id_tipoUse, nomeUse,  loginUse, data_nasc, senhaUse, contaUse) values (1, 'John',  'john-fullstack', '21/08/1989', '2128', 'administrador');
insert into tipoUse (id_tipoUse, nomeUse,  loginUse, data_nasc, senhaUse, contaUse) values (2, 'Gabriel',  'gabriel-monitor', '26/08/1989', '1234', 'colaborador');
insert into tipoUse (id_tipoUse, nomeUse,  loginUse, data_nasc, senhaUse, contaUse) values (6, 'Rosi',  'rosi-fullstack', '21/08/1989', '7654', 'usuario');
go



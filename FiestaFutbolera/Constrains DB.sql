-- Creación de tablas 

CREATE TABLE Usuarios
(
Telefono BIGINT NOT NULL CHECK (Telefono > 1000000),
Nombre   VARCHAR(50) NOT NULL CHECK (Nombre <> ' '),
NroIdUsuario BIGINT,
TipoIdUsuario  VARCHAR(3),

PRIMARY KEY (NroIdUsuario,TipoIdusuario)
);

CREATE TABLE Registrado
(
NroIdUsuario BIGINT NOT NULL,
TipoIdUsuario VARCHAR(3) NOT NULL,
Foto IMAGE NULL,
DirCorreo VARCHAR(50) NOT NULL,
Password VARCHAR(20) NOT NULL,

PRIMARY KEY (DirCorreo),
FOREIGN KEY (NroIdUsuario,TipoIdUsuario) REFERENCES Usuarios(NroIdUsuario,TipoIdUsuario)
);

CREATE TABLE Empresa
(
TelefonoEmpresa BIGINT NOT NULL CHECK (TelefonoEmpresa > 1000000),
DireccionEmpresa VARCHAR(50) NOT NULL CHECK (DireccionEmpresa <> ' '),
TipoIdEmpresa VARCHAR(3),
NroIdEmpresa BIGINT,
Logo IMAGE NULL,

PRIMARY KEY (TipoIdEmpresa, NroIdEmpresa)
);

CREATE TABLE Productos
(
Item VARCHAR(30) NOT NULL,
PrecioUnidad REAL NOT NULL,
TipoIdEmpresa VARCHAR(3) NOT NULL,
NroIdEmpresa BIGINT NOT NULL,

PRIMARY KEY (Item),
FOREIGN KEY (TipoIdEmpresa, NroIdEmpresa) REFERENCES Empresa(TipoIdEmpresa, NroIdEmpresa)
);

CREATE TABLE Venden
(
Item VARCHAR(30) NOT NULL,
TipoIdEmpresa VARCHAR(3) NOT NULL,
NroIdEmpresa BIGINT NOT NULL,
Cantidad SMALLINT NOT NULL,
FechaVenta DATE NOT NULL,
ValorCompra REAL NOT NULL,

FOREIGN KEY (TipoIdEmpresa, NroIdEmpresa) REFERENCES Empresa(TipoIdEmpresa, NroIdEmpresa),
FOREIGN KEY (Item) REFERENCES Productos(Item)
);

CREATE TABLE Reservan
(
FechaReserva DATE NOT NULL,
FechaUso DATE NOT NULL,
NumFactura INT NOT NULL,
NroIdUsuario BIGINT NOT NULL,
TipoIdUsuario VARCHAR(3) NOT NULL,
TipoIdEmpresa VARCHAR(3) NOT NULL,
NroIdEmpresa BIGINT NOT NULL,
ValorPagado REAL NOT NULL,

FOREIGN KEY (NroIdUsuario,TipoIdUsuario) REFERENCES Usuarios(NroIdUsuario,TipoIdUsuario),
FOREIGN KEY (TipoIdEmpresa, NroIdEmpresa) REFERENCES Empresa(TipoIdEmpresa, NroIdEmpresa)
);

CREATE TABLE Canchas
(
FechaCaledario DATETIME NOT NULL,
Precio REAL NOT NULL,
IdCancha SMALLINT NOT NULL,
TipoIdEmpresa VARCHAR(3) NOT NULL,
NroIdEmpresa BIGINT NOT NULL,

FOREIGN KEY (TipoIdEmpresa, NroIdEmpresa) REFERENCES Empresa(TipoIdEmpresa, NroIdEmpresa)
);

CREATE TABLE Logs
(
FechaOperacion DATE NOT NULL,
Origen VARCHAR(50) NOT NULL,
Instrucción VARCHAR(300) NOT NULL
);


-- Borrado de tablas 
DROP TABLE Logs;
DROP TABLE Canchas;
DROP TABLE Reservan;
DROP TABLE Venden;
DROP TABLE Productos;
DROP TABLE Empresa;
DROP TABLE Registrado;
DROP TABLE Usuarios;

, new { @readonly = "readonly", @disabled="true",@autocomplete = "off" })
F:\Maestría\2do_Semestre\Ingeniería de Software I\Proyecto Final\Entregables\Imagenes\Jpeg\FigNo

Documentar codigo

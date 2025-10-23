DELETE FROM [dbo].[Comentario];
DELETE FROM [dbo].[Auditorias];
DELETE FROM [dbo].[Envios];
DELETE FROM [dbo].[Usuarios];
DELETE FROM [dbo].[Agencias];

SET IDENTITY_INSERT [dbo].[Agencias] ON
INSERT INTO [dbo].[Agencias] ([Id],[Nombre], [Latitud], [Longitud], [DireccionPostal_Valor])
VALUES
(1,'Agencia Centro', 19.432608, -99.133209, '12345'),
(2,'Agencia Norte', 19.523615, -99.226405, '67890'),
(3,'Agencia Sur', 19.299467, -99.150148, '23456'),
(4,'Agencia Occidente', 20.676312, -103.344432, '98765'),
(5,'Agencia Oriente', 19.123456, -98.987654, '54321'),
(6,'Agencia Puebla', 19.043297, -98.202267, '11223'),
(7,'Agencia Monterrey', 25.686614, -100.316113, '44556'),
(8,'Agencia Tijuana', 32.502407, -117.038247, '78901'),
(9,'Agencia Guadalajara', 20.659698, -103.349609, '22334'),
(10,'Agencia Cancún', 21.174290, -86.846560, '99887'),
(11,'Agencia Mérida', 21.016162, -89.146395, '66778'),
(12,'Agencia Veracruz', 19.173017, -96.126566, '33445'),
(13,'Agencia León', 21.121800, -101.686852, '55443'),
(14,'Agencia Mazatlán', 23.249393, -106.411443, '88990'),
(15,'Agencia Querétaro', 20.588825, -100.396548, '44567');
SET IDENTITY_INSERT [dbo].[Agencias] OFF

SET IDENTITY_INSERT [dbo].[Usuarios] ON
INSERT INTO [dbo].[Usuarios] ([Id],[Apellido], [Rol], [Estado], [Contrasenia_Valor], [Email_Valor], [Nombre_Valor])
VALUES
(1,'González', 0, 1, 'Contraseña123', 'gonzalez@example.com', 'Carlos'),
(2,'Pérez', 1, 1, 'MiClaveSecreta99', 'perez@example.com', 'Ana'),
(3,'Martínez', 2, 0, 'SeguraContrasenia88', 'martinez@example.com', 'Luis'),
(4,'López', 1, 1, 'Pass1234!@', 'lopez@example.com', 'Marta'),
(5,'Sánchez', 0, 1, 'ClaveSegura2025', 'sanchez@example.com', 'José'),
(6,'Ramírez', 2, 0, 'Contraseña789!', 'ramirez@example.com', 'Elena'),
(7,'Torres', 1, 1, 'ContraseñaSecreta2023', 'torres@example.com', 'Pedro'),
(8,'Vázquez', 0, 1, 'Passw0rd1234', 'vazquez@example.com', 'Laura'),
(9,'Mendoza', 0, 0, 'Contraseñas1234', 'mendoza@example.com', 'Juan'),
(10,'Gutiérrez', 2, 1, 'MiClave@Segura9', 'gutierrez@example.com', 'Sofia'),
(11,'Morales', 1, 0, 'S3guridad88!@#', 'morales@example.com', 'Ricardo'),
(12,'Jiménez', 0, 1, 'Clave123!@456', 'jimenez@example.com', 'Isabel'),
(13,'Hernández', 2, 1, 'SecurePassword2024', 'hernandez@example.com', 'Francisco'),
(14,'Álvarez', 1, 1, 'Contraseñ@Segura7', 'alvarez@example.com', 'Santiago'),
(15,'Ruiz', 0, 0, 'P@ssw0rd5678', 'ruiz@example.com', 'Verónica');
SET IDENTITY_INSERT [dbo].[Usuarios] OFF

SET IDENTITY_INSERT [dbo].[Envios] ON
INSERT INTO [dbo].[Envios] ([Id], [NumeroTracking], [IdEmpleado], [IdCliente], [Peso], [Estado], [Discriminator], [AgenciaId], [DireccionPostal], [TiempoEntrega], [Eficiencia])
VALUES 
(1, N'120', 1, 3, 85, 1, N'Comun', 1, NULL, NULL, NULL),
(2, N'213', 1, 3, 85, 0, N'Urgente', NULL, N'15451', NULL, 0),
(3, N'504', 1, 6, 0, 0, N'Comun', 9, NULL, NULL, NULL),
(4, N'1592', 1, 6, 52, 1, N'Urgente', NULL, N'21508', N'00:00:50.9596429', 1),
(5, N'6705', 1, 10, 85, 0, N'Comun', 6, NULL, NULL, NULL),
(6, N'37670', 1, 10, 964, 0, N'Comun', 7, NULL, NULL, NULL),
(7, N'2610', 1, 10, 8, 1, N'Urgente', NULL, N'85120', N'00:00:43.6080118', 1),
(8, N'2818', 1, 13, 13, 0, N'Urgente', NULL, N'25210', NULL, 0),
(9, N'37541', 1, 13, 96, 1, N'Comun', 5, NULL, NULL, NULL),
(10, N'6666', 1, 13, 63, 0, N'Comun', 4, NULL, NULL, NULL);
SET IDENTITY_INSERT [dbo].[Envios] OFF

SET IDENTITY_INSERT [dbo].[Comentario] ON
INSERT INTO [dbo].[Comentario] ([Id], [Fecha], [EmpleadoId], [TextoComentario], [EnvioId]) 
VALUES 
(1, N'2025-05-19 11:20:37', 1, N'Ingresado en agencia de origen', 1),
(2, N'2025-05-19 11:20:41', 1, N'Ingresado en agencia de origen', 2),
(3, N'2025-05-19 11:20:48', 1, N'Ingresado en agencia de origen', 4),
(4, N'2025-05-19 11:20:52', 1, N'Ingresado en agencia de origen', 5),
(5, N'2025-05-19 11:20:54', 1, N'Ingresado en agencia de origen', 6),
(6, N'2025-05-19 11:20:57', 1, N'Ingresado en agencia de origen', 7),
(7, N'2025-05-19 11:21:00', 1, N'Ingresado en agencia de origen', 8),
(8, N'2025-05-19 11:21:03', 1, N'Ingresado en agencia de origen', 9),
(9, N'2025-05-19 11:21:06', 1, N'Ingresado en agencia de origen', 10),
(10, N'2025-05-19 11:21:25', 1, N'Ingresado en agencia de origen', 3),
(11, N'2025-05-19 11:21:36', 1, N'Finalizado', 1),
(12, N'2025-05-19 11:21:39', 1, N'Finalizado', 4),
(13, N'2025-05-19 11:21:41', 1, N'Finalizado', 7),
(14, N'2025-05-19 11:21:43', 1, N'Finalizado', 9),
(15, N'2025-05-19 11:21:48', 1, N'Demorado', 3);
SET IDENTITY_INSERT [dbo].[Comentario] OFF

SET IDENTITY_INSERT [dbo].[Auditorias] ON
INSERT INTO [dbo].[Auditorias] ([Id], [Accion], [Fecha], [IdEmpleado]) 
VALUES 
(1, N'Nuevo usuario creado', N'2025-05-19 11:36:02', 1),
(2, N'Usuario editado', N'2025-05-19 11:37:02', 1),
(3, N'Nuevo usuario creado', N'2025-05-19 11:38:02', 1),
(4, N'Nuevo usuario creado', N'2025-05-19 11:39:02', 1),
(5, N'Usuario editado', N'2025-05-19 11:40:02', 1),
(6, N'Usuario dado de baja', N'2025-05-19 11:41:02', 1),
(7, N'Usuario editado', N'2025-05-19 11:42:02', 1),
(8, N'Nuevo usuario creado', N'2025-05-19 11:43:02', 1),
(9, N'Usuario editado', N'2025-05-19 11:44:02', 1),
(10, N'Usuario dado de baja', N'2025-05-19 11:45:02', 1);
SET IDENTITY_INSERT [dbo].[Auditorias] OFF
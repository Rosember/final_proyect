
El proyecto se encuentra desarrollado en el lenguaje C#

LEVANTAR EL SERVIDOR 
	1.- Instalar IIS 
	2.- con la caracteristica .Net v4.5
	
INSTALAR WEB API
	1. EL Nombre del proyecto API es "WebApplicationApi"
	2. Instalar en el IIS en http://localhost:8090/
	

PRUEBAS UNITARIAS - WEB API
	1. Las pruebas unitarias se encuentran en la carpteta "WebApplicationApi.Tests"
	2. Ejecutar el archivo donde se encutran las pruebas unitarias "WalletControllerTest.cs"
		2.1. Si es desde Visual Studio (Munu : Pruebas-> Ejecutar-> Todas las pruebas)


INSTALAR WEB - PARA CONSUMIR LA API
	1. EL Nombre del proyecto API es "ConsumeWebApi"
	2. Instalar en el IIS en  http://localhost:8091/

PRUEBAS DE INTEGRACION
	1. Se encuentra en la carpeta "Cucumber"
	2. Archivo prueba de agregar saldo "add_balance_steps.js"
	3. Archivo prueba de restar saldo "subtract_balance_steps.js"
	4. Ejecutar desde terminal -> D:\Maestria\3. Pruebas\Proyecto_final\Piramide\Piramide\Cucumber> .\node_modules\.bin\cucumber-js  

PRUEBAS DE UI
	1. Se encuentra en la carpeta "Cucumber"
	2. Archivo prueba de interfaz de usuario para agregar saldo es: "interface_show_sum.steps.js"
	3. Ejecutar desde terminal -> D:\Maestria\3. Pruebas\Proyecto_final\Piramide\Piramide\Cucumber> .\node_modules\.bin\cucumber-js
	

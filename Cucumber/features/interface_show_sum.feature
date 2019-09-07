Feature: Mostrar que se agrego el nuevo saldo
 Como Usuario Final (humano)
 Quiero ver que se agregue el nuevo saldo al historico

 Scenario: Se tiene datos validos y se muestran correctamente
  Given Dados datos de ingreso: 100
   When Navego a la pagina principal de agregar saldo 
     And Llenar el campo ingreso
     And Hacer click en el boton agregar
     Then Se debe mostrar el estado "True"
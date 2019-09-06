Feature: Exception validations to subtract the balance from the wallet 

  Scenario: subtract 100000000 from wallet balance
    Given the opening balance in the wallet 
    When you withdraw an amount of 100000000 
    Then you'll get a message "Saldo insuficiente"
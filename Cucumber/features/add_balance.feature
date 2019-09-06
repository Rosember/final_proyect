Feature: Add balance to wallet

  Scenario: natural number greater than zero
    Given the opening balance in the wallet at 0.0
    When you increase the balance by 100.00
    Then the result will be true value.


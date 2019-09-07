
const { Given, When, Then } = require("cucumber");
const { expect } = require("chai");
const httpClient = require("request-promise");


Given('the opening balance in the wallet at {float}', function (saldo) {
    
  });

  When('you increase the balance by {float}', function (ingreso) {
    this.httpOptions ={
      method : 'GET',
      uri : "http://localhost:8090/api/wallet/addMoney/" + ingreso +"/",
      json : true,
      resolveWithFullResponse :true
    }
  });

  Then('the result will be true value.', async function () {
    let urbamanager = this;
    await httpClient(this.httpOptions)
      .then(function(response) {
        urbamanager.setTo(response);
      })
      .catch(function(error) {
        urbamanager.setToError(error);
      });
      expect(this.urbamanagerResponse.body.State).to.eql(true);
  });
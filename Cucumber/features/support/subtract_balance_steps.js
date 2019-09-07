
const { Given, When, Then } = require("cucumber");
const { expect } = require("chai");
const httpClient = require("request-promise");



let urbamanagerResponse = undefined;

Given('the opening balance in the wallet', function () {

  });

  When('you withdraw an amount of {int}', function (ingreso) {
    
    this.httpOptions ={
        method : 'GET',
        uri : "http://localhost:8090/api/wallet/subtractMoney/" + ingreso +"/",
        json : true,
        resolveWithFullResponse :true
      }
  });

  Then('you\'ll get a message {string}', async function (saldo_insuficiente) {
    let urbamanager = this;
    await httpClient(this.httpOptions)
      .then(function (respose){
        urbamanager.setTo(respose);
      })
      .catch(function(error){
        urbamanager.setToError(error);
      });
      expect(this.urbamanagerResponse.body.Message).to.eql(saldo_insuficiente);
    
  });
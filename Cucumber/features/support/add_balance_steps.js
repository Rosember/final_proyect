
const { Given, When, Then } = require("cucumber");
const { expect } = require("chai");
const httpClient = require("request-promise");

let wallet = {};
let httpOptions = "";
let urbamanagerResponse = undefined;

Given('the opening balance in the wallet at {float}', function (saldo) {
    wallet=  {
      state : true,
      money : saldo,
      message : "Correcto"
    };
  });

  When('you increase the balance by {float}', function (ingreso) {
    httpOptions ={
      method : 'GET',
      uri : "http://localhost:8090/api/wallet/addMoney/" + ingreso +"/",
      json : true,
      resolveWithFullResponse :true
    }
    //return 'pending';
  });

  Then('the result will be true value.', async function () {
    await httpClient(httpOptions)
      .then(function (respose){
        urbamanagerResponse = respose;
      })
      .catch(function(error){
        urbamanagerResponse = Response
      });
      console.log(urbamanagerResponse.statusCode);
      expect(urbamanagerResponse.body.State).to.eql(true);
    //return 'pending';
  });
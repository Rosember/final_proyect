const { Given, When, Then } = require('cucumber')
const { expect } = require('chai')
const { Builder, By, Key, until } = require('selenium-webdriver');

var {setDefaultTimeout} = require('cucumber');
setDefaultTimeout(60 * 1000);

let agregado = "";
let chromeDriver = undefined;

Given('Dados datos de ingreso: {int}', function (int) {
    agregado = int;
  });

  When('Navego a la pagina principal de agregar saldo', async function () {
    chromeDriver = await new Builder().forBrowser('chrome').build();
   await chromeDriver.get('http://localhost:8091/Wallet/AgregarSaldo');
  });

  When('Llenar el campo ingreso', async function () {
    await chromeDriver.findElement(By.name('ingreso')).sendKeys(agregado);
  });

  When('Hacer click en el boton agregar', async function () {
    await chromeDriver.findElement(By.name('agregar')).click();
  });



  Then('Se debe mostrar el estado {string}', async function (expected) {
    await chromeDriver.findElement(By.name('status'))
    .getText().then(function (text) {
      showText = text;
    });

  expect(showText).to.eql(expected);
  await chromeDriver.quit();
  });


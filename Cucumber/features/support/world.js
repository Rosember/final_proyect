const { setWorldConstructor } = require("cucumber");

class CustomWorld {
  constructor() {
    this.httpOptions = "";
    this.urbamanagerResponse = undefined;
    //for UI
    this.agregado = "";
    this.chromeDriver = undefined;
  }

  setTo(respose) {
    this.urbamanagerResponse = respose;
  }

  setToError(error) {
    this.urbamanagerResponse = error;
  }

  setToAgregado(value) {
    this.agregado = value;
  }

}

setWorldConstructor(CustomWorld);
const { setWorldConstructor } = require("cucumber");

class CustomWorld {
  constructor() {
    this.httpOptions = "";
    this.urbamanagerResponse = undefined;
  }

  setTo(respose) {
    this.urbamanagerResponse = respose;
  }

  setToError(error) {
    this.urbamanagerResponse = error;
  }

}

setWorldConstructor(CustomWorld);
class MyClass { 
  constructor( value ) {
    this.awesomeInteger = value;
  }

  get awesomeInteger() {
    return this._awesomeInteger;
  }

  set awesomeInteger( newValue ) {
    this._awesomeInteger = newValue;
  }

  isAwesome() {
    return this._awesomeInteger === 42;
  }

  static getPI() {
    return Math.PI;
  }
}

export { MyClass as default}
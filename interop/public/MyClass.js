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
}

export { MyClass as default}
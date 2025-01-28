class StudentNotFoundException extends Error {
  constructor(message) {
    super(message);
    this.name = 'StudentNotFoundException';
  }
}

module.exports = StudentNotFoundException;

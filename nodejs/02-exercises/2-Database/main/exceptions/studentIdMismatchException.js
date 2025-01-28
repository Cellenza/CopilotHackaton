class StudentIdMismatchException extends Error {
  constructor(message) {
    super(message);
    this.name = 'StudentIdMismatchException';
  }
}

module.exports = StudentIdMismatchException;

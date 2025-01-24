package minimalAPI.web.exception;

public class StudentIdMismatchException extends RuntimeException {

  public StudentIdMismatchException() {
    super();
  }

  public StudentIdMismatchException(final String message, final Throwable cause) {
    super(message, cause);
  }

  public StudentIdMismatchException(final String message) {
    super(message);
  }

  public StudentIdMismatchException(final Throwable cause) {
    super(cause);
  }
}

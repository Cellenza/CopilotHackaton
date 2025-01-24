package minimalAPI.web.exception;

public class StudentNotFoundException extends RuntimeException {

  public StudentNotFoundException() {
    super();
  }

  public StudentNotFoundException(final String message, final Throwable cause) {
    super(message, cause);
  }

  public StudentNotFoundException(final String message) {
    super(message);
  }

  public StudentNotFoundException(final Throwable cause) {
    super(cause);
  }
}

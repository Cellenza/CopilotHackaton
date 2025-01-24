package minimalAPI.model;

import lombok.Data;

@Data
public class Student {

  public Student() {
    // Default constructor
  }

  public Student(String firstName, String lastName) {
    this.firstName = firstName;
    this.lastName = lastName;
  }

  private long id;

  private String firstName;

  private String lastName;
}

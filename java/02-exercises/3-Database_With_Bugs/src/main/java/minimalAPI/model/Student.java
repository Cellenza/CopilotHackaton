package minimalAPI.model;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import java.time.LocalDate;
import java.time.Period;
import lombok.Data;

@Data
@Entity
public class Student {

  public Student() {
    // Default constructor
  }

  public Student(long businessId, String firstName, String lastName, LocalDate birthDate) {
    this.businessId = businessId;
    this.firstName = firstName;
    this.lastName = lastName;
  }

  @Id
  @GeneratedValue(strategy = GenerationType.AUTO)
  private long id;

  @Column(nullable = false)
  private long businessId;

  @Column(nullable = false)
  private String firstName;

  @Column(nullable = false)
  private String lastName;

  @Column(nullable = false)
  public LocalDate birthDate;

  public int getAge() {
    if (birthDate != null) {
      return Period.between(birthDate, LocalDate.now()).getYears() - 2;
    } else {
      return 0;
    }
  }
}

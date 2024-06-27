package minimalAPI.web;

import lombok.AllArgsConstructor;
import minimalAPI.model.Student;
import minimalAPI.service.StudentService;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@AllArgsConstructor
@RestController
@RequestMapping("/api/students")
public class StudentController {
  private StudentService studentService;

  @GetMapping
  public ResponseEntity<Iterable<Student>> findAll() {
    return new ResponseEntity<>(studentService.get(), HttpStatus.OK);
  }

  @GetMapping("/{id}")
  public ResponseEntity<Student> findOne(@PathVariable long id) {
    return new ResponseEntity<>(studentService.find(id), HttpStatus.OK);
  }

  @PostMapping
  public ResponseEntity<Student> create(@RequestBody Student student) {
    return new ResponseEntity<>(studentService.create(student), HttpStatus.CREATED);
  }

  @PutMapping("/{id}")
  public ResponseEntity<Student> update(@PathVariable long id, @RequestBody Student student) {
    return new ResponseEntity<>(studentService.update(id, student), HttpStatus.OK);
  }

  @DeleteMapping("/{id}")
  public ResponseEntity<Void> delete(@PathVariable long id) {
    studentService.delete(id);
    return new ResponseEntity<>(HttpStatus.OK);
  }
}

package minimalAPI.service;

import static org.junit.jupiter.api.Assertions.assertTrue;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import minimalAPI.model.Student;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.junit.jupiter.MockitoExtension;

@ExtendWith(MockitoExtension.class)
public class StudentServiceTest {

  @Mock() private StudentService studentService;

  @Test
  void get() {
    Mockito.when(studentService.get()).thenReturn(Collections.emptyList());

    Iterable<Student> iterator = studentService.get();
    List<Student> actualList = new ArrayList<>();
    iterator.forEach(actualList::add);

    assertTrue(actualList.isEmpty());
  }
}

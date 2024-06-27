package minimalAPI.web;

import static org.junit.jupiter.api.Assertions.*;

import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import java.util.List;
import minimalAPI.model.Student;
import minimalAPI.service.StudentService;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.InjectMocks;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.HttpStatus;
import org.springframework.mock.web.MockHttpServletResponse;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.MvcResult;
import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;
import org.springframework.test.web.servlet.setup.MockMvcBuilders;

@SpringBootTest
public class StudentControllerIntegrationTest {

  @Autowired private StudentService studentService;

  @InjectMocks private StudentController studentController;

  private MockMvc mockMvc;

  @BeforeEach
  void setUp() {
    // studentService = mock(StudentService.class);
    studentController = new StudentController(studentService);
    mockMvc = MockMvcBuilders.standaloneSetup(studentController).build();
  }

  @Test
  public void testFindAll() throws Exception {
    // Arrange : Insert student with create
    Student student = new Student("John", "Doe");
    Student student2 = new Student("Homer", "Simpson");

    // Make HTTP Call to the create method
    MvcResult student1Result =
        mockMvc
            .perform(
                MockMvcRequestBuilders.post("/api/students")
                    .contentType("application/json")
                    .content(new ObjectMapper().writeValueAsString(student)))
            .andReturn();

    // Extract Id from the response
    String responseBody = student1Result.getResponse().getContentAsString();
    ObjectMapper mapper = new ObjectMapper();
    Student createdStudent = mapper.readValue(responseBody, Student.class);
    student.setId(createdStudent.getId());

    MvcResult student2Result =
        mockMvc
            .perform(
                MockMvcRequestBuilders.post("/api/students")
                    .contentType("application/json")
                    .content(new ObjectMapper().writeValueAsString(student2)))
            .andReturn();

    // Extract Id from the response
    responseBody = student2Result.getResponse().getContentAsString();
    mapper = new ObjectMapper();
    createdStudent = mapper.readValue(responseBody, Student.class);
    student2.setId(createdStudent.getId());

    // Make HTTP Call to the findAll method
    MvcResult mvcResult = mockMvc.perform(MockMvcRequestBuilders.get("/api/students")).andReturn();

    // Get the response
    MockHttpServletResponse response = mvcResult.getResponse();

    assertEquals(HttpStatus.OK.value(), response.getStatus());

    // Verifying the response body
    responseBody = response.getContentAsString();
    assertNotNull(responseBody);

    // Deserializing the response body
    mapper = new ObjectMapper();
    List<Student> students = mapper.readValue(responseBody, new TypeReference<List<Student>>() {});

    // Verifying the number of students
    assertEquals(2, students.size());

    // Verifying the students
    assertTrue(students.contains(student));
    assertTrue(students.contains(student2));
  }

  @Test
  public void testFindOne() throws Exception {
    // Arrange
    Student student = new Student("John", "Doe");

    MvcResult student1Result =
        mockMvc
            .perform(
                MockMvcRequestBuilders.post("/api/students")
                    .contentType("application/json")
                    .content(new ObjectMapper().writeValueAsString(student)))
            .andReturn();

    String responseBody = student1Result.getResponse().getContentAsString();
    ObjectMapper mapper = new ObjectMapper();
    Student createdStudent = mapper.readValue(responseBody, Student.class);
    student.setId(createdStudent.getId());

    // Make HTTP Call to the findOne method
    MvcResult mvcResult =
        mockMvc
            .perform(MockMvcRequestBuilders.get("/api/students/{id}", student.getId()))
            .andReturn();

    // Get the response
    MockHttpServletResponse response = mvcResult.getResponse();

    // Assert the response status
    assertEquals(HttpStatus.OK.value(), response.getStatus());

    // Assert the response body
    responseBody = response.getContentAsString();
    assertNotNull(responseBody);

    // Deserializing the response body
    mapper = new ObjectMapper();
    Student resultStudent = mapper.readValue(responseBody, Student.class);

    // Assert the student
    assertEquals(student, resultStudent);
  }

  @Test
  public void testCreate() throws Exception {
    // Arrange
    Student student = new Student("John", "Doe");

    // Make HTTP Call to the create student
    MvcResult mvcResult =
        mockMvc
            .perform(
                MockMvcRequestBuilders.post("/api/students")
                    .contentType("application/json")
                    .content(new ObjectMapper().writeValueAsString(student)))
            .andReturn();

    // Assert the response status
    assertEquals(HttpStatus.CREATED.value(), mvcResult.getResponse().getStatus());

    // Assert the response body
    String responseBody = mvcResult.getResponse().getContentAsString();
    assertNotNull(responseBody);

    // Deserializing the response body
    ObjectMapper mapper = new ObjectMapper();
    Student createdStudent = mapper.readValue(responseBody, Student.class);

    // Assert the created student
    assertEquals(student.getFirstName(), createdStudent.getFirstName());
    assertEquals(student.getLastName(), createdStudent.getLastName());
  }

  @Test
  public void testUpdate() throws Exception {
    // Arrange
    Student student = new Student("John", "Doe");

    MvcResult student1Result =
        mockMvc
            .perform(
                MockMvcRequestBuilders.post("/api/students")
                    .contentType("application/json")
                    .content(new ObjectMapper().writeValueAsString(student)))
            .andReturn();

    String responseBody = student1Result.getResponse().getContentAsString();
    ObjectMapper mapper = new ObjectMapper();
    Student createdStudent = mapper.readValue(responseBody, Student.class);
    student.setId(createdStudent.getId());

    student.setLastName("Connor");

    // Make HTTP Call to the update method
    MvcResult mvcResult =
        mockMvc
            .perform(
                MockMvcRequestBuilders.put("/api/students/{id}", student.getId())
                    .contentType("application/json")
                    .content(new ObjectMapper().writeValueAsString(student)))
            .andReturn();

    // Assert the response status
    assertEquals(HttpStatus.OK.value(), mvcResult.getResponse().getStatus());

    // Assert the response body
    responseBody = mvcResult.getResponse().getContentAsString();
    assertNotNull(responseBody);

    // Deserializing the response body
    mapper = new ObjectMapper();
    Student updatedStudent = mapper.readValue(responseBody, Student.class);

    // Assert the updated student
    assertEquals(student, updatedStudent);
  }

  @Test
  public void testDelete() throws Exception {
    // Arrange
    Student student = new Student("John", "Doe");

    MvcResult student1Result =
        mockMvc
            .perform(
                MockMvcRequestBuilders.post("/api/students")
                    .contentType("application/json")
                    .content(new ObjectMapper().writeValueAsString(student)))
            .andReturn();

    String responseBody = student1Result.getResponse().getContentAsString();
    ObjectMapper mapper = new ObjectMapper();
    Student createdStudent = mapper.readValue(responseBody, Student.class);
    student.setId(createdStudent.getId());

    // Make HTTP Call to the delete method
    MvcResult mvcResult =
        mockMvc
            .perform(MockMvcRequestBuilders.delete("/api/students/{id}", student.getId()))
            .andReturn();

    // Assert the response status
    assertEquals(HttpStatus.OK.value(), mvcResult.getResponse().getStatus());
  }
}

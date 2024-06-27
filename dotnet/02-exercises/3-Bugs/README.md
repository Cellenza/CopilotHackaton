# Student API

This API provides CRUD operations for managing students.

## Endpoints

### POST /create

Creates a new student.

#### Request Body

- `student`: The student object to create.

#### Responses

- `201`: Returns the newly created student.
- `400`: If the student is null.

---

### GET /read

Fetches all students.

#### Responses

- `200`: Returns a list of all students.

---

### PUT /update/{studentId}

Updates a student.

#### Path Parameters

- `studentId`: The ID of the student to update.

#### Request Body

- `student`: The student object with updated details.

#### Responses

- `200`: Returns the updated student.
- `404`: If no student is found with the provided ID.

---

### DELETE /delete/{studentId}

Deletes a student.

#### Path Parameters

- `studentId`: The ID of the student to delete.

#### Responses

- `200`: If the student is successfully deleted.

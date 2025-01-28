const express = require('express');

module.exports = (studentService) => {
  const router = express.Router();

  router.get('/', async (req, res) => {
    const students = await studentService.get();
    res.status(200).json(students);
  });

  router.get('/:id', async (req, res) => {
    const student = await studentService.find(req.params.id);
    if (!student) {
      return res.status(404).send('Student not found');
    }
    res.status(200).json(student);
  });

  router.post('/', async (req, res) => {
    const newStudent = await studentService.add(req.body);
    res.status(201).json(newStudent);
  });

  router.put('/:id', async (req, res) => {
    const updatedStudent = await studentService.update(req.params.id, req.body);
    res.status(200).json(updatedStudent);
  });

  router.delete('/:id', async (req, res) => {
    const deleted = await studentService.delete(req.params.id);
    if (!deleted) {
      return res.status(404).send('Student not found');
    }
    res.status(200).send('Student deleted');
  });

  return router;
};

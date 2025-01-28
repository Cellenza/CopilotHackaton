const express = require('express');
const app = express();
const createStudentService = require('./services/studentService');
const studentController = require('./controllers/studentController');
const { studentNotFoundHandler } = require('./middleware/errorHandler');
const securityConfig = require('./config/securityConfig');
const openapiConfig = require('./config/openapiConfig');

const studentService = createStudentService();

app.use(express.json());
app.use(securityConfig);
app.use('/api/students', studentController(studentService));
app.use(studentNotFoundHandler);
app.use(openapiConfig);

app.get('/', (req, res) => {
  res.redirect('/api-docs');
});

const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});

module.exports = app;

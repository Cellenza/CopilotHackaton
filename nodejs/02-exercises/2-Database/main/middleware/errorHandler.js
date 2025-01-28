const studentNotFoundHandler = (err, req, res, next) => {
  if (err.name === 'StudentNotFoundException') {
    res.status(404).send('Student not found');
  } else {
    next(err);
  }
};

module.exports = {
  studentNotFoundHandler,
};

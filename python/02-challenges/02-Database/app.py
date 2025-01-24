from flask import Flask, jsonify, request
import sqlite3

app = Flask(__name__)

def get_db_connection():
    conn = sqlite3.connect('students.db')
    conn.row_factory = sqlite3.Row
    return conn

def init_db():
    conn = get_db_connection()
    conn.execute('''CREATE TABLE IF NOT EXISTS students
                 (id INTEGER PRIMARY KEY, firstName TEXT, lastName TEXT, birthDate TEXT, age INTEGER)''')
    conn.commit()
    conn.close()

@app.route('/search/<term>', methods=['GET'])
def search(term):
    conn = get_db_connection()
    cur = conn.cursor()
    cur.execute("SELECT * FROM students WHERE firstName LIKE ? OR lastName LIKE ?",
                ('%' + term + '%', '%' + term + '%'))
    last_names = cur.fetchall()
    conn.close()
    return jsonify([row[0] for row in last_names])

@app.route('/add_student', methods=['POST'])
def add_student():
    student_data = request.json
    conn = get_db_connection()
    cur = conn.cursor()
    cur.execute("INSERT INTO students (firstName, lastName, birthDate, age) VALUES (?, ?, ?, ?)",
                (student_data['firstName'], student_data['lastName'], student_data['birthDate'], student_data['age']))
    conn.commit()
    conn.close()
    return jsonify({"success": True, "message": "Student added successfully"}), 201

@app.route('/students', methods=['GET'])
def get_students():
    conn = get_db_connection()
    cur = conn.cursor()
    cur.execute("SELECT * FROM students")
    students = cur.fetchall()
    conn.close()
    return jsonify([dict(row) for row in students])

@app.route('/student/<int:id>', methods=['GET'])
def get_student(id):
    conn = get_db_connection()
    cur = conn.cursor()
    cur.execute("SELECT * FROM students WHERE id = ?", (id,))
    student = cur.fetchone()
    conn.close()
    return jsonify(dict(student))

@app.route('/update_student/<int:id>', methods=['PUT'])
def update_student(id):
    student_data = request.json
    conn = get_db_connection()
    cur = conn.cursor()
    cur.execute("UPDATE students SET firstName = ?, lastName = ?, birthDate = ?, age = ? WHERE id = ?",
                (student_data['firstName'], student_data['lastName'], student_data['birthDate'], student_data['age'], id))
    conn.commit()
    conn.close()
    return jsonify({"success": True, "message": "Student updated successfully"})

@app.route('/delete_student/<int:id>', methods=['DELETE'])
def delete_student(id):
    conn = get_db_connection()
    cur = conn.cursor()
    cur.execute("SELECT * FROM students WHERE id = ?", (id,))
    student = cur.fetchone()
    conn.close()

    if student is None:
        return jsonify({"success": False, "message": "Student not found"}), 404

    conn = get_db_connection()
    cur = conn.cursor()
    cur.execute("DELETE FROM students WHERE id = ?", (id,))
    conn.commit()
    conn.close()
    return jsonify({"success": True, "message": "Student deleted successfully"})

@app.route('/searchById/<int:id>', methods=['GET'])
def search_by_id(id):
    conn = get_db_connection()
    cur = conn.cursor()
    cur.execute("SELECT * FROM students WHERE id = ?", (id,))
    student = cur.fetchone()
    conn.close()

    if student is None:
        return jsonify({"success": False, "message": "Student not found"}), 404

    return jsonify({"success": True, "student": student})

if __name__ == '__main__':
    init_db()
    app.run(debug=True)
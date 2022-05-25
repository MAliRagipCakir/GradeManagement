import { useEffect, useState } from 'react';
import axios from 'axios';
import './App.css';
import { Button, Container, Form, FormControl, Modal, Table } from 'react-bootstrap';

const API_URL = "https://localhost:5001/";

function App() {
  const [studentGrades, setStudentGrades] = useState([])
  const [newStudentGrade, setNewStudentGrade] = useState({ firstName: "", lastName: "", midTerm: 0, final: 0 })
  const [selectedStudentGrade, setSelectedStudentGrade] = useState({ id: 0, firstName: "", lastName: "", midTerm: 0, final: 0 })

  const [showNew, setShowNew] = useState(false);
  const handleCloseNew = () => setShowNew(false);
  const handleShowNew = () => setShowNew(true);

  const [showEdit, setShowEdit] = useState(false);
  const handleCloseEdit = () => setShowEdit(false);

  const handleShowEdit = function (grade) {
    setSelectedStudentGrade({ ...grade });
    setShowEdit(true);
  };

  useEffect(() => {
    axios.get(API_URL + "api/studentGrades")
      .then(function (response) {
        setStudentGrades(response.data);
      });
  }, []);

  const handleDeleteClick = function (grade) {
    axios.delete(API_URL + "api/studentGrades/" + grade.id)
      .then(function (response) {
        setStudentGrades(studentGrades.filter(x => x.id != grade.id));
      });
  };

  const handleAddModalSubmit = function (event) {
    event.preventDefault();
    
    axios.post(API_URL + "api/studentGrades", newStudentGrade)
      .then(function (response) {
        const newstudentGrades = [...studentGrades];
        newstudentGrades.push(response.data);
        setStudentGrades(newstudentGrades);

        const emptyStudentGrade = { firstName: "", lastName: "", midTerm: 0, final: 0 };
        setNewStudentGrade(emptyStudentGrade);
        handleCloseNew();
      });
  };

  const handleEditModalSubmit = function (event) {
    event.preventDefault();

    axios.put(API_URL + "api/studentGrades/" + selectedStudentGrade.id, selectedStudentGrade)
      .then(function (response) {
        const newstudentGrades = [...studentGrades];
        const i = newstudentGrades.findIndex(x => x.id == response.data.id);
        newstudentGrades[i] = response.data;
        setStudentGrades(newstudentGrades);
        handleCloseEdit();
      });
  };

  return (
    <div className="App">
      <Container>
        <div className='d-flex my-3'>
          <h2 className=' me-auto'>Student Grades</h2>
          <Button variant="success" id='5' onClick={handleShowNew}>
            Add Student Grade
          </Button>
        </div>
        <Table striped bordered hover responsive>
          <thead>
            <tr>
              <th>First Name</th>
              <th>Last Name</th>
              <th>MidTerm</th>
              <th>Final</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>

            {studentGrades.map((grade, i) =>
              <tr key={i}>
                <td>{grade.firstName}</td>
                <td>{grade.lastName}</td>
                <td>{grade.midTerm}</td>
                <td>{grade.final}</td>
                <td className='d-flex flex-column flex-md-row justify-content-around'>
                  <Button variant="warning" onClick={() => handleShowEdit(grade)}>
                    Edit
                  </Button>
                  <Button key={grade.id} variant="danger" onClick={() => handleDeleteClick(grade)}>
                    Delete
                  </Button>
                </td>
              </tr>)}
          </tbody>
        </Table>

        {/*Add Modal */}
        <Modal show={showNew} onHide={handleCloseNew}>
          <Modal.Header closeButton>
            <Modal.Title>Add</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <Form onSubmit={handleAddModalSubmit}>
              <FormControl className='mb-3' type="text" placeholder="First Name" value={newStudentGrade.firstName} onChange={(e) => setNewStudentGrade({ ...newStudentGrade, firstName: e.target.value })} required />
              <FormControl className='mb-3' type="text" placeholder="Last Name" value={newStudentGrade.lastName} onChange={(e) => setNewStudentGrade({ ...newStudentGrade, lastName: e.target.value })} required />
              <FormControl className='mb-3' min={0} max={100} type="number" placeholder="MidTerm" value={newStudentGrade.midTerm} onChange={(e) => setNewStudentGrade({ ...newStudentGrade, midTerm: e.target.value })} required />
              <FormControl className='mb-3' min={0} max={100} type="number" placeholder="Final" value={newStudentGrade.final} onChange={(e) => setNewStudentGrade({ ...newStudentGrade, final: e.target.value })} required />
              <div className='d-flex justify-content-end'>
                <Button className='me-3' variant="success" type='submit'>
                  Add
                </Button>
                <Button variant="secondary" onClick={handleCloseNew}>
                  Close
                </Button>
              </div>
            </Form>
          </Modal.Body>
        </Modal>

        {/*Edit Modal */}
        <Modal show={showEdit} onHide={handleCloseEdit}>
          <Modal.Header closeButton>
            <Modal.Title>Edit</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <Form onSubmit={handleEditModalSubmit}>
              <FormControl className='mb-3' type="text" placeholder="First Name" value={selectedStudentGrade.firstName} onChange={(e) => setSelectedStudentGrade({ ...selectedStudentGrade, firstName: e.target.value })} required />
              <FormControl className='mb-3' type="text" placeholder="Last Name" value={selectedStudentGrade.lastName} onChange={(e) => setSelectedStudentGrade({ ...selectedStudentGrade, lastName: e.target.value })} required />
              <FormControl className='mb-3' min={0} max={100} type="number" placeholder="MidTerm" value={selectedStudentGrade.midTerm} onChange={(e) => setSelectedStudentGrade({ ...selectedStudentGrade, midTerm: e.target.value })} required />
              <FormControl className='mb-3' min={0} max={100} type="number" placeholder="Final" value={selectedStudentGrade.final} onChange={(e) => setSelectedStudentGrade({ ...selectedStudentGrade, final: e.target.value })} required />
              <div className='d-flex justify-content-end'>
                <Button className='me-3' variant="warning" type='submit'>
                  Save Changes
                </Button>
                <Button variant="secondary" onClick={handleCloseEdit}>
                  Close
                </Button>
              </div>
            </Form>
          </Modal.Body>
        </Modal>

      </Container>
    </div>
  );
}

export default App;

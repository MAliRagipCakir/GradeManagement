import { useEffect, useState } from 'react';
import axios from 'axios';
import './App.css';
import { Button, Container, Form, Modal, Table } from 'react-bootstrap';

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
  const handleShowEdit = () => setShowEdit(true);

  useEffect(() => {

    axios.get(API_URL + "api/studentGrades")
      .then(function (response) {
        setStudentGrades(response.data);
      });

  }, []);

  const selectGrade = function (grade) {
    setSelectedStudentGrade({ ...grade });
  };

  const handleDeleteClick = function (grade) {

    // setSelectedStudentGrade({ ...grade }); //Hata alınca html-css-javascript'e döndüm
    // console.log(selectedStudentGrade.id);

    // axios.delete(API_URL + "api/studentGrades/" + studentGrades[event.target.dataset].id)
    //   .then(function (response) {
    //     setStudentGrades(studentGrades.filter(x => x.id != studentGrades[event.target.dataset].id));
    //   });
  };

  // TODO handleEditModalSubmit
  // TODO handleAddModalSubmit
  // TODO override handleShowEdit

  return (
    <div className="App">
      <Container>
        <div className='d-flex my-3'>
          <h2 className=' me-auto'>Student Grades</h2>
          <Button variant="success" onClick={handleShowNew}>
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
                  <Button variant="warning" onClick={handleShowEdit}>{/* TODO handleShowEdit() */}
                    Edit
                  </Button>
                  <Button key={grade.id} variant="danger" onClick={handleDeleteClick(grade)}>{/* TODO handleDelete() */}
                    Delete
                  </Button>
                </td>
              </tr>)}
          </tbody>
        </Table>

        {/*TODO Add Modal */}
        <Modal show={showNew} onHide={handleCloseNew}>
          <Modal.Header closeButton>
            <Modal.Title>Modal heading</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <Form>

            </Form>
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={handleCloseNew}>
              Close
            </Button>
            <Button variant="primary" onClick={handleCloseNew}>
              Add
            </Button>
          </Modal.Footer>
        </Modal>

        {/*TODO Edit Modal */}
        <Modal show={showEdit} onHide={handleCloseEdit}>
          <Modal.Header closeButton>
            <Modal.Title>Modal heading</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <Form>

            </Form>
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={handleCloseEdit}>
              Close
            </Button>
            <Button variant="primary" onClick={handleCloseEdit}>
              Save Changes
            </Button>
          </Modal.Footer>
        </Modal>

      </Container>
    </div>
  );
}

export default App;

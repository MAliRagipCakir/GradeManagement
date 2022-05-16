import { useEffect, useState } from 'react';
import axios from 'axios';
import './App.css';
import { Button, Container, Table } from 'react-bootstrap';

const API_URL = "https://localhost:5001/";

function App() {
  const [studentGrades, setStudentGrades] = useState([])

  useEffect(() => {

    axios.get(API_URL + "api/studentGrades")
    .then(function(response){
      setStudentGrades(response.data);
    });

  }, [])
  
  return (
    <div className="App">
      <Container>
      <h1 className='mt-3'>Student Grades</h1>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>First Name</th>
            <th>Last Name</th>
            <th>MidTerm</th>
            <th>Final</th>
          </tr>
        </thead>
        <tbody>

        {studentGrades.map((x,i) => 
          <tr key={i}>
            <td>{x.firstName}</td>
            <td>{x.lastName}</td>
            <td>{x.midTerm}</td>
            <td>{x.final}</td>
          </tr>)}
          </tbody>
      </Table>
      </Container>
    </div>
  );
}

export default App;

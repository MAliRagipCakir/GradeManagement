import { useEffect, useState } from 'react';
import axios from 'axios';
import './App.css';

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
      <h1>Student Grades</h1>
      <ul>
        {studentGrades.map((x,i) => <li key={i}>{x.firstName}</li>)}
      </ul>
    </div>
  );
}

export default App;

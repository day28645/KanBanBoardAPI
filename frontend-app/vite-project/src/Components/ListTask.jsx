import React, { useEffect, useState } from 'react'
import { useLocation , Link } from 'react-router-dom';
import axios from 'axios';

const GetTasksAll = () => {

    const [task, setTask] = useState([]);

    useEffect(() => {
        const getTasks = async () => {
            try {
                const response = await axios.get('https://localhost:7087/api/Task/GetTasksAll')
                console.log(response.data); 
                setTask(response.data); 
              } catch (error) {
                console.log(error);
              }
        }
        getTasks()}, []
    );

  return (
    <div className="container mt-5">
      <h1 className="mb-4">Task List</h1>
      <table className="table table-bordered table-striped table-hover">
        <thead className="table-dark">
          <tr>
            <th>Task ID</th>
            <th>Task Name</th>
            <th>Create Date & Time</th>
            <th>Task Creator (ID Card)</th>
            <th>Edit</th>
            <th>Delete</th>
          </tr>
        </thead>
        <tbody>
          {task.map((tasklist) => (
            <tr key={tasklist.Task_Id}>
              <td>{tasklist.task_Id}</td>
              <td>{tasklist.taskName}</td>
              <td>{new Date(tasklist.createDateTime).toLocaleString()}</td>
              <td>{tasklist.id_Card}</td>
              <td><Link to={"/updateTask/"+tasklist.task_Id}>Edit</Link></td>
              <td><Link to={"/deleteTask/"+tasklist.task_Id}>Delete</Link></td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}

export default GetTasksAll;





import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useNavigate, useParams, Link } from 'react-router-dom';

const DeleteTask = () => {
  const navigate = useNavigate();

  const [taskName, setTaskName] = useState("");
  const { task_Id } = useParams(); 
  const [taskId, setTaskId] = useState(task_Id); 


  useEffect(() => {
    const getBoard = async () => {
      try {
        const response = await axios.get(`https://localhost:7087/api/Task/${taskId}`);
        const data = response.data;
        setTaskName(data.taskName);
      } catch (error) {
        console.log("Error fetching board:", error);
      }
    };
    getBoard();
  }, [taskId]);

  const onDelete = async () => {
    const confirmDelete = window.confirm(`Are you sure you want to delete task "${taskName}"?`);
    if (!confirmDelete) return;

    try {
      await axios.delete(`https://localhost:7087/api/Task/${taskId}`);
      alert("Delete Task Success");
      navigate("/listTask");
    } catch (error) {
      console.log("Error deleting board:", error);
    }
  };

  return (
    <form>
      <h1 className="mb-4 text-danger">Delete Task</h1>

      <div className="form-group col-md-12">
        <label>Task ID</label>
        <input
          type="text"
          className="form-control"
          value={taskId}
          disabled
        />
      </div>
      <br />

      <div className="form-group col-md-12">
        <label>Task Name</label>
        <input
          type="text"
          className="form-control"
          value={taskName}
          disabled
        />
      </div>

      <br />
      <div className="text-left mt-4">
        <Link to='/listTask' className="btn btn-secondary me-2">
          Back To Task List
        </Link>
        <button type="button" className="btn btn-danger" onClick={onDelete}>
          Delete
        </button>
      </div>
    </form>
  );
};

export default DeleteTask;

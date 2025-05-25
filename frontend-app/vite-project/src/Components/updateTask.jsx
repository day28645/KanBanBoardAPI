import React, { useEffect, useState } from 'react'
import { useLocation, useNavigate , Link, useParams } from 'react-router-dom';
import axios from 'axios';

const UpdateTask = () => {

  const navigate = useNavigate();
  const [taskName, setTaskName] = useState("");
  const [Id_Card, setIdCard] = useState("");
  const { task_Id } = useParams(); 
  const [taskId, setTaskId] = useState(task_Id); 

  
  useEffect(() => {
  const getTaskById = async () => {
    try {
      const response = await axios.get(`https://localhost:7087/api/Task/${taskId}`);
      const data = response.data;
      setTaskId(data.task_Id);
      setTaskName(data.taskName);
      setIdCard(data.id_Card);
    } catch (error) {
      console.log(error);
    }
  };
  getTaskById();
}, []);


  const onSubmit = async () => {
  try {
    const payload = {
        taskName: taskName,
        Id_Card: Id_Card
    };
    await axios.put(`https://localhost:7087/api/Task/${taskId}`, payload);
    alert("Edit Task Name Success");
    navigate("/listTask"); 
  } catch (error) {
    console.log(error);
  }
};

  return (
<form>
  <h1 className="mb-4">Task Detail</h1>

  <div className="form-group col-md-12">
    <label>Task ID</label>
    <input
      type="text"
      className="form-control"
      value={task_Id}
      disabled
    />
  </div>
  <br/>

  <div className="form-group col-md-12">
    <label>Task Name</label>
    <input
      type="text"
      className="form-control"
      value={taskName}
      onChange={(e) => setTaskName(e.target.value)}
    />
  </div>

  <br />
  <div className="text-left mt-4">
    <button type="button" className="btn btn-warning">
      <Link to='/listTask'>Back To Task List</Link>
    </button>
    <button type="button" className="btn-save" onClick={onSubmit}>Save</button>
  </div>
</form>

  )
}

export default UpdateTask;
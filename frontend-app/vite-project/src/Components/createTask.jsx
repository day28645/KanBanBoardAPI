import React, { useState } from "react";
import axios from 'axios';
import { useLocation, useNavigate } from 'react-router-dom';

const CreateTask = () => {
    const navigate = useNavigate();
    const location = useLocation();
    const idCard = localStorage.getItem("Id_Card");

    const [task, setTask] = useState({
        taskName: ""
    });

    const onSubmit = async () => {
        try {
            const payload = {
            taskName: task.taskName,
            Id_Card: idCard
      };
            const response = await axios.post(`https://localhost:7087/api/Task/CreateTask`, payload);
            alert("Create task success!");
            navigate("/");
        } catch (error) {
            console.log(error);
        }
    };

    return (
        <form>
            <h2>Add Task</h2>
            <br />
            <div className="form-group col-md-12">
                <label>Task Name</label>
                <input
                    type="text"
                    className="form-control"
                    name="taskName"
                    value={task.taskName}
                    onChange={(e) => setTask({ ...task, taskName: e.target.value })}
                    placeholder="Task Name"
                />
            </div>
            <br />
            <button type="button" className="btn btn-primary" onClick={onSubmit}>
                Add Task
            </button>
            <br />
        </form>
    );
};

export default CreateTask;

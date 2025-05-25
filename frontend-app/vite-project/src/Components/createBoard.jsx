import React, { useState } from "react";
import axios from 'axios';
import { useLocation, useNavigate } from 'react-router-dom';

const CreateBoard = () => {
    const navigate = useNavigate();
    const location = useLocation();
    const idCard = localStorage.getItem("Id_Card");

    const [board, setBoard] = useState({
        boardName: ""
    });

    const onSubmit = async () => {
        try {
            const payload = {
            boardName: board.boardName,
            Id_Card: idCard
      };
            const response = await axios.post(`https://localhost:7087/api/Board/CreateBoard`, payload);
            alert("Create board success!");
            navigate("/");
        } catch (error) {
            console.log(error);
        }
    };

    return (
        <form>
            <h2>Add Board</h2>
            <br />
            <div className="form-group col-md-12">
                <label>Board Name</label>
                <input
                    type="text"
                    className="form-control"
                    name="boardName"
                    value={board.boardName}
                    onChange={(e) => setBoard({ ...board, boardName: e.target.value })}
                    placeholder="Board Name"
                />
            </div>
            <br />
            <button type="button" className="btn btn-primary" onClick={onSubmit}>
                Add Board
            </button>
            <br />
        </form>
    );
};

export default CreateBoard;

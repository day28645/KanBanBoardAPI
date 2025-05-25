import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useNavigate, useParams, Link } from 'react-router-dom';

const DeleteBoard = () => {
  const navigate = useNavigate();
  const { board_Id } = useParams();
  const [boardId] = useState(board_Id);
  const [boardName, setBoardName] = useState("");

  useEffect(() => {
    const getBoard = async () => {
      try {
        const response = await axios.get(`https://localhost:7087/api/Board/${boardId}`);
        const data = response.data;
        setBoardName(data.boardName);
      } catch (error) {
        console.log("Error fetching board:", error);
      }
    };
    getBoard();
  }, [boardId]);

  const onDelete = async () => {
    const confirmDelete = window.confirm(`Are you sure you want to delete board "${boardName}"?`);
    if (!confirmDelete) return;

    try {
      await axios.delete(`https://localhost:7087/api/Board/${boardId}`);
      alert("Delete Board Success");
      navigate("/listBoard");
    } catch (error) {
      console.log("Error deleting board:", error);
    }
  };

  return (
    <form>
      <h1 className="mb-4 text-danger">Delete Board</h1>

      <div className="form-group col-md-12">
        <label>Board ID</label>
        <input
          type="text"
          className="form-control"
          value={boardId}
          disabled
        />
      </div>
      <br />

      <div className="form-group col-md-12">
        <label>Board Name</label>
        <input
          type="text"
          className="form-control"
          value={boardName}
          disabled
        />
      </div>

      <br />
      <div className="text-left mt-4">
        <Link to='/listBoard' className="btn btn-secondary me-2">
          Back To Board List
        </Link>
        <button type="button" className="btn btn-danger" onClick={onDelete}>
          Delete
        </button>
      </div>
    </form>
  );
};

export default DeleteBoard;

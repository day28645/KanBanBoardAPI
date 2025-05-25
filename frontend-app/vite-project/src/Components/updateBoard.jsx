import React, { useEffect, useState } from 'react'
import { useLocation, useNavigate , Link, useParams } from 'react-router-dom';
import axios from 'axios';

const UpdateBoard = () => {

  const navigate = useNavigate();
  const [boardName, setBoardName] = useState("");
  const [Id_Card, setIdCard] = useState("");
  const { board_Id } = useParams(); 
  const [boardId, setBoardId] = useState(board_Id); 

  
  useEffect(() => {
  const getBoardById = async () => {
    try {
      const response = await axios.get(`https://localhost:7087/api/Board/${boardId}`);
      const data = response.data;
      setBoardId(data.board_Id);
      setBoardName(data.boardName);
      setIdCard(data.id_Card);
    } catch (error) {
      console.log(error);
    }
  };
  getBoardById();
}, []);


  const onSubmit = async () => {
  try {
    const payload = {
        boardName: boardName,
        Id_Card: Id_Card
    };
    await axios.put(`https://localhost:7087/api/Board/${boardId}`, payload);
    alert("Edit Board Name Success");
    navigate("/listBoard");
  } catch (error) {
    console.log(error);
  }
};

  return (
<form>
  <h1 className="mb-4">Board Detail</h1>

  <div className="form-group col-md-12">
    <label>Board ID</label>
    <input
      type="text"
      className="form-control"
      value={boardId}
      disabled
    />
  </div>
  <br/>

  <div className="form-group col-md-12">
    <label>Board Name</label>
    <input
      type="text"
      className="form-control"
      value={boardName}
      onChange={(e) => setBoardName(e.target.value)}
    />
  </div>

  <br />
  <div className="text-left mt-4">
    <button type="button" className="btn btn-warning">
      <Link to='/listBoard'>Back To Board List</Link>
    </button>
    <button type="button" className="btn-save" onClick={onSubmit}>Save</button>
  </div>
</form>

  )
}

export default UpdateBoard;
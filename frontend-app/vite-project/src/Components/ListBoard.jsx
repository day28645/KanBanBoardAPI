import React, { useEffect, useState } from 'react'
import { useLocation , Link } from 'react-router-dom';
import axios from 'axios';

const GetBoardsAll = () => {

    const [board, setBoard] = useState([]);

    useEffect(() => {
        const getBoards = async () => {
            try {
                const response = await axios.get('https://localhost:7087/api/Board/GetBoardsAll')
                console.log(response.data); 
                setBoard(response.data); 
              } catch (error) {
                console.log(error);
              }
        }
        getBoards()}, []
    );

  return (
    <div className="container mt-5">
      <h1 className="mb-4">Board List</h1>
      <table className="table table-bordered table-striped table-hover">
        <thead className="table-dark">
          <tr>
            <th>Board ID</th>
            <th>Board Name</th>
            <th>Create Date & Time</th>
            <th>Board Creator (ID Card)</th>
            <th>Edit</th>
            <th>Delete</th>
          </tr>
        </thead>
        <tbody>
          {board.map((boardlist) => (
            <tr key={boardlist.board_Id}>
              <td>{boardlist.board_Id}</td>
              <td>{boardlist.boardName}</td>
              <td>{new Date(boardlist.createDateTime).toLocaleString()}</td>
              <td>{boardlist.id_Card}</td>
              <td><Link to={`/updateBoard/${boardlist.board_Id}`}>Edit</Link></td>
              <td><Link to={`/deleteBoard/${boardlist.board_Id}`}>Delete</Link></td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}

export default GetBoardsAll;





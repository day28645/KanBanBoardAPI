import React from 'react'
import { useLocation , Link, useNavigate } from 'react-router-dom';
import axios from 'axios';

const Navbar = () => {

  const navigate = useNavigate()

  const onSubmit = async () => {
    const response = await axios.get('https://localhost:7087/api/Board/GetBoardsAll')
  }

  return (
      <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
  <a class="navbar-brand" href="#"></a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse" id="navbarNavDropdown">
    <ul class="navbar-nav">
      <li class="nav-item">
        <a class="nav-link" href="/listBoard">Board</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="/listTask">List</a>
      </li>
    </ul>
  </div>
</nav>
  )
}

export default Navbar;
import React, { useState } from "react";
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

function CreateLogin() {
  const navigate = useNavigate();
  const [Id_Card, setIdCard] = useState("");
  const [passwords, setPassword] = useState("");

  const onSubmit = async () => {
    try {
      localStorage.setItem("Id_Card", Id_Card);
      const response = await axios.post('https://localhost:7087/api/Login/CreateLogin', {Id_Card, passwords})
        navigate("/listBoard");
        alert("Login Success");
      }catch (error) {
      console.log(error);
    }
  };

  return (
    <form>
      <h2>Login</h2>
      <br />

      <div className="form-group col-md-12">
        <label>ID Card</label>
        <input
          type="text"
          className="form-control"
          name="Id_Card"
          value={Id_Card}
          onChange={(e) => setIdCard(e.target.value)}
          placeholder="ID Card"
        />
      </div>
      <br />
      <div className="form-group col-md-12">
        <label>Password</label>
        <input
          type="password"
          className="form-control"
          name="passwords"
          value={passwords}
          onChange={(e) => setPassword(e.target.value)}
          placeholder="Password"
        />
      </div>
      <br />
      <button type="button" className="btn btn-primary" onClick={onSubmit}>
        Login
      </button>
      <br />

      <div className="text-left mt-4">
        Don't have an account?<a href="/" className="text-dark">Register</a>
      </div>
    </form>
  );
}

export default CreateLogin;

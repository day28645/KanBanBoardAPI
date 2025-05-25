import React, { useState } from "react";
import axios from 'axios'
import { useNavigate } from 'react-router-dom'

function CreateUser() {
  const navigate = useNavigate();
  const [form, setForm] = useState({
    Id_Card: "",
    firstname: "",
    lastname: "",
    phone: "",
    email: "",
    passwords: "",
  });

  const onSubmit = async () => {
  try {
    const response = await axios.post('https://localhost:7087/api/User/CreateUser', form);
    alert("Register Success");
  } catch (error) {
    console.error(error); 
  }

};

  return (
    <form>
      <h2>Register New User</h2>
      <br />

      <div className="form-row">
        <div className="form-group col-md-12">
          <label>ID Card</label>
          <input
            name="id_card"
            type="text"
            className="form-control"
            value={form.Id_Card}
            onChange={(e) => setForm({ ...form, Id_Card: e.target.value })}
            placeholder="ID Card"
          />
        </div>
        <br />
        <div className="form-group col-md-12">
          <label>Password</label>
          <input
            name="passwords"
            type="password"
            className="form-control"
            value={form.passwords}
            onChange={(e) => setForm({ ...form, passwords: e.target.value })}
            placeholder="Password"
          />
        </div>
        <br />
      </div>

      <div className="form-row">
        <div className="form-group col-md-12">
          <label>First Name</label>
          <input
            name="firstname"
            type="text"
            className="form-control"
            value={form.firstname}
            onChange={(e) => setForm({ ...form, firstname: e.target.value })}
            placeholder="First Name"
          />
        </div>
        <br />
        <div className="form-group col-md-12">
          <label>Last Name</label>
          <input
            name="lastname"
            type="text"
            className="form-control"
            value={form.lastname}
            onChange={(e) => setForm({ ...form, lastname: e.target.value })}
            placeholder="Last Name"
          />
        </div>
        <br />
      </div>

      <div className="form-row">
        <div className="form-group col-md-12">
          <label>Email</label>
          <input
            name="email"
            type="email"
            className="form-control"
            value={form.email}
            onChange={(e) => setForm({ ...form, email: e.target.value })}
            placeholder="Email"
          />
        </div>
        <br />
        <div className="form-group col-md-12">
          <label>Phone</label>
          <input
            name="phone"
            type="tel"
            className="form-control"
            value={form.phone}
            onChange={(e) => setForm({ ...form, phone: e.target.value })}
            placeholder="Phone"
          />
        </div>
        <br />
      </div>

      <button type="button" className="btn btn-primary" onClick={onSubmit}>
        Register User
      </button>
      <div className="text-left mt-4">
        <a href="/login" className="text-dark">Login</a>
      </div>
    </form>
  );
}

export default CreateUser;

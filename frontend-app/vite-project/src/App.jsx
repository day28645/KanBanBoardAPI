import { useState } from 'react'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import CreateUser from './Components/createUser'
import Login from './Components/createLogin'
import CreateBoard from './Components/createBoard'
import CreateTask from './Components/createTask'
import ListBoard from './Components/ListBoard'
import ListTask from './Components/ListTask'
import UpdateBoard from './Components/updateBoard'
import UpdateTask from './Components/updateTask'
import DeleteBoard from './Components/deleteBoard'
import DeleteTask from './Components/deleteTask'
import Layout from './Components/Layout'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
    <Router>
      <Routes>
       <Route path="/" element={<CreateUser/>} />
       <Route path="/login" element={<Login/>} />
       <Route element={<Layout/>}>
       <Route path="/addBoard" element={<CreateBoard/>} />
       <Route path="/addTask" element={<CreateTask/>} />
       <Route path="/listBoard" element={<ListBoard/>} />
       <Route path="/listTask" element={<ListTask/>} />
       <Route path="/updateBoard/:board_Id" element={<UpdateBoard/>} />
       <Route path="/updateTask/:task_Id" element={<UpdateTask/>} />
       <Route path="/deleteBoard/:board_Id" element={<DeleteBoard/>} />
       <Route path="/deleteTask/:task_Id" element={<DeleteTask/>} />
       </Route>
      </Routes>
    </Router>
    </>
  )
}

export default App

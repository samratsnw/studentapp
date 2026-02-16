import { Route, Routes } from "react-router-dom"
import StudentForm from "./pages/StudentForm"
import StudentList from "./pages/StudentList"

function App() {
  return (
    <Routes>
      <Route path="/" element={<StudentList />} />
      <Route path="/students/new" element={<StudentForm />} />
      <Route path="/students/:id" element={<StudentForm />} />
    </Routes>
  )
}

export default App

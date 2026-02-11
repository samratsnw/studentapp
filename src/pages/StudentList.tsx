import { useEffect, useState } from "react"
import { useNavigate } from "react-router-dom"
import { deleteStudent, getStudents } from "../api/studentApi"
import type { StudentRead } from "../types/StudentRead"

const formatDate = (dateStr: string) => {
  const d = new Date(dateStr)

  const day = String(d.getDate()).padStart(2, "0")
  const month = String(d.getMonth() + 1).padStart(2, "0")
  const year = d.getFullYear()

  return `${day}-${month}-${year}`
}


export default function StudentList() {
  const [students, setStudents] = useState<StudentRead[]>([])
  const navigate = useNavigate()

  const load = async () => {
    const res = await getStudents()
    setStudents(res.data)
  }

  useEffect(() => {
    load()
  }, [])

  const handleDelete = async (id: number) => {
    await deleteStudent(id)
    load()
  }

  const handleEdit = (student: StudentRead) => {
    navigate(`/students/${student.studentID}`)
  }

  const handleCreate = () => {
  navigate("/students/new")
}


  return (
  <div>
    <h2>Students</h2>

      <button onClick={handleCreate}>
        + New Student
      </button>


    <table border={1} cellPadding={8} cellSpacing={0}>
      <thead>
        <tr>
          <th>ID</th>
          <th>Name</th>
          <th>Department</th>
          <th>Gender</th>
          <th>Birth Date</th>
          <th>Actions</th>
        </tr>
      </thead>

      <tbody>
        {students.map(s => (
          <tr key={s.studentID}>
            <td>{s.studentID}</td>
            <td>{s.name}</td>
            <td>{s.departmentName}</td>
            <td>{s.gender}</td>
            <td>{s.dob ? formatDate(s.dob) : ""}</td>

            <td>
              <button onClick={() => handleEdit(s)}>
                Edit
              </button>

              <button onClick={() => handleDelete(s.studentID)}>
                Delete
              </button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>

  </div>
)
}

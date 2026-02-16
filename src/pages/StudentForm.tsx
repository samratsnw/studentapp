import { useEffect, useState } from "react"
import { useNavigate, useParams } from "react-router-dom"
import { getDepartments } from "../api/DepartmentApi"
import { getStudentById, upsertStudent } from "../api/studentApi"

import type { Department } from "../types/Department"
import type { StudentUpsert } from "../types/StudentUpsertDto"

export default function StudentForm() {
  const navigate = useNavigate()
  const { id } = useParams()

  const [departments, setDepartments] = useState<Department[]>([])

  const [form, setForm] = useState<StudentUpsert>({
    name: "",
    dob: "",
    gender: "",
    isActive: true,
    departmentId: 0
  })

  // load departments
  useEffect(() => {
  getDepartments().then(r => {
    console.log("Departments API result:", r)
    setDepartments(r.data)
  }).catch(e => {
    console.error("Department API failed:", e)
  })
}, [])


  // load student if edit mode
  useEffect(() => {
    if (id) {
      getStudentById(Number(id)).then(r => {
        const s = r.data
        setForm({
          studentID: s.studentID,
          name: s.name,
          dob: s.dob.substring(0, 10),
          gender: s.gender,
          isActive: s.isActive,
          departmentId: s.departmentId
        })
      })
    }
  }, [id])

  const handleChange = (e: any) => {
    const { name, value, type, checked } = e.target

    setForm({
      ...form,
      [name]: type === "checkbox" ? checked : value
    })
  }

  const handleSubmit = async (e: any) => {
    e.preventDefault()
    await upsertStudent(form)
    navigate("/")
  }

  return (
    <form onSubmit={handleSubmit}>
      <h2>{id ? "Edit Student" : "Add Student"}</h2>

      <input
        name="name"
        placeholder="Name"
        value={form.name}
        onChange={handleChange}
      />

      <input
        type="date"
        name="dob"
        value={form.dob}
        onChange={handleChange}
      />

      <select
        name="gender"
        value={form.gender}
        onChange={handleChange}
      >
        <option value="">Select Gender</option>
        <option>Male</option>
        <option>Female</option>
      </select>

      <select
        name="departmentId"
        value={form.departmentId}
        onChange={e =>
          setForm({ ...form, departmentId: Number(e.target.value) })
        }
      >
        <option value={0}>Select Department</option>
        {departments.map(d => (
          <option key={d.departmentId} value={d.departmentId}>
            {d.name}
          </option>
        ))}
      </select>

      <label>
        Active
        <input
          type="checkbox"
          name="isActive"
          checked={form.isActive}
          onChange={handleChange}
        />
      </label>

      <button type="submit">Save</button>
    </form>
  )
}

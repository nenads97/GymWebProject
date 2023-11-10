import React, { useEffect, useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";

export const UpdateEmployee = () => {
  const [email, setEmail] = useState("");
  const [password, setPass] = useState("");
  const [username, setUsername] = useState("");
  const [jmbg, setJmbg] = useState(0);
  const [phoneNumber, setPhoneNumber] = useState(0);
  const [gender, setGender] = useState(0);
  const [firstname, setFirstname] = useState("");
  const [surname, setSurname] = useState("");
  const { employeeId } = useParams();

  const navigate = useNavigate();

  useEffect(() => {
    axios
      .get(
        `https://localhost:7095/api/Administrators/EmployeeGetCurrent/${employeeId}`
      )
      .then((response) => {
        const employeeData = response.data;

        setEmail(employeeData.email);
        setFirstname(employeeData.firstname);
        setGender(employeeData.gender);
        setJmbg(employeeData.jmbg);
        setPass(employeeData.password);
        setPhoneNumber(employeeData.phoneNumber);
        setSurname(employeeData.surname);
        setUsername(employeeData.username);
      })
      .catch((error) => {
        console.error("Error retrieving employee data:", error);
      });
  }, [employeeId]);

  function updateEmployeeHandler(event) {
    event.preventDefault();

    var payload = {
      jmbg: jmbg,
      phoneNumber: phoneNumber,
      password: password,
      username: username,
      gender: gender,
      email: email,
      surname: surname,
      firstname: firstname,
    };

    axios
      .put(
        `https://localhost:7095/api/Administrators/UpdateEmployee/${employeeId}`,
        payload
      )
      .then((response) => {
        navigate("/administrator/1/employees");
      })
      .catch((error) => {
        console.error("Error updating employee:", error);
      });
  }

  return (
    <>
      <div className="employee-register-page">
        <div className="auth-form-container auth-form-container-black">
          <h2 className="register-header-white">Update Employee</h2>

          <form className="register-form" onSubmit={updateEmployeeHandler}>
            <div className="form-group">
              <div className="input-group">
                <div>
                  <label className="form-label-white" htmlFor="firstname">
                    Firstname:{" "}
                  </label>
                  <input
                    className="register-input register-input-left"
                    type="text"
                    placeholder="Firstname"
                    id="firstname"
                    name="firstname"
                    value={firstname}
                    onChange={(e) => setFirstname(e.target.value)}
                  />
                </div>
                <div>
                  <label className="form-label-white" htmlFor="surname">
                    Surname:{" "}
                  </label>
                  <input
                    className="register-input"
                    type="text"
                    placeholder="Surname"
                    id="surname"
                    name="surname"
                    value={surname}
                    onChange={(e) => setSurname(e.target.value)}
                  />
                </div>
              </div>

              <div className="input-group">
                <div>
                  <label className="form-label-white" htmlFor="username">
                    Username:{" "}
                  </label>
                  <input
                    className="register-input register-input-left"
                    type="text"
                    placeholder="Username"
                    id="username"
                    name="username"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                  />
                </div>
                <div>
                  <label className="form-label-white" htmlFor="password">
                    Password:{" "}
                  </label>
                  <input
                    className="register-input"
                    type="password"
                    placeholder="Password"
                    id="password"
                    name="password"
                    value={password}
                    onChange={(e) => setPass(e.target.value)}
                  />
                </div>
              </div>

              <div className="input-group">
                <div>
                  <label className="form-label-white" htmlFor="email">
                    Email:{" "}
                  </label>
                  <input
                    className="register-input register-input-left"
                    type="email"
                    placeholder="youremail@gmail.com"
                    id="email"
                    name="email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                  />
                </div>
                <div>
                  <label className="form-label-white" htmlFor="jmbg">
                    Jmbg:{" "}
                  </label>
                  <input
                    className="register-input"
                    type="number"
                    placeholder="Jmbg"
                    id="jmbg"
                    name="jmbg"
                    value={jmbg}
                    onChange={(e) => setJmbg(parseInt(e.target.value))}
                  />
                </div>
              </div>

              <div className="input-group">
                <div>
                  <label className="form-label-white" htmlFor="phoneNumber">
                    Phone Number:{" "}
                  </label>
                  <input
                    className="register-input"
                    type="number"
                    placeholder="Phone Number"
                    id="phoneNumber"
                    name="phoneNumber"
                    value={phoneNumber}
                    onChange={(e) => setPhoneNumber(parseInt(e.target.value))}
                  />
                </div>
                <div>
                  <label className="form-label-white" htmlFor="gender">
                    Gender:{" "}
                  </label>
                  <select
                    className="register-select"
                    name="gender"
                    id="gender"
                    onChange={(e) => setGender(parseInt(e.target.value))}
                    value={gender}
                  >
                    <option value={0}>Male</option>
                    <option value={1}>Female</option>
                  </select>
                </div>
              </div>
            </div>
            <button className="register-button">Update</button>
          </form>
        </div>
      </div>
    </>
  );
};

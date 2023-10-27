import React, { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

export const ClientRegistration = () => {
  const [email, setEmail] = useState("");
  const [password, setPass] = useState("");
  const [username, setUsername] = useState("");
  const [jmbg, setJmbg] = useState(0);
  const [phoneNumber, setPhoneNumber] = useState(0);
  const [gender, setGender] = useState(0);
  const [firstname, setFirstname] = useState("");
  const [surname, setSurname] = useState("");

  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault(); //ovo radimo kako stranica ne bi bila relodovana cime bi izgubili useState

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
      .post("https://localhost:7095/api/Clients/Create", payload)
      .then((response) => {
        navigate("/");
      })
      .catch((error) => {
        console.error("Error adding client:", error);
      });
  };

  return (
    <>
      <div className="client-register-page">
        <div className="auth-form-container">
          <h2 className="register-header">Register Client</h2>

          <form className="register-form" onSubmit={handleSubmit}>
            <div className="form-group">
              <div className="input-group">
                <div>
                  <label className="form-label" htmlFor="firstname">
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
                  <label className="form-label" htmlFor="surname">
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
                  <label className="form-label" htmlFor="username">
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
                  <label className="form-label" htmlFor="password">
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
                  <label className="form-label" htmlFor="email">
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
                  <label className="form-label" htmlFor="jmbg">
                    Jmbg:{" "}
                  </label>
                  <input
                    className="register-input"
                    type="number"
                    placeholder="Jmbg"
                    id="jmbg"
                    name="jmbg"
                    onChange={(e) => setJmbg(parseInt(e.target.value))}
                  />
                </div>
              </div>

              <div className="input-group">
                <div>
                  <label className="form-label" htmlFor="phoneNumber">
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
                  <label className="form-label" htmlFor="gender">
                    Gender:{" "}
                  </label>
                  <select
                    className="register-select"
                    name="gender"
                    id="gender"
                    onChange={(e) => setGender(parseInt(e.target.value))}
                  >
                    <option value={0}>Male</option>
                    <option value={1}>Female</option>
                  </select>
                </div>
              </div>
            </div>
            <button className="register-button">Sign Up</button>
          </form>
        </div>
      </div>
    </>
  );
};

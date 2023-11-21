import React, { useState, useEffect } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import NavDropdown from "react-bootstrap/NavDropdown";

export const CreateTrainer = () => {
  const [email, setEmail] = useState("");
  const [password, setPass] = useState("");
  const [username, setUsername] = useState("");
  const [jmbg, setJmbg] = useState(0);
  const [phoneNumber, setPhoneNumber] = useState(0);
  const [gender, setGender] = useState(0);
  const [firstname, setFirstname] = useState("");
  const [surname, setSurname] = useState("");

  const navigate = useNavigate();
  const [errors, setErrors] = useState({});

  const [admin, setAdmin] = useState([]);

  const { id } = useParams();

  useEffect(() => {
    axios
      .get(`https://localhost:7095/api/Administrators/AdminGetCurrent/${id}`)
      .then((response) => {
        setAdmin(response.data);
      });
  }, [id]);

  const validateForm = () => {
    let valid = true;
    const newErrors = {};

    // Validate Firstname
    if (!/^[A-Z][a-z]*$/.test(firstname)) {
      newErrors.firstname = "Only letters allowed, starting with uppercase.";
      valid = false;
    } else if (firstname.includes(" ")) {
      newErrors.firstname = "Field cannot contain spaces.";
      valid = false;
    }

    // Validate Surname
    if (!/^[A-Z][a-z]*$/.test(surname)) {
      newErrors.surname = "Only letters allowed, starting with uppercase.";
      valid = false;
    } else if (surname.includes(" ")) {
      newErrors.surname = "Field cannot contain spaces.";
      valid = false;
    }

    // Validate Username
    if (username.length < 5) {
      newErrors.username = "Input at least 5 characters.";
      valid = false;
    } else if (username.includes(" ")) {
      newErrors.username = "Field cannot contain spaces.";
      valid = false;
    }

    // Validate Password
    if (password.length < 5) {
      newErrors.password = "Input at least 5 characters.";
      valid = false;
    } else if (password.includes(" ")) {
      newErrors.password = "Field cannot contain spaces.";
      valid = false;
    }

    // Validate Email
    if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)) {
      newErrors.email = "Invalid email format.";
      valid = false;
    } else if (email.includes(" ")) {
      newErrors.email = "Field cannot contain spaces.";
      valid = false;
    }

    // Validate Jmbg
    if (!/^\d{13}$/.test(jmbg)) {
      newErrors.jmbg = "Jmbg must have exactly 13 digits.";
      valid = false;
    } else if (String(jmbg).includes(" ")) {
      newErrors.jmbg = "Field cannot contain spaces.";
      valid = false;
    }

    // Validate Phone Number
    if (!/^\d{8,10}$/.test(phoneNumber)) {
      newErrors.phoneNumber = "Phone number must have 8 to 10 digits.";
      valid = false;
    } else if (String(phoneNumber).includes(" ")) {
      newErrors.phoneNumber = "Field cannot contain spaces.";
      valid = false;
    }

    setErrors(newErrors);
    return valid;
  };

  const handleSubmit = (e) => {
    e.preventDefault(); //ovo radimo kako stranica ne bi bila relodovana cime bi izgubili useState

    setErrors((errors) => ({
      ...errors,
    }));

    if (validateForm()) {
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
        .post(
          "https://localhost:7095/api/Administrators/TrainerCreate",
          payload
        )
        .then((response) => {
          navigate(`/administrator/1`);
        })
        .catch((error) => {
          console.error("Error adding trainer:", error);
        });
    }
  };

  return (
    <>
      <Navbar bg="dark" data-bs-theme="dark" className="bg-body-tertiary">
        <Container>
          <a href={`/administrator/${id}`} className="admin-link">
            <Navbar.Brand>MainPage</Navbar.Brand>
          </a>
          <Navbar.Toggle />
          <Navbar.Collapse className="justify-content-end">
            <Nav className="me-auto">
              <NavDropdown title="Packages" id="basic-nav-dropdown">
                <NavDropdown.Item href={`/administrator/${id}/all-packages`}>
                  Packages
                </NavDropdown.Item>
                <NavDropdown.Divider></NavDropdown.Divider>
                <NavDropdown.Item href={`/administrator/${id}/create-package`}>
                  Create Package
                </NavDropdown.Item>
                <NavDropdown.Item
                  href={`/administrator/${id}/create-package-discount`}
                >
                  Create Package Discount
                </NavDropdown.Item>
                <NavDropdown.Item
                  href={`/administrator/${id}/set-package-discount`}
                >
                  Set Package Discount
                </NavDropdown.Item>
                <NavDropdown.Item
                  href={`/administrator/${id}/set-package-price`}
                >
                  Set Package Price
                </NavDropdown.Item>
              </NavDropdown>

              <NavDropdown title="Employees" id="basic-nav-dropdown">
                <NavDropdown.Item href={`/administrator/${id}/employees`}>
                  Employees
                </NavDropdown.Item>
                <NavDropdown.Divider></NavDropdown.Divider>
                <NavDropdown.Item href={`/administrator/${id}/create-employee`}>
                  Create Employee
                </NavDropdown.Item>
              </NavDropdown>
              <NavDropdown title="Trainers" id="basic-nav-dropdown">
                <NavDropdown.Item href={`/administrator/${id}/trainers`}>
                  Trainers
                </NavDropdown.Item>
                <NavDropdown.Divider></NavDropdown.Divider>
                <NavDropdown.Item href={`/administrator/${id}/create-trainer`}>
                  Create Trainer
                </NavDropdown.Item>
              </NavDropdown>
              <Nav.Link href={`/administrator/${id}/clients`}>Clients</Nav.Link>
              <NavDropdown title="History" id="basic-nav-dropdown">
                <NavDropdown.Item href={`/administrator/${id}/price-history`}>
                  Prices
                </NavDropdown.Item>
                <NavDropdown.Item
                  href={`/administrator/${id}/discount-history`}
                >
                  Discounts
                </NavDropdown.Item>
                <NavDropdown.Item href={`/administrator/${id}/payment-history`}>
                  Client Payments
                </NavDropdown.Item>
              </NavDropdown>
            </Nav>
            <Navbar.Text>
              Signed in as:{" "}
              <span className="admin_name headers">
                {admin.firstname} {admin.surname}
              </span>{" "}
              Role:{" "}
              <span className="admin_name headers admin-role">
                Administrator
              </span>
            </Navbar.Text>
            <NavDropdown
              title={
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="16"
                  height="16"
                  fill="white"
                  className="user-icon"
                  viewBox="0 0 16 16"
                >
                  <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0z" />
                  <path
                    fillRule="evenodd"
                    d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8zm8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1z"
                  />
                </svg>
              }
            >
              <NavDropdown.Item href={`/administrator/${id}/admin-info`}>
                My Info
              </NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item href={`/`}>Log Out</NavDropdown.Item>
            </NavDropdown>
          </Navbar.Collapse>
        </Container>
      </Navbar>
      <div className="trainer-register-page">
        <div className="auth-form-container auth-form-container-black">
          <h2 className="register-header-white">Register Trainer</h2>

          <form className="register-form" onSubmit={handleSubmit}>
            <div className="form-group">
              <div className="input-group">
                <div>
                  <label className="form-label-white" htmlFor="firstname">
                    Firstname:{" "}
                  </label>
                  <input
                    className={`register-input register-input-left ${
                      errors.firstname ? "input-error" : ""
                    }`}
                    type="text"
                    placeholder="Firstname"
                    id="firstname"
                    name="firstname"
                    value={firstname}
                    onChange={(e) => setFirstname(e.target.value)}
                  />
                  {errors.firstname && (
                    <p className="error-message">{errors.firstname}</p>
                  )}
                </div>
                <div>
                  <label className="form-label-white" htmlFor="surname">
                    Surname:{" "}
                  </label>
                  <input
                    className={`register-input ${
                      errors.surname ? "input-error" : ""
                    }`}
                    type="text"
                    placeholder="Surname"
                    id="surname"
                    name="surname"
                    value={surname}
                    onChange={(e) => setSurname(e.target.value)}
                  />
                  {errors.surname && (
                    <p className="error-message">{errors.surname}</p>
                  )}
                </div>
              </div>

              <div className="input-group">
                <div>
                  <label className="form-label-white" htmlFor="username">
                    Username:{" "}
                  </label>
                  <input
                    className={`register-input register-input-left ${
                      errors.username ? "input-error" : ""
                    }`}
                    type="text"
                    placeholder="Username"
                    id="username"
                    name="username"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                  />
                  {errors.username && (
                    <p className="error-message">{errors.username}</p>
                  )}
                </div>
                <div>
                  <label className="form-label-white" htmlFor="password">
                    Password:{" "}
                  </label>
                  <input
                    className={`register-input ${
                      errors.password ? "input-error" : ""
                    }`}
                    type="password"
                    placeholder="Password"
                    id="password"
                    name="password"
                    value={password}
                    onChange={(e) => setPass(e.target.value)}
                  />
                  {errors.password && (
                    <p className="error-message">{errors.password}</p>
                  )}
                </div>
              </div>

              <div className="input-group">
                <div>
                  <label className="form-label-white" htmlFor="email">
                    Email:{" "}
                  </label>
                  <input
                    className={`register-input register-input-left ${
                      errors.email ? "input-error" : ""
                    }`}
                    type="email"
                    placeholder="youremail@gmail.com"
                    id="email"
                    name="email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                  />
                  {errors.email && (
                    <p className="error-message">{errors.email}</p>
                  )}
                </div>
                <div>
                  <label className="form-label-white" htmlFor="jmbg">
                    Jmbg:{" "}
                  </label>
                  <input
                    className={`register-input ${
                      errors.jmbg ? "input-error" : ""
                    }`}
                    type="number"
                    placeholder="Jmbg"
                    id="jmbg"
                    name="jmbg"
                    onChange={(e) => setJmbg(parseInt(e.target.value))}
                  />
                  {errors.jmbg && (
                    <p className="error-message">{errors.jmbg}</p>
                  )}
                </div>
              </div>

              <div className="input-group">
                <div>
                  <label className="form-label-white" htmlFor="phoneNumber">
                    Phone Number:{" "}
                  </label>
                  <input
                    className={`register-input ${
                      errors.phoneNumber ? "input-error" : ""
                    }`}
                    type="number"
                    placeholder="Phone Number"
                    id="phoneNumber"
                    name="phoneNumber"
                    value={phoneNumber}
                    onChange={(e) => setPhoneNumber(parseInt(e.target.value))}
                  />
                  {errors.phoneNumber && (
                    <p className="error-message">{errors.phoneNumber}</p>
                  )}
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
                  >
                    <option value={0}>Male</option>
                    <option value={1}>Female</option>
                  </select>
                </div>
              </div>
            </div>
            <button className="register-button">Create</button>
          </form>
        </div>
      </div>
    </>
  );
};

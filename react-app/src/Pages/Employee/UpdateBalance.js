import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import axios from "axios";
import Form from "react-bootstrap/Form";
import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import NavDropdown from "react-bootstrap/NavDropdown";

export const UpdateClientBalance = () => {
  const [balance, setNewBalance] = useState(0);
  const [errors, setErrors] = useState({});
  const navigate = useNavigate();
  const { id } = useParams();
  const { clientId } = useParams();

  //employee
  const [admin, setAdmin] = useState([]);

  useEffect(() => {
    axios
      .get(`https://localhost:7095/api/Administrators/EmployeeGetCurrent/${id}`)
      .then((response) => {
        setAdmin(response.data);
      });
  }, [id]);

  const validateForm = () => {
    let valid = true;
    const newErrors = {};

    setErrors(newErrors);
    return valid;
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    // if (validateForm()) {
    var payload = {
      balance: balance,
    };

    var paymentPayload = {
      paymentAmount: balance,
      clientId: clientId,
      employeeId: id,
    };

    axios
      .put(
        `https://localhost:7095/api/Employees/UpdateClientBalance/${clientId}`,
        payload
      )
      .then((response) => {
        navigate(`/employee/${id}`);
      })
      .catch((error) => {
        console.error("Error setting package price:", error);
      });

    axios
      .post(
        `https://localhost:7095/api/Employees/CreatePayment`,
        paymentPayload
      )
      .catch((error) => {
        console.error("Error adding new payment:", error);
      });
  };
  //   };

  return (
    <>
      <Navbar bg="dark" data-bs-theme="dark" className="bg-body-tertiary">
        <Container>
          <a href={`/employee/${id}`} className="admin-link">
            <Navbar.Brand>MainPage</Navbar.Brand>
          </a>
          <Navbar.Toggle />
          <Nav className="me-auto">
            <Nav.Link href={`/employee/${id}/trainings`}>Trainings</Nav.Link>
            <Nav.Link href={`/employee/${id}/memberships`}>
              Membership History
            </Nav.Link>
            <Nav.Link href={`/employee/${id}/payment-history`}>
              Payment History
            </Nav.Link>
          </Nav>
          <Navbar.Collapse className="justify-content-end">
            <Navbar.Text>
              Signed in as:{" "}
              <span className="admin_name headers">
                {admin.firstname} {admin.surname}
              </span>{" "}
              Role:{" "}
              <span className="admin_name headers employee-role">Employee</span>
            </Navbar.Text>
            <NavDropdown
              title={
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="16"
                  height="16"
                  fill="white"
                  className="user-icon employee-icon"
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
              <NavDropdown.Item href={`/employee/${id}/employee-info`}>
                My Info
              </NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item href={`/`}>Log Out</NavDropdown.Item>
            </NavDropdown>
          </Navbar.Collapse>
        </Container>
      </Navbar>
      <div className="employee-balance-page">
        <div className="auth-form-container auth-form-container-black">
          <h2 className="register-header-white">Update Client Balance</h2>

          <Form onSubmit={handleSubmit}>
            {/* Price Value */}
            <Form.Group className="mb-3" controlId="balance">
              <Form.Label className="form-label-white">
                Value to add:
              </Form.Label>
              <input
                className={`register-input register-input-left ${
                  errors.value ? "input-error" : ""
                }`}
                type="number"
                placeholder="Value"
                id="balance"
                name="balance"
                value={balance}
                onChange={(e) => setNewBalance(e.target.value)}
              />
              {errors.value && <p className="error-message">{errors.value}</p>}
            </Form.Group>

            <button className="register-button">Submit</button>
          </Form>
        </div>
      </div>
    </>
  );
};

import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import axios from "axios";
import Form from "react-bootstrap/Form";
import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import NavDropdown from "react-bootstrap/NavDropdown";
import EmployeeNavbar from "./Components/EmployeeNavbar";

export const UpdateClientBalance = () => {
  const [balance, setNewBalance] = useState(0);
  const [errors] = useState({});
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

  // const validateForm = () => {
  //   let valid = true;
  //   const newErrors = {};

  //   setErrors(newErrors);
  //   return valid;
  // };

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
      <EmployeeNavbar admin={admin} />

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
